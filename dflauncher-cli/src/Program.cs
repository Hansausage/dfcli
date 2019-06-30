using System;
using System.IO;

namespace dflaunchercli
{
	class MainClass
	{
		public static void Main(string[] args) {
			string name = "New Instance";
			string ver = "latest";
			bool isDfHack = false;
			Instance newInstance = new Instance();
			if (args == null || args.Length == 0)
			{
				DirectoryInfo d;
				foreach (string dir in Directory.GetDirectories(newInstance.instancesDirectory + "/"))
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
					if (args[i] == "-n") name = args[i + 1];
					if (args[i] == "-v") ver = args[i + 1];
					if (args[i] == "dfhack") isDfHack = true;
				}

				newInstance = new Instance(name, ver, isDfHack);
			}         
		}
	}
}
