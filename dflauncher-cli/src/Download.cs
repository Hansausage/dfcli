using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace dflaunchercli
{
    static class Download
    {
      
        private static Dictionary<string, string> dfversionsWindows = new Dictionary<string, string>() {
            {"0.44.12","http://www.bay12games.com/dwarves/df_44_12_win.zip"},
            {"0.44.11","http://www.bay12games.com/dwarves/df_44_11_win.zip"},
            {"0.44.10","http://www.bay12games.com/dwarves/df_44_10_win.zip"},
        };

		private static Dictionary<string, string> dfversionsLinux = new Dictionary<string, string>() {
			{"0.44.12","http://bay12games.com/dwarves/df_44_12_linux.tar.bz2"},
			{"0.44.11","http://bay12games.com/dwarves/df_44_11_linux.tar.bz2"},
			{"0.44.10","http://bay12games.com/dwarves/df_44_10_linux.tar.bz2"},
        };

		public static void DownloadGameLinux(string version, string directory)
		{
			var url = new Uri(dfversionsLinux[version]);
			using (WebClient c = new WebClient())
			{
				c.DownloadFile(url, directory);
			}
		}

		public static void DownloadGameWindows(string version, string directory)
        {
            var url = new Uri(dfversionsWindows[version]);
            using (WebClient c = new WebClient())
            {
                c.DownloadFile(url, directory);
            }
		}
    }
}
