using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class UIHelper
    {
        //variabel som kan återanvändas för förfrågan av user input
        static string requestedInput;

        public static void TypeOption()
        {
            Console.Write("\nPlease make your selection: ");
        }
        public static Car.BrandEnum AskBrandEnum()
        {
            int count = 0;
            Console.WriteLine("What Brand is your Car?");
            foreach (Car.BrandEnum brand in Enum.GetValues(typeof(Car.BrandEnum)))
            {
                count++;
                Console.Write("[" + count + "] ");
                Console.WriteLine(brand);
            }
            while (true)
            {
                UIHelper.TypeOption();
                requestedInput = Console.ReadLine();
                if ((int.TryParse(requestedInput, out int option)) && option > 0 && option <= 6)
                    return (Car.BrandEnum)option;
            }
        }
        public static Truck.LoadedWithEnum AskLoadedWith()
        {
            int count = 0;
            Console.WriteLine("What is your Truck loaded with?");
            foreach (Truck.LoadedWithEnum load in Enum.GetValues(typeof(Truck.LoadedWithEnum)))
            {
                count++;
                Console.Write($"[{ count}] ");
                Console.WriteLine(load);
            }
            while (true)
            {
                UIHelper.TypeOption();
                requestedInput = Console.ReadLine();
                if ((int.TryParse(requestedInput, out int option)) && option > 0 && option <= 4)
                    return (Truck.LoadedWithEnum)option;

                Console.WriteLine("\nNot a valid option. Please try again.");
            }
        }
        public static string AskYesNo()
        {
            while (true)
            {
                Console.WriteLine("[Y] Yes" +
                "\n[N] No");
                UIHelper.TypeOption();
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
            }

        }
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
                UIHelper.TypeOption();
                requestedInput = Console.ReadLine();
                if ((int.TryParse(requestedInput, out int option)) && option > 0 && option <= 4)
                    return (Vehicle.NumberWheelEnum)option;

                Console.WriteLine("\nNot a valid option. Please try again.");
            }
        }
        public static string AskLicenceNumber()
        {
            while (true)
            {
                Console.Write("Type your LicenceNumber[ABC123]: ");
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
                UIHelper.TypeOption();
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
                UIHelper.TypeOption();
                int.TryParse(Console.ReadLine(), out int requestedInput);
                if (requestedInput == 1) return Vehicle.FuelEnum.Gas;
                else if (requestedInput == 2) return Vehicle.FuelEnum.Electric;
                else if (requestedInput == 3) return Vehicle.FuelEnum.Legs;
            }
        }
        public static decimal AskTruckLength()
        {
            while (true)
            {
                Console.WriteLine("What is the Length of your Truck? [1 - 11.11]");
                const int MaxLength = 5;
                const int MinLenght = 1;
                requestedInput = Console.ReadLine().Trim();
                decimal test = 0;
                if (requestedInput.Length <= MaxLength && requestedInput.Length >= MinLenght)
                {
                    if (decimal.TryParse(requestedInput, out test))
                    {
                        return decimal.Parse(requestedInput);
                    }
                }
                else
                {
                    Console.WriteLine("\nNot a valid option. Please try again.");
                }


            }
        }
    }
}
