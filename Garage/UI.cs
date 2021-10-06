using System;
using System.Collections.Generic;

namespace Garage
{
    public class UI
    {
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

                String input = Console.ReadLine();
                if ((int.TryParse(input, out option)) && option > 0 && option <= 4)
                    return option;

                Console.WriteLine("\nNot a valid option. Please try again.");
                Console.ReadLine();
            }
        }

        public static Vehicle AddVehicle()
        {

            Console.WriteLine("Choose a Vehicle-Type to the park in the garage.");
            Console.WriteLine("[1] Bicycle." +
                "\n[2] Motorcycle." +
                "\n[3] Car." +
                "\n[4] Bus." +
                "\n[5] Truck");
            //int userInput;
            int.TryParse(Console.ReadLine(), out int userInput);
            Vehicle returnVehicle = new();
            switch (userInput)
            {

                case (int)Vehicle.TypeEnum.Bicycle:
                    Bicycle addBicycle = new Bicycle();
                    Console.WriteLine("What is the Color of the Bicycle?");
                    addBicycle.Color = Console.ReadLine();
                    Console.WriteLine("What type of Fuel do you use?");
                    addBicycle.Fuel = Console.ReadLine();
                    Console.WriteLine("What is your Licence Number of your vehicle?");
                    addBicycle.LicenceNumber = Console.ReadLine();
                    Console.WriteLine("How many Wheels does your vehicle have?");
                    addBicycle.NumberWheel = int.Parse(Console.ReadLine());
                    Console.WriteLine("Is it a Mountain Bike?");
                    addBicycle.IsMountainBike = Console.ReadLine();
                    Console.WriteLine("Who is your vehicle suitable for?");
                    addBicycle.SuitableFor = Console.ReadLine();
                    return addBicycle;

                     case (int)Vehicle.TypeEnum.Motorcycle:
                         Motorcycle addMotorcycle = new Motorcycle();
                         Console.WriteLine("What is the Color of the Motorcycle?");
                         addMotorcycle.Color = Console.ReadLine();
                         Console.WriteLine("What type of Fuel do you use?");
                         addMotorcycle.Fuel = Console.ReadLine();
                         Console.WriteLine("What is your Licence Number?");
                         addMotorcycle.LicenceNumber = Console.ReadLine();
                         Console.WriteLine("How many Wheels does your Motorcycle have?");
                         addMotorcycle.NumberWheel = int.Parse(Console.ReadLine());
                         Console.WriteLine("How many mirrors does your Motorcycle have??");
                         addMotorcycle.NumberMirror = int.Parse(Console.ReadLine());
                         Console.WriteLine("What Model Year is your Motorcycle from?");
                         addMotorcycle.YearModel = int.Parse(Console.ReadLine());
                         return addMotorcycle;

                     case (int)Vehicle.TypeEnum.Car:
                         Car addCar = new Car();
                         Console.WriteLine("What is the Color of the Car?");
                         addCar.Color = Console.ReadLine();
                         Console.WriteLine("What type of Fuel do you use?");
                         addCar.Fuel = Console.ReadLine();
                         Console.WriteLine("What is your Licence Number?");
                         addCar.LicenceNumber = Console.ReadLine();
                         Console.WriteLine("How many Wheels does your Car have?");
                         addCar.NumberWheel = int.Parse(Console.ReadLine());
                         Console.WriteLine("What's the brand of your Car?");
                         addCar.Brand = Console.ReadLine();
                         Console.WriteLine("Whats the Model?");
                         addCar.Model = Console.ReadLine();
                         return addCar;

                     case (int)Vehicle.TypeEnum.Bus:
                         Bus addBus = new Bus();
                         Console.WriteLine("What is the Color of the Bus?");
                         addBus.Color = Console.ReadLine();
                         Console.WriteLine("What type of Fuel do you use?");
                         addBus.Fuel = Console.ReadLine();
                         Console.WriteLine("What is your Licence Number?");
                         addBus.LicenceNumber = Console.ReadLine();
                         Console.WriteLine("How many Wheels does your Bus have?");
                         addBus.NumberWheel = int.Parse(Console.ReadLine());
                         Console.WriteLine("How many passengers can fit in the Bus?");
                         addBus.PassengerCapacity = int.Parse(Console.ReadLine());
                         Console.WriteLine("Is it a school bus?");
                         addBus.SchoolBus = Console.ReadLine();
                         return addBus;

                     case (int)Vehicle.TypeEnum.Truck:
                         Truck addTruck = new Truck();
                         Console.WriteLine("What is the Color of the Truck?");
                         addTruck.Color = Console.ReadLine();
                         Console.WriteLine("What type of Fuel do you use?");
                         addTruck.Fuel = Console.ReadLine();
                         Console.WriteLine("What is your Licence Number?");
                         addTruck.LicenceNumber = Console.ReadLine();
                         Console.WriteLine("How many Wheels does your Truck have?");
                         addTruck.NumberWheel = int.Parse(Console.ReadLine());
                         Console.WriteLine("What is the length of your Truck?");
                         addTruck.TruckLenght = int.Parse(Console.ReadLine());
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
            //Funktion som raderar fordon från listan.
            int.TryParse(Console.ReadLine(), out int userInput);
            return vehicles[userInput - 1];
            //Console.WriteLine($"{userInput}. {vehicles} has been moved.");

        }

        public static void ListVehicles(List<Vehicle> vehicles)
        {
            Console.WriteLine("All vehicles parked in the garage.");
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


        public static int AskGarageSize()
        {
            Console.WriteLine("\nWelcome to Garage Simulator 2021!\n");
            Console.WriteLine("How many parking spaces does this garage have?");
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
                Console.WriteLine(
                    "-- Vehicle Search Menu --\n" +
                    "Please select search option:\n" +
                    "[1] Vehicle Type\n" +
                    "[2] Color\n" +
                    "[3] Licence Number\n" +
                    "[4] Fuel Type\n"
                    );
                
                string input = Console.ReadLine();
                if (int.TryParse(input, out option) && option > 0 && option <= 5) break; //Break if valid selection
                Console.WriteLine("Please try again, only positive numbers accepted.");
            }
            
            switch(option)
            {
                case 1:
                    break;
                case 2:
                    //Search for Color
                    Console.WriteLine("Please type color to search for:");
                    return ("Color", Console.ReadLine());
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
            Console.ReadLine();

            //Dummy code, remove later
            Console.WriteLine("Please type color to search for:");
            return ("Color", Console.ReadLine());
        }
    }
}