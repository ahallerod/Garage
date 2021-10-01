using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Garage
    {
        public IEnumerable<Vehicle> ParkedVehicles
        {
            get;
            set;
        }

        public Garage()
        {
            ParkedVehicles = new List<Vehicle>();
            MaxCapacity = 0;
        }
        public int MaxCapacity { get; set; }        
        
        public void AddVehicle(Vehicle vehicle)
        {
            ParkedVehicles = ParkedVehicles.Append(vehicle);
            
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            ParkedVehicles = ParkedVehicles.Where(v => v.LicenceNumber != vehicle.LicenceNumber);
        }


        public void ListVehicles()
        {
            Console.WriteLine("Cars Currently in the Garage:");
            foreach(Vehicle vehicle in ParkedVehicles)
            {
                Console.Write($"regnr: {vehicle.LicenceNumber}\n");
            }
        }

        public void ListTypeOfVehicles()
        {

        }



        public void SearchVehicle()
        {
            throw new System.NotImplementedException();
        }
    }
}