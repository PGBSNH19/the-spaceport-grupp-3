using RestSharp;
using System.Threading.Tasks;
using System;

namespace SpacePark
{

    class Program
    {
        static void Main(string[] args)
        {
           static async Task<string> getapi()
            {
                var client =  new RestClient("https://swapi.co/api/");
                var request = new RestRequest("starships", DataFormat.Json);
                var response = client.Get(request);

                Console.WriteLine(response);

                return response.ToString();
            }

            getapi();

        }
    }
}

