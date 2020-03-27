using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



namespace SpacePark
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var p = ParkingEngine.GetPersonFromDatabase("Luke Skywalker").Result;
            Console.WriteLine(ParkingEngine.HasPersonPaid(p));
            ParkingEngine.PayParking(p);
            Console.WriteLine(ParkingEngine.HasPersonPaid(p));

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