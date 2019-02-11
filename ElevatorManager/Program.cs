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

            buildingStructure[0][0] = "[*] ";
            building.Display(buildingStructure);
            /* POSITION TESTING CODE
            Console.Write("Floor: ");
            int newcfloor = int.Parse(Console.ReadLine());
            Console.Write("Lift: ");
            int newclift = int.Parse(Console.ReadLine());
            buildingStructure[floors - newcfloor][newclift-1] = "[*] ";
            Console.Clear();
            building.Display(buildingStructure);
            */

            //create all lifts
            List<Lift> allLifts = Lift.AllLiftsGenerator(lifts);

            //linq to access
            int directionof1 =
            (from a in allLifts
             where a.ID == 1
             select a.Direction).First();

            int directionof2 =
            (from a in allLifts
             where a.ID == 2
             select a.Direction).First();

            Console.WriteLine(directionof1);
            Console.WriteLine(directionof2);
            





            Console.ReadLine();
        }
    }
}
