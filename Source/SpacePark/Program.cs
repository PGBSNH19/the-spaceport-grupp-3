using RestSharp;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace SpacePark
{

    class Program
    {
        public static bool IsValidPerson(string name)
        {
            var response = CallToApi(($"people/?search={name}"));
            foreach (var p in response.Data.results)
            {
                if (p.Name == name)
                {
                    Console.WriteLine(p.Name+ p.Starships[0]);
                    return true;
                }
            }
            return false;

        }
        public static IRestResponse<Result> CallToApi(string input)
        {
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest(input, DataFormat.Json);
            var apiResponse = client.Get<Result>(request);
            return apiResponse;
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
            IsValidPerson("Chewbacca");
            Console.ReadLine();
        }

    }

    public class Result
    {
        
        public List<Person> results { get; set; }
    }
}

