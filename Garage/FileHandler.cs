using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Garage
{
    class FileHandler
    {

        private const string path = @".\";
        public static void SaveGarage(Garage garage)
        {
            

            string jsonGarageSize = JsonSerializer.Serialize(garage.Capacity);
            string jsonParkedVehicles = JsonSerializer.Serialize<IEnumerable<Vehicle>>(garage.ParkedVehicles);

            Console.WriteLine( DeserializeVehicles(jsonParkedVehicles));
            File.WriteAllText(path + @"garage.json", jsonGarageSize);
            File.WriteAllText(path + @"parkedvehicles.json", jsonParkedVehicles);
        }

        public static IEnumerable<Vehicle> DeserializeVehicles(string json)
        {
            return JsonSerializer.Deserialize<IEnumerable<Vehicle>>(json);
        }

        public static Garage LoadGarage()
        {
            Garage g = new();

            string jsonGarageSize = File.ReadAllText(path + @"garage.json");
            string jsonParkedVehicles = File.ReadAllText(path + @"parkedvehicles.json");
            g.Capacity = JsonSerializer.Deserialize<int>(jsonGarageSize);
            g.ParkedVehicles = JsonSerializer.Deserialize<IEnumerable<Vehicle>>(jsonParkedVehicles);

            return g;
        }
    }
}
