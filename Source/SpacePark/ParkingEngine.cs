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

        public static async Task IsTherParkinSpacesAvailable()
        {
            try
            {
                FindAvailableParkingSpace();
                Menu.CheckIn();
            }
            catch (Exception)
            {
                Console.WriteLine("Ther are no spaces available ");

            }
        }






    }
}
