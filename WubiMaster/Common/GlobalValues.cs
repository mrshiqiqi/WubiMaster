using System;

namespace WubiMaster.Common
{
    public class GlobalValues
    {
        public static string AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string HeitiFont = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Fonts\黑体字根.ttf";
        public static string SchemaKey = @"\wubi_master.txt";
        public static string SchemaZip = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Schemas\schema.zip";
        public static string SpellingText06 = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Spelling\wb06_spelling.txt";
        public static string SpellingText86 = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Spelling\wb86_spelling.txt";
        public static string SpellingText98 = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Spelling\wb98_spelling.txt";
        public static string Table06Zip = AppDomain.CurrentDomain.BaseDirectory + @"Assets\Schemas\table06.zip";
        public static string Table86Zip = AppDomain.CurrentDomain.BaseDirectory + @"Assets\Schemas\table86.zip";
        public static string Table98Zip = AppDomain.CurrentDomain.BaseDirectory + @"Assets\Schemas\table98.zip";
        private static string processPath;
        private static string rimeKey;
        private static string serverName;
        private static string userPath;

        public static string ProcessPath
        {
            get { return processPath; }
            set { processPath = value; }
        }

        public static string RimeKey
        {
            get { return rimeKey; }
            set { rimeKey = value; }
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