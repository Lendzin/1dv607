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
        public BoatType RetrieveBoatType(int value) {
                    if (value == 1) {
                        return BoatType.Canoe;
                    }
                    if (value == 2) {
                        return BoatType.Kayak;
                    }
                    if (value == 3) {
                        return BoatType.Sailboat;
                    }
                    if (value == 4) {
                        return BoatType.Motorsailer;
                    }
                    return BoatType.Other;
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
