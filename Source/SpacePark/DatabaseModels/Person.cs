using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePark
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public List<string> Starships { get; set; }
        public SpaceShip CurrentShip { get; set; }

        public static Person CreatePersonFromAPI(string name)
        {
            //Name = response.Data.results.Select(x => x.Name).ToString(),
            //p.Starships = response.Data.results.Select(x => x.starships).Tolist();

            var p = new Person();


            if (ParkingEngine.IsValidPerson(name))
            {
                var response = ParkingEngine.GetPersonData(($"people/?search={name}"));
                foreach (var person in response.Data.Results)
                {
                    if (person.Name == name)
                    {
                        p.Name = person.Name;
                        p.Starships = person.Starships;
                    }
                }
                return p;
            }
            return null;
        }
    }
}
