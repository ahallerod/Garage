using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Garage
    {
        
        public IEnumerable<Vehicle> ParkedVehicles { get; set; }
        public int Capacity { get; set; }

        public Garage()
        {
            ParkedVehicles = new List<Vehicle>();
            Capacity = 0;
            ParkedVehicles.Count();
        }


        public bool IsAnyVehicleParked() { return ParkedVehicles.Any(); }
        public int NumberParkedVehicles() { return ParkedVehicles.Count(); }

        public void AddVehicle(Vehicle vehicle)
        {
            ParkedVehicles = ParkedVehicles.Append(vehicle);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            ParkedVehicles = ParkedVehicles.Where(v => v.LicenceNumber != vehicle.LicenceNumber);
            //Ta bort Vehicle via LicenceNumber från Garaget.
        }

        public List<Vehicle> ListVehicles()
        {
            return ParkedVehicles.ToList();
        }

        public List<Vehicle> ListTypeOfVehicles(Vehicle.TypeEnum type)
        {
            return ParkedVehicles.Where(v => v.Type == type).ToList();
        }

        public List<Vehicle> SearchVehicle(string searchType, string searchCriteria)
        {
            switch (searchType)
            {
                case "Type":
                    return ListTypeOfVehicles((Vehicle.TypeEnum)Enum.Parse(typeof(Vehicle.TypeEnum), searchCriteria)).ToList();
                //return ListTypeOfVehicles((Vehicle.TypeEnum)Enum.Parse(typeof(Vehicle.TypeEnum), searchCriteria));
                case "Color":
                    return ParkedVehicles.Where(v => v.Color == (Vehicle.ColorEnum)Enum.Parse(typeof(Vehicle.ColorEnum), searchCriteria)).ToList();
                case "LicenceNumber":
                    return ParkedVehicles.Where(v => v.LicenceNumber.ToLower() == searchCriteria.ToLower()).ToList();
                case "Fuel":
                    return ParkedVehicles.Where(v => v.Fuel == (Vehicle.FuelEnum)Enum.Parse(typeof(Vehicle.FuelEnum), searchCriteria)).ToList();
              
            }

            return null;
        }

        public SerializationGarage ConvertGarageForSerialization()
        {
             return new SerializationGarage(this.Capacity, this.ParkedVehicles.ToList());
        }


        public void LoadGarage(SerializationGarage sg)
        {
            this.Capacity = sg.Size;
            this.ParkedVehicles = sg.ParkedVehicles;
        }

    }
}