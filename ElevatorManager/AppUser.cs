using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    class AppUser
    {
        public String Name { get; set; }

        public AppUser(String name)
        {
            this.Name = name;
        }

        public virtual void Greet()
        {
            Console.WriteLine("You walk into the building");
        }

        public virtual void Farewell(TimeSpan finalTimer)
        {
            Console.WriteLine("You exit the building");
        }
    }

    class Employee : AppUser
    {
        public Employee(String name) : base(name)
        {
            this.Name = name;
        }

        public override void Greet()
        {
            Console.WriteLine("Good morning {0}, You walk into the building via the staff entrance.", Name);
        }

        public override void Farewell(TimeSpan finalTimer)
        {
            Console.WriteLine("Your working day is complete! You put in a whopping {0:hh\\:mm\\:ss} working day.\n\nAs you leave the building you say goodbye to your newest employee Nigel.", finalTimer);
        }
    }

    class Guest : AppUser
    {
        public Guest(String name) : base(name)
        {
            this.Name = name;
        }

        public override void Greet()
        {
            Console.WriteLine("Good morning {0}, You walk into the building via the guest entrance.", Name);
        }

        public override void Farewell(TimeSpan finalTimer)
        {
            Console.WriteLine("Your visit lasted {0:hh\\:mm\\:ss}.\n\nAs you leave the building you say goodbye to a friendly employee called Nigel.", finalTimer);
        }
    }
}