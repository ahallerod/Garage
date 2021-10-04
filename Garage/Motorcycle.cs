using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Motorcycle : Vehicle
    {
        public int NumberMirror { get; set; }

        public int YearModel { get; set; }
        public Motorcycle()
        {
            Type = TypeEnum.Motorcycle;
        }

        public override string ToString()
        {
            return base.ToString() + $" Number Mirrors: {NumberMirror}" +
                $"\n\tModel Year: {YearModel}";
        }
    }
}