using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using WubiMaster.Common;
using WubiMaster.Models;
using WubiMaster.Controls;
using WubiMaster.Views.PopViews;
using System;

namespace WubiMaster.ViewModels
{
    public partial class PopViewModel : ObservableObject
    {

        [ObservableProperty]
        private MessageBoxControl messageBox;

        [RelayCommand]
        public void Close(object obj)
        {      
            //this.CloseMessage(obj);

            if (obj == null) return;
            WeakReferenceMessenger.Default.Send<string, string>("false", "ShowMaskLayer");

            try
            {
                Window w = (Window)obj;
                w.DialogResult = true;
            }
            catch (Exception ex)
            {
                Window w = (Window)obj;
                w.Close();

                LogHelper.Warn("提示窗口未正常关闭");
                LogHelper.Error(ex.Message);
            }
        }

        [RelayCommand]
        public void CloseMessage(object obj)
        {
            if (obj == null) return;
            obj.CloseMessage(obj);
        }
    }
}