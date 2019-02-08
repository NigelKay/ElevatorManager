using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Gilmond HQ!");
            int floors = Setup.Floors();
            int lifts = Setup.Lifts();
            Console.WriteLine("There are {0} floors and {1} lifts!",floors, lifts);
            Console.ReadLine();
        }
    }
}
