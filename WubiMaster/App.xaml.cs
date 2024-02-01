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
            LogHelper.Info("程序启动");
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            LogHelper.Info("程序退出");
        }
    }
}
