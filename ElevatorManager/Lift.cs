using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    public class Lift
    {
        public int ID { get; set; }
        public bool Active { get; set; }
        public int CurrentFloor { get; set; }
        public int Direction { get; set; }
        public int MaxFloor { get; set; }
        public int? DistanceToCalledFloor { get; set; }
        public int CurrentWeightKG { get; set; }
        public int MaxWeightKG { get; set; }
    }
}
