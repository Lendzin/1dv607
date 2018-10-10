using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2
{

    class HelpFunctions {
        public void printOptions (List<string> options)
        {
            int count = 0;
            foreach (string option in options)
            {
                Console.WriteLine(count + ". " +option);           
                count++;
            }
        }

        public int GetValueFromUser(int options) {
                int value;
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (char.IsDigit(input.KeyChar))
                    {
                        Int32.TryParse(input.KeyChar.ToString(), out value);
                        return value;
                    } else {
                        return options;
                    }
        }
        
        public void ShowSectionText(string action) {
            ChangeColorRedAddLine();
            Console.WriteLine($"# {action} Boat Section #");
            Console.WriteLine($"To {action} boat is a permanent action!");
            ResetColorAddLine();
            Console.WriteLine($"Choose boat to {action} from the list, or type 0 to exit, then ENTER.");
            Console.WriteLine();
        }

        public void ChangeColorBlueAddLine()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        public void ChangeColorRedAddLine()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        public void ChangeColorGreenAddLine()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public void ResetColorAddLine()
        {
            Console.ResetColor();
            Console.WriteLine();
        }

        public void Pause()
        {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine();
        Console.WriteLine("** Press any key to continue!");
        Console.ResetColor();
        Console.ReadKey(true);
        Console.WriteLine();
        }

        
        public List<string> CreateBoatTypeOptions() {
            return new List<string>(new string[] {
             "to CANCEL",
             "Canoe",
             "Kayak",
             "Sail Boat",
             "Motor Sailer",
             "Other" });
        }
        public int RetrieveBoatLength() {
            int length = -1;
            do
            {   
                Console.WriteLine("Type in the boats length in meter (1-999):");
                Int32.TryParse(Console.ReadLine(), out length);
                Console.WriteLine();
            } while (length < 0 || length > 999);
            return length;
        }
    }
}
