using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var spacepark = new ParkingEngine();
            var starship = spacepark.CreateStarshipFromAPI("https://swapi.co/api/starships/15/");
            Console.WriteLine(starship.ShipLength);
            Console.WriteLine(starship.Name);
        }
    }
}