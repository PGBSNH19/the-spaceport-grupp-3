using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpacePark.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace SpacePark
{
    public class ParkingEngine
    {
        public static IRestResponse<PersonResult> GetPersonData(string input)
        {
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest(input, DataFormat.Json);
            var apiResponse = client.Get<PersonResult>(request);
            return apiResponse;
        }

        public static SpaceShip GetSpaceShipData(string input)
        {
            var client = new RestClient(input);
            var request = new RestRequest("", DataFormat.Json);
            var apiResponse = client.ExecuteAsync<SpaceShip>(request);
            apiResponse.Wait();
            //apiResponse.Result.Data.ShipLength = int.Parse(apiResponse.Result.Data.Length);
            return apiResponse.Result.Data;
        }

        public static bool IsValidPerson(string name)
        {

            // Behövs en nullcheck här  
            var response = GetPersonData(($"people/?search={name}"));
            foreach (var p in response.Data.Results)
            {
                if (p.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public async static Task<bool> IsPersonInDatabase(string name)
        {
            using (var context = new SpaceParkContext())
            {
                if (context.People.FirstOrDefault().Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public static async Task ParkShip(Person p)
        {
            ParkingLot currentSpace;

            using (var context = new SpaceParkContext())
            {
                try
                {
                    currentSpace = FindAvailableParkingSpace().Result;

                    if (int.Parse(p.CurrentShip.Length) <= currentSpace.Length)
                    {
                        context
                       .ParkingLot
                       .Where(x => x.ParkingLotID == currentSpace.ParkingLotID)
                       .FirstOrDefault()
                       .SpaceShip = p.CurrentShip;
                    }
                    else
                    {
                        Console.WriteLine("Sorry your ship is to big");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No avaialable parking spaces");
                    Thread.Sleep(2500);
                }

                context.SpaceShips.Add(p.CurrentShip);
                context.People.Add(p);
                context.SaveChanges();
            }
        }

        public static async Task ClearParkedShips()
        {
            using (var context = new SpaceParkContext())
            {
                // Vi fick inte denna att fungera an någon anledning...
                //context.Database.ExecuteSqlCommand($"TRUNCATE TABLE [dbo.{tableName}]");

                foreach (var row in context.ParkingLot)
                {
                    row.Length = 50;
                    row.SpaceShipID = null;
                }
                context.SaveChanges();
            }
        }

        public static async Task<ParkingLot> FindAvailableParkingSpace()
        {
            using (var context = new SpaceParkContext())
            {
                var parkingSpace = context.ParkingLot.FirstOrDefault(x => x.SpaceShipID == null);
                if (parkingSpace == null)
                {
                    throw new NullReferenceException();
                }
                return parkingSpace;
            }
        }

        public static async Task WriteParkingSpaceToDataBase()
        {
            using (var context = new SpaceParkContext())
            {
                for (int i = 0; i < 10; i++)
                {
                    var parkingSpace = new ParkingLot
                    {
                        Length = 50,
                        SpaceShip = null
                    };
                    context.ParkingLot.Add(parkingSpace);
                }

                context.SaveChanges();
            }
        }

        public static void CheckIn()
        {
            Console.WriteLine("");
            Console.WriteLine("Enter your name:");
            var name = Console.ReadLine();

            // If the person is in starwars and isn't in the database.
            if (ParkingEngine.IsValidPerson(name) && !IsPersonInDatabase(name).Result)
            {
                // Creates the person obejct.
                var person = Person.CreatePersonFromAPI(name);

                Console.WriteLine("Enter the number of the ship do you want to park:");

                // Prints all starships associated with person.
                int count = 0;
                foreach (var item in person.Starships)
                {
                    count++;
                    var s = ParkingEngine.GetSpaceShipData(item);

                    Console.WriteLine($"{count}.{s.Name}");
                }

                // Choise of ship.
                var shipNumber = int.Parse(Console.ReadLine());

                // Actually creates the ship object.
                var spaceShip = SpaceShip.CreateStarshipFromAPI(person.Starships[shipNumber - 1]);
                person.CurrentShip = spaceShip;

                // Adds the person and ship to the database.
                ParkingEngine.ParkShip(person);
            }

            else if (!ParkingEngine.IsValidPerson(name))
            {
                Console.WriteLine("Sorry you have to be a member of Star Wars to park here");
                Thread.Sleep(2500);
            }

            else
            {
                Console.WriteLine("You have already parked here.");
                Thread.Sleep(2500);
            }
        }

        public static async Task IsThereParkingSpaceAvailable()
        {
            try
            {
                FindAvailableParkingSpace();
                CheckIn();
            }
            catch (Exception)
            {
                Console.WriteLine("There aren't parking spaces available ");

            }
        }

        public static async Task<bool> HasPersonPaid(Person p)
        {
            using (var context = new SpaceParkContext())
            {
                var hasPaid = context
                    .People
                    .Where(x => x.Name == p.Name)
                    .FirstOrDefault().HasPaid;
                
                if (hasPaid)
                {
                    return true;
                }

                return false;
            }

        }

        public static async Task PayParking(Person p)
        {
            using (var context = new SpaceParkContext())
            {
                Console.WriteLine();

                context.People
                    .Where(x => x.Name == p.Name)
                    .FirstOrDefault()
                    .HasPaid = true;

                Console.WriteLine($"{p.CurrentShip}s pakrking has been paid.");
                Console.WriteLine();
            }
        }

        public static async Task<Person> GetPersonFromDatabase(string name)
        {
            using (var context = new SpaceParkContext())
            {
                return context.People
                     .Where(x => x.Name == name)
                     .FirstOrDefault();
            }
        }




    }
}
