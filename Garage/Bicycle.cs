using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Bicycle : Vehicle
    {
        public const string Type = "Bicycle";
        public string IsMountainBike { get; set; }

        public string SuitableFor { get; set; }

        public override string ToString()
        {
            return $"Color:{Color}, Licence Number{LicenceNumber}, Number of wheels:{NumberWheel}, Fuel:{Fuel}, Is Mountainbike: {IsMountainBike}, Suitable for: {SuitableFor}";
        }
    }
}