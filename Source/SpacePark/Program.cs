using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;



namespace SpacePark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US",true);

            var p = ParkingEngine.GetPersonFromDatabase("Luke Skywalker").Result;
            Console.WriteLine(ParkingEngine.HasPersonPaid(p).Result);
            ParkingEngine.PayParking(p);
            Console.WriteLine(ParkingEngine.HasPersonPaid(p).Result);

            // Menu
            while (true)
            {
                Menu.MenuHeader();
                Menu.MenuSwitch(Menu.MenuOptions("Check in", "Check out", "Pay"));
                Console.Clear();
            }
        }

       
    }
}