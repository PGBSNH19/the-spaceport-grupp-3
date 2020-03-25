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
    }
}
