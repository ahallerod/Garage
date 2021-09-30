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
            get => default;
            set
            {
            }
        }

        public int MaxCapacity
        {
            get => default;
            set
            {
            }
        }

        public void ListVehicles()
        {
            throw new System.NotImplementedException();
        }

        public void ListTypeOfVehicles()
        {
            throw new System.NotImplementedException();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            ParkedVehicles.Append<Vehicle>(vehicle);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {

        }

        public void SearchVehicle()
        {
            throw new System.NotImplementedException();
        }
    }
}