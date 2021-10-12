using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Truck : Vehicle
    {
        public decimal TruckLenght { get; set; }
        public enum LoadedWithEnum { Rocks = 1, Sand, Trash, Other}
        public LoadedWithEnum LoadedWith { get; set; }

        public Truck()
        {
            Type = TypeEnum.Truck;
        }

        public override string ToString()
        {
            return base.ToString() + $"\n\tLength of Truck: {TruckLenght}m" +
                $"\n\tLoaded with: {LoadedWith}";
        }
    }
}