using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpacePark
{
    public class SpacePark
    {
        public IRestResponse<PersonResult> GetPersonData(string input)
        {
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest(input, DataFormat.Json);
            var apiResponse = client.Get<PersonResult>(request);
            return apiResponse;
        }

        public IRestResponse<SpaceShipResult> GetSpaceShipData(string input)
        {
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest(input, DataFormat.Json);
            var apiResponse = client.Get<SpaceShipResult>(request);
            return apiResponse;
        }

        public bool IsValidPerson(string name)
        {
            var response = GetPersonData(($"people/?search={name}"));
            foreach (var p in response.Data.GetResults())
            {
                if (p.Name == name)
                {
                    return true;
                }
            }
            return false;

        }
        public void CreatePersonFromAPI(string name)
        {
            //Name = response.Data.results.Select(x => x.Name).ToString(),
            //p.Starships = response.Data.results.Select(x => x.starships).Tolist();
            
            var p = new Person();


            if (IsValidPerson(name))
            {
                var response = GetPersonData(($"people/?search={name}"));
                foreach (var person in response.Data.GetResults())
                {
                    if (person.Name == name)
                    {
                        p.Name = person.Name;
                        p.Starships = person.Starships;
                    }
                }

            }
        }

        public void CreateStarshipFromAPI(string url)
        {
            //Name = response.Data.results.Select(x => x.Name).ToString(),

            //var p = new SpaceShip();
            //var response = GetSpaceShipData(url);

            //foreach (var starship in response.Data.GetResults())
            //{
              
            //    //if(starship == url)
            //    //{
            //    //    p.Name = response.Data.SpaceShipResults;
            //    //    p.Length = starship.Length;

            //    //}
                

            //}

        }

    }
}
