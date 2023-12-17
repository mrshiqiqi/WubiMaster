using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WubiMaster.Common
{
    public static class PopExtend
    {
        public static void ShowPop(this Window pop)
        {
            if (pop == null) return;

            pop.ShowDialog();
        }

        public static void ClosePop(this Window pop)
        {
            if (pop == null) return;

            try
            {
                pop.DialogResult = true;
            }
            catch (Exception ex)
            {
                pop.Close();
            }

        }
    }
}
