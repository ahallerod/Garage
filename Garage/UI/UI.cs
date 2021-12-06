using System;
using System.Collections.Generic;

namespace Garage
{
    public static class UI
    {
        public static void PrintLogo()                                          //FL
        {
            string header = @"
   ___   ___  ____   ___    ___   ____     __  __ ___  ___ __ __ __     ___  ______   ___   ____ 
  // \\ // \\ || \\ // \\  // \\ ||       (( \ || ||\\//|| || || ||    // \\ | || |  // \\  || \\
 (( ___ ||=|| ||_// ||=|| (( ___ ||==      \\  || || \/ || || || ||    ||=||   ||   ((   )) ||_//
  \\_|| || || || \\ || ||  \\_|| ||___    \_)) || ||    || \\_// ||__| || ||   ||    \\_//  || \\
                                                                                                 ";
            Console.Clear();
            Console.WriteLine(header);
        } 
        public static void Header(int parked, int max)
        {
            PrintLogo();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t\t\t {parked} Vehicles parked out of {max} parking spaces.");
            Console.ResetColor();
        }
        public static void Intro()
        {
            PrintLogo();
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
                UIHelper.PrintNotValidOption();
            }
            if (option == 1) return false;
            return true;
        }
        public static int AskGarageSize()
        {
            Console.WriteLine("\nHow many parking spaces will this garage have?");
            Console.Write("Please insert a number. Minimum 10: ");
            string input;
            int option;
            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out option) && option >= 10)
                    return option;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid option. Please try again. Minimum 10.");
                Console.ResetColor();
                UIHelper.PrintTypeSelection();
            }
        }
        public static int PrintMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n -- Main menu --");
                Console.WriteLine("[1] List all vehicles parked in the garage.");
                Console.WriteLine("[2] Add vehicle to garage");
                Console.WriteLine("[3] Remove vehicle from garage");
                Console.WriteLine("[4] Search for vehicles.");
                Console.WriteLine("[5] Save Garage and Exit Program.");

                return UIHelper.MakeAndValidateSelection(1, 5);
            }
        }
        public static void ListVehicles(List<Vehicle> vehicles)
        {
            Console.Clear();
            PrintLogo();
            Console.WriteLine("All Vehicles Parked in the Garage:");
            int i = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                i++;
                Console.WriteLine($"{i}. {vehicle}");
            }
        }
        public static Vehicle AddVehicle()
        {
            Console.Clear();
            PrintLogo();
            Console.WriteLine("Choose a Vehicle-Type to the park in the garage.");
            Console.WriteLine("[1] Bicycle" +
                "\n[2] Motorcycle" +
                "\n[3] Car" +
                "\n[4] Bus" +
                "\n[5] Truck");
            int userInput = UIHelper.MakeAndValidateSelection(1, 5);

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
                    UIHelper.PrintSuccessfullAddedVehicle();
                    UIHelper.PrintBackOption();
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
                    UIHelper.PrintSuccessfullAddedVehicle();
                    UIHelper.PrintBackOption();
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
                    UIHelper.PrintSuccessfullAddedVehicle();
                    UIHelper.PrintBackOption();
                    return addCar;

                case (int)Vehicle.TypeEnum.Bus:

                    Bus addBus = new()
                    {
                        Color = UIHelper.AskColor(),
                        Fuel = UIHelper.AskFuel(),
                        LicenceNumber = UIHelper.AskLicenceNumber(),
                        NumberWheel = UIHelper.AskWheel()
                    };
                    Console.WriteLine("\nDoes your Bus have more than 30 passenger seats?");
                    addBus.PassengerCapacity = UIHelper.AskYesNo();
                    Console.WriteLine("\nIs it a school bus?");
                    addBus.SchoolBus = UIHelper.AskYesNo();
                    UIHelper.PrintSuccessfullAddedVehicle();
                    UIHelper.PrintBackOption();
                    return addBus;

                case (int)Vehicle.TypeEnum.Truck:

                    Truck addTruck = new()
                    {
                        Color = UIHelper.AskColor(),
                        Fuel = UIHelper.AskFuel(),
                        LicenceNumber = UIHelper.AskLicenceNumber(),
                        NumberWheel = UIHelper.AskWheel(),
                        LoadedWith = UIHelper.AskLoadedWith(),
                        TruckLenght = UIHelper.AskTruckLength()
                    };
                    UIHelper.PrintSuccessfullAddedVehicle();
                    UIHelper.PrintBackOption();
                    return addTruck;
                default:
                    return null;
            }
        }
        public static Vehicle RemoveVehicle(List<Vehicle> vehicles)
        {
            Console.Clear();
            PrintLogo();
            Console.WriteLine("Remove a vehicle from the garage."); 
            int index = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                index++;
                Console.WriteLine($"{index}. {vehicle}");
            }
            Console.WriteLine("\nEnter a number of which Vehicle you would like to remove." +
                "\nOR" +
                "\nEnter [0] to Go back to Main Menu.");
            int input;
            if ((input = UIHelper.MakeAndValidateSelection(0, vehicles.Count)) == 0)
            {
                return null;
            }
            else
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully removed Vehicle from Garage.");
                Console.ResetColor();
                return vehicles[input - 1];
        }
        public static (string, string) SearchMenu(List<Vehicle> vehicles)
        {
            int option;
            while (true)
            {
                Console.WriteLine("\n" +
                    "-- Vehicle Search Menu --\n" +
                    "Possible search options:\n" +
                    "[1] Vehicle Type\n" +
                    "[2] Color\n" +
                    "[3] Licence Number\n" +
                    "[4] Fuel Type\n"
                    );

                option = UIHelper.MakeAndValidateSelection(1, 4);
                break;
            }
            switch (option)
            {
                case 1:
                    UIHelper.PrintEnumValues(Enum.GetValues(typeof(Vehicle.TypeEnum)));
                    return ("Type", UIHelper.AskType().ToString());
                case 2:
                    UIHelper.PrintEnumValues(Enum.GetValues(typeof(Vehicle.ColorEnum)));
                    return ("Color", UIHelper.AskColor().ToString());
                case 3:
                    Console.WriteLine("Please type Licence Number to search for:");
                    return ("LicenceNumber", UIHelper.AskLicenceNumber());
                case 4:
                    Console.WriteLine("Please type Fuel Type to search for:");
                    return ("Fuel", UIHelper.AskFuel().ToString());
                default:
                    break;
            }

            return ("Color", Console.ReadLine());
        }
    }
}


