﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    class UserInput
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

        public static int GetMenuInput()
        {
            String menuPrompt = "Enter selection: ";
            int menuChoiceResult = Utilities.GetPositiveLimitedIntInput(menuPrompt, 4);
            return menuChoiceResult;
        }

        public static int CurrentFloorInput(int totalFloors)
        {
            String maxFloor = (totalFloors-1).ToString();
            String currentFloorInputPrompt = "Enter your current floor (G-"+maxFloor+"): ";
            int currentFloorInputResult = Utilities.GetPositiveLimitedIntInput(currentFloorInputPrompt, totalFloors);
            return currentFloorInputResult;
        }

        public static int DesiredFloorInput(int totalFloors)
        {
            String maxFloor = (totalFloors-1).ToString();
            String desiredFloorInputPrompt = "Enter which floor you'd like to go to (G-" + maxFloor + "): ";
            int desiredFloorInputResult = Utilities.GetPositiveLimitedIntInput(desiredFloorInputPrompt, totalFloors);
            return desiredFloorInputResult;
        }
    }
}