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
                input = input.ToUpper() == "G" ? "0" : input;
                var isNumeric = int.TryParse(input, out choice);
                if (isNumeric)
                {
                    if (choice > -1 && choice < (limit+1))
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid number.");
                        Console.WriteLine();
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

        public static int GetTempDirectionOverride(List<Lift> allLifts, int id)
        {
            int result = (from a in allLifts
                          where a.ID == id
                          select a.Direction).First();
            return result;
        }

        public static void SetNewFloor(Lift liftInstance, int newFloorChoice)
        {
            liftInstance.CurrentFloor = newFloorChoice;
        }

        public static void SetNewDirection(Lift liftInstance, int newDirection)
        {
            liftInstance.Direction = newDirection;
        }

        public static void SwitchMaintainenceMode(Lift liftInstance)
        {
            liftInstance.Active = liftInstance.Active ? false : true;
        }

        public static int SwitchDirection(Lift liftInstance)
        {
            return liftInstance.Direction = liftInstance.Direction == 1 ? 0 : 1;
        }        
    }
}
