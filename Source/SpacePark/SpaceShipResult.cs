using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark
{
    public class SpaceShipResult
    {
        private List<SpaceShip> results { get; set; }

        public List<SpaceShip> Results;

        public List<SpaceShip> GetResults()
        {
            return results;
        }
    }
}
