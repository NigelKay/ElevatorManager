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

        public static int DirectionSelector(int currentFloor, int floors)
        {
            //Ensure lifts do not go through the ceiling/floor
            Random rnd = new Random();
            int direction = 0;
            if (currentFloor == 0)
            {
                direction = 1;
            }
            else if (currentFloor == floors - 1)
            {
                direction = 0;
            }
            else
            {
                direction = rnd.Next(0, 2);
            }
            return direction;
        }
    }
}
