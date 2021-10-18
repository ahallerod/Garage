using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Garage
    {

        public IEnumerable<Vehicle> ParkedVehicles { get; set; }                            //AH
        public int Capacity { get; set; }                                                   //AH

        public Garage()                                                                     //AH
        {
            ParkedVehicles = new List<Vehicle>();
            Capacity = 0;
            ParkedVehicles.Count();
        }

        public bool IsAnyVehicleParked() { return ParkedVehicles.Any(); }                   //AH
        public int NumberParkedVehicles() { return ParkedVehicles.Count(); }                //AH
        
        public void AddVehicle(Vehicle vehicle)                                             //AH
        {
            ParkedVehicles = ParkedVehicles.Append(vehicle);
        }

        public void RemoveVehicle(Vehicle vehicle)                                          //AH
        {
            ParkedVehicles = ParkedVehicles.Where(v => v.LicenceNumber != vehicle.LicenceNumber);
        }

        public List<Vehicle> ListVehicles()                                                 //AH
        {
            return ParkedVehicles.ToList();
        }

        public List<Vehicle> ListTypeOfVehicles(Vehicle.TypeEnum type)                      //AH
        {
            return ParkedVehicles.Where(v => v.Type == type).ToList();
        }
        
        public List<Vehicle> SearchVehicle(string searchType, string searchCriteria)        //AH & FL
        {
            List<Vehicle> searchResults = new();
            switch (searchType)
            {
                case "Type":
                    searchResults = ListTypeOfVehicles((Vehicle.TypeEnum)Enum.Parse(typeof(Vehicle.TypeEnum), searchCriteria)).ToList();
                    break;
                case "Color":
                    searchResults = ParkedVehicles.Where(v => v.Color == (Vehicle.ColorEnum)Enum.Parse(typeof(Vehicle.ColorEnum), searchCriteria)).ToList();
                    break;
                case "LicenceNumber":
                    searchResults = ParkedVehicles.Where(v => v.LicenceNumber.ToLower() == searchCriteria.ToLower()).ToList();
                    break;
                case "Fuel":
                    searchResults = ParkedVehicles.Where(v => v.Fuel == (Vehicle.FuelEnum)Enum.Parse(typeof(Vehicle.FuelEnum), searchCriteria)).ToList();
                    break;
            }
            if (searchResults.Any()) return searchResults;
            return null;
        }

        public SerializationGarage ConvertGarageForSerialization()                          //AH
        {
            return new SerializationGarage(this.Capacity, this.ParkedVehicles.ToList());
        }

        public void LoadGarage(SerializationGarage sg)                                      //AH
        {
            this.Capacity = sg.Size;
            this.ParkedVehicles = sg.ParkedVehicles;
        }

    }
}