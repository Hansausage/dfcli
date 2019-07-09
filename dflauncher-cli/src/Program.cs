using System;
using System.IO;

namespace dflaunchercli
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var name = "";
			var ver = "";
			var _create = false;

			if (args == null || args.Length == 0)
			{
				foreach (string instance in Files.GetInstances())
				{
					Console.WriteLine(instance);
				}
				Console.WriteLine("No arguments passed, for help run dfcli -h");
			}
			else
			{
				for (int i = 0; i < args.Length; i++)
				{
					switch (args[i])
					{
						case Args.name_new:
							name = args[i + 1];
							_create = true;
							break;
						case Args.version:
							ver = args[i + 1];
							break;
						case Args.help:
							Args.PrintDoc();
							break;
						case Args.remove:
							Console.Write("type instance name again to confirm: ");
							string c = Console.ReadLine();
							if (c == args[i + 1]) Files.DeleteInstance(args[i + 1]);
							Console.WriteLine("Deleted instance {0}", c);
							break;
						case Args.dfhack:
							break;
						case Args.rename:
							break;
						case Args.package:
							break;
						case Args.detailed:
							new Instance().ListDetailedInstances();
							break;
						default:
							if (args[i] == Files.Matches(args[i]))
							{
								Console.WriteLine("Launching instance {0}", args[i]);
								Instance instance = new Instance(args[i]);
								instance.LaunchInstance(args[i]);
							}
							else if (!_create)
							{
								Console.WriteLine("Invalid operation, use dfcli -h for help.");
							}
							break;
					}
				}
			}
			if (_create)
			{
				var instance = new Instance(name, ver);
				instance.SetupInstance(instance);
			}
		}
	}
}
