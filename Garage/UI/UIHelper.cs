using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class UIHelper
    {
        //re-usable frequently variables.
        static string requestedInput;
        public static void PrintSuccessfullAddedVehicle()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vehicle successfully parked in the Garage.");
            Console.ResetColor();
        }
        public static void PrintBackOption()
        {
            Console.Write("\n<< Press ENTER to return to Main Menu >>");
        }
        public static void PrintNotValidOption()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not a valid option. Please try again.");
            Console.ResetColor();
        }
        public static void PrintTypeSelection()
        {
            Console.Write("Please make your selection: ");
        }
        public static int MakeAndValidateSelection(int min, int max)
        {
            while (true)
            {
                PrintTypeSelection();
                requestedInput = Console.ReadLine();
                if ((int.TryParse(requestedInput, out int option)) && option >= min && option <= max)
                    return option;

                PrintNotValidOption();
            }
        }
        public static Car.BrandEnum AskBrandEnum()
        {
            int count = 0;
            Console.WriteLine("\nWhat Brand is your Car?");
            foreach (Car.BrandEnum brand in Enum.GetValues(typeof(Car.BrandEnum)))
            {
                count++;
                Console.Write("[" + count + "] ");
                Console.WriteLine(brand);
            }
            while (true)
            {
                PrintTypeSelection();
                requestedInput = Console.ReadLine();
                if ((int.TryParse(requestedInput, out int option)) && option > 0 && option <= 6)
                    return (Car.BrandEnum)option;

                PrintNotValidOption();
            }
        }
        public static Truck.LoadedWithEnum AskLoadedWith()
        {
            int count = 0;
            Console.WriteLine("\nWhat is your Truck loaded with?");
            foreach (Truck.LoadedWithEnum load in Enum.GetValues(typeof(Truck.LoadedWithEnum)))
            {
                count++;
                Console.Write($"[{ count}] ");
                Console.WriteLine(load);
            }
            while (true)
            {
                PrintTypeSelection();
                requestedInput = Console.ReadLine();
                if ((int.TryParse(requestedInput, out int option)) && option > 0 && option <= 4)
                    return (Truck.LoadedWithEnum)option;

                PrintNotValidOption();
            }
        }
        public static string AskYesNo()
        {
            while (true)
            {
                Console.WriteLine("[Y] Yes" +
                "\n[N] No");
                PrintTypeSelection();
                requestedInput = Console.ReadLine().ToLower().Trim();
                if (requestedInput == "y" || requestedInput == "yes")
                {
                    requestedInput = "Yes";
                    return requestedInput;
                }
                else if (requestedInput == "n" || requestedInput == "no")
                {
                    requestedInput = "No";
                    return requestedInput;
                }
                PrintNotValidOption();
            }

        }
        public static Vehicle.NumberWheelEnum AskWheel()
        {
            int count = 0;
            Console.WriteLine("\nHow many Wheels does your Vehicle have?");
            foreach (Vehicle.NumberWheelEnum wheel in Enum.GetValues(typeof(Vehicle.NumberWheelEnum)))
            {
                count++;
                Console.Write($"[{ count}] ");
                Console.WriteLine(wheel);
            }
            while (true)
            {
                PrintTypeSelection();
                requestedInput = Console.ReadLine();
                if ((int.TryParse(requestedInput, out int option)) && option > 0 && option <= 4)
                    return (Vehicle.NumberWheelEnum)option;

                PrintNotValidOption();
            }
        }
        public static string AskLicenceNumber()
        {
            while (true)
            {
                Console.Write("\nType your LicenceNumber [ABC123]: ");
                const int MaxLength = 6;
                requestedInput = Console.ReadLine().ToUpper().Trim();
                if (requestedInput.Length == MaxLength) return requestedInput;

                PrintNotValidOption();
            }
        }
        public static Vehicle.ColorEnum AskColor()
        {
            int count = 0;
            Console.WriteLine("\nWhat is the Color of your Vehicle?");
            foreach (Vehicle.ColorEnum color in Enum.GetValues(typeof(Vehicle.ColorEnum)))
            {
                count++;
                Console.Write("[" + count + "] ");
                Console.WriteLine(color);
            }
            while (true)
            {
                PrintTypeSelection();
                requestedInput = Console.ReadLine();
                if ((int.TryParse(requestedInput, out int option)) && option > 0 && option <= 5)
                    return (Vehicle.ColorEnum)option;
                //int.TryParse(Console.ReadLine(), out int requestedInput);
                //if (requestedInput == 1) return Vehicle.ColorEnum.Black;
                //else if (requestedInput == 2) return Vehicle.ColorEnum.Blue;
                //else if (requestedInput == 3) return Vehicle.ColorEnum.Green;
                //else if (requestedInput == 4) return Vehicle.ColorEnum.Red;
                //else if (requestedInput == 5) return Vehicle.ColorEnum.White;

                PrintNotValidOption();
            }
        }
        public static Vehicle.TypeEnum AskType()
        {
            int count = -1;
            Console.WriteLine("\nWhat is the Type of your Vehicle?");
            foreach (Vehicle.TypeEnum type in Enum.GetValues(typeof(Vehicle.TypeEnum)))
            {
                count++;
                Console.Write("[" + count + "] ");
                Console.WriteLine(type);
            }
            while (true)
            {
                PrintTypeSelection();
                requestedInput = Console.ReadLine();
                if ((int.TryParse(requestedInput, out int option)) && option > 0 && option <= 5)
                    return (Vehicle.TypeEnum)option;

                PrintNotValidOption();
            }
        }
        public static Vehicle.FuelEnum AskFuel()
        {
            int count = 0;
            Console.WriteLine("\nWhat type of Fuel do you use?");
            foreach (Vehicle.FuelEnum fuel in Enum.GetValues(typeof(Vehicle.FuelEnum)))
            {
                count++;
                Console.Write("[" + count + "] ");
                Console.WriteLine(fuel);
            }
            while (true)
            {
                PrintTypeSelection();
                int.TryParse(Console.ReadLine(), out int requestedInput);
                if (requestedInput == 1) return Vehicle.FuelEnum.Gas;
                else if (requestedInput == 2) return Vehicle.FuelEnum.Electric;
                else if (requestedInput == 3) return Vehicle.FuelEnum.Legs;

                PrintNotValidOption();
            }
        }
        public static decimal AskTruckLength()
        {
            while (true)
            {
                Console.WriteLine("\nWhat is the Length of your Truck in metre? [1 - 99.9]");
                const int MaxLength = 4;
                const int MinLength = 1;
                requestedInput = Console.ReadLine().Trim();
                decimal input = 0;
                if (requestedInput.Length <= MaxLength && requestedInput.Length >= MinLength)
                {
                    if (decimal.TryParse(requestedInput, out input))
                    {
                        return decimal.Parse(requestedInput);
                    }
                }
                else
                {
                    PrintNotValidOption();
                }
            }
        }
        public static int AskYearModel()
        {
            while (true)
            {
                Console.WriteLine("\nModel Year? [1990 - 2022]");
                const int MaxLength = 4;
                const int MinYear = 1990;
                requestedInput = Console.ReadLine().ToLower().Trim();
                if(requestedInput.Length == MaxLength)                  //Check if input is exactly 4 characters
                {
                    if (int.Parse(requestedInput) >= MinYear)           //Then check if it's bigger or equal to 1990
                        return int.Parse(requestedInput);               //If true, return
                }
                PrintNotValidOption();
            }
 
        }
        
    }
}
