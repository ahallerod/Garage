using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Motorcycle : Vehicle                              //FL
    {
        public string MadeInSweden { get; set; }
        public int YearModel { get; set; }

        public Motorcycle()
        {
            Type = TypeEnum.Motorcycle;
        }

        public override string ToString()
        {
            return base.ToString() + $"\n\tProduced in Sweden: {MadeInSweden}" +
                $"\n\tModel Year: {YearModel}";
        }
    }
}