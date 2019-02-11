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
            Console.WriteLine("Welcome to Gilmond HQ!");
            int floors = Setup.Floors();
            int lifts = Setup.Lifts();
            Console.WriteLine();

            //Initialise Building
            String[][] buildingStructure = new string[floors][];
            Building building = new Building(floors, lifts);
            buildingStructure = building.Construct(floors, lifts);         

            //create list of Lift instances
            List<Lift> allLifts = Lift.AllLiftsGenerator(lifts);
            buildingStructure = Lift.LinkLifts(allLifts, buildingStructure, lifts);
            building.Display(buildingStructure);














            //linq to access
            int directionof1 =
            (from a in allLifts
             where a.ID == 1
             select a.CurrentFloor).First();

            int directionof2 =
            (from a in allLifts
             where a.ID == 2
             select a.CurrentFloor).First();

            Console.WriteLine(directionof1);
            Console.WriteLine(directionof2);
            





            Console.ReadLine();
        }
    }
}
