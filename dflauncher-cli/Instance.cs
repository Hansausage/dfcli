using System;
using System.IO;
using Newtonsoft.Json;
namespace dflaunchercli
{
    public class Instance
    {
		public string name;
        public string version { get; set; }
        public bool dfhack { get; set; }
        public string execPath { get; set; }
        public string directory { get; set; }

        public Instance(string name, string version, bool dfhack)
        {
            this.name = name;
            this.version = version;
            this.dfhack = dfhack;
            directory = Directory.GetCurrentDirectory() + "/instances/" + name;
            Directory.CreateDirectory(directory);
            execPath = directory + "/df";
        }

		public Instance() {
            //default
		}
        
        public void CreateJson(object instance) {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(new JsonTextWriter(new StreamWriter(name + ".json")), instance);
        }
    }
}
