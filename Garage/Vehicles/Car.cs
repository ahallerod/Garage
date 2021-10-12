using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Car : Vehicle
    {
        public enum BrandEnum { Volvo = 1, Volkswagen, SAAB, BMW, AUDI, Porsche, }
        public BrandEnum Brand { get; set; }

        public string Has4Doors { get; set; }
        public Car()
        {
            Type = TypeEnum.Car;
        }

        public override string ToString()
        {
            return base.ToString() + $"\n\tBrand: {Brand}" +
                $"\n\tHas more than 4 doors: {Has4Doors}";      //Yes,No
        }
    }
}