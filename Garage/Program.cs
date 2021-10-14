using System;

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
                        UI.ListVehicles(garage.ListVehicles());
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
                        (string searchType, string searchCondition) = UI.SearchMenu(garage.ListVehicles());
                        UI.ListVehicles(garage.SearchVehicle(searchType, searchCondition));
                        break;
                    case 5:
                        //Exit Program
                        FileHandler.SaveGarage(garage);
                        return;
                    default:
                        break;
                }
            }
        }
    }
}