using System;

namespace WubiMaster.Common
{
    public class GlobalValues
    {
        public static string AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string HeitiFont = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Fonts\黑体字根.ttf";
        public static string SchemaZip = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Schemas\wubi_schema.zip";
        public static string SchemaKey = @"\wubi_master.txt";
        public static string Schema06 = @"\schema06";
        public static string Schema86 = @"\schema86";
        public static string Schema98 = @"\schema98";
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