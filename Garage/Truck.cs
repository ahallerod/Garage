using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Truck : Vehicle
    {
        public decimal TruckLenght { get; set; }
        public string LoadedWith { get; set; }

        public Truck()
        {
            Type = TypeEnum.Truck;
        }

        public override string ToString()
        {
            return base.ToString() + $"\n\tLength of Truck: {TruckLenght}" +
                $"\n\tLoaded with: {LoadedWith}";
        }
    }
}