using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private int shiciInterval = 25;

        private ConcurrentQueue<SpellingRKModel> SpellingRKQueue = new ConcurrentQueue<SpellingRKModel>();

        [ObservableProperty]
        private string spellingText;

        public HomeViewModel()
        {
            WeakReferenceMessenger.Default.Register<string, string>(this, "ChangeShiciInterval", ChangeShiciInterval);
            WeakReferenceMessenger.Default.Register<string, string>(this, "ChangeQuickSpellType", ReLoadSpellingRKList);

            LoadSpellingRKList();
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
                var result = SpellingRKQueue.AsParallel().FirstOrDefault(s => s.Text == keyWord);
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

        private void LoadSpellingRKList()
        {
            Task.Run(() =>
            {
                try
                {
                    string spellingFile;
                    string typeValue;
                    string spellingRKType = ConfigHelper.ReadConfigByString("spelling_rk_type");

                    if (string.IsNullOrEmpty(spellingRKType)) typeValue = "86";
                    else typeValue = spellingRKType;
                    spellingFile = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Spelling\wubi{typeValue}_spelling_rk.txt";

                    string[] spellingDatas = File.ReadAllLines(spellingFile);
                    Parallel.For(0, spellingDatas.Length,
                      index =>
                      {
                          SpellingRKModel model = new SpellingRKModel();
                          string dataStr = spellingDatas[index];
                          string[] dataKeyValue = dataStr.Split('\t');
                          string _tempStr = dataKeyValue[1].Replace('〔', ' ').Replace('〕', ' ').Replace('※', ' ');
                          string[] spellAndCode = _tempStr.Split('☯');
                          model.Text = dataKeyValue[0].Trim();
                          model.Spelling = spellAndCode[0].Trim();
                          model.Code = spellAndCode[1].Trim();
                          SpellingRKQueue.Enqueue(model);
                      });
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex.Message);
                    this.ShowMessage("Can not find spelling_rk file", DialogType.Error);
                }
            });
        }

        private void ReLoadSpellingRKList(object recipient, string message)
        {
            SpellingRKQueue.Clear();
            LoadSpellingRKList();
        }
    }
}