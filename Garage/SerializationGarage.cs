using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class SerializationGarage                                            //AH
    {
        
        public int Size { get; set; }
        public List<Vehicle> ParkedVehicles { get; set; }
        public SerializationGarage()
        {}
        public SerializationGarage(int size, List<Vehicle> vehicles)
        {
            Size = size;
            ParkedVehicles = vehicles;
        }
    }
}
