using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark
{
    class Program
    {
        static void Main(string[] args)
        {
            var spacePark = new SpacePark();
            Console.WriteLine(spacePark.IsValidPerson("Luke Skywalker"));
        }
    }
}
