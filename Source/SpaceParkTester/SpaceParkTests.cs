using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceParkTester
{
    [TestClass]
    public class SpaceParkTests
    {
        [TestMethod]
        public void IsValidPerson_ValidInput()
        {
            var spacePark = new SpacePark();
            Console.WriteLine(spacePark.IsValidPerson("Luke Skywalker"));

        }
    }
}
