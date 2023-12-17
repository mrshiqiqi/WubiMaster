using CommunityToolkit.Mvvm.Input;
using System.Windows;
using WubiMaster.Common;

namespace WubiMaster.ViewModels
{
    public partial class PopViewModel
    {
        [RelayCommand]
        public void Close(object obj)
        {
            if (obj == null) return;

            Window pop = obj as Window;
            pop.ClosePop();
        }
    }
}