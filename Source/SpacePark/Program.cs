﻿using Microsoft.Extensions.Configuration;
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

            while (true)
            {
                Menu.MenuHeader();
                Menu.MenuSwitch(Menu.MenuOptions("Check in", "Check out", "Pay"));
                Console.Clear();
            }




            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Configuration.json");
            //var config = builder.Build();

            // var defaultConnectionString = config.GetConnectionString("DefaultConnection");


            //var spacepark = new ParkingEngine();
            //var starship = spacepark.IsValidPerson("Luke");
            //Console.WriteLine(starship.ShipLength);
            //Console.WriteLine(starship.Name);
        }

       
    }
}