using System;
using System.Collections.Generic;

namespace Garage
{
    class Program
    {


        static void Main(string[] args)
        {
            UI.Intro();
            Garage garage = new();

            if (FileHandler.CheckForSavedFiles() && UI.AskLoadGarage())     //option 2
                garage = FileHandler.LoadGarage();
            else
                garage.Capacity = UI.AskGarageSize();                       //option 1


            while (true)
            {
                switch (UI.PrintMainMenu())
                {
                    case 1:
                        //List Vehicles      
                        if (garage.IsAnyVehicleParked())
                            UI.ListVehicles(garage.ListVehicles());
                        else
                            Console.WriteLine("\n\tNo Vehicles parked in the Garage.");
                        break;
                    case 2:
                        //Add Vehicles
                        garage.AddVehicle(UI.AddVehicle());
                        break;
                    case 3:
                        //Remove Vehicles
                        garage.RemoveVehicle(UI.RemoveVehicle(garage.ListVehicles()));
                        break;
                    case 4:
                        //Search Vehicles
                        List<Vehicle> searchResults = new();
                        (string searchType, string searchCondition) = UI.SearchMenu(garage.ListVehicles());
                        if ((searchResults = garage.SearchVehicle(searchType, searchCondition)) != null)
                            UI.ListVehicles(searchResults);
                        else
                            Console.WriteLine("\nNo vehicles found searching for " + searchCondition + ".");
                        break;
                    case 5:
                        //Exit Program
                        FileHandler.SaveGarage(garage);
                        return;
                    default:
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}