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

        public static string MenuOptions(string optionOne, string optionTwo, string optionThree)
        {
            Console.WriteLine("Options");
            string[] options = { optionOne, optionTwo, optionThree };

            int selected = 0;

            Console.CursorVisible = false;

            ConsoleKey? key = null;
            //Until the user presses enter the loop will continue to run
            while (key != ConsoleKey.Enter)
            {
                
                //Keeps track of what position the cursor has 
                if (key != null)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.CursorTop - options.Length;
                }

                //Change the color at the cursor position
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

                //Moves the cursor up or down
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

            //Return the selected option as lowercase
            return options[selected].ToLower();
        }

        public static void MenuSwitch(string input)
        {
            string name;
            switch (input)
            {
                case "check in":
                    // If there are parking available, check in
                    if (ParkingEngine.FindAvailableParkingSpace().Result != null)
                    {
                        Console.WriteLine();
                        ParkingEngine.CheckIn();
                    }
                    break;
                case "check out":
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the person checking out: ");
                    name = Console.ReadLine();

                    //If the person is in the database and run check out that person
                    if (ParkingEngine.IsPersonInDatabase(name).Result)
                    {
                        ParkingEngine.CheckOut(ParkingEngine.GetPersonFromDatabase(name).Result);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Cant find person in database");
                        Thread.Sleep(2500);
                    }
                    break;
                case "pay":
                    Console.WriteLine("Enter the name of the person paying: ");
                    name = Console.ReadLine();

                    //If the person is in the database run payparking whit that person objekt
                    if (ParkingEngine.IsPersonInDatabase(name).Result)
                    {
                        ParkingEngine.PayParking(ParkingEngine.GetPersonFromDatabase(name).Result);
                    }
                    
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Cant find person in database");
                        Thread.Sleep(2500);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
