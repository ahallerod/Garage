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
        public string Color { get; set; }
        public string LicenceNumber { get; set; }
        public int NumberWheel { get; set; }
        //
        public enum FuelEnum {Gas = 1, Electric };
        public FuelEnum Fuel { get; set; }

        public Vehicle()
        {
            Type = TypeEnum.Vehicle;
        }

        public void askFuel()
        {
            int count = 0;
            foreach (FuelEnum f in Enum.GetValues(typeof(FuelEnum)))
            {
                count++;
                Console.Write("[" + count + "] ");
                Console.WriteLine(f);
                
            }
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