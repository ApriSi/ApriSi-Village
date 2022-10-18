using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System;

namespace ApriSiVillage
{
    public static class JsonHandler
    {
        private static string _directoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/";
        public static JObject GetJsonObject(string path)
        {
            string json = File.ReadAllText(_directoryPath + path);
            var obj = JObject.Parse(json);
            
            return obj;
        }
    }
}
