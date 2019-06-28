using System;
using System.IO;

namespace dflaunchercli
{
    class MainClass
	{
        public static void Main(string[] args)
        {
			for (int i = 0; i < args.Length; i++) {
				string name, ver;
				bool isDfhack;

				if (args[i] == "-n") {
					name = args[i + 1];
				}

				if (args[i] == "-v") {
					ver = args[i + 1];
				}

				if (args[i] == "--dfhack") {
					isDfhack = true;
				}
                            
			}

			if (args == null) { //later change to parse master json for instances
				foreach(string dir in Directory.GetDirectories(Directory.GetCurrentDirectory() + "/instances/")) {
					Console.WriteLine(dir);
					Console.WriteLine("No arguments passed, run dfcli -h for help.");
				}
			}
        }
    }
}
