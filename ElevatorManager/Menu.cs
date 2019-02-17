using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    class Menu
    {
        public static void Display()
        {
            Console.WriteLine("--Menu--");
            Console.WriteLine("1. Call elevator");
            Console.WriteLine("2. System Status");
            Console.WriteLine("3. Maintainence mode");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
        }

        public static int Action()
        {
            int menuChoice = UserInput.GetMenuInput();
            return menuChoice;
        }

        public static String[][] CallElevator(List<Lift> allLifts, String[][] buildingStructure, int totalFloors, int totalLifts)
        {
            int personCurrentFloor = UserInput.CurrentFloorInput(totalFloors);
            int personCalledFloor = UserInput.DesiredFloorInput(totalFloors);

            Console.Clear();

            Lift.CalculateDistancesToCalledFloor(allLifts, personCurrentFloor, personCalledFloor, totalFloors);
            int closestLift = Lift.ChooseLift(allLifts);

            int tempDirectionOverride = Utilities.GetTempDirectionOverride(allLifts, closestLift);

            Lift.NaturalLiftMovement(allLifts, buildingStructure, totalFloors);
            
            buildingStructure[allLifts[closestLift].CurrentFloor][allLifts[closestLift].ID] = "[ ] ";
            Utilities.SetNewDirection(allLifts[closestLift], tempDirectionOverride);
            Utilities.SetNewFloor(allLifts[closestLift], personCalledFloor);           

            buildingStructure = Lift.LinkLifts(allLifts, buildingStructure, totalFloors, totalLifts);
            Building.Display(buildingStructure, totalFloors, totalLifts);

            Console.WriteLine();
            Console.WriteLine("You get in lift {0} and exit at floor {1}.", closestLift + 1, personCalledFloor);

            return buildingStructure;
            //TODO: Implement people in and out of lifts
        }


        public static void Status(List<Lift> allLifts)
        {
            foreach (var liftInstance in allLifts)
            {
                String direction = liftInstance.Direction == 1 ? "Up" : "Down";

                Console.WriteLine("Lift: "+ (liftInstance.ID + 1));
                Console.WriteLine("Active: "+liftInstance.Active);
                Console.WriteLine("Current Floor: "+liftInstance.CurrentFloor);
                Console.WriteLine("Direction: "+direction);
                Console.WriteLine("Max Floor: "+liftInstance.MaxFloor);
                Console.WriteLine();
            }
        }

        //Maintainence mode
        public static void MaintainenceMode(int totalLifts, List<Lift> allLifts)
        {
            //TODO: Add X's to void lifts.
            int chosenLift = UserInput.SelectedLiftInput(totalLifts);
            Utilities.SwitchMaintainenceMode(allLifts[chosenLift]);
            if (allLifts[chosenLift].Active)
            {
                Console.WriteLine("Lift {0} has returned to normal service.", chosenLift);
            }
            else
            {
                Console.WriteLine("Lift {0} has been set to maintainence mode.", chosenLift);
            }
        }
    }
}
