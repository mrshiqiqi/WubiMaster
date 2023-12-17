using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.ViewModels
{
    public partial class PopViewModel : ObservableObject
    {
        [ObservableProperty]
        public MessageDialogModel messageDialogModel;

        [RelayCommand]
        public void Close(object obj)
        {
            if (obj == null) return;

            Window pop = obj as Window;
            pop.ClosePop();
            WeakReferenceMessenger.Default.Send<ValueChangedMessage<bool>, string>(new ValueChangedMessage<bool>(false), "ShowMaskLayer");
        }
    }
}