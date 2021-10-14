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



            //string jsonGarageSize = JsonSeializer.Serialize(garage.Capacity);
            //string jsonParkedVehicles = JsonSerializer.Serialize<IEnumerable<Vehicle>>(garage.ParkedVehicles);
            //string jsonGarage = JsonConvert.SerializeObject(garage, settings);
            //File.WriteAllText(filePath + @"garage.json", jsonGarage);
            //File.WriteAllText(filePath + @"parkedvehicles.json", jsonParkedVehicles);
            //WriteToXmlFile<SerializationGarage>(garage.ConvertGarageForSerialization());
            
            
            /*
            DataContractSerializer dsc = new(garage.GetType());
            if (File.Exists(filePath + @"garage.xml"))
            {
                File.Delete(filePath + @"garage.xml");
            }
            using (FileStream fs = File.Create(filePath + @"garage.xml")) { }
            using (FileStream fs = File.OpenWrite(filePath + @"garage.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create(fs))
                dsc.WriteObject(writer, garage);
            }
            */
            
        }
    /*
        public static void WriteToXmlFile<T>(T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath + "garage.xml", append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        public static T ReadFromXmlFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public static IEnumerable<Vehicle> DeserializeVehicles(string json)
        {
            return JsonSerializer.Deserialize<IEnumerable<Vehicle>>(json);
        }
    */
        public static bool CheckForSavedFiles()
        {
            if (!File.Exists(filePath + @"garage.json") || !File.Exists(filePath + @"parkedvehicles.json")) return false;
            return true;
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
