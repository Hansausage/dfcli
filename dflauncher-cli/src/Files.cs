using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;
using Newtonsoft.Json;

namespace dflaunchercli
{
	public static class Files
	{
		[DllImport("libc", SetLastError = true)]
		public static extern int chmod(string pathname, int mode);

		// user permissions
		const int S_IRUSR = 0x100;
		const int S_IWUSR = 0x80;
		const int S_IXUSR = 0x40;

		// group permission
		const int S_IRGRP = 0x20;
		const int S_IWGRP = 0x10;
		const int S_IXGRP = 0x8;

		// other permissions
		const int S_IROTH = 0x4;
		const int S_IWOTH = 0x2;
		const int S_IXOTH = 0x1;

		public static void SetFull(string file)
		{
			chmod(file, (int)S_IRUSR | S_IWUSR | S_IXUSR);
		}

		public static void DecompressBz2(string bz2, string tarball)
		{
			using (FileStream outStream = File.OpenWrite(tarball))
			using (FileStream inStream = File.OpenRead(bz2))
			{ //change to BZip2nputStream
				BZip2.Decompress(inStream, outStream, outStream.CanWrite && inStream.CanRead);
			}
		}

		public static void Untar(string tarball, string path)
		{
			using (FileStream inStream = File.OpenRead(tarball))
			using (TarArchive tar = TarArchive.CreateInputTarArchive(inStream))
			{
				tar.ExtractContents(path);
			}
		}

		public static void Unzip(string zip, string path)
		{

		}

		public static void CreateJsonFromObject(string filename, object instance)
		{
			string json = JsonConvert.SerializeObject(instance, Formatting.Indented);
			Console.WriteLine(json);
			using (StreamWriter f = File.CreateText(filename))
			{
				JsonSerializer s = new JsonSerializer();
				s.Serialize(f, instance);
			}
		}

		public static object CreateObjectFromJson(string file)
		{
			Instance i;
			using (StreamReader f = File.OpenText(file))
			{
				JsonSerializer s = new JsonSerializer();
				i = (Instance)s.Deserialize(f, typeof(Instance));
			}
			return i;
		}

		public static Dictionary<string, TValue> CreateDictFromObject<TValue>(object o)
		{
			var j = JsonConvert.SerializeObject(o);
			var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(j);
			return dictionary;
		}

		public static bool Exists(string name)
		{
			DirectoryInfo d;
			foreach (string dir in Directory.GetDirectories(new Instance().GetInstancesDirectory()))
			{
				d = new DirectoryInfo(dir);
				if (d.Name == name) return true;
			}
			return false;
		}

		public static string Matches(string name)
		{
			DirectoryInfo d;
			foreach (string dir in Directory.GetDirectories(new Instance().GetInstancesDirectory()))
			{
				d = new DirectoryInfo(dir);
				if (d.Name == name) return d.Name;
			}
			return null;
		}

		public static List<string> GetInstances()
		{
			var instances = new List<string>();
			DirectoryInfo d;
			foreach (string dir in Directory.GetDirectories(new Instance().GetInstancesDirectory() + "/"))
			{
				d = new DirectoryInfo(dir);
				instances.Add(d.Name);
			}
			return instances;
		}

		public static void DeleteInstance(string name)
		{
			Directory.Delete(new Instance().GetInstanceDirectory(name), true);
		}
	}
}
