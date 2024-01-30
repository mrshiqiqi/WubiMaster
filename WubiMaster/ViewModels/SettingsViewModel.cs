using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WubiMaster.Models;

namespace WubiMaster.ViewModels
{
    public partial class SettingsViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private List<ThemeModel> themeList;

        [ObservableProperty]
        private ObservableCollection<string> shiciIntervalList;

        [ObservableProperty]
        private int themeIndex;

        [ObservableProperty]
        private int shiciIndex;

        private void InitShiciInterval()
        {
            ShiciIntervalList.Add("5分钟");
            ShiciIntervalList.Add("25分钟");
            ShiciIntervalList.Add("1小时");
            ShiciIntervalList.Add("1天");
        }

        public SettingsViewModel()
        {
            ThemeList = new List<ThemeModel>();
            ShiciIntervalList = new ObservableCollection<string>();

            InitThemes();
            InitShiciInterval();

            var currentTheme = ThemeList.FirstOrDefault(t => t.Name == "DefultBlue");
            ThemeIndex = themeList.IndexOf(currentTheme);
            ShiciIndex = 1;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
    }
}