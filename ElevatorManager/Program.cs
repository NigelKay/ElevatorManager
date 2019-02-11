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
            buildingStructure = Building.Construct(floors, lifts);         

            //create list of Lift instances
            List<Lift> allLifts = Lift.AllLiftsGenerator(lifts, floors);
            buildingStructure = Lift.LinkLifts(allLifts, buildingStructure, lifts, floors);
            //buildingStructure[0][1] = "[X] ";
            //buildingStructure[1][3] = "[X] ";
            Building.Display(buildingStructure, floors, lifts);












            int directionof0 =
            (from a in allLifts
             where a.ID == 0
             select a.CurrentFloor).First();

            //linq to access
            int directionof1 =
            (from a in allLifts
             where a.ID == 1
             select a.CurrentFloor).First();

            int directionof2 =
            (from a in allLifts
             where a.ID == 2
             select a.CurrentFloor).First();

            int directionof3 =
            (from a in allLifts
             where a.ID == 3
             select a.CurrentFloor).First();

            int directionof4 =
            (from a in allLifts
             where a.ID == 4
             select a.CurrentFloor).First();

            Console.WriteLine(directionof0);
            Console.WriteLine(directionof1);
            Console.WriteLine(directionof2);
            Console.WriteLine(directionof3);
            Console.WriteLine(directionof4);
            





            Console.ReadLine();
        }
    }
}
