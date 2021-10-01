﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Vehicle
    {
        public const string Type = "Vehicle";
        public string Color { get; set; }
        public string LicenceNumber { get; set; }
        public int NumberWheel { get; set; }
        public string Fuel { get; set; }

        public override string ToString()
        {
            return $"Type: {Type}, Color:{Color}, Licence Number{LicenceNumber}, Number of wheels:{NumberWheel}, Fuel:{Fuel}";
        }
    }
}