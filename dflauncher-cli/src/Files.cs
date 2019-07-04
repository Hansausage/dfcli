using System;
using System.IO;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;
using Newtonsoft.Json;

namespace dflaunchercli
{
    public static class Files
    {
		public static void DecompressBz2(string bz2, string tarball) {
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
    }
}
