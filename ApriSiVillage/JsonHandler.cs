using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System;

namespace ApriSiVillage
{
    public static class JsonHandler
    {
        public static JObject GetJsonObject(string path)
        {
            string json = File.ReadAllText(path);
            var obj = JObject.Parse(json);

            return obj;
        }
    }
}
