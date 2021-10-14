using System;
using System.Collections.Generic;

namespace Garage
{
    public static class UI
    {
        public static void Header()
        {
            string header = @"
   ___   ___  ____   ___    ___   ____     __  __ ___  ___ __ __ __     ___  ______   ___   ____ 
  // \\ // \\ || \\ // \\  // \\ ||       (( \ || ||\\//|| || || ||    // \\ | || |  // \\  || \\
 (( ___ ||=|| ||_// ||=|| (( ___ ||==      \\  || || \/ || || || ||    ||=||   ||   ((   )) ||_//
  \\_|| || || || \\ || ||  \\_|| ||___    \_)) || ||    || \\_// ||__| || ||   ||    \\_//  || \\
                                                                                                 ";
            Console.WriteLine(header);
        }

        public static void Intro()
        {
            Header();
            Console.WriteLine("\n\tWelcome to Garage Simulator 2021!");
        }
        public static bool AskLoadGarage()
        {
            int option;
            while (true)
            {
                Console.WriteLine(
                    "\nDo you want to\n" +
                    "[1] Create a brand new Garage (This will overwrite any previously saved Garage)\n" +
                    "[2] Load the last Garage");
                UIHelper.PrintTypeSelection();
                string input = Console.ReadLine();
                if (int.TryParse(input, out option) && option > 0 && option <= 2) break; //Break if valid selection
                Console.WriteLine("Not a valid option.Please try again.");
            }
            if (option == 1) return false;
            return true;
        }
        public static int AskGarageSize()
        {
            Console.WriteLine("How many parking spaces will this garage have?");
            Console.Write("Please insert a number. Minimum 10: ");
            string input;
            int option;
            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out option) && option >= 1)
                    return option;                                      //Change back to minimum 10 when complete
                Console.WriteLine("Not a valid option.Please try again. Minimum 10.");
            }
        }
        //----------------------------------------
        public static int PrintMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Header();
                Console.WriteLine("\n -- Main menu --");
                Console.WriteLine("1. List all vehicles parked in the garage.");
                Console.WriteLine("2. Add vehicle to garage");
                Console.WriteLine("3. Remove vehicle from garage");
                Console.WriteLine("4. Search for vehicles.");
                Console.WriteLine("5. Exit Program.");

                UIHelper.PrintTypeSelection();
                //int option;

                string input = Console.ReadLine();
                if ((int.TryParse(input, out int option)) && option > 0 && option <= 5)
                    return option;
                Console.WriteLine("Not a valid option. Please try again.");
            }
        }
        public static void ListVehicles(List<Vehicle> vehicles)
        {
            Console.Clear();
            Header();
            Console.WriteLine("All Vehicles Parked in the Garage:");
            int i = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                i++;
                Console.WriteLine($"{i}. {vehicle}");
            }
            Console.Write("\n<< Press ENTER to return to Main Menu >>");
            Console.ReadLine();
        }

        public static Vehicle AddVehicle()
        {
            Console.Clear();
            Header();
            Console.WriteLine("Choose a Vehicle-Type to the park in the garage.");
            Console.WriteLine("[1] Bicycle" +
                "\n[2] Motorcycle" +
                "\n[3] Car" +
                "\n[4] Bus" +
                "\n[5] Truck");
            UIHelper.PrintTypeSelection();
            int.TryParse(Console.ReadLine(), out int userInput);
            switch (userInput)
            {
                case (int)Vehicle.TypeEnum.Bicycle:
                    Bicycle addBicycle = new()
                    {
                        Color = UIHelper.AskColor(),
                        Fuel = UIHelper.AskFuel(),
                        //LicenceNumber = UI.LicenceNumber(),               //Bicycle doesn't have licence number
                        NumberWheel = UIHelper.AskWheel()
                    };
                    Console.WriteLine("\nIs it a mountain bike?");
                    addBicycle.IsMountainBike = UIHelper.AskYesNo();
                    Console.WriteLine("\nIs suitable for kids?");
                    addBicycle.SuitsKids = UIHelper.AskYesNo();
                    return addBicycle;

                case (int)Vehicle.TypeEnum.Motorcycle:

                    Motorcycle addMotorcycle = new()
                    {
                        Color = UIHelper.AskColor(),
                        Fuel = UIHelper.AskFuel(),
                        LicenceNumber = UIHelper.AskLicenceNumber(),
                        NumberWheel = UIHelper.AskWheel(),
                        YearModel = UIHelper.AskYearModel()
                    };

                    Console.WriteLine("\nIs it Made in Sweden?");
                    addMotorcycle.MadeInSweden = UIHelper.AskYesNo();
                    return addMotorcycle;

                case (int)Vehicle.TypeEnum.Car:

                    Car addCar = new()
                    {
                        Color = UIHelper.AskColor(),
                        Fuel = UIHelper.AskFuel(),
                        LicenceNumber = UIHelper.AskLicenceNumber(),
                        NumberWheel = UIHelper.AskWheel(),
                        Brand = UIHelper.AskBrandEnum()
                    };

                    Console.WriteLine("\nDoes it have more than 4 doors?");
                    addCar.Has4Doors = UIHelper.AskYesNo();
                    return addCar;

                case (int)Vehicle.TypeEnum.Bus:

                    Bus addBus = new()
                    {
                        Color = UIHelper.AskColor(),
                        Fuel = UIHelper.AskFuel(),
                        LicenceNumber = UIHelper.AskLicenceNumber(),
                        NumberWheel = UIHelper.AskWheel()
                    };

                    Console.WriteLine("\nIs Capacity more than 30?");
                    addBus.PassengerCapacity = UIHelper.AskYesNo();
                    Console.WriteLine("\nIs it a school bus?");
                    addBus.SchoolBus = UIHelper.AskYesNo();
                    return addBus;

                case (int)Vehicle.TypeEnum.Truck:

                    Truck addTruck = new()
                    {
                        Color = UIHelper.AskColor(),
                        Fuel = UIHelper.AskFuel(),
                        LicenceNumber = UIHelper.AskLicenceNumber(),
                        NumberWheel = UIHelper.AskWheel(),                    //int
                        LoadedWith = UIHelper.AskLoadedWith(),
                        TruckLenght = UIHelper.AskTruckLength()
                    };

                    return addTruck;
                default:
                    return null;
            }
        }
        public static Vehicle RemoveVehicle(List<Vehicle> vehicles)
        {
            Console.Clear();
            Header();
            Console.WriteLine("Remove a vehicle from the garage.");
            int index = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                index++;
                Console.WriteLine($"{index}. {vehicle}");
            }
            Console.Write("Enter a number of which Vehicle you would like to remove: ");
            int.TryParse(Console.ReadLine(), out int userInput);
            //if (!userInput >= 1)
            {
                return vehicles[userInput - 1];                             //userinput[1] minus 1 = userinput [0] to access index 0
            }

        }
        public static (string, string) SearchMenu(List<Vehicle> vehicles)
        {
            int option;
            while(true)
            {
                Console.WriteLine("" +
                    "-- Vehicle Search Menu --\n" +
                    "Possible search options:\n" +
                    "[1] Vehicle Type\n" +
                    "[2] Color\n" +
                    "[3] Licence Number\n" +
                    "[4] Fuel Type\n"
                    );

                UIHelper.PrintTypeSelection();
                string input = Console.ReadLine();
                if (int.TryParse(input, out option) && option > 0 && option <= 4) break; //Break if valid selection
                Console.WriteLine("Please try again, only positive numbers accepted.");
            }
            
            switch(option)
            {
                case 1:
                    Console.WriteLine("Please type which vehicle type to search for:");
                    return ("Type", Console.ReadLine());
                case 2:
                    //Search for Color
                    //Console.WriteLine("Please type color to search for:");
                    //UI.PrintEnumValues(Enum.GetValues(typeof(Vehicle.ColorEnum)));
                    PrintEnumValues(Enum.GetValues(typeof(Vehicle.ColorEnum)));
                    return ("Color", UIHelper.AskColor().ToString());
                case 3:
                    //Search for Licence Number
                    Console.WriteLine("Please type Licence Number to search for:");
                    return ("LicenceNumber", Console.ReadLine());
                case 4:
                   //Search for Fuel
                    Console.WriteLine("Please type Fuel Type to search for:");
                    return ("Fuel", UIHelper.AskFuel().ToString());
                default:
                    break;
            }
            //Should probably be removed:
            Console.ReadLine();

            //Dummy code, remove later
            Console.WriteLine("Please type color to search for:");
            return ("Color", Console.ReadLine());
        }
        public static void PrintHeaderText(string header)
        {
            Console.WriteLine($" -- {header} --");
        }
        public static void PrintEnumValues(Array e)
        {
            for(int i=0; i >= e.Length; i++)
            {
                Console.Write("[" + i + "] ");
                Console.WriteLine(e);
            }
        }
        //public static void ParkedVehicleCounter(List<Vehicle> vehicles)
        //{
        //    int i = 0;
        //    foreach (Vehicle vehicle in vehicles)
        //    {
        //        i++;
        //        Console.WriteLine($"{i}");
        //    }
        //}
    }
}
     

