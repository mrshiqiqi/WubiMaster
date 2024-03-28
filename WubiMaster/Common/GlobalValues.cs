using System;

namespace WubiMaster.Common
{
    public class GlobalValues
    {
        public static string AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string HeitiFont = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Fonts\黑体字根.ttf";
        public static string Scheme06Zip = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Schemes\scheme06.zip";
        public static string Scheme86Zip = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Schemes\scheme86.zip";
        public static string Scheme98Zip = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Schemes\scheme98.zip";
        public static string SpellingText06 = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Spelling\wb06_spelling.txt";
        public static string SpellingText86 = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Spelling\wb86_spelling.txt";
        public static string SpellingText98 = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Spelling\wb98_spelling.txt";
        private static string processPath;
        private static string serverName;
        private static string userPath;

        public static string ProcessPath
        {
            get { return processPath; }
            set { processPath = value; }
        }

        public static string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }

        public static string UserPath
        {
            get { return userPath; }
            set { userPath = value; }
        }

    }
}