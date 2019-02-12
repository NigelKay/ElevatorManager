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

            Console.WriteLine();
            Menu.Display();












            Console.ReadLine();
        }
    }
}
