using System;
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
            @" ____    __    ____  _______  __        ______   ______   .___  ___.  _______    .___________.  ______           _______..______      ___       ______  _______ .______      ___      .______       __  ___",
            @" \   \  /  \  /   / |   ____||  |      /      | /  __  \  |   \/   | |   ____|   |           | /  __  \         /       ||   _  \    /   \     /      ||   ____||   _  \    /   \     |   _  \     |  |/  /",
            @"  \   \/    \/   /  |  |__   |  |     |  ,----'|  |  |  | |  \  /  | |  |__      `---|  |----`|  |  |  |       |   (----`|  |_)  |  /  ^  \   |  ,----'|  |__   |  |_)  |  /  ^  \    |  |_)  |    |  '  /",
            @"   \            /   |   __|  |  |     |  |     |  |  |  | |  |\/|  | |   __|         |  |     |  |  |  |        \   \    |   ___/  /  /_\  \  |  |     |   __|  |   ___/  /  /_\  \   |      /     |    <",
            @"    \    /\    /    |  |____ |  `----.|  `----.|  `--'  | |  |  |  | |  |____        |  |     |  `--'  |    .----)   |   |  |     /  _____  \ |  `----.|  |____ |  |     /  _____  \  |  |\  \----.|  .  \",
            @"     \__/  \__/     |_______||_______| \______| \______/  |__|  |__| |_______|       |__|      \______/     |_______/    | _|    /__/     \__\ \______||_______|| _|    /__/     \__\ | _| `._____||__|\__\"
            };

            foreach (var line in header)
            {
                Console.WriteLine(line);
            }
        }
   
        public static string MenuOptions(string optionOne, string optionTwo ,string optionThree)
        {
            Console.WriteLine("Options");
            string[] options = { optionOne, optionTwo, optionThree };

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

        // HUNGERIAN NOTATION?
        public static void MenuSwitch(string input)
        {
            string name;

            switch (input)
            {
                case "check in":
                    ParkingEngine.IsThereParkingSpaceAvailable();
                    break;
                case "check out":
                    Console.WriteLine("Enter the name of the person checking out: ");
                    name = Console.ReadLine();
                    ParkingEngine.CheckOut(ParkingEngine.GetPersonFromDatabase(name).Result);
                    break;
                case "pay":
                    Console.WriteLine("Enter the name of the person paying: ");
                    name = Console.ReadLine();
                    ParkingEngine.PayParking(ParkingEngine.GetPersonFromDatabase(name).Result);
                    break;
                default:
                    break;
            }
        }
    }
}
