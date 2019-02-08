using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    class Setup
    {
        public static int Floors()
        {
            string floorsPrompt = "Please indicate the total number of floors: ";
            int floorsResult = Utilities.GetPositiveIntInput(floorsPrompt);
            return floorsResult;
        }

        public static int Lifts()
        {
            string liftsPrompt = "Please indicate the total number of lifts: ";
            int liftsResult = Utilities.GetPositiveIntInput(liftsPrompt);
            return liftsResult;
        }
    }
}
