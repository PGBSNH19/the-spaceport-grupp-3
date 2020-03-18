using System;

namespace SpacePark
{
    public interface ISpacePark
    {
        ISpacePark IsCorrectLength(Func<SpaceShip, bool> lengthCheck);
        ISpacePark IsParkingPaidFor(Func<SpaceShip, bool> paidCheck);
        ISpacePark IsThereFreeParkingSpace();
        ISpacePark IsValidPerson(Func<Person, bool> personCheck);
        ISpacePark IsValidShip(Func<SpaceShip, bool> spaceShipCheck);
        ISpacePark ParkSpaceShip(ParkingLot parkingLot);
        void RunProgram();
    }
}