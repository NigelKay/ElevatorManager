using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    class Menu
    {
        /*
         * 1. Call lift
         * 2. Status
         * 3. MaintainenceMode
         * 4.
         * 5. Exit
         */

        public static void Display()
        {
            Console.WriteLine("--Menu--");
            Console.WriteLine("1. Call elevator");
            Console.WriteLine("2. System Status");
            Console.WriteLine("3. Maintainence mode");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
        }

        public static void Action()
        {
            String menuPrompt = "Enter selection: ";
            int menuChoice = Utilities.GetMenuInput(menuPrompt);

            switch (menuChoice)
            {
                //TODO: create methods and replace cw
                case 1:
                    Console.WriteLine("Chosen call elevator");
                    break;
                case 2:
                    Console.WriteLine("Chosen status");
                    break;
                case 3:
                    Console.WriteLine("Chosen Maintainence Mode");
                    break;
                case 4:
                    Console.WriteLine("Chosen to exit");
                    break;
            }
        }
    }
}
