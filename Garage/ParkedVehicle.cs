using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class ParkedVehicle
    {
      
        Bicycle mountainBike = new Bicycle { Color = (Vehicle.ColorEnum)2, Fuel = (Vehicle.FuelEnum)3, LicenceNumber = "UDJ123", NumberWheel = (Vehicle.NumberWheelEnum)1, IsMountainBike = "Yes", SuitsKids = "No" };
        Bicycle racerBike = new Bicycle { Color = (Vehicle.ColorEnum)4, Fuel = (Vehicle.FuelEnum)3, LicenceNumber = "UEG233", NumberWheel = (Vehicle.NumberWheelEnum)1, IsMountainBike = "No", SuitsKids = "No" };

        Motorcycle vesslaMotorcycle = new Motorcycle { Color = (Vehicle.ColorEnum)3, Fuel = (Vehicle.FuelEnum)2, LicenceNumber = "HEK395", NumberWheel = (Vehicle.NumberWheelEnum)1, MadeInSweden = "Yes", YearModel = 2020 };
        Motorcycle yamahaMotorcycle = new Motorcycle { Color = (Vehicle.ColorEnum)5, Fuel = (Vehicle.FuelEnum)1, LicenceNumber = "PEW237", NumberWheel = (Vehicle.NumberWheelEnum)1, MadeInSweden = "No", YearModel = 1987 };


    }
}
