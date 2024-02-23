using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.ViewModels
{
    public partial class SettingsViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private bool cobboxThemesEnable;

        [ObservableProperty]
        private bool isRandomThemes;

        [ObservableProperty]
        private int logBackIndex;

        [ObservableProperty]
        private ObservableCollection<LogBackModel> logBackList;

        [ObservableProperty]
        private string processFilePath;

        [ObservableProperty]
        private string defaultCikuFile;

        [ObservableProperty]
        private string userCikuFile;

        [ObservableProperty]
        private int shiciIndex;

        [ObservableProperty]
        private ObservableCollection<ShiciIntervalModel> shiciIntervalList;

        [ObservableProperty]
        private int themeIndex;

        [ObservableProperty]
        private List<ThemeModel> themeList;

        [ObservableProperty]
        private string userFilePath;

        public SettingsViewModel()
        {
            ThemeList = new List<ThemeModel>();
            ShiciIntervalList = new ObservableCollection<ShiciIntervalModel>();
            LogBackList = new ObservableCollection<LogBackModel>();

            InitThemes();
            InitShiciInterval();
            InitLogBackList();
            LoadConfig();
        }

        [RelayCommand]
        public void ChangeLogBackDays(string days)
        {
            ConfigHelper.WriteConfigByString("log_back_days", days);
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
        public void OpenProcessFilePath()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            ProcessFilePath = dialog.SelectedPath;

            ConfigHelper.WriteConfigByString("process_file_path", ProcessFilePath);
        }

        [RelayCommand]
        public void OpenUserFilePath()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            UserFilePath = dialog.SelectedPath;

            ConfigHelper.WriteConfigByString("user_file_path", UserFilePath);
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
            UserFilePath = ConfigHelper.ReadConfigByString("user_file_path");

            // 加载程序目录配置
            ProcessFilePath = ConfigHelper.ReadConfigByString("process_file_path");

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
        }
    }
}