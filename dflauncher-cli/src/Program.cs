using System;
using System.IO;

namespace dflaunchercli
{
	class MainClass
	{
		public static void Main(string[] args) {
			string name = "dnc";
			string ver = "dnv";
			//bool isDfHack = false;
			string[] copyArgs = new string[100];
			Instance newInstance = new Instance();
			if (args == null || args.Length == 0)
			{
				DirectoryInfo d;
				foreach (string dir in Directory.GetDirectories(newInstance.GetInstancesDirectory() + "/"))
				{
					d = new DirectoryInfo(dir);
					Console.WriteLine(d.Name);
				}
				Console.WriteLine("No arguments passed, for help run dfcli -h");
			}
			else
			{
				for (int i = 0; i < args.Length; i++)
				{
					if (args[i] == Args.name_new) {
						name = args[i + 1];
						copyArgs[i] = name;
					}
					if (args[i] == Args.version) {
						ver = args[i + 1];
						copyArgs[i] = ver;
					}
					if (args[i] == Args.help) {
						Args.PrintDoc();
					}
				}

				for (int i = 0; i < copyArgs.Length; i++) {
					if (copyArgs[i] == null) break;
					if (copyArgs[i] == Files.Matches(copyArgs[i]))
                    {
                        newInstance.LaunchInstance(copyArgs[i]);
                    }
					if (copyArgs[i] == "dnc") break;
					if (copyArgs[i] == "dnv") break;               
					newInstance = new Instance(name, ver);
					newInstance.SetupInstance(newInstance);               
				}
			}         
		}
	}
}
