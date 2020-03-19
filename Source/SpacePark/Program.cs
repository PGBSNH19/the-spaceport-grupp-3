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
            var request =  new RestRequest($"people/?search={name}", DataFormat.Json);
            var peopleResponse = client.Get<PersonSearch>(request);

            foreach (var p in peopleResponse.Data.results)
            {
                if (p.Name == name)
                {
                    
                    return true;
                }
            }
            return false;
        }

        static void CreatePersonFromAPI()
        {

        }

        static void Main(string[] args)
        {
            var tempPerson = new Person { Name="Luke Skywalker" };
            Console.WriteLine(IsValidPerson(tempPerson.Name).Result);


            Console.WriteLine(IsValidPerson("Fel namn").Result);



        }

    }

    public class PersonSearch
    {
        public List<Person> results { get; set; }
    }
}

