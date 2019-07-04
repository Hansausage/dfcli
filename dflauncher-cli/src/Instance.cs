using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;
namespace dflaunchercli
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Instance 
    {
		[JsonProperty]
		private string name { get; set; }

		[JsonProperty]
        private string version { get; set; }

		[JsonProperty]
        private string execPath { get; set; }

        [JsonProperty]
        private string directory { get; set; }

		[JsonProperty]
        private readonly PlatformID os = Environment.OSVersion.Platform;
        
        private bool dfhack { get; set; }      
		private readonly string instancesDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dfcli/instances");
              
		public Instance(string name, string version)
        {
            this.name = name;
            this.version = version;
			directory = instancesDirectory + "/" + name;
			if (os == PlatformID.Unix) execPath = directory + "/game/df";
			if (os == PlatformID.Win32NT) execPath = directory + "/game/Dwarf Fortress.exe";
        }

		public Instance() 
		{
			if (!Directory.Exists(instancesDirectory)) Directory.CreateDirectory(instancesDirectory);
		}
        
		public string GetInstancesDirectory() 
		{
			return instancesDirectory;
		}
              
        public void LaunchInstance(string name) 
		{
			if (Files.Exists(name)) {
				using (Process p = new Process()) {
					p.StartInfo.RedirectStandardOutput = true;
					p.StartInfo.UseShellExecute = false;
					p.StartInfo.FileName = execPath;
				}
			}
		}
        
		public void SetupInstance(object instance)
		{
			Console.WriteLine("Platform ID is {0}", os);
			Console.WriteLine("Setting up instance {0}", name);

			Directory.CreateDirectory(directory + "/game/");

			var linuxGame = directory + "/game/game.tar.bz2";
			var windowsGame = directory + "/game/game.zip";
			var jsonFile = directory + "/" + name + ".json";
			var tarball = directory + "/game/game.tar";
          
			Console.WriteLine("Downloading {0} from http://www.bay12games.com/dwarves/ to {1}", version, linuxGame);

			if (os == PlatformID.Unix) Download.DownloadGameLinux(version, linuxGame);
			if (os == PlatformID.Win32NT) Download.DownloadGameWindows(version, windowsGame);

			if (os == PlatformID.Unix && File.Exists(linuxGame)) 
			{
				Console.WriteLine("Decompressing {0}", linuxGame);
				Files.DecompressBz2(linuxGame, tarball);
				File.Delete(linuxGame);

				Console.WriteLine("Untar {0}", tarball);
				Files.Untar(tarball, directory + "/game/");
				File.Delete(tarball);            
			}
            

			if (os == PlatformID.Win32NT && File.Exists(windowsGame)) 
			{
                //unzip
			}

			Console.WriteLine("Generate {0}", jsonFile);
			Files.CreateJsonFromObject(jsonFile, instance);

			Console.Write("Instance created.\n" +
						  "Run dfcli {0} to start instance\n", name
						 );
		}
    }
}
