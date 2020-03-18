namespace SpacePark
{
    interface IParkingLot
    {
        int Length { get; set; }
        int ParkingID { get; set; }
        int? SpaceShipId { get; set; }
    }
}