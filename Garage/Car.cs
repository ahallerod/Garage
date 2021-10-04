using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Car : Vehicle
    {
        public string Brand { get; set; }

        public string Model { get; set; }
        public Car()
        {
            Type = TypeEnum.Car;
        }

        public override string ToString()
        {
            return base.ToString() + $" Brand: {Brand}" +
                $"\n\tModel: {Model}";
        }
    }
}