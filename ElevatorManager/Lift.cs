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

        public static List<Lift> AllLiftsGenerator(int lifts)
        {
            Random rnd = new Random();
            List<Lift> allLifts = new List<Lift>();
            for (int i = 1; i < lifts+1; i++)
            {
                allLifts.Add(new Lift {ID = i, Active = true, CurrentFloor = rnd.Next(0,lifts+1), Direction = rnd.Next(0, 2), MaxWeightKG = 700});
            }
            return allLifts;
        }
    }
}
