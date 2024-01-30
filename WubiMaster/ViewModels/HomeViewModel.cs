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

namespace WubiMaster.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {

        [ObservableProperty]
        private int shiciInterval = 25;

        public HomeViewModel()
        {
            WeakReferenceMessenger.Default.Register<string, string>(this, "ChangeShiciInterval", ChangeShiciInterval);
            //Messenger.Register<HomeViewModel, ValueChangedMessage<bool>, int>(this, "ChangeShiciInterval", ChangeShiciInterval);
        }

        [RelayCommand]
        public void ShowEtymon()
        {
            WeakReferenceMessenger.Default.Send<ValueChangedMessage<bool>, string>(new ValueChangedMessage<bool>(true), "ShowMaskLayer");
            this.ShowMessage("提示", "找不到该页面", DialogType.Warring);
        }

        [RelayCommand]
        public void ToQQSocial()
        {
            MessageBox.Show("Hello");
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

                MessageBox.Show(ex.Message);
            }

        }
    }
}
