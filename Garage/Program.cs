using System;
using System.Collections.Generic;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.Intro();
            Garage garage = new();                                          //AH

            if (FileHandler.CheckForSavedFiles() && UI.AskLoadGarage())     //option 2
                garage = FileHandler.LoadGarage();
            else
                garage.Capacity = UI.AskGarageSize();                       //option 1


            while (true)
            {
                UI.Header(garage.NumberParkedVehicles(), garage.Capacity);  //AH
                switch (UI.PrintMainMenu())                                 
                {
                    case 1:                                                 //AH
                        //List Vehicles      
                        if (garage.IsAnyVehicleParked())
                            UI.ListVehicles(garage.ListVehicles());
                        else
                            Console.WriteLine("\n\tNo Vehicles parked in the Garage.");
                            UIHelper.PrintBackOption();
                        break;
                    case 2:                                                 //FL & AH
                        //Add Vehicles
                        if (garage.NumberParkedVehicles() < garage.Capacity)
                            garage.AddVehicle(UI.AddVehicle());
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThere are no parking spaces left. It's full.");
                            Console.ResetColor();
                            UIHelper.PrintBackOption();
                        }
                        break;
                    case 3:                                                 //FL & AH
                        //Remove Vehicles
                        if (!garage.IsAnyVehicleParked())
                            Console.WriteLine("\n\tNo Vehicles parked in the Garage.");

                        Vehicle vehicle2remove = UI.RemoveVehicle(garage.ListVehicles()); //ask user for which vehicle to remove (null=user cancelled)
                        if (vehicle2remove == null)
                            break; //Break switch and return to main menu.
                        garage.RemoveVehicle(vehicle2remove);
                        UIHelper.PrintBackOption();
                        break;
                    case 4:                                                 //AH
                        //Search Vehicles
                        List<Vehicle> searchResults = new();
                        (string searchType, string searchCondition) = UI.SearchMenu(garage.ListVehicles());
                        if ((searchResults = garage.SearchVehicle(searchType, searchCondition)) != null)
                            UI.ListVehicles(searchResults);

                        else Console.WriteLine("\nNo vehicles found searching for " + searchCondition + ".");
                        UIHelper.PrintBackOption();
                        break;
                    case 5:                                                 //AH
                        //Exit Program
                        FileHandler.SaveGarage(garage);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Garage successfully saved.");
                        Console.ResetColor();
                        return;
                    default:
                        break;
                }
            }
        }
    }
}