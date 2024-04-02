using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WubiMaster.Common;
using WubiMaster.Models;
using static WubiMaster.Common.RegistryHelper;

namespace WubiMaster.ViewModels
{
    public partial class SettingsViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private bool cobboxThemesEnable;

        [ObservableProperty]
        private string defaultCikuFile;

        [ObservableProperty]
        private bool isRandomThemes;

        [ObservableProperty]
        private int logBackIndex;

        [ObservableProperty]
        private ObservableCollection<LogBackModel> logBackList;

        [ObservableProperty]
        private string processFilePath;

        [ObservableProperty]
        private bool quickSpllType06;

        [ObservableProperty]
        private bool quickSpllType86;

        [ObservableProperty]
        private bool quickSpllType98;

        private RegistryHelper registryHelper;

        private string rimeKey;

        [ObservableProperty]
        private bool serviceIsRun;

        [ObservableProperty]
        private int shiciIndex;

        [ObservableProperty]
        private ObservableCollection<ShiciIntervalModel> shiciIntervalList;

        [ObservableProperty]
        private int themeIndex;

        [ObservableProperty]
        private List<ThemeModel> themeList;

        [ObservableProperty]
        private string userCikuFile;

        [ObservableProperty]
        private string userFilePath;

        [ObservableProperty]
        private string backupPath;

        [ObservableProperty]
        private string wubiSchemaTip;

        public SettingsViewModel()
        {
            registryHelper = new RegistryHelper();
            ThemeList = new List<ThemeModel>();
            ShiciIntervalList = new ObservableCollection<ShiciIntervalModel>();
            LogBackList = new ObservableCollection<LogBackModel>();

            WeakReferenceMessenger.Default.Register<string, string>(this, "ChangequickSpllType", ChangequickSpllType);

            InitThemes();
            InitShiciInterval();
            InitLogBackList();
            GetRimeRegistryKey();
            ReadUserPathRegistry();
            ReadProcessPathRegistry();
            ReadServerRegistry();
            CheckService();
            LoadConfig();
        }

        private void ChangequickSpllType(object recipient, string message)
        {
            string type = message;
            switch (type)
            {
                case "86":
                    QuickSpllType86 = true;
                    break;
                case "98":
                    QuickSpllType98 = true;
                    break;
                case "06":
                    QuickSpllType06 = true;
                    break;
                default:
                    QuickSpllType86 = true;
                    break;
            }
            QuickSpellChange();
        }

        private void UpdateWubiSchemaTip()
        {
            try
            {
                string wubi_master_key = GlobalValues.UserPath + GlobalValues.SchemaKey;
                bool hasKey = File.Exists(wubi_master_key);
                if (hasKey)
                    WubiSchemaTip = "已加载五笔引擎";
                else
                {
                    WubiSchemaTip = "未检测到五笔引擎";
                    WeakReferenceMessenger.Default.Send<string, string>("", "ChangeShcemaState");
                }
                    
            }
            catch (Exception ex)
            {
                WubiSchemaTip = "未检测到五笔引擎";
                WeakReferenceMessenger.Default.Send<string, string>("", "ChangeShcemaState");
                LogHelper.Error(ex.Message);
            }

        }

        [RelayCommand]
        public async Task InitializeSchema()
        {
            string schema_zip = GlobalValues.SchemaZip;

            try
            {
                // 先检测rime环境
                if (string.IsNullOrEmpty(GlobalValues.UserPath) || string.IsNullOrEmpty(GlobalValues.ProcessPath))
                {
                    this.ShowMessage("未检测到 Rime 引擎的安装信息，请先安装 Rime 程序！", DialogType.Warring);
                    return;
                }

                if (!File.Exists(schema_zip))
                {
                    this.ShowMessage("找不到五笔引擎包！",DialogType.Error);
                    return;
                }

                // 在配置前，先提示会将原有的方案覆盖
                bool? result = this.ShowAskMessage("请注意：本次操作将清除 Rime 用户目录下所有数据！", DialogType.Normal);
                if (result != true)
                    return;

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
                ZipHelper.DecompressZip(schema_zip, GlobalValues.UserPath);

                // 安装字根字体
                if (!FontHelper.CheckFont("黑体字根.ttf"))
                {
                    string heiti_font = GlobalValues.HeitiFont;
                    FontHelper.InstallFont(heiti_font);
                }

                this.ShowMessage("初始化成功", DialogType.Success);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, true);
                this.ShowMessage($"初始化失败: {ex.Message}", DialogType.Error);
                return;
            }
            finally
            {
                // 启动服务
                ServiceHelper.RunService();
                UpdateWubiSchemaTip();
            }
        }

        [RelayCommand]
        public void ChangeLogBackDays(string days)
        {
            ConfigHelper.WriteConfigByString("log_back_days", days);
        }

        [RelayCommand]
        public void ChangeShiciInterval(int index)
        {
            string interval = ShiciIntervalList.First(i => i.Id == index).Minutes.ToString();
            WeakReferenceMessenger.Default.Send<string, string>(interval, "ChangeShiciInterval");

            ConfigHelper.WriteConfigByString("shici_interval", interval);
        }

        [RelayCommand]
        public void ChangeTheme(string theme)
        {
            if (theme == null || theme.Length == 0) { return; }
            try
            {
                string pack = $"pack://application:,,,/WubiMaster;component/Themes/{theme}.xaml";
                ResourceDictionary themeResource = new ResourceDictionary();
                themeResource.Source = new Uri(pack);
                Application.Current.Resources.MergedDictionaries[0].Source = themeResource.Source;

                ConfigHelper.WriteConfigByString("theme_value", theme);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        [RelayCommand]
        public void CheckService()
        {
            ServiceIsRun = ServiceHelper.FindService();
        }

        [RelayCommand]
        public void OpenLogPath()
        {
            string path = GlobalValues.AppDirectory + "Logs";
            if (!Directory.Exists(path))
            {
                this.ShowMessage("找不到日志目录！", DialogType.Error);
                return;
            }
            Process.Start("explorer.exe", path);
        }

        [RelayCommand]
        public void OpenProcessFilePath()
        {
            if (string.IsNullOrEmpty(GlobalValues.ProcessPath) || !Directory.Exists(GlobalValues.ProcessPath))
            {
                this.ShowMessage("找不到 Rime 程序安装目录！", DialogType.Error);
                return;
            }
            Process.Start("explorer.exe", GlobalValues.ProcessPath);

            //System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            //System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            //if (result == System.Windows.Forms.DialogResult.Cancel)
            //{
            //    return;
            //}
            //ProcessFilePath = dialog.SelectedPath;

            //ConfigHelper.WriteConfigByString("process_file_path", ProcessFilePath);
        }

        [RelayCommand]
        public void SetBackupPath()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            BackupPath = dialog.SelectedPath;

            ConfigHelper.WriteConfigByString("backup_path", BackupPath);
        }

        [RelayCommand]
        public async void Backup()
        {
            try
            {
                if (string.IsNullOrEmpty(GlobalValues.UserPath) || !Directory.Exists(GlobalValues.UserPath))
                {
                    this.ShowMessage("找不到 Rime 程序用户目录！", DialogType.Error);
                    return;
                }

                if (string.IsNullOrEmpty(BackupPath))
                    this.ShowMessage("请先设置备份目录");

                ServiceHelper.KillService();
                await Task.Delay(500);

                string zipName = $"backup_{DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss.fff")}.zip";
                ZipHelper.CompressDirectoryZip(GlobalValues.UserPath, BackupPath + $@"\{zipName}");

                ServiceHelper.RunService();

                this.ShowMessage($"备份成功：{zipName}", DialogType.Success);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
                this.ShowMessage("备份失败：" + ex.Message);
            }

        }

        [RelayCommand]
        public void OpenUserFilePath()
        {
            if (string.IsNullOrEmpty(GlobalValues.UserPath) || !Directory.Exists(GlobalValues.UserPath))
            {
                this.ShowMessage("找不到 Rime 程序用户目录！", DialogType.Error);
                return;
            }
            Process.Start("explorer.exe", GlobalValues.UserPath);
            //System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            //System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            //if (result == System.Windows.Forms.DialogResult.Cancel)
            //{
            //    return;
            //}
            //UserFilePath = dialog.SelectedPath;

            //ConfigHelper.WriteConfigByString("user_file_path", UserFilePath);
        }

        [RelayCommand]
        public void QuickSpellChange()
        {
            try
            {
                if (QuickSpllType86)
                    ConfigHelper.WriteConfigByString("quick_search_type", "86");
                else if (QuickSpllType98)
                    ConfigHelper.WriteConfigByString("quick_search_type", "98");
                else if (QuickSpllType06)
                    ConfigHelper.WriteConfigByString("quick_search_type", "06");
                else
                    ConfigHelper.WriteConfigByString("quick_search_type", "86");
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                this.ShowMessage(ex.Message, DialogType.Warring);
            }
        }

        [RelayCommand]
        public void RandomThemes()
        {
            if (IsRandomThemes)
            {
                CobboxThemesEnable = false;
                Random random = new Random();
                ThemeIndex = random.Next(0, ThemeList.Count);
                ChangeTheme(ThemeList[ThemeIndex].Value);
            }
            else
            {
                CobboxThemesEnable = true;
            }
            ConfigHelper.WriteConfigByBool("is_random_themes", IsRandomThemes);
        }

        [RelayCommand]
        public void SetDefaultCikuFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = UserFilePath;
            openFileDialog.Filter = "Yaml|*.dict.yaml";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();
            string fullPath = openFileDialog.FileName;
            DefaultCikuFile = Path.GetFileName(fullPath);

            ConfigHelper.WriteConfigByString("default_ciku_file", DefaultCikuFile);
            WeakReferenceMessenger.Default.Send<string, string>("20", "ReLoadCikuData"); // todo: 参数设置成显示条数吧
        }

        [RelayCommand]
        public void SetUserCikuFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = UserFilePath;
            openFileDialog.Filter = "Yaml|*.dict.yaml";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();
            string fullPath = openFileDialog.FileName;
            UserCikuFile = Path.GetFileName(fullPath);

            ConfigHelper.WriteConfigByString("user_ciku_file", UserCikuFile);
        }

        [RelayCommand]
        public void SwicthService()
        {
            try
            {
                if (ServiceIsRun)
                    ServiceHelper.RunService();
                else
                    ServiceHelper.KillService();
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message, DialogType.Warring);
            }
        }

        private void GetRimeRegistryKey()
        {
            try
            {
                if (registryHelper.IsExist(KeyType.HKEY_LOCAL_MACHINE, @"Rime\Weasel"))
                {
                    rimeKey = @"Rime\Weasel";
                }
                else if (registryHelper.IsExist(KeyType.HKEY_LOCAL_MACHINE, @"WOW6432Node\Rime\Weasel"))
                {
                    rimeKey = @"WOW6432Node\Rime\Weasel";
                }

                if (string.IsNullOrEmpty(rimeKey)) throw new NullReferenceException("无法找到Rime程序安装目录");
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
        }

        private void InitLogBackList()
        {
            int[] backDays = new int[] { 5, 15, 30, 100 };
            foreach (int day in backDays)
            {
                LogBackModel backModel = new LogBackModel();
                backModel.Value = day.ToString();
                backModel.Text = day.ToString() + "天";
                LogBackList.Add(backModel);
            }
        }

        private void InitShiciInterval()
        {
            ShiciIntervalList.Add(new ShiciIntervalModel() { Id = 0, Value = "5分钟", Minutes = 5 });
            ShiciIntervalList.Add(new ShiciIntervalModel() { Id = 1, Value = "25分钟", Minutes = 25 });
            ShiciIntervalList.Add(new ShiciIntervalModel() { Id = 2, Value = "1小时", Minutes = 60 });
            ShiciIntervalList.Add(new ShiciIntervalModel() { Id = 3, Value = "1天", Minutes = 1440 });
        }

        private void InitThemes()
        {
            try
            {
                ObservableCollection<ThemeModel> themeModels = new ObservableCollection<ThemeModel>();
                var sourceThemes = new ResourceDictionary();
                sourceThemes.Source = new Uri("pack://application:,,,/WubiMaster;component/Themes/ThemeNames.xaml");
                foreach (string name in sourceThemes.Keys)
                {
                    string path = sourceThemes[name].ToString();
                    ThemeModel themeModel = new ThemeModel();
                    themeModel.Name = name;
                    themeModel.Value = path;
                    themeModels?.Add(themeModel);
                }
                ThemeList = themeModels.OrderBy(t => t.Name).ToList();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
        }

        private void LoadConfig()
        {
            // 加载用户目录配置
            //UserFilePath = ConfigHelper.ReadConfigByString("user_file_path");

            // 加载程序目录配置
            //ProcessFilePath = ConfigHelper.ReadConfigByString("process_file_path");

            // 加载默认词库
            DefaultCikuFile = ConfigHelper.ReadConfigByString("default_ciku_file");

            // 加载扩展词库
            UserCikuFile = ConfigHelper.ReadConfigByString("user_ciku_file");

            // 加载今日诗词更换时间
            string interval = ConfigHelper.ReadConfigByString("shici_interval", "25");
            var _list = ShiciIntervalList.Select(i => i.Minutes).ToList();
            if (_list.IndexOf(int.Parse(interval)) == -1) { ShiciIndex = 1; interval = "25"; }
            else ShiciIndex = _list.IndexOf(int.Parse(interval));
            WeakReferenceMessenger.Default.Send<string, string>(interval, "ChangeShiciInterval");

            // 加载日志备份时长
            string logBackDays = ConfigHelper.ReadConfigByString("log_back_days", "30");
            LogBackIndex = LogBackList.Select(l => l.Value).ToList().IndexOf(logBackDays);

            // 加载主题配置
            IsRandomThemes = ConfigHelper.ReadConfigByBool("is_random_themes", false);
            if (IsRandomThemes)
            {
                CobboxThemesEnable = false;
                RandomThemes();
            }
            else
            {
                CobboxThemesEnable = true;
                string themeValue = ConfigHelper.ReadConfigByString("theme_value");
                if (!string.IsNullOrEmpty(themeValue)) ChangeTheme(themeValue);
                else ChangeTheme("DefultBlueTheme");
            }

            // 加载首页快速查询字根版本类型
            string quickSpllType = ConfigHelper.ReadConfigByString("quick_search_type");
            if (quickSpllType == "86")
                QuickSpllType86 = true;
            else if (quickSpllType == "98")
                QuickSpllType98 = true;
            else if (quickSpllType == "06")
                QuickSpllType06 = true;
            else
                QuickSpllType86 = true;

            // 加载方案备份目录
            BackupPath = ConfigHelper.ReadConfigByString("backup_path");

            // 加载工作方案版本
            UpdateWubiSchemaTip();
        }

        private void ReadProcessPathRegistry()
        {
            try
            {
                if (string.IsNullOrEmpty(rimeKey)) return;

                string pPath = registryHelper.GetValue(KeyType.HKEY_LOCAL_MACHINE, rimeKey, "WeaselRoot");
                if (string.IsNullOrEmpty(pPath)) throw new NullReferenceException("ProcessFilePath: 无法找到 Rime 的注册表信息");
                ProcessFilePath = GlobalValues.ProcessPath = pPath;
                ConfigHelper.WriteConfigByString("process_file_path", ProcessFilePath);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
        }

        private void ReadServerRegistry()
        {
            try
            {
                if (string.IsNullOrEmpty(rimeKey)) return;

                string sName = registryHelper.GetValue(KeyType.HKEY_LOCAL_MACHINE, rimeKey, "ServerExecutable");
                if (string.IsNullOrEmpty(sName)) throw new NullReferenceException("无法找到 Rime 的注册表信息");
                GlobalValues.ServerName = sName;
                //ConfigHelper.WriteConfigByString("weasel_server", sName);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
        }

        private void ReadUserPathRegistry()
        {
            try
            {
                if (!registryHelper.IsExist(KeyType.HKEY_CURRENT_USER, @"Rime\Weasel")) return;

                string uPath = registryHelper.GetValue(KeyType.HKEY_CURRENT_USER, @"Rime\Weasel", "RimeUserDir");
                if (string.IsNullOrEmpty(uPath))
                {
                    uPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Rime";
                    if (!Directory.Exists(uPath)) throw new NullReferenceException("UserPath: 无法找到 Rime 的注册表信息");
                }

                UserFilePath = GlobalValues.UserPath = uPath;
                ConfigHelper.WriteConfigByString("user_file_path", UserFilePath);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
        }
    }
}