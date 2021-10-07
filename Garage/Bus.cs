using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Bus : Vehicle
    {
        public string PassengerCapacity { get; set; }
        public string SchoolBus { get; set; }
        public Bus()
        {
            Type = TypeEnum.Bus;
        }

        public override string ToString()
        {
            return base.ToString() + $"\n\tPassenger Capacity 30+: {PassengerCapacity}" +       //Yes,No
                $"\n\tIs Schoolbus: {SchoolBus}";       //Yes,No
        }

    }
}