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

namespace WubiMaster.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {

        public HomeViewModel()
        {

        }

        [RelayCommand]
        public void ShowEtymon()
        {
            WeakReferenceMessenger.Default.Send<ValueChangedMessage<bool>, string>(new ValueChangedMessage<bool>(true), "ShowMaskLayer");
            this.ShowMessage("提示", "找不到该页面", DialogType.Warring);
        }
    }
}
