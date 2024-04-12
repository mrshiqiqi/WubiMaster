using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WubiMaster.Common;

namespace WubiMaster
{
    public partial class App : Application
    {
        private Mutex mutex;
        public static bool IsMaximized { get; set; }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                e.Handled = true;
                LogHelper.Fatal(e.Exception.Message);
            }
            catch (Exception ex)
            {
                LogHelper.Fatal("程序发生致命错误，将终止，请联系开发人员！" + ex.Message);
                this.ShowMessage("程序发生致命错误，将终止，请联系开发人员！", DialogType.Error);
                Environment.Exit(0);
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            LogHelper.Info("程序退出");
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //bool ret;
            //mutex = new Mutex(true, "WubiMaster", out ret);
            //if (!ret)
            //{
            //    LogHelper.Info("禁止启用多个进程");
            //    Environment.Exit(0);
            //    return;
            //}

            LogHelper.Info("程序启动");

            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            StringBuilder sbEx = new StringBuilder();
            if (e.IsTerminating)
            {
                sbEx.Append("程序发生致命错误，将终止，请联系开发人员！\n");
            }

            if (e.ExceptionObject is Exception)
            {
                sbEx.Append(((Exception)e.ExceptionObject).Message);
            }
            else
            {
                sbEx.Append(e.ExceptionObject);
            }
            this.ShowMessage(sbEx.ToString(), DialogType.Error);
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            LogHelper.Fatal(e.Exception.Message);
            e.SetObserved();
            this.ShowMessage(e.Exception.Message, DialogType.Error);
        }
    }
}