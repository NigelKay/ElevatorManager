using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    class Program
    {

        static void Main(string[] args)
        {
            //Initial input
            Console.WriteLine("Welcome to Gilmond HQ!");
            int floors = Setup.Floors();
            int lifts = Setup.Lifts();
            Console.Clear();

            //Initialise Building
            String[][] buildingStructure = new string[floors][];
            buildingStructure = Building.Construct(floors, lifts);         

            //create list of Lift instances
            List<Lift> allLifts = Lift.AllLiftsGenerator(floors, lifts);
            buildingStructure = Lift.LinkLifts(allLifts, buildingStructure, floors, lifts);
            Building.Display(buildingStructure, floors, lifts);

            bool isWorkingDay = true;

            while (isWorkingDay)
            {
                //Program loop
                Console.WriteLine();
                Menu.Display();
                int menuChoice = Menu.Action();
                Console.WriteLine();

                switch (menuChoice)
                {                   
                    case 1:
                        Menu.CallElevator(allLifts, 3, 5, floors);
                        //TODO: Create call lift method
                        break;
                    case 2:
                        Menu.Status(allLifts);
                        break;
                    case 3:
                        Console.WriteLine("Chosen Maintainence Mode");
                        //TODO: Add maintainence mode
                        //TODO: Add Utility method to take in floor numbers.
                        break;
                    case 4:                        
                        isWorkingDay = false;
                        break;
                //TODO: readkey to continue, clear screen, reprint building
                }
            //TODO: Implement next lift moves
            //TODO: Implement people in and out of lifts
            }
            //Subtle subliminal messaging
            Console.WriteLine("Your working day is complete!\nAs you leave the building you say goodbye to your newest employee Nigel.");
            Console.ReadLine();
        }
    }
}
