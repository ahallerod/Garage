using System;

namespace Garage
{
    class Program
    {


        static void Main(string[] args)
        {

            Garage g = new();
            Vehicle v1 = new();
            v1.LicenceNumber = 123;
            Vehicle v2 = new();
            v2.LicenceNumber = 456;
            g.AddVehicle(v1);
            g.AddVehicle(v2);
            g.ListVehicles();

            g.RemoveVehicle(v1);
            g.ListVehicles();


        }
    }
}
