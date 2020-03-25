using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpacePark;
using SpacePark.DatabaseModels;
using System.Linq;

namespace SpaceParkTester2
{
    [TestClass]
    public class ParkingEngineTester
    {
        [TestMethod]
        public void IsValidPerson_ValidInput_True()
        {
            var IsValid = ParkingEngine.IsValidPerson("Luke Skywalker");

            Assert.IsTrue(IsValid);

        }

        [TestMethod]
        public void IsValidPerson_InvalidInput_False()
        {
            var IsValid = ParkingEngine.IsValidPerson("Benjamin Ytterström");

            Assert.IsFalse(IsValid);
        }


        [TestMethod]
        public void ParkShip_ReadWriteToDBValidPerson_True()
        {
            var park = new ParkingEngine();

            var person = new Person
            {
                Name = "TrädgårdsLasse",
                CurrentShip = new SpaceShip
                {
                    Name = "DestroyerX2000",
                    Length = "200"
                }
            };

            park.ParkShip(person);

            var context = new SpaceParkContext();
            var query = context.SpaceShips.FirstOrDefault();


            Assert.IsTrue(query.Name == "DestroyerX2000");
            Assert.IsTrue(query.Length == "200");
        }



    }
}
