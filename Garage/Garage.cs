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
        public int MaxCapacity { get; set; }

        public Garage()
        {
            ParkedVehicles = new List<Vehicle>();
            MaxCapacity = 0;
        }
        
        public void AddVehicle(Vehicle vehicle)
        {
            ParkedVehicles = ParkedVehicles.Append(vehicle);
            
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            ParkedVehicles = ParkedVehicles.Where(v => v.LicenceNumber != vehicle.LicenceNumber);
        }
        public List<Vehicle> ListVehicles()
        {
            return ParkedVehicles.ToList();
        }

        public void ListTypeOfVehicles()
        {
            //return ParkedVehicles.Where(v => v.)
        }



        public void SearchVehicle()
        {
            throw new System.NotImplementedException();
        }
    }
}