using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {

    class ViewHandler {

        private Members _members;
        public ViewHandler(Members members) {
            this._members = members;
        }
        public void Options(){
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
                    _members.ListCompact();
                }

                if (value == 2)
                {
                    _members.ListVerbose();
                }

                if (value == 3)
                {
                    _members.AddMember();
                }
                if (value == 4)
                {
                   _members.DeleteMember();
                }
                if (value == 5)
                {
                    _members.ViewMember();
                }
            } while (value != 0);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Application Terminated.");
            Console.ResetColor();
        }
    }

}