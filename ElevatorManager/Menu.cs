using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    class Menu
    {
        /*
         * 1. Call lift
         * 2. Status
         * 3. MaintainenceMode
         * 4.
         * 5. Exit
         */

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

        public static void CallElevator(List<Lift> allLifts, int totalFloors)
        {
            int personCurrentFloor = UserInput.CurrentFloorInput(totalFloors);
            int personCalledFloor = UserInput.DesiredFloorInput(totalFloors);
            Lift.CalculateDistancesToCalledFloor(allLifts, personCurrentFloor, personCalledFloor, totalFloors);
        }

        //Call elevator
            //take input  (PERSON CURRENT FLOOR + DESIRED FLOOR)
            //assign each instance with a distance to called floor
            //LINQ to find smallest distance
            //TODO: Utilities method to assign new values

        public static void Status(List<Lift> allLifts)
        {
            foreach (var liftInstance in allLifts)
            {
                String direction = liftInstance.Direction == 1 ? "Up" : "Down";

                Console.WriteLine("Lift: "+liftInstance.ID);
                Console.WriteLine("Active: "+liftInstance.Active);
                Console.WriteLine("Current Floor: "+liftInstance.CurrentFloor);
                Console.WriteLine("Direction: "+direction);
                Console.WriteLine("Distance to floor: "+liftInstance.DistanceToCalledFloor); //TODO: Remove when done testing
                Console.WriteLine("Max Floor: "+liftInstance.MaxFloor);
                Console.WriteLine();
            }
        }

        //Maintainence mode
    }
}
