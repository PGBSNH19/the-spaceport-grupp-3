using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark
{
    public interface IParkingLot
    {
        int Length { get; set; }
        int ParkingID { get; set; }
        int? SpaceShipId { get; set; }
    }
}