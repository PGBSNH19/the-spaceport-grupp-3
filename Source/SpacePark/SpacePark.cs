using System;

namespace SpacePark
{
    public class SpacePark : ISpacePark
    {
        public void RunProgram()
        {

        }

        public ISpacePark IsThereFreeParkingSpace()
        {
            return this;

        }

        public ISpacePark IsValidPerson(Func<Person, bool> personCheck)
        {
            return this;
        }

        public ISpacePark IsValidShip(Func<SpaceShip, bool> spaceShipCheck)
        {
            return this;
        }
        public ISpacePark IsCorrectLength(Func<SpaceShip, bool> lengthCheck)
        {
            return this;
        }
        public ISpacePark ParkSpaceShip(ParkingLot parkingLot)
        {
            return this;
        }


        public ISpacePark IsParkingPaidFor(Func<SpaceShip, bool> paidCheck)
        {
            return this;
        }

    }
}
