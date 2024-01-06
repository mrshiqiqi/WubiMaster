using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using WubiMaster.Models;

namespace WubiMaster.ViewModels
{
    public partial class SettingsViewModel : ObservableRecipient
    {
        [ObservableProperty]
        public ObservableCollection<ThemeModel> themeList;

        public SettingsViewModel()
        {
            themeList = new ObservableCollection<ThemeModel>();
            InitThemes();
        }

        [RelayCommand]
        public void ChangeTheme(object obj)
        {
            if (obj == null) { return; }
            MessageBox.Show(obj.ToString());
        }

        private void InitThemes()
        {
            List<string> themeNames = new List<string>()
            {
                "Gold Dark",
                "Light Blue",
                "Summer Meadow",
                "Electric City Nights",
                "Lavendar",
                "Hacker News",
                "Navy And Blush",
                "White Width Blue",
                "Dark Sage Green",
                "Spring",
                "Neon",
            };

            foreach (var themeName in themeNames)
            {
                ThemeModel themeModel = new ThemeModel();
                themeModel.Name = themeName;
                themeModel.Value = themeName;
                ThemeList?.Add(themeModel);
            }
        }
    }
}