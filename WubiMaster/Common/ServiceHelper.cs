using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;

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
            if (ps.Length <= 0)
                return false;

            var _p = ps.FirstOrDefault(p => GetProcessUserName(p.Id) == Environment.UserName);
            if (_p == null) return false;
            return true;
        }

        public static void KillService()
        {
            if (!ServiceHelper.FindService())
                return;

            Process[] ps = Process.GetProcessesByName(GlobalValues.ServerName.Split(".exe")[0]);
            var _p = ps.FirstOrDefault(p => GetProcessUserName(p.Id) == Environment.UserName);
            if (_p != null) { _p.Kill(); }

            //string prcessPath = ConfigHelper.ReadConfigByString("process_file_path");
            //string processPath = GlobalValues.ProcessPath;
            //if (string.IsNullOrEmpty(processPath) || !Directory.Exists(processPath))
            //{
            //    throw new Exception("请先配置程序文件目录");
            //}
            //CmdHelper.RunCmd(processPath, "WeaselServer.exe /q", false);
        }

        public static void RunService()
        {
            if (ServiceHelper.FindService()) return;
            //string prcessPath = ConfigHelper.ReadConfigByString("process_file_path");
            string processPath = GlobalValues.ProcessPath;
            if (string.IsNullOrEmpty(processPath))
                throw new Exception("请先配置程序文件目录");

            CmdHelper.RunCmd(processPath, "WeaselServer.exe", false);
        }

        /// <summary>
        /// 查找进程所属的系统账户
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        private static string GetProcessUserName(int pID)
        {
            string userName = string.Empty;

            try
            {
                foreach (ManagementObject item in new ManagementObjectSearcher("Select * from Win32_Process WHERE processID=" + pID).Get())
                {
                    ManagementBaseObject inPar = null;
                    ManagementBaseObject outPar = null;

                    inPar = item.GetMethodParameters("GetOwner");
                    outPar = item.InvokeMethod("GetOwner", inPar, null);

                    userName = Convert.ToString(outPar["User"]);

                    break;
                }
            }
            catch
            {
                userName = "SYSTEM";
            }

            return userName;
        }
    }
}