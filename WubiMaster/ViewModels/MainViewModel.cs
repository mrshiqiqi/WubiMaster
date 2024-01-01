using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using WubiMaster.Views;

namespace WubiMaster.ViewModels
{
    public partial class MainViewModel : ObservableRecipient
    {
        [ObservableProperty]
        public object currentView;
        [ObservableProperty]
        public string pageTitle;
        [ObservableProperty]
        public Visibility maskLayerVisable = Visibility.Collapsed;

        public MainViewModel()
        {
            IsActive = true;
            pageDict = new Dictionary<string, object>();
            Application.Current.Resources.MergedDictionaries[0].Source = new Uri(goldDarkThemePack);

            Messenger.Register<MainViewModel, ValueChangedMessage<bool>, string>(this, "ShowMaskLayer", ShowMaskLayer);
        }

        [RelayCommand]
        public async void LoadedWindow()
        {
            await Task.Delay(500);
            ChangePage("Home");
        }

        [RelayCommand]
        public void ChangePage(object pageName)
        {
            if (pageName == null) return;

            string pName = pageName.ToString();
            PageTitle = pName;
            if (pageDict.ContainsKey(pName))
                CurrentView = pageDict[pName];
            else
            {
                switch (pageName.ToString())
                {
                    case "Home":
                        HomeView homeView = new HomeView();
                        pageDict[pName] = homeView;
                        CurrentView = homeView;
                        break;

                    case "Etymon":
                        EtymonView etymonView = new EtymonView();
                        pageDict[pName] = etymonView;
                        CurrentView = etymonView;
                        break;

                    case "Lexicon":
                        LexiconView lexiconView = new LexiconView();
                        pageDict[pName] = lexiconView;
                        CurrentView = lexiconView;
                        break;

                    case "Settings":
                        SettingsView settingsView = new SettingsView();
                        pageDict[pName] = settingsView;
                        CurrentView = settingsView;
                        break;

                    default:
                        TestView testView = new TestView();
                        pageDict[pName] = testView;
                        CurrentView = testView;
                        break;
                }
            }
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

        private void ShowMaskLayer(MainViewModel vm, ValueChangedMessage<bool> vcm)
        {
            bool isShow = vcm.Value;

            if (isShow)
                MaskLayerVisable = Visibility.Visible;
            else
                MaskLayerVisable = Visibility.Collapsed;
        }

        private string goldDarkThemePack = "pack://application:,,,/WubiMaster;component/Themes/GoldDarkTheme.xaml";
        private string darkYellowThemePack = "pack://application:,,,/WubiMaster;component/Themes/DarkYellowTheme.xaml";
        private string darkBlueThemePack = "pack://application:,,,/WubiMaster;component/Themes/DarkBlueTheme.xaml";
        private string lightBrownThemePack = "pack://application:,,,/WubiMaster;component/Themes/LightBrownTheme.xaml";
        private string lightBlackThemePack = "pack://application:,,,/WubiMaster;component/Themes/LightBlackTheme.xaml";
        private string lightGreenThemePack = "pack://application:,,,/WubiMaster;component/Themes/LightGreenTheme.xaml";

        public Dictionary<string, object> pageDict { get; set; }
    }
}