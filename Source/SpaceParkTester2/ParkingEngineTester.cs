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
            var IsValid = ParkingEngine.IsValidPerson("Benjamin Ytterstr�m");

            Assert.IsFalse(IsValid);
        }
    }
}
