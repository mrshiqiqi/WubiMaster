using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WubiMaster.Common
{
    public class GlobalValues
    {
		private static string userPath;

		public static string UserPath
		{
			get { return userPath; }
			set { userPath = value; }
		}

        private static string processPath;

        public static string ProcessPath
        {
            get { return processPath; }
            set { processPath = value; }
        }

        private static string serverName;

        public static string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }
    }
}
