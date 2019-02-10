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
        public int MaxWeight = 700;

        public Lift (int id, bool active, int currentFloor, int direction, int maxWeight)
        {
            this.ID = id;
            this.Active = active;
            this.CurrentFloor = currentFloor;
            this.Direction = direction;
            this.MaxWeight = maxWeight;
        }

    }
}
