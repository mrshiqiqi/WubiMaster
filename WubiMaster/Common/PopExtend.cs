using System;
using System.Windows;

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

            return pop.ShowDialog();
        }
    }
}