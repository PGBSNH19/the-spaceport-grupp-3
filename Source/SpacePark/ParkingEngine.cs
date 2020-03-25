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
        

    
    }
}
