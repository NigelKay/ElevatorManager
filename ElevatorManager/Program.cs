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
            int floors = UserInput.Floors();
            int lifts = UserInput.Lifts();
            Console.Clear();

            //Initialise Building
            String[][] buildingStructure = new string[floors][];
            buildingStructure = Building.Construct(floors, lifts);         

            //Create list of Lift instances
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
                        //Call elevator
                        try
                        {
                            buildingStructure = Menu.CallElevator(allLifts, buildingStructure, floors, lifts);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("No lifts available, please wait for one to become available.");
                        }
                        break;
                    case 2:
                        //View status
                        Menu.Status(allLifts);                     
                        break;
                    case 3:
                        //Maintainence mode
                        Console.WriteLine("Welcome to Maintainence Mode");
                        buildingStructure = Menu.MaintainenceMode(buildingStructure, floors, lifts, allLifts);
                        break;
                    case 4:
                        //Exit programme
                        isWorkingDay = false;
                        break;
                }
                Console.Write("Press any key to continue.");
                Console.ReadKey();
                //Update display
                Console.Clear();
                buildingStructure = Lift.LinkLifts(allLifts, buildingStructure, floors, lifts);
                Building.Display(buildingStructure, floors, lifts);

            }
            //Subtle subliminal messaging
            Console.WriteLine();
            Console.WriteLine("Your working day is complete!\nAs you leave the building you say goodbye to your newest employee Nigel.");
            Console.ReadLine();
        }
    }
}
