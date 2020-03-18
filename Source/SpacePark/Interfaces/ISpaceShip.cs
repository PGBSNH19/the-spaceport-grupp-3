using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark
{
    public interface ISpaceShip
    {
        int SpaceShipID { get; set; }
        string Name { get; set; }
        int Length { get; set; }
    }
}
