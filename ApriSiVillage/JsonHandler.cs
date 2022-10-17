using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System;

namespace ApriSiVillage
{
    public static class JsonHandler
    {
        public static object ReadJson(string path)
        {
            var json = new StreamReader(path);
            
            return json;
        }
    }
}
