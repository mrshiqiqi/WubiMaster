using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WubiMaster.Common;

namespace WubiMaster
{
    public partial class App : Application
    {
        public static bool IsMaximized { get; set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LogHelper.Info("【书中君】启动");
            LogHelper.Error("你好，世界", true);
        }
    }
}
