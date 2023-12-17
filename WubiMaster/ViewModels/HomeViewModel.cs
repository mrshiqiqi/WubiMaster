using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WubiMaster.Common;
using WubiMaster.Views.PopViews;

namespace WubiMaster.ViewModels
{
   public partial class HomeViewModel:ObservableObject
    {

        public HomeViewModel()
        {
                
        }

        [RelayCommand]
        public void ShowZiGen()
        {
            MessageView messageView = new MessageView();
            messageView.ShowPop();
        }
    }
}
