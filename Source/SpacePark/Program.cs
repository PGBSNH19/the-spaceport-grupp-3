﻿using RestSharp;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace SpacePark
{

    class Program
    {
        static async Task<string> getapi()
        {
            List<Person> results = new List<Person>();
            var client = new RestClient("https://swapi.co/api/");
            var request = new RestRequest($"people/?search=Skywalker", DataFormat.Json);
            var peopleResponse = client.Get<Person>(request);

<<<<<<< HEAD
                Console.WriteLine(response.result[0].name.ToString());
=======
>>>>>>> f3b08a1749f6db4b8d35523271092fb16fd2fd5b

            foreach (var p in results)
            {
                Console.WriteLine(p.Name);
            }

            return null;
        }

        static void Main(string[] args)
        {

            getapi();



        }

    }

}

