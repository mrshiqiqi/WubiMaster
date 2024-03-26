using System;
using System.Diagnostics;

namespace WubiMaster.Common
{
    public class ServiceHelper
    {
        public static bool FindService()
        {
            //string serverName = ConfigHelper.ReadConfigByString("weasel_server");
            string serverName = GlobalValues.ServerName;
            if (string.IsNullOrEmpty(serverName)) { return false; }
            Process[] ps = Process.GetProcessesByName(serverName.Split(".exe")[0]);
            if (ps.Length > 0)
            {
                return true;
            }
            return false;
        }

        public static void KillService()
        {
            if (!ServiceHelper.FindService()) return;
            //string prcessPath = ConfigHelper.ReadConfigByString("process_file_path");
            string processPath = GlobalValues.ProcessPath;
            if (string.IsNullOrEmpty(processPath))
            {
                throw new Exception("请先配置程序文件目录");
            }
            CmdHelper.RunCmd(processPath, "WeaselServer.exe /q", false);
        }

        public static void RunService()
        {
            if (ServiceHelper.FindService()) return;
            //string prcessPath = ConfigHelper.ReadConfigByString("process_file_path");
            string processPath = GlobalValues.ProcessPath;
            if (string.IsNullOrEmpty(processPath))
            {
                throw new Exception("请先配置程序文件目录");
            }
            CmdHelper.RunCmd(processPath, "WeaselServer.exe", false);
        }
    }
}