using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Motorcycle : Vehicle
    {
        public const string Type = "Motorcycle"; 
        public int NumberMirror { get; set; }

        public int YearModel { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Number Mirrors: {NumberMirror}, Model Year: {YearModel}";
        }
    }
}