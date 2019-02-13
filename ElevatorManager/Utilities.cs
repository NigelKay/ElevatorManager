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

        public static int GetPositiveLimitedIntInput(string prompt, int limit)
        {
            int choice = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write(prompt);
                String input = Console.ReadLine();
                input = input == "G" ? "0" : input;
                var isNumeric = int.TryParse(input, out choice);
                if (isNumeric)
                {
                    if (choice > -1 && choice < (limit+1))
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number.");
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

        public static int MaxFloorSelector(int liftInstance, int totalFloors, int totalLifts)
        {
            //if building large enough, set last lift to have a maxfloor limit
            if (totalLifts > 2 && totalFloors > 3 && liftInstance == (totalLifts - 1))
            {
                return totalFloors - 3;               
            }
            else
            {
                return totalFloors;
            }
        }
    }
}
