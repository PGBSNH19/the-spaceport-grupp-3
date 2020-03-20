using System.Collections.Generic;

namespace SpacePark
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public List<string> Starships { get; set; }
        public SpaceShip CurentShip { get; set; }
    }
}
