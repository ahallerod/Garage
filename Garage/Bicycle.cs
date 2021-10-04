using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Bicycle : Vehicle
    {
        public string IsMountainBike { get; set; }

        public string SuitableFor { get; set; }

        public Bicycle()
        {
            Type = TypeEnum.Bicycle;
        }

        public override string ToString()
        {
            return base.ToString() + $"\n\tIs Mountainbike: {IsMountainBike}" +
                $"\n\tSuitable for: {SuitableFor}";
            
        }
    }
}