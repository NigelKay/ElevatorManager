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
        public int MaxWeightKG = 700;

        //INIT
        /*public Lift (int id, bool active, int currentFloor, int direction, int maxWeightKG)
        {
            this.ID = id;
            this.Active = active;
            this.CurrentFloor = currentFloor;
            this.Direction = direction;
            this.MaxWeightKG = maxWeightKG;
        }*/

        public static List<Lift> AllLiftsGenerator(int lifts, int floors)
        {
            //Generate list of Lift instances and assigns values
            Random rnd = new Random();
            List<Lift> allLifts = new List<Lift>();
            for (int i = 0; i < lifts; i++)
            {
                int instanceCurrentFloor = rnd.Next(0, floors);
                allLifts.Add(new Lift {ID = i, Active = true, CurrentFloor = instanceCurrentFloor, Direction = Lift.DirectionSelector(instanceCurrentFloor, floors), MaxWeightKG = 700});
            }
            return allLifts;
        }

        public static String[][] LinkLifts(List<Lift> allLifts, String[][] buildingStructure, int lifts, int floors)
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

        public static int DirectionSelector(int currentFloor, int floors)
        {
            //Ensure lifts do not go through the ceiling/floor
            Random rnd = new Random();
            int direction = 0;
            if (currentFloor == 0)
            {
                direction = 1;
            }
            else if (currentFloor == floors)
            {
                direction = 0;
            }
            else
            {
                direction = rnd.Next(0, 2);
            }
            return direction;
        }
    }
}
