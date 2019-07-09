using System;
namespace dflaunchercli
{
	public struct Args
	{
		public const string name_new = "-n";
		public const string version = "-v";
		public const string help = "-h";
		public const string dfhack = "--dfhack";
		public const string verbose = "--verbose"; //unimplemented
		public const string rename = "-r"; //unimplemented
		public const string remove = "-rm";
		public const string package = "-p";
		public const string detailed = "-l";

		public static void PrintDoc()
		{
			Console.Write(
				"dfcli - Utility for creating and managing instances of Dwarf Fortress for Linux/Windows\n" +
				"Run dfcli alone to list instances\n" +
				"dfcli <instance name> - Launch instance\n" +
				"Arguments:\n" +
				"-n <instance name> - Create an instance with the specified name\n" +
				"-v <version> - Specify version of Dwarf Fortress to download\n" +
				"-h - Print this help message\n" +
				"-r <instance name> <new instance name> - Rename a specified instance\n" +
				"--dfhack - Download and install dfhack to the instance being created\n" +
				"--version - Prints the version of dfcli being used\n"
			);
		}
	}
}
