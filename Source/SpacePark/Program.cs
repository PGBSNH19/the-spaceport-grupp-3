﻿using RestSharp;
using System.Threading.Tasks;
using System;

namespace SpacePark
{

    class Program
    {
        

         static void Main(string[] args)
        {
            var spacePark = new SpacePark();
            var temp = spacePark.IsValidPerson("Luke Skywalker");

            Console.WriteLine(temp);
            Console.ReadLine();
        }

    }
}

