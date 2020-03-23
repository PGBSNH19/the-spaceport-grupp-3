using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceParkTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsValidPerson_ValidInput_True ()
        {
            var spacePark = new SpacePark();

            var IsValid = spacePark.IsValidPerson("Luke Skywalker");

            Assert.IsTrue(IsValid);

        }

        [TestMethod]
        public void IsValidPerson_InvalidInput_False()
        {
            var spacePark = new SpacePark();

            var IsValid = spacePark.IsValidPerson("Benjamin Ytterström");

            Assert.IsTrue(IsValid);
        }
    }
}
}
