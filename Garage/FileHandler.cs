using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Garage
{
    class FileHandler
    {
        public static void SaveGarage(Garage garage)
        {
            string x = JsonSerializer.Serialize(garage.GetType());
            Console.WriteLine(x);

        } 
    }
}
