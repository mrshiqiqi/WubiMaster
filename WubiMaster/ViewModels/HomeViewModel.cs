using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WubiMaster.Common;
using WubiMaster.Views.PopViews;
using System.Windows;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Controls;

namespace WubiMaster.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {

        [ObservableProperty]
        private int shiciInterval = 25;

        public HomeViewModel()
        {
            WeakReferenceMessenger.Default.Register<string, string>(this, "ChangeShiciInterval", ChangeShiciInterval);
        }

        [RelayCommand]
        public void CopyInfo(object obj)
        {
            Clipboard.SetDataObject(obj);
            this.ShowMessage("已复制到剪贴板");
        }

        [RelayCommand]
        public void ToWebPage(object obj)
        {
            try
            {
                string url = obj?.ToString();
                Process.Start("explorer.exe", url);
            }
            catch (Exception ex)
            {
                this.ShowMessage("无法打开网址", DialogType.Error);
                LogHelper.Error(ex.Message);
            }

        }

        private void ChangeShiciInterval(object recipient, string message)
        {
            try
            {
                int newInterval = int.Parse(message);

                if (newInterval < 5)
                {
                    ShiciInterval = 25;
                    return;
                }
                ShiciInterval = newInterval;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }

        }
    }
}
