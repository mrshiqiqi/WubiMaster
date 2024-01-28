using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using WubiMaster.Common;
using WubiMaster.Views;
using Newtonsoft.Json;
using WubiMaster.Models;
using Newtonsoft.Json.Linq;

namespace WubiMaster.ViewModels
{
    public partial class MainViewModel : ObservableRecipient
    {
        [ObservableProperty]
        public object currentView;

        [ObservableProperty]
        public Visibility maskLayerVisable = Visibility.Collapsed;

        [ObservableProperty]
        public string pageTitle;

        public MainViewModel()
        {
            IsActive = true;
            pageDict = new Dictionary<string, object>();

            Messenger.Register<MainViewModel, ValueChangedMessage<bool>, string>(this, "ShowMaskLayer", ShowMaskLayer);

            SetDefultTheme();
        }

        private Dictionary<string, object> pageDict { get; set; }

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
        public void CloseWindow(object obj)
        {
            App.Current.MainWindow.Close();
        }

        [RelayCommand]
        public async void LoadedWindow()
        {
            await Task.Delay(500);
            ChangePage("Home");
        }

        [RelayCommand]
        public void MaxWindow(object obj)
        {
            if (App.IsMaximized)
            {
                App.Current.MainWindow.WindowState = WindowState.Normal;
                App.Current.MainWindow.Width = 1000;
                App.Current.MainWindow.Height = 700;

                App.IsMaximized = false;
            }
            else
            {
                App.Current.MainWindow.WindowState = WindowState.Maximized;

                App.IsMaximized = true;
            }
        }

        [RelayCommand]
        public void MinWindow(object obj)
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private static void SetDefultTheme()
        {
            //Todo: 优先从配置文件里读取
            string defultPack = "Pack://application:,,,/WubiMaster;component/Themes/DefultBlueTheme.xaml";
            Application.Current.Resources.MergedDictionaries[0].Source = new Uri(defultPack);
        }

        private void ShowMaskLayer(MainViewModel vm, ValueChangedMessage<bool> vcm)
        {
            bool isShow = vcm.Value;

            if (isShow)
                MaskLayerVisable = Visibility.Visible;
            else
                MaskLayerVisable = Visibility.Collapsed;
        }
    }
}