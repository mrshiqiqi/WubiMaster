using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

                if (!FindProcess())
                {
                    this.ShowMessage("算法服务未启动，无法执行部署操作", DialogType.Warring);
                    return;
                }

                RunCmd(prcessPath, "WeaselDeployer.exe /deploy");
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

                    case "Etymon":
                        EtymonView etymonView = new EtymonView();
                        pageDict[pName] = etymonView;
                        break;

                    case "Lexicon":
                        LexiconView lexiconView = new LexiconView();
                        pageDict[pName] = lexiconView;
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
            //Todo: 优先从配置文件里读取
            string defultPack = "Pack://application:,,,/WubiMaster;component/Themes/DefultBlueTheme.xaml";
            Application.Current.Resources.MergedDictionaries[0].Source = new Uri(defultPack);
        }

        private bool FindProcess()
        {
            Process[] ps = Process.GetProcessesByName("WeaselServer");
            if (ps.Length > 0)
            {
                return true;
            }
            return false;
        }

        private void KillProcess()
        {
            string prcessPath = ConfigHelper.ReadConfigByString("process_file_path");
            if (string.IsNullOrEmpty(prcessPath))
            {
                this.ShowMessage("请先配置程序文件目录", DialogType.Warring);
                return;
            }
            RunCmd(prcessPath, "WeaselServer.exe /q");
        }

        private string RunCmd(string path, string cmd)
        {
            string CmdPath = @"C:\Windows\System32\cmd.exe";
            cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
            using (Process p = new Process())
            {
                p.StartInfo.FileName = CmdPath;
                p.StartInfo.WorkingDirectory = path; // 指定运行目录
                p.StartInfo.UseShellExecute = false; //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true; //重定向标准错误输出
                p.StartInfo.CreateNoWindow = true; //不显示程序窗口
                p.Start();//启动程序

                //向cmd窗口写入命令
                p.StandardInput.WriteLine(cmd);
                p.StandardInput.AutoFlush = true;

                //获取cmd窗口的输出信息
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();//等待程序执行完退出进程
                p.Close();

                return output;
            }
        }

        private void RunProcess()
        {
            string prcessPath = ConfigHelper.ReadConfigByString("process_file_path");
            if (string.IsNullOrEmpty(prcessPath))
            {
                this.ShowMessage("请先配置程序文件目录", DialogType.Warring);
                return;
            }
            RunCmd(prcessPath, "WeaselServer.exe");
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