using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    class Utilities
    {
        public static int GetPositiveIntInput(string prompt)
        {
            int choice = 0;
            bool isInt = false;

            while (!isInt)
            {
                Console.Write(prompt);
                String input = Console.ReadLine();
                var isNumeric = int.TryParse(input, out choice);
                if (isNumeric)
                {
                    if (choice >= 0)
                    {
                        isInt = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a positive integer.");
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            return choice;
        }
    }
}
