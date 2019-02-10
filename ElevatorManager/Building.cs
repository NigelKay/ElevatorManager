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

        public String[][] Construct(int floors, int lifts)
        {
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

        public void Display(String[][] buildingStructure)
        {
            foreach (String[] array in buildingStructure)
            {
                foreach (String item in array)
                {
                    Console.Write(item);
                }
                Console.Write(System.Environment.NewLine);
            }
        }


    } 
}
