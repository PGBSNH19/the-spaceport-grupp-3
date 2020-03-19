using RestSharp;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace SpacePark
{

    class Program
    {
        static async Task<string> CreatePersonFromAPI(string name) 
        {
            if (IsValidPerson(name).Result)
            {
                var person = new Person();
                foreach (var item in results)
                {

                }

            }
            

            return peopleResponse;

        }
        static async Task<bool> IsValidPerson(string name)
        {
            
            
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest($"people/?search={name}", DataFormat.Json);
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

       }

        static void Main(string[] args)
        {
           var parking =new SpacePark().IsValidPerson(x=> x.Name == Console.ReadLine()).creat

            Console.WriteLine(IsValidPerson(tempPerson.Name).Result);
            Console.WriteLine(IsValidPerson("Fel namn").Result);



        }

    }

    public class PersonSearch
    {
        public List<Person> results { get; set; }
    }
}

