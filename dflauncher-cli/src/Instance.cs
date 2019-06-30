using System;
using System.IO;
using Newtonsoft.Json;
using SharpCompress;
using System.Runtime.InteropServices;

namespace dflaunchercli
{
	public class Instance 
    {
		public string name;
        public string version { get; set; }
        public bool dfhack { get; set; }
        public string execPath { get; set; }
        public string directory { get; set; }
		public string instancesDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dfcli/instances");

        public Instance(string name, string version, bool dfhack)
        {
            this.name = name;
            this.version = version;
            this.dfhack = dfhack;
			directory = instancesDirectory + "/" + name;
            execPath = directory + "/df";
			Directory.CreateDirectory(directory);
			Console.WriteLine("New instance created.");
        }

		public Instance() {
			if (!Directory.Exists(instancesDirectory)) Directory.CreateDirectory(instancesDirectory);
		}
        
        public void CreateJson(object instance) {
            JsonSerializer serializer = new JsonSerializer();
			serializer.Serialize(new JsonTextWriter(new StreamWriter(name + ".json")), instance);
        }

		public void CreateJson(string dir) {
            //will attempt to rebuild Json from directory and game info
		}

		public void SetupInstance()
		{
			var linuxGame = directory + "/game/game.tar.bz2";
			var windowsGame = directory + "/game/game.tar.zip";
			var os = Environment.OSVersion.Platform;

			Console.WriteLine("Downloading {0} from http://www.bay12games.com/dwarves/", version);

			if (os == PlatformID.Unix) Download.DownloadGameLinux(version, directory);
			if (os == PlatformID.Win32NT) Download.DownloadGameWindows(version, directory);
			
			while(!Download.downloadFinished) {
				Console.Write(Download.downloadProgress);
			}

			if (os == PlatformID.Unix && File.Exists(linuxGame)) {
				using (Stream s = File.OpenRead(linuxGame)) {

				}
			}

			if (os == PlatformID.Win32NT && File.Exists(directory + "/game/game.zip")) {
                //unzip
			}
		}

		public void DeleteInstance(object instance) {
            //
		}

		public void DeleteInstance(string dir) {
			try {
				Directory.Delete(dir);
			} catch(IOException) {
				Console.WriteLine("Failed to remove instance");
			}
		}

		public void LaunchInstance(string instance) //possibly implement File json as input instead
		{ 

		}    
    }
}
