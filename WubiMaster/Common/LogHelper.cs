using log4net;
using System.Diagnostics;
using System.IO;

namespace WubiMaster.Common
{
    public class LogHelper
    {
        private static ILog LogError = LogManager.GetLogger("logerror");
        private static ILog LogInfo = LogManager.GetLogger("loginfo");

        public static void Error(string errorStr, bool addTrace = false)
        {
            if (string.IsNullOrEmpty(errorStr)) return;
            if (addTrace)
                LogError.Error(AppendClassLine(errorStr));
            else
                LogError.Error(errorStr);
        }

        public static void Info(string infoStr, bool addTrace = false)
        {
            if (string.IsNullOrEmpty(infoStr)) return;
            if (addTrace)
                LogInfo.Info(AppendClassLine(infoStr));
            else
                LogInfo.Info(infoStr);
        }

        private static string AppendClassLine(string msg)
        {
            string logStr = msg;

            try
            {
                StackTrace st = new StackTrace(true);
                StackFrame sf = st.GetFrame(2);
                logStr = $"{msg} [{Path.GetFileName(sf.GetFileName())}: {sf.GetFileLineNumber().ToString()}]";
            }
            catch { }

            return logStr;
        }
    }
}