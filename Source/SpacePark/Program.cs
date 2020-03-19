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
=======
            var request = new RestRequest($"people/?search=Skywalker", DataFormat.Json);
            var peopleResponse = client.Get<Person>(request);

<<<<<<< HEAD
                Console.WriteLine(response.result[0].name.ToString());
=======
>>>>>>> f3b08a1749f6db4b8d35523271092fb16fd2fd5b
>>>>>>> 4cc84def53fbbfa85b967d7dac344451ca19f354

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

