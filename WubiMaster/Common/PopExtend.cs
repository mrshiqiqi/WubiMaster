using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WubiMaster.Common
{
    public static class PopExtend
    {
        public static void ClosePop(this Window pop)
        {
            if (pop == null) return;

            try
            {
                pop.DialogResult = true;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
                pop.Close();
            }
        }

        public static bool? ShowPop(this Window pop)
        {
            if (pop == null) return null;

            Window mainWindow = App.Current.MainWindow;

            WeakReferenceMessenger.Default.Send<string, string>("true", "ShowMaskLayer");
            pop.Owner = mainWindow;
            pop.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            return pop.ShowDialog();
        }
    }
}