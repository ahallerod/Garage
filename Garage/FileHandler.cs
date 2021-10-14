using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Garage
{ 
    class FileHandler
    {
        private const string filePath = @".\";
        public static void SaveGarage(Garage garage)
        {

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            SerializationGarage sg = garage.ConvertGarageForSerialization();
            string jsonGarage = JsonConvert.SerializeObject(sg, settings);
            File.WriteAllText(filePath + @"garage.json", jsonGarage);
        }

        public static bool CheckForSavedFiles()
        {
            if (File.Exists(filePath + @"garage.json")) return true;
            return false;
        }
        
        public static Garage LoadGarage()
        {
            Garage g = new();
            
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string jsonGarage = File.ReadAllText(filePath + @"garage.json");
          
            g.LoadGarage(JsonConvert.DeserializeObject<SerializationGarage>(jsonGarage, settings));

            return g;
        }
    }
}
