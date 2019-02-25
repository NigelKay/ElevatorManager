using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    static class UserInput
    {
        public static int Floors()
        {
            string floorsPrompt = "Please indicate the total number of floors: ";
            return Utilities.GetPositiveIntInput(floorsPrompt);
        }

        public static int Lifts()
        {
            string liftsPrompt = "Please indicate the total number of lifts: ";
            return Utilities.GetPositiveIntInput(liftsPrompt);
        }

        public static int GetMenuInput()
        {
            String menuPrompt = "Enter selection: ";
            return Utilities.GetPositiveIntInput(menuPrompt, 4);
        }

        public static int CurrentFloorInput(int totalFloors)
        {
            String maxFloor = (totalFloors-1).ToString();
            String currentFloorInputPrompt = "Enter your current floor (G-"+maxFloor+"): ";
            return Utilities.GetPositiveIntInput(currentFloorInputPrompt, (totalFloors-1));
        }

        public static int DesiredFloorInput(int totalFloors)
        {
            String maxFloor = (totalFloors-1).ToString();
            String desiredFloorInputPrompt = "Enter which floor you'd like to go to (G-" + maxFloor + "): ";
            return Utilities.GetPositiveIntInput(desiredFloorInputPrompt, (totalFloors-1));
        }

        public static int SelectedLiftInput(int totalLifts)
        {
            String maxLift = totalLifts.ToString();
            String selectedLiftInputPrompt = "Please select a lift (1-" + maxLift + "): ";
            return Utilities.GetPositiveIntInput(selectedLiftInputPrompt, totalLifts) - 1;
        }

        public static String GetName()
        {
            String getNamePrompt = "Please enter your name: ";
            return Utilities.GetName(getNamePrompt);
        }

        public static bool IsEmployee()
        {
            String isEmployeePrompt = "Are you an employee or guest? (E/G): ";
            return Utilities.GetEmployeeStatus(isEmployeePrompt);
        }
    }
}
