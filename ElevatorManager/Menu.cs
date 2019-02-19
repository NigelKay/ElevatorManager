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
            Console.WriteLine("2. System status");
            Console.WriteLine("3. Maintainence mode");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
        }

        public static int Action()
        {
            int menuChoice = UserInput.GetMenuInput();
            return menuChoice;
        }

        //Call elevator
        public static String[][] CallElevator(List<Lift> allLifts, String[][] buildingStructure, int totalFloors, int totalLifts)
        {
            bool logicalInput = false;
            int personCurrentFloor = 0;
            int personCalledFloor = 0;

            //Prevent pushing the same floor button
            while (!logicalInput)
            {
                personCurrentFloor = UserInput.CurrentFloorInput(totalFloors);
                personCalledFloor = UserInput.DesiredFloorInput(totalFloors);

                if (personCurrentFloor == personCalledFloor)
                {
                    Console.WriteLine();
                    Console.WriteLine("That makes no sense..");
                    Console.WriteLine();
                }
                else
                {
                    logicalInput = true;
                }
            }

            Console.Clear();

            //Select best lift for action
            Lift.CalculateDistancesToCalledFloor(allLifts, personCurrentFloor, personCalledFloor, totalFloors);
            int closestLift = Lift.ChooseLift(allLifts);

            //Temp store direction to override natural movement.
            int tempDirectionOverride = Utilities.GetTempDirectionOverride(allLifts, closestLift);

            Lift.NaturalLiftMovement(allLifts, buildingStructure, totalFloors);
            Lift.NaturalPeopleMovement(allLifts);
            
            //Set floor and direction from user action and adjust markers
            buildingStructure[allLifts[closestLift].CurrentFloor][allLifts[closestLift].ID] = "[ ] ";
            Utilities.SetNewDirection(allLifts[closestLift], tempDirectionOverride);
            Utilities.SetNewFloor(allLifts[closestLift], personCalledFloor);           
            buildingStructure = Lift.LinkLifts(allLifts, buildingStructure, totalFloors, totalLifts);
            Building.Display(buildingStructure, totalFloors, totalLifts);

            Console.WriteLine();
            Console.WriteLine("You get in lift {0} and exit at floor {1}.", closestLift + 1, personCalledFloor);

            return buildingStructure;
        }

        //View status
        public static void Status(List<Lift> allLifts)
        {
            foreach (var liftInstance in allLifts)
            {
                String direction = liftInstance.Direction == 1 ? "Up" : "Down";
                String statusCurrentFloor = liftInstance.CurrentFloor == 0 ? "G" : liftInstance.CurrentFloor.ToString();

                Console.WriteLine("Lift: "+ (liftInstance.ID + 1));
                Console.WriteLine("Active: "+liftInstance.Active);               
                Console.WriteLine("Current floor: "+statusCurrentFloor);
                Console.WriteLine("Direction: "+direction);
                Console.WriteLine("Max Floor: "+liftInstance.MaxFloor);
                Console.WriteLine("Current weight in lift: {0}Kg / {1}Kg",liftInstance.CurrentWeightKG, liftInstance.MaxWeightKG);
                Console.WriteLine();
            }
        }

        //Maintainence mode
        public static String[][] MaintainenceMode(String[][] buildingStructure, int totalFloors, int totalLifts, List<Lift> allLifts)
        {
            int chosenLift = UserInput.SelectedLiftInput(totalLifts);
            Utilities.SwitchMaintainenceMode(allLifts[chosenLift]);
            if (!allLifts[chosenLift].Active)
            {               
                Console.WriteLine("Lift {0} has been set to maintainence mode.", (chosenLift + 1));
                //Fill maintainence mode lifts with X's
                for (int i = 0; i < totalFloors; i++)
                {
                    buildingStructure[i][chosenLift] = "[X] ";
                }
            }
            else
            {
                Console.WriteLine("Lift {0} has returned to normal service.", (chosenLift + 1));
                //clear maintainence mode X's
                for (int i = 0; i < totalFloors; i++)
                {
                    buildingStructure[i][chosenLift] = "[ ] ";
                }
            }
            return buildingStructure;
        }
    }
}
