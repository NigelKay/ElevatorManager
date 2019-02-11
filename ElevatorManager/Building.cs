using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{

    class Building
    {
        public int TotalFloors { get; set; }
        public int TotalLifts { get; set; }

        public Building(int totalFloors, int totalLifts)
        {
            this.TotalFloors = totalFloors;
            this.TotalLifts = totalLifts;
        }

        public static String[][] Construct(int floors, int lifts)
        {
            //Builds the building based on user input
            String[][] result = new String[floors][];
            for (int x = 0; x < floors; x++)
            {
                result[x] = new string[lifts];
                for (int y = 0; y < lifts; y++)
                {
                    result[x][y] = "[ ] ";
                }
            }
            return result;
        }

        public static void Display(String[][] buildingStructure, int floors, int lifts)
        {
            //reverse print floors to resemble building
            for(int x = floors-1; x >= 0; x--)
            {
                int itCount = 0;
                for (int y = 0; y < lifts; y++)
                {
                    itCount++;
                    Console.Write(buildingStructure[x][y]);
                    if (itCount % lifts == 0)
                    {
                        Console.WriteLine();
                    }
                }
            }

            //Displays the building on Console
            /*foreach (String[] array in buildingStructure)
            {
                foreach (String item in array)
                {
                    Console.Write(item);
                }
                Console.Write(System.Environment.NewLine);
            }*/
        }
    }
}
