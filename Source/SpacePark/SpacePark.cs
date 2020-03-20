using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpacePark
{
    public class SpacePark
    {
        public IRestResponse<Result> CallToApi(string input)
        {
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest(input, DataFormat.Json);
            var apiResponse = client.Get<Result>(request);
            return apiResponse;
        }
        public bool IsValidPerson(string name)
        {
            var response = CallToApi(($"people/?search={name}"));
            foreach (var p in response.Data.results)
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
            
            var p = new Person();

            if (IsValidPerson(name))
            {
                var response = CallToApi(($"people/?search={name}"));
                foreach (var person in response.Data.results)
                {
                    if (person.Name == name)
                    {
                        p.Name = person.Name;
                        p.Starships = person.Starships;
                    }
                }

            }
        }

        public void CreateStarshipFromAPI()
        {
            //Name = response.Data.results.Select(x => x.Name).ToString(),

            var p = new Person();

            if (IsValidPerson(name))
            {
                var response = CallToApi(($"people/?search={name}"));
                foreach (var person in response.Data.results)
                {
                    if (person.Name == name)
                    {
                        p.Name = person.Name;
                        p.Starships = person.Starships;
                    }
                }

            }
        }

    }
}
