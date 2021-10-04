using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Bus : Vehicle
    {
        public new const string Type = "Bus";
        public int PassengerCapacity { get; set; }
        public string SchoolBus { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Passerger Capacity: {PassengerCapacity}, SchoolBus: {SchoolBus}";
        }

    }
}