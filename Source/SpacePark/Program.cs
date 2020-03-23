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

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Configuration.json");
            var config = builder.Build();

             var defaultConnectionString = config.GetConnectionString("DefaultConnection");


            var spacepark = new ParkingEngine();
            var starship = spacepark.CreateStarshipFromAPI("https://swapi.co/api/starships/15/");
            Console.WriteLine(starship.ShipLength);
            Console.WriteLine(starship.Name);
        }
    }
}