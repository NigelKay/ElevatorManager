using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    class Lift
    {
        public int ID { get; set; }
        public bool Active { get; set; }
        public int CurrentFloor { get; set; }
        public int Direction { get; set; }
        public int MaxFloor { get; set; }
        public int MaxWeightKG = 700;


        public static List<Lift> AllLiftsGenerator(int floors, int lifts)
        {
            //Generate list of Lift instances and assigns values
            Random rnd = new Random();
            List<Lift> allLifts = new List<Lift>();
            for (int i = 0; i < lifts; i++)
            {
                //Instance variables to control max floor and direction
                int instanceMaxFloor = Utilities.MaxFloorSelector(i, floors, lifts);
                int instanceCurrentFloor = rnd.Next(0, instanceMaxFloor);
                //Create values for each Lift
                allLifts.Add(new Lift {
                    ID = i,
                    Active = true,
                    CurrentFloor = instanceCurrentFloor,
                    Direction = instanceCurrentFloor == 0 ? 1 : instanceCurrentFloor == instanceMaxFloor-1 ? 0 : rnd.Next(0, 2),
                    MaxFloor = instanceMaxFloor,
                    MaxWeightKG = 700
                });
            }
            return allLifts;
        }

        public static String[][] LinkLifts(List<Lift> allLifts, String[][] buildingStructure, int floors, int lifts)
        {
            //Displays directions of lifts
            for (int i = 0; i < lifts; i++)
            {
                int floor =
            (from a in allLifts
             where a.ID == i
             select a.CurrentFloor).First();

                int direction =
            (from a in allLifts
             where a.ID == i
             select a.Direction).First();

                if (direction == 0)
                {
                    buildingStructure[floor][i] = "[v] ";
                }
                else if (direction == 1)
                {   
                    buildingStructure[floor][i] = "[^] ";
                }
            }
            return buildingStructure;
        }
    }
}
