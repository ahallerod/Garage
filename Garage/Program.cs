using System;

namespace Garage
{
    class Program
    {


        static void Main(string[] args)
        {

            Garage garage = new();

            garage.MaxCapacity = UI.AskGarageSize();

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


                        break;




                }

            }

            /*
            Vehicle v1 = new();
            v1.LicenceNumber = "123";
            Vehicle v2 = new();
            v2.LicenceNumber = "456";
            g.AddVehicle(v1);
            g.AddVehicle(v2);
            g.ListVehicles();

            g.RemoveVehicle(v1);
            g.ListVehicles();
            */

        }

    }
}