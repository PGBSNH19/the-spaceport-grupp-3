using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var spacePark = new SpacePark();
            Console.WriteLine(spacePark.IsValidPerson("Luke Skywalker"));
        }
    }
}
