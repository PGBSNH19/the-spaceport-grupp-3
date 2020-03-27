using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



namespace SpacePark
{
    public class Program
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                Menu.MenuHeader();
                Menu.MenuSwitch(Menu.MenuOptions("Check in", "Check out", "Pay"));
                Console.Clear();
            }
        }

       
    }
}