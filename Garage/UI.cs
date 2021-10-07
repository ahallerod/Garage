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

        //variabel som kan återanvändas för förfrågan av user input
        static string requestedInput;
        public static void TypeOption()
        {
            Console.Write("Please type an option: ");
        }
/*
        public static void YesNo()
        {
            //Console.WriteLine("Is it a Mountain Bike?");
            //addBicycle.IsMountainBike = Console.ReadLine();
            Console.WriteLine("[Y] Yes" +
                "\n[N] No");
            UI.TypeOption();
            requestedInput = Console.ReadLine().ToLower().Trim();
            while (true)
            {
                if (requestedInput == "Y")
                {
                    Console.WriteLine("Yes saved");
                }
                else if (requestedInput == "N")
                {
                    Console.WriteLine("No saved");
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }

            }
        }
        */
        public static Vehicle.NumberWheelEnum AskWheel()
        {
            int count = 0;
            Console.WriteLine("How many Wheels does your Vehicle have?");
            foreach (Vehicle.NumberWheelEnum wheel in Enum.GetValues(typeof(Vehicle.NumberWheelEnum)))
            {
                count++;
                Console.Write($"[{ count}] ");
                Console.WriteLine(wheel);
            }
            while (true)
            {
                UI.TypeOption();
                requestedInput = Console.ReadLine();
                if ((int.TryParse(requestedInput, out int option)) && option > 0 && option <= 4)
                    return (Vehicle.NumberWheelEnum)option;

                Console.WriteLine("\nNot a valid option. Please try again.");
            }
        }
        public static string LicenceNumber()
        {
            while (true)
            {
                Console.Write("Type your LicenceNumber[AAA000]: ");
                const int MaxLength = 6;
                requestedInput = Console.ReadLine().ToUpper().Trim();
                if (requestedInput.Length == MaxLength) return requestedInput;

                Console.WriteLine("\nNot a valid option. Please try again.");
            }
        }
        public static Vehicle.ColorEnum AskColor()
        {
            int count = 0;
            Console.WriteLine("What is the Color of your Vehicle?");
            foreach (Vehicle.ColorEnum color in Enum.GetValues(typeof(Vehicle.ColorEnum)))
            {
                count++;
                Console.Write("[" + count + "] ");
                Console.WriteLine(color);
            }
            while (true)
            {
                UI.TypeOption();
                int.TryParse(Console.ReadLine(), out int requestedInput);
                if (requestedInput == 1) return Vehicle.ColorEnum.Black;
                else if (requestedInput == 2) return Vehicle.ColorEnum.Blue;
                else if (requestedInput == 3) return Vehicle.ColorEnum.Green;
                else if (requestedInput == 4) return Vehicle.ColorEnum.Red;
                else if (requestedInput == 5) return Vehicle.ColorEnum.White;
            }
        }
        public static Vehicle.FuelEnum AskFuel()
        {
            int count = 0;
            Console.WriteLine("What type of Fuel do you use?");
            foreach (Vehicle.FuelEnum fuel in Enum.GetValues(typeof(Vehicle.FuelEnum)))
            {
                count++;
                Console.Write("[" + count + "] ");
                Console.WriteLine(fuel);
            }
            while (true)
            {
                UI.TypeOption();
                int.TryParse(Console.ReadLine(), out int requestedInput);
                if (requestedInput == 1) return Vehicle.FuelEnum.Gas;
                else if (requestedInput == 2) return Vehicle.FuelEnum.Electric;
                else if (requestedInput == 3) return Vehicle.FuelEnum.Legs;
            }
        }
        public static int PrintMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n -- Main menu --");
                Console.WriteLine("1. List all vehicles parked in the garage.");
                Console.WriteLine("2. Add vehicle to garage");
                Console.WriteLine("3. Remove vehicle from garage");
                Console.WriteLine("4. Search for vehicles.");
                Console.WriteLine("5. Exit Program.");

                Console.Write("Please type a number: ");
                int option;

                string input = Console.ReadLine();
                if ((int.TryParse(input, out option)) && option > 0 && option <= 5)
                    return option;

                Console.WriteLine("\nNot a valid option. Please try again.");
            }
        }

        public static Vehicle AddVehicle()
        {
            Console.WriteLine("Choose a Vehicle-Type to the park in the garage.");
            Console.WriteLine("[1] Bicycle" +
                "\n[2] Motorcycle" +
                "\n[3] Car" +
                "\n[4] Bus" +
                "\n[5] Truck");
            UI.TypeOption();
            int.TryParse(Console.ReadLine(), out int userInput);
            Vehicle returnVehicle = new();
            switch (userInput)
            {

                case (int)Vehicle.TypeEnum.Bicycle:
                    Bicycle addBicycle = new()
                    {
                        Color = UI.AskColor(),
                        Fuel = UI.AskFuel(),
                        LicenceNumber = UI.LicenceNumber(),
                        NumberWheel = UI.AskWheel()
                    };
                    Console.WriteLine("Is it a Mountain Bike?");
                    //addBicycle.IsMountainBike = YesNo();
                    Console.WriteLine("Who is your vehicle suitable for?");
                    addBicycle.SuitableFor = Console.ReadLine();
                    return addBicycle;

                case (int)Vehicle.TypeEnum.Motorcycle:

                    Motorcycle addMotorcycle = new()
                    {
                        Color = UI.AskColor(),
                        Fuel = UI.AskFuel(),
                        LicenceNumber = UI.LicenceNumber(),
                        NumberWheel = UI.AskWheel()
                    };

                    Console.WriteLine("Is it Made in Sweden?");
                    addMotorcycle.MadeInSweden = Console.ReadLine();
                    Console.WriteLine("Model year?");
                    addMotorcycle.YearModel = int.Parse(Console.ReadLine());
                    return addMotorcycle;

                case (int)Vehicle.TypeEnum.Car:

                    Car addCar = new()
                    {
                        Color = UI.AskColor(),
                        Fuel = UI.AskFuel(),
                        LicenceNumber = UI.LicenceNumber(),
                        NumberWheel = UI.AskWheel()
                    };

                    Console.WriteLine("What's the brand of your Car?");
                    addCar.Brand = Console.ReadLine();
                    Console.WriteLine("Does it have more than 4 doors?");
                    addCar.Has4Doors = Console.ReadLine();
                    return addCar;

                case (int)Vehicle.TypeEnum.Bus:

                    Bus addBus = new()
                    {
                        Color = UI.AskColor(),
                        Fuel = UI.AskFuel(),
                        LicenceNumber = UI.LicenceNumber(),
                        NumberWheel = UI.AskWheel()
                    };

                    Console.WriteLine("How many passengers can fit in the Bus?");
                    addBus.PassengerCapacity = Console.ReadLine();
                    Console.WriteLine("Is it a school bus?");
                    addBus.SchoolBus = Console.ReadLine();
                    return addBus;

                case (int)Vehicle.TypeEnum.Truck:

                    Truck addTruck = new()
                    {
                        Color = UI.AskColor(),
                        Fuel = UI.AskFuel(),
                        LicenceNumber = UI.LicenceNumber(),
                        NumberWheel = UI.AskWheel()
                    };

                    Console.WriteLine("What is the length of your Truck?");
                    addTruck.TruckLenght = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("What is it loaded with?");
                    addTruck.LoadedWith = Console.ReadLine();
                    return addTruck;
                default:
                    return null;
            }
        }

        public static Vehicle RemoveVehicle(List<Vehicle> vehicles)
        {
            Console.WriteLine("Remove a vehicle from the garage." +
                "Choose a number to remove:");
            int index = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                index++;
                Console.WriteLine($"{index}. {vehicle}");
            }
            Console.WriteLine("Remove vehicles from the garage.");
            int.TryParse(Console.ReadLine(), out int userInput);
            return vehicles[userInput - 1];
            //Console.WriteLine($"{userInput}. {vehicles} has been moved.");

        }

        public static void ListVehicles(List<Vehicle> vehicles)
        {

            int i = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                i++;
                Console.WriteLine($"{i}. {vehicle}");
            }
            Console.ReadLine();
        }


        public static void SearchVehicles()
        {

        }

        public static void Intro()
        {
            UI.Header();
            Console.WriteLine("\n\tWelcome to Garage Simulator 2021!\n");
        }

        public static int AskGarageSize()
        {

            Console.WriteLine("How many parking spaces will this garage have?");
            string input;
            int option;
            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out option) && option >= 0) return option;
                Console.WriteLine("Please try again, only positive numbers accepted.");
            }
        }
        
        public static (string, string) SearchMenu(List<Vehicle> vehicles)
        {
            int option;
            while(true)
            {
                Console.Clear();
                Console.WriteLine("" +
                    "-- Vehicle Search Menu --\n" +
                    "Possible search options:\n" +
                    "[1] Vehicle Type\n" +
                    "[2] Color\n" +
                    "[3] Licence Number\n" +
                    "[4] Fuel Type\n"
                    );
                
                Console.WriteLine("Please make your selection: ");
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
                    Console.WriteLine("Please type color to search for:");
                    return ("Color", Console.ReadLine());
                case 3:
                    //Search for Licence Number
                    Console.WriteLine("Please type Licence Number to search for:");
                    return ("LicenceNumber", Console.ReadLine());
                case 4:
                   //Search for Licence Number
                    Console.WriteLine("Please type Licence Number to search for:");
                    return ("Fuel", Console.ReadLine());
                default:
                    break;
            }
            //Should probably be removed:
            Console.ReadLine();

            //Dummy code, remove later
            Console.WriteLine("Please type color to search for:");
            return ("Color", Console.ReadLine());
        }

        public static void PrintHeader(string header)
        {
            Console.WriteLine($" -- {header} --");
        }

        public static bool AskLoadGarage()
        {
            int option;
            while(true){
                Console.WriteLine(
                    "Do you want to\n" +
                    "[1] Create a brand new Garage (This will overwrite any previously saved Garage)\n" +
                    "[2] Load the last Garage\n");
                
                string input = Console.ReadLine();
                if (int.TryParse(input, out option) && option > 0 && option <= 2) break; //Break if valid selection
                Console.WriteLine("Please try again, not a valid selection.");
            }
            if (option == 1) return false;
            return true;
        }


    }
}
     

