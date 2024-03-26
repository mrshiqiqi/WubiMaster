using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private int shiciInterval = 25;

        [ObservableProperty]
        private string spellTextShow86;

        [ObservableProperty]
        private string spellTextShow98;

        [ObservableProperty]
        private string spellTextShow06;

        [ObservableProperty]
        private string spellingText;

        [ObservableProperty]
        private string spellingKeytText = "钱";

        public HomeViewModel()
        {
            WeakReferenceMessenger.Default.Register<string, string>(this, "ChangeShiciInterval", ChangeShiciInterval);

            LoadSpellTextShow();
            GetTheKeyTextAsync();
        }

        private async void GetTheKeyTextAsync()
        {
            ConcurrentDictionary<string, string[]> keyTextDict = new ConcurrentDictionary<string, string[]>();
            List<string> keyTextList = new List<string>();

            await Task.Run(() =>
            {
                SpellingWorker.SpellingQueue86.AsParallel().ForAll(s =>
                {
                    if (s.GBType != "GBK")
                        keyTextDict.TryAdd(s.Text, new string[] { s.Code, "", "" });
                });

                SpellingWorker.SpellingQueue98.AsParallel().ForAll(s =>
                {
                    if (keyTextDict.ContainsKey(s.Text))
                        keyTextDict[s.Text][1] = s.Code;
                });


                SpellingWorker.SpellingQueue06.AsParallel().ForAll(s =>
                {
                    if (keyTextDict.ContainsKey(s.Text))
                        keyTextDict[s.Text][2] = s.Code;
                });

                Parallel.ForEach(keyTextDict.Keys, k =>
                {
                    var value = keyTextDict[k];
                    if ((value[0] != value[1]) && (value[0] != value[2]) && (value[1] != value[2]))
                        keyTextList.Add(k);
                });
            });

            Random random = new Random();
            int _keyindex = random.Next(0, keyTextList.Count);
            SpellingKeytText = keyTextList[_keyindex];
            LoadSpellTextShow();
        }

        private void LoadSpellTextShow()
        {
            try
            {
                string keyWord = SpellingKeytText;
                var result86 = SpellingWorker.ZingenSearch(keyWord, "86");
                SpellTextShow86 = result86.Spelling + "・" + result86.Code;
                var result98 = SpellingWorker.ZingenSearch(keyWord, "98");
                SpellTextShow98 = result98.Spelling + "・" + result98.Code;
                var result06 = SpellingWorker.ZingenSearch(keyWord, "06");
                SpellTextShow06 = result06.Spelling + "・" + result06.Code;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                this.ShowMessage("无法加载字根版本示例", DialogType.Error);
            }
        }

        [RelayCommand]
        public void CopyInfo(object obj)
        {
            Clipboard.SetDataObject(obj);
            this.ShowMessage("已复制到剪贴板");
        }

        [RelayCommand]
        public void ToWebPage(object obj)
        {
            try
            {
                string url = obj?.ToString();
                Process.Start("explorer.exe", url);
            }
            catch (Exception ex)
            {
                this.ShowMessage("无法打开网址", DialogType.Error);
                LogHelper.Error(ex.Message);
            }
        }

        [RelayCommand]
        public void ZingenSearch(object obj)
        {
            if (obj == null)
            {
                SpellingText = "";
                return;
            }

            try
            {
                string keyWord = obj.ToString().Trim();
                string type = ConfigHelper.ReadConfigByString("quick_search_type");
                var result = SpellingWorker.ZingenSearch(keyWord, type);
                if (result == null)
                {
                    SpellingText = "";
                    return;
                }
                else
                {
                    SpellingText = result.Spelling + "・" + result.Code;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
        }

        private void ChangeShiciInterval(object recipient, string message)
        {
            try
            {
                int newInterval = int.Parse(message);

                if (newInterval < 5)
                {
                    ShiciInterval = 25;
                    return;
                }
                ShiciInterval = newInterval;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
        }

        [RelayCommand]
        public async void CreateScheme(object obj)
        {
            if (obj == null) return;

            string type = obj.ToString();
            switch (type)
            {
                case "86":
                    // 先检测rime环境
                    if (string.IsNullOrEmpty(GlobalValues.UserPath) || string.IsNullOrEmpty(GlobalValues.ProcessPath))
                    {
                        this.ShowMessage("未检测到 Rime 引擎的安装信息，请先安装 Rime 程序！", DialogType.Warring);
                        return;
                    }

                    // 在配置前，先提示会将原有的方案覆盖
                    bool? result = this.ShowAskMessage("请注意：本次操作将清除 Rime 用户目录下所有数据！", DialogType.Normal);
                    if (result != true)
                        return;

                    // 再将包导入进去
                    try
                    {
                        // 停止服务
                        ServiceHelper.KillService();
                        await Task.Delay(1000);

                        // 删除用户目录中的配置
                        if (Directory.Exists(GlobalValues.UserPath))
                        {
                            DirectoryInfo dir = new DirectoryInfo(GlobalValues.UserPath);
                            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                            foreach (FileSystemInfo i in fileinfo)
                            {
                                if (i is DirectoryInfo)            //判断是否文件夹
                                {
                                    DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                                    subdir.Delete(true);          //删除子目录和文件
                                }
                                else
                                {
                                    File.Delete(i.FullName);      //删除指定文件
                                }
                            }
                        }
                        await Task.Delay(500);

                        // 将方案解压到用户目录
                        string scheme_zip = GlobalValues.Scheme86Zip;
                        ZipHelper.DecompressZip(scheme_zip, GlobalValues.UserPath);

                        // 安装字根字体
                        if (!FontHelper.CheckFont("黑体字根.ttf"))
                        {
                            string heiti_font = GlobalValues.HeitiFont;
                            FontHelper.InstallFont(heiti_font);
                        }

                        // 启动服务
                        ServiceHelper.RunService();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex.Message,true);
                        this.ShowMessage("配置失败", DialogType.Error);
                        return;
                    }

                    this.ShowMessage("配置成功，记得重新部署哦😀");

                    break;
                case "98":
                    this.ShowMessage("该功能暂未开放", DialogType.Normal);
                    break;
                default:
                    this.ShowMessage("该功能暂未开放", DialogType.Normal);
                    break;
            }
        }
    }
}