using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WubiMaster.Common;
using WubiMaster.Models;

namespace WubiMaster.ViewModels
{
    public partial class EtymonViewModel : ObservableObject
    {

        [ObservableProperty]
        public ObservableCollection<ZigenModel> zigenList;

        public EtymonViewModel()
        {
            ObservableCollection<ZigenModel> temp = new ObservableCollection<ZigenModel>();
            for (int i = 0; i < 5; i++)
            {
                ZigenModel zm = new ZigenModel();
                zm.Worlds = "你好";
                temp.Add(zm);
            }
            zigenList = temp;
        }


        [RelayCommand]
        public void ZigenSearch()
        {

        }
    }
}
