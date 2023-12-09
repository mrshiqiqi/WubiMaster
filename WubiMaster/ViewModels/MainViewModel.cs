using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WubiMaster.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Application.Current.Resources.MergedDictionaries[0].Source = new Uri(darkYellowThemePack);
        }

        [RelayCommand]
        public void ChangeTheme()
        {
            ResourceDictionary resource = new ResourceDictionary();

            if (Application.Current.Resources.MergedDictionaries[0].Source.ToString() == darkYellowThemePack)
            {
                resource.Source = new Uri(darkBlueThemePack);
            }
            else
            {
                resource.Source = new Uri(darkYellowThemePack);
            }
            Application.Current.Resources.MergedDictionaries[0].Source = resource.Source;
        }

        [RelayCommand]
        public void SetTheme(object themeName)
        {
            switch (themeName.ToString())
            {
                case "DarkYellow":
                    Application.Current.Resources.MergedDictionaries[0].Source = new Uri(darkYellowThemePack);
                    break;
                case "DarkBlue":
                    Application.Current.Resources.MergedDictionaries[0].Source = new Uri(darkBlueThemePack);
                    break;
                case "LightBrown":
                    Application.Current.Resources.MergedDictionaries[0].Source = new Uri(lightBrownThemePack);
                    break;
                case "LightBlack":
                    Application.Current.Resources.MergedDictionaries[0].Source = new Uri(lightBlackThemePack);
                    break;
                case "LightGreen":
                    Application.Current.Resources.MergedDictionaries[0].Source = new Uri(lightGreenThemePack);
                    break;
                default:
                    break;
            }
        }

        private string darkYellowThemePack = "pack://application:,,,/WubiMaster;component/Themes/DarkYellowTheme.xaml";
        private string darkBlueThemePack = "pack://application:,,,/WubiMaster;component/Themes/DarkBlueTheme.xaml";
        private string lightBrownThemePack = "pack://application:,,,/WubiMaster;component/Themes/LightBrownTheme.xaml";
        private string lightBlackThemePack = "pack://application:,,,/WubiMaster;component/Themes/LightBlackTheme.xaml";
        private string lightGreenThemePack = "pack://application:,,,/WubiMaster;component/Themes/LightGreenTheme.xaml";
    }
}
