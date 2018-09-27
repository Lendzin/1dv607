using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2
{
    class Program
    {
        static int Main(string[] args)
        {
            Members members = new Members();
            members.Load();

            int value;
            do
            {
                do
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Welcome to the members and boat listings, choose an OPTION:");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("0. To exit the application.");
                    Console.WriteLine("1. Show list of members (COMPACT).");
                    Console.WriteLine("2. Show list of members (VERBOSE)");
                    Console.WriteLine("3. Add a member to list.");
                    Console.WriteLine("4. Delete a member from the list.");
                    Console.WriteLine("5. View a member from the list.");
                    ConsoleKeyInfo input = Console.ReadKey(true);
                    if (char.IsDigit(input.KeyChar))
                    {
                        Int32.TryParse(input.KeyChar.ToString(), out value);
                    } else {
                        value = 6;
                    }
                } while ( value < 0 || value > 5);

                if (value == 1)
                {
                    members.ListCompact();
                }

                if (value == 2)
                {
                    members.ListVerbose();
                }

                if (value == 3)
                {
                    members.AddMember();
                }
                if (value == 4)
                {
                    members.DeleteMember();
                }
                if (value == 5)
                {
                    members.ViewMember();
                }
            } while (value != 0);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Application Terminated.");
            Console.ResetColor();
            return 0;
        }
    }
}
