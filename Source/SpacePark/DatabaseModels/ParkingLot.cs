using System;


namespace SpacePark
{
    class ParkingLot : IParkingLot
    {
        public int ParkingID { get; set; }
        public int Length { get; set; }
        public int? SpaceShipId { get; set; }
    }
}
