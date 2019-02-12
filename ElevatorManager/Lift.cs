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
                int instanceCurrentFloor = rnd.Next(0, floors);
                allLifts.Add(new Lift {
                    ID = i,
                    Active = true,
                    CurrentFloor = instanceCurrentFloor,
                    Direction = Utilities.DirectionSelector(instanceCurrentFloor, floors),
                    MaxFloor = floors,
                    MaxWeightKG = 700
                });
            }
            //TODO: Add max floor logic
            //allLifts[lifts-1].MaxFloor = floors > 3 && lifts > 2 ? floors-3 : floors-1;
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

                if (direction == 1)
                {
                    buildingStructure[floor][i] = "[^] ";
                }
                else
                {
                    buildingStructure[floor][i] = "[v] ";
                }
            }
            return buildingStructure;
        }

        
    }
}
