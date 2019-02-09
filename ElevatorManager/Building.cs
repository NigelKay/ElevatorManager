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
    }

    
}
