﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpacePark
{
    public class Menu
    {

        public static void MenuHeader()
        {
            Console.Title = "SpacePark";
            Console.ForegroundColor = ConsoleColor.Yellow;
            var header = new[]
            {
            @"                                           ____    __    ____  _______  __        ______   ______   .___  ___.  _______    .___________.  ______           _______..______      ___       ______  _______ .______      ___      .______       __  ___",
            @"                                           \   \  /  \  /   / |   ____||  |      /      | /  __  \  |   \/   | |   ____|   |           | /  __  \         /       ||   _  \    /   \     /      ||   ____||   _  \    /   \     |   _  \     |  |/  /",
            @"                                            \   \/    \/   /  |  |__   |  |     |  ,----'|  |  |  | |  \  /  | |  |__      `---|  |----`|  |  |  |       |   (----`|  |_)  |  /  ^  \   |  ,----'|  |__   |  |_)  |  /  ^  \    |  |_)  |    |  '  /",
            @"                                             \            /   |   __|  |  |     |  |     |  |  |  | |  |\/|  | |   __|         |  |     |  |  |  |        \   \    |   ___/  /  /_\  \  |  |     |   __|  |   ___/  /  /_\  \   |      /     |    <",
            @"                                              \    /\    /    |  |____ |  `----.|  `----.|  `--'  | |  |  |  | |  |____        |  |     |  `--'  |    .----)   |   |  |     /  _____  \ |  `----.|  |____ |  |     /  _____  \  |  |\  \----.|  .  \",
            @"                                               \__/  \__/     |_______||_______| \______| \______/  |__|  |__| |_______|       |__|      \______/     |_______/    | _|    /__/     \__\ \______||_______|| _|    /__/     \__\ | _| `._____||__|\__\"
            };
            foreach (var line in header)
            {
                Console.WriteLine(line);
            }
        }
        //This method make us be able to move around the menu whit the arrows. And returns the option we choose as a string.
        public static string MenuOptions(string optionone, string optiontwo ,string optionthree)
        {
            Console.WriteLine("Options");
            string[] options = { optionone, optiontwo, optionthree };

            int selected = 0;

            Console.CursorVisible = false;

            ConsoleKey? key = null;
            while (key != ConsoleKey.Enter)
            {
                if (key != null)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.CursorTop - options.Length;
                }

                for (int i = 0; i < options.Length; i++)
                {
                    var option = options[i];
                    if (i == selected)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.WriteLine("- " + option);
                    Console.ResetColor();
                }

                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, options.Length - 1);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                }
            }

            Console.CursorVisible = true;
            return options[selected].ToLower();
        }
        // a switch case for parking / checking out
        public static  void MenuSwitch(string input)
        {
            //just to check if the parking lot is full
            int parkingSpaces = 10;
            int parkingCounter = 0;

            switch (input)
            {
                case "check in":
                    if (parkingCounter < parkingSpaces)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter your name:");
                        var name = Console.ReadLine();

                        if (ParkingEngine.IsValidPerson(name))
                        {
                            var person = ParkingEngine.CreatePersonFromAPI(name);
                            Console.WriteLine("What ship do you want to park?");
                            int count=0;
                            foreach (var item in person.Starships)
                            {
                               
                                count++;
                                var s =  ParkingEngine.GetSpaceShipData(item);
                                Console.WriteLine($"{count}.{s.Name}");
                            }
                            var shipNumber=int.Parse(Console.ReadLine());

                           var spaceShip= ParkingEngine.CreateStarshipFromAPI(person.Starships[shipNumber-1]);

                           parkingCounter++;
                           
                            Console.WriteLine($"You have parked {spaceShip.Name}");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Sorry you have to be a member of Star Wars to park here");
                            Thread.Sleep(2500);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry the parking lot is full");
                    }

                    break;
                case "check out":
                    Console.WriteLine("Enter your name:");
                    string checkOutName = Console.ReadLine();
                    break;
                case "pay":
                    Console.WriteLine("");
                    break;
                default:
                    break;
            }
        }


        public static void StarShipsSwitch(string input) 
        {

        }

    }
}