using System;
using System.Diagnostics;
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
            //Timer
            Stopwatch workTimer = new Stopwatch();
            workTimer.Start();

            //Initial input
            Console.WriteLine("Welcome to Gilmond HQ!\n");
            String userName = UserInput.GetName();
            int totalFloors = UserInput.Floors();
            int totalLifts = UserInput.Lifts();
            bool isEmployee = UserInput.IsEmployee();

            //User greeting
            if (isEmployee)
            {
                Employee user = new Employee(userName);
                Console.WriteLine();
                user.Greet();
            }
            else
            {
                Guest user = new Guest(userName);
                Console.WriteLine();
                user.Greet();
            }

            Console.WriteLine();
            Console.Write("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();

            //Initialise Building
            String[][] buildingStructure = new string[totalFloors][];
            buildingStructure = Building.Construct(totalFloors, totalLifts);         

            //Create list of Lift instances
            List<Lift> allLifts = LiftMethods.AllLiftsGenerator(totalFloors, totalLifts);
            buildingStructure = LiftMethods.LinkLifts(allLifts, buildingStructure, totalFloors, totalLifts);
            Building.Display(buildingStructure, totalFloors, totalLifts);

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
                            buildingStructure = Menu.CallElevator(allLifts, buildingStructure, totalFloors, totalLifts);
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
                        buildingStructure = Menu.MaintainenceMode(buildingStructure, totalFloors, totalLifts, allLifts);
                        break;
                    case 4:
                        //Exit program
                        isWorkingDay = false;
                        break;
                }
                Console.WriteLine();
                Console.Write("Press any key to continue.");
                Console.ReadKey();
                //Update display
                Console.Clear();
                buildingStructure = LiftMethods.LinkLifts(allLifts, buildingStructure, totalFloors, totalLifts);
                Building.Display(buildingStructure, totalFloors, totalLifts);

            }
            //Subtle subliminal messaging
            workTimer.Stop();
            var finalTimer = workTimer.Elapsed;

            //User farewell
            if (isEmployee)
            {
                Employee user = new Employee(userName);
                Console.WriteLine();
                user.Farewell(finalTimer);
            }
            else
            {
                Guest user = new Guest(userName);
                Console.WriteLine();
                user.Farewell(finalTimer);
            }
            Console.ReadLine();
        }
    }
}
