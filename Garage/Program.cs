using System;

namespace Garage
{
    class Program
    {


        static void Main(string[] args)
        {

            Garage garage = new();

            garage.Capacity = UI.AskGarageSize();

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
                        UI.SearchMenu(garage.ListVehicles());
                        break;

                    case 5:
                        //Exit Program
                        return;
                }
            }
        }
    }
}