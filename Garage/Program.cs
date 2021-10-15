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
                UI.Header(garage.NumberParkedVehicles(), garage.Capacity);
                switch (UI.PrintMainMenu())
                {
                    case 1:
                        //List Vehicles      
                        if (garage.IsAnyVehicleParked())
                            UI.ListVehicles(garage.ListVehicles());
                        else
                            Console.WriteLine("\n\tNo Vehicles parked in the Garage.");
                            UIHelper.PrintBackOption();
                        break;
                    case 2:
                        //Add Vehicles
                        garage.AddVehicle(UI.AddVehicle());
                        break;
                    case 3:
                        //Remove Vehicles
                        if (garage.IsAnyVehicleParked())
                            garage.RemoveVehicle(UI.RemoveVehicle(garage.ListVehicles()));
                        else
                            Console.WriteLine("\n\tNo Vehicles parked in the Garage.");
                            UIHelper.PrintBackOption();
                        //garage.RemoveVehicle(UI.RemoveVehicle(garage.ListVehicles()));            //If Garage is empty and enter Remove section, doesn't show anything and empty.
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Garage successfully saved.");
                        Console.ResetColor();
                        return;
                    default:
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}