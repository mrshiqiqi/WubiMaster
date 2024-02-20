using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private string processFilePath;

        [ObservableProperty]
        private int shiciIndex;

        [ObservableProperty]
        private ObservableCollection<string> shiciIntervalList;

        [ObservableProperty]
        private int themeIndex;

        [ObservableProperty]
        private List<ThemeModel> themeList;

        [ObservableProperty]
        private string userFilePath;

        public SettingsViewModel()
        {
            ThemeList = new List<ThemeModel>();
            ShiciIntervalList = new ObservableCollection<string>();

            InitThemes();
            InitShiciInterval();
            LoadConfig();
        }

        [RelayCommand]
        public void ChangeShiciInterval(string value)
        {
            string interval = "25";
            int index = ShiciIntervalList.IndexOf(value);
            switch (index)
            {
                case 0:
                    interval = "5";
                    break;

                case 1:
                    interval = "25";
                    break;

                case 2:
                    interval = "60";
                    break;

                case 3:
                    interval = "1440";
                    break;

                default:
                    break;
            }
            WeakReferenceMessenger.Default.Send<string, string>(interval, "ChangeShiciInterval");

            ConfigHelper.WriteConfigByInt("shici_interval", index);
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
                int index = random.Next(0, ThemeList.Count);
                ChangeTheme(ThemeList[index].Value);
            }
            else
            {
                CobboxThemesEnable = true;
            }
            ConfigHelper.WriteConfigByBool("is_random_themes", IsRandomThemes);
        }

        private void InitShiciInterval()
        {
            ShiciIntervalList.Add("5分钟");
            ShiciIntervalList.Add("25分钟");
            ShiciIntervalList.Add("1小时");
            ShiciIntervalList.Add("1天");
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
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadConfig()
        {
            // 加载用户目录配置
            UserFilePath = ConfigHelper.ReadConfigByString("user_file_path");

            // 加载程序目录配置
            ProcessFilePath = ConfigHelper.ReadConfigByString("process_file_path");

            // 加载今日诗词更换时间
            ShiciIndex = ConfigHelper.ReadConfigByInt("shici_interval", 1);

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