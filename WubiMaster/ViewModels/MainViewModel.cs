using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.VisualStyles;
using WubiMaster.Common;
using WubiMaster.Controls;
using WubiMaster.Views;

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

            //Register<string, string>：消息类型、token类型
            WeakReferenceMessenger.Default.Register<string, string>(this, "ShowMaskLayer", ShowMaskLayer);

            LaodAllSpellingDataAsync();
        }

        private async void LaodAllSpellingDataAsync()
        {
            await Task.Run(() =>
            {
                SpellingWorker.LoadAllSpellingData();
            });
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

                    case "Attribute":
                        AttributeView attributeView = new AttributeView();
                        pageDict[pName] = attributeView;
                        CurrentView = attributeView;
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

                    case "EtymonKey":
                        EtymonKeyView etymonKeyView = new EtymonKeyView();
                        pageDict[pName] = etymonKeyView;
                        CurrentView = etymonKeyView;
                        break;

                    case "Themes":
                        ThemeView themeView = new ThemeView();
                        pageDict[pName] = themeView;
                        CurrentView = themeView;
                        break;

                    case "Settings":
                        SettingsView settingsView = new SettingsView();
                        pageDict[pName] = settingsView;
                        CurrentView = settingsView;
                        break;

                    case "About":
                        AboutView aboutView = new AboutView();
                        pageDict[pName] = aboutView;
                        CurrentView = aboutView;
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
        public void Deploy()
        {
            try
            {
                string prcessPath = ConfigHelper.ReadConfigByString("process_file_path");
                if (string.IsNullOrEmpty(prcessPath))
                {
                    this.ShowMessage("请先配置程序文件目录", DialogType.Warring);
                    return;
                }

                try
                {
                    bool isRun = ServiceHelper.FindService();
                    if (!isRun)
                    {
                        this.ShowMessage("算法服务未启动，无法执行部署操作", DialogType.Warring);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.ShowMessage(ex.Message, DialogType.Warring);
                }

                CmdHelper.RunCmd(prcessPath, "WeaselDeployer.exe /deploy");
                this.ShowMessage("部署成功", DialogType.Success);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                this.ShowMessage("部署失败", DialogType.Fail);
            }
        }

        [RelayCommand]
        public async void LoadedNav(object navParent)
        {
            StackPanel panel = (StackPanel)navParent;
            foreach (NavButton navBtn in panel.Children)
            {
                string pName = navBtn.NavName;
                if (pageDict.ContainsKey(pName)) continue;

                switch (pName)
                {
                    case "Home":
                        HomeView homeView = new HomeView();
                        pageDict[pName] = homeView;
                        break;

                    case "Attribute":
                        AttributeView attributeView = new AttributeView();
                        pageDict[pName] = attributeView;
                        break;

                    case "Etymon":
                        EtymonView etymonView = new EtymonView();
                        pageDict[pName] = etymonView;
                        break;

                    case "Lexicon":
                        LexiconView lexiconView = new LexiconView();
                        pageDict[pName] = lexiconView;
                        break;

                    case "Themes":
                        ThemeView themeView = new ThemeView();
                        pageDict[pName] = themeView;
                        break;

                    case "EtymonKey":
                        EtymonKeyView etymonKeyView = new EtymonKeyView();
                        pageDict[pName] = etymonKeyView;
                        break;

                    case "Settings":
                        SettingsView settingsView = new SettingsView();
                        pageDict[pName] = settingsView;
                        break;

                    case "About":
                        AboutView aboutView = new AboutView();
                        pageDict[pName] = aboutView;
                        break;

                    default:
                        TestView testView = new TestView();
                        pageDict[pName] = testView;
                        break;
                }
            }
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
            string defultPack = "Pack://application:,,,/WubiMaster;component/Themes/DefultBlueTheme.xaml";
            Application.Current.Resources.MergedDictionaries[0].Source = new Uri(defultPack);
        }

        private void ShowMaskLayer(object recipient, string message)
        {
            bool isShow = bool.Parse(message);

            if (isShow)
                MaskLayerVisable = Visibility.Visible;
            else
                MaskLayerVisable = Visibility.Collapsed;
        }
    }
}