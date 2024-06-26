﻿using log4net;
using System;
using System.Diagnostics;
using System.IO;

namespace WubiMaster.Common
{
    public class LogHelper
    {
        private static ILog Log = LogManager.GetLogger(typeof(LogHelper));
        private static string LogDirectory = AppDomain.CurrentDomain.BaseDirectory + "Logs";

        static LogHelper()
        {
            if (!Directory.Exists(LogDirectory))
                Directory.CreateDirectory(LogDirectory);
            LogHelper.RemoveLogs();
        }

        public static void Debug(string msg, bool addTrace = false)
        {
            string message = "";

            if (string.IsNullOrEmpty(msg)) return;
            if (addTrace)
                message = AppendClassLine(msg);
            else
                message = msg;

            string htmlStr = ToHtmlStr(message, "DEBUG", "green");
            Log.Debug(htmlStr);
        }

        public static void Error(string msg, bool addTrace = false)
        {
            string message = "";

            if (string.IsNullOrEmpty(msg)) return;
            if (addTrace)
                message = AppendClassLine(msg);
            else
                message = msg;

            string htmlStr = ToHtmlStr(message, "ERROR", "red");
            Log.Error(htmlStr);
        }

        public static void Fatal(string msg, bool addTrace = false)
        {
            string message = "";

            if (string.IsNullOrEmpty(msg)) return;
            if (addTrace)
                message = AppendClassLine(msg);
            else
                message = msg;

            string htmlStr = ToHtmlStr(message, "FATAL", "fuchsia");
            Log.Fatal(htmlStr);
        }

        public static void Info(string msg, bool addTrace = false)
        {
            string message = "";

            if (string.IsNullOrEmpty(msg)) return;
            if (addTrace)
                message = AppendClassLine(msg);
            else
                message = msg;

            string htmlStr = ToHtmlStr(message, "INFO", "black");
            Log.Error(htmlStr);
        }

        public static void Warn(string msg, bool addTrace = false)
        {
            string message = "";

            if (string.IsNullOrEmpty(msg)) return;
            if (addTrace)
                message = AppendClassLine(msg);
            else
                message = msg;

            string htmlStr = ToHtmlStr(message, "WARN", "orange");
            Log.Warn(htmlStr);
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

        private static void RemoveLogs()
        {
            try
            {
                string logPath = AppDomain.CurrentDomain.BaseDirectory + "Logs\\";
                DirectoryInfo root = new DirectoryInfo(logPath);
                FileInfo[] logFiles = root.GetFiles();

                string logBackDays = ConfigHelper.ReadConfigByString("log_back_days", "30");
                int backDays = int.Parse(logBackDays);

                foreach (var log in logFiles)
                    if ((DateTime.Today - log.LastWriteTime).Days >= backDays)
                        log.Delete();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }
        }

        private static string ToHtmlStr(string mesg, string type, string color = "black")
        {
            string htmlStr = $"<p style='color:{color}'>{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} [{type}] - {mesg}</p>";
            return htmlStr;
        }
    }
}