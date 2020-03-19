using RestSharp;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace SpacePark
{

    class Program
    {
        static async Task<bool> IsValidPerson(string name)
        {
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest($"people/?search={name}", DataFormat.Json);
            var peopleResponse = client.Get<PersonSearch>(request);

            foreach (var p in peopleResponse.Data.results)
            {
                if (p.Name == name)
                {
                    CreatePersonFromAPI();

                    foreach (var starship in peopleResponse.Data.starships)
                    {
                        Console.WriteLine(starship);
                    }

                    CreateStarshipFromAPI();
                    return true;
                }
            }
            return false;
        }

        public static void CreateStarshipFromAPI() 
        {
            //var client = new RestClient("https://swapi.co/api/");
            //var request = new RestRequest($"people/?search=", DataFormat.Json);
            //var peopleResponse = client.Get<PersonSearch>(request);
        }

        public static void CreatePersonFromAPI()  
        {
            
        }

        static void Main(string[] args)
        {
            IsValidPerson("Luke Skywalker");
        }

    }

    public class PersonSearch
    {
        public List<string> starships { get; set; }
        public List<Person> results { get; set; }
    }
}

