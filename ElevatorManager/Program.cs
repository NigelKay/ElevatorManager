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

            String[][] buildingStructure = new string[floors][];
            Building building = new Building(floors, lifts);
            buildingStructure = building.Construct(floors, lifts);
            building.Display(buildingStructure);

            Console.ReadLine();

        }
    }
}
