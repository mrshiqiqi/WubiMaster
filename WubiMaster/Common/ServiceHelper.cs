using System;
using System.Diagnostics;

namespace WubiMaster.Common
{
    public class ServiceHelper
    {
        public static bool FindService()
        {
            Process[] ps = Process.GetProcessesByName("WeaselServer");
            if (ps.Length > 0)
            {
                return true;
            }
            return false;
        }

        public static void KillService()
        {
            if (!ServiceHelper.FindService()) return;
            string prcessPath = ConfigHelper.ReadConfigByString("process_file_path");
            if (string.IsNullOrEmpty(prcessPath))
            {
                throw new Exception("请先配置程序文件目录");
            }
            CmdHelper.RunCmd(prcessPath, "WeaselServer.exe /q", false);
        }

        public static void RunService()
        {
            if (ServiceHelper.FindService()) return;
            string prcessPath = ConfigHelper.ReadConfigByString("process_file_path");
            if (string.IsNullOrEmpty(prcessPath))
            {
                throw new Exception("请先配置程序文件目录");
            }
            CmdHelper.RunCmd(prcessPath, "WeaselServer.exe", false);
        }
    }
}