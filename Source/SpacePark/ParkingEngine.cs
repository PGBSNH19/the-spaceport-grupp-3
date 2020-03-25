using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public static Person CreatePersonFromAPI(string name)
        {
            //Name = response.Data.results.Select(x => x.Name).ToString(),
            //p.Starships = response.Data.results.Select(x => x.starships).Tolist();
            
            var p = new Person();


            if (IsValidPerson(name))
            {
                var response = GetPersonData(($"people/?search={name}"));
                foreach (var person in response.Data.Results)
                {
                    if (person.Name == name)
                    {
                        p.Name = person.Name;
                        p.Starships = person.Starships;
                    }
                }
                return p;
            }
            return null;
        }

        public static SpaceShip CreateStarshipFromAPI(string url)
        {
            var p = new SpaceShip();
            var response = GetSpaceShipData(url);

            p.Name = response.Name;
            p.ShipLength = response.ShipLength;

            return p;
        }
    }
}
