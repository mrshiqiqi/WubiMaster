using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using WubiMaster.Common;
using WubiMaster.Models;
using WubiMaster.Controls;
using WubiMaster.Views.PopViews;

namespace WubiMaster.ViewModels
{
    public partial class PopViewModel : ObservableObject
    {

        [ObservableProperty]
        private MessageBoxControl messageBox;

        [RelayCommand]
        public void Close(object obj)
        {      
            this.CloseMessage(obj);
        }
    }
}