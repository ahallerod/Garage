﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Vehicle
    {
        public enum TypeEnum { Vehicle, Bicycle, Motorcycle, Car, Bus, Truck }   //{ Vehicle{0}, Bicycle{1}, Motorcycle{2}, Car{3}, Bus{4}, Truck{5} }
        public TypeEnum Type { get; set; }
        public enum ColorEnum { Black = 1, Blue, Green, Red, White}             //Black{1}, Blue{2}, Green{3}, Red{4}, White{5}
        public ColorEnum Color { get; set; }
        public string LicenceNumber { get; set; }
        public enum NumberWheelEnum { Two = 1, Four, Six, Eight }
        public NumberWheelEnum NumberWheel { get; set; }
        public enum FuelEnum { Gas = 1, Electric, Legs };
        public FuelEnum Fuel { get; set; }

        public Vehicle()
        {
            Type = TypeEnum.Vehicle;
        }
        
        public override string ToString()
        {
            return $"-----" +
                $"\n\tType: {Type}" +
                $"\n\tColor: {Color}" +
                $"\n\tLicence Number: {LicenceNumber}" +
                $"\n\tNumber of wheels: {NumberWheel}" +
                $"\n\tFuel: {Fuel}";
        }
    }
}