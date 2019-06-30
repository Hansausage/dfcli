using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dflaunchercli
{
    static class Download
    {
		public static int downloadProgress { get; set; }
        public static bool downloadFinished { get; set; }

        public static Dictionary<string, string> dfversionsWindows = new Dictionary<string, string>() {
            {"0.44.12","http://www.bay12games.com/dwarves/df_44_12_win.zip"},
            {"0.44.11","http://www.bay12games.com/dwarves/df_44_11_win.zip"},
            {"0.44.10","http://www.bay12games.com/dwarves/df_44_10_win.zip"},
        };

		public static Dictionary<string, string> dfversionsLinux = new Dictionary<string, string>() {
			{"0.44.12","http://bay12games.com/dwarves/df_44_12_linux.tar.bz2"},
			{"0.44.11","http://bay12games.com/dwarves/df_44_11_linux.tar.bz2"},
			{"0.44.10","http://bay12games.com/dwarves/df_44_10_linux.tar.bz2"},
        };

        public static void DownloadGameWindows(string version, string directory)
        {
            WebClient dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            dl.DownloadFileAsync(new Uri(dfversionsWindows[version]), directory + "/game/" + "/game.zip");
        }

		public static void DownloadGameLinux(string version, string directory)
        {
            WebClient dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
			dl.DownloadFileAsync(new Uri(dfversionsLinux[version]), directory + "/game/" + "/game.tar.bz2");
        }

        public static void dl_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            downloadProgress = e.ProgressPercentage;
        }

        public static void dl_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            downloadFinished = true;
        }
    }
}
