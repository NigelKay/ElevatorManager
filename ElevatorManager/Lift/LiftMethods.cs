﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    static class LiftMethods
    {
        public static List<Lift> AllLiftsGenerator(int floors, int lifts)
        {
            //Generate list of Lift instances and assigns values
            Random rnd = new Random();
            List<Lift> allLifts = new List<Lift>();
            for (int i = 0; i < lifts; i++)
            {
                //Instance variables to control max floor and direction
                int instanceMaxFloor = Utilities.MaxFloorSelector(i, floors, lifts);
                int instanceCurrentFloor = rnd.Next(0, instanceMaxFloor);

                //Create values for each Lift
                var liftBuilder = new LiftBuilder();

                LiftBuilder newLift = liftBuilder
                    .WithID(i)
                    .IsActive(true)
                    .HasCurrentFloorOf(instanceCurrentFloor)
                    .HasDirectionOf(instanceCurrentFloor == 0 ? 1 : instanceCurrentFloor == instanceMaxFloor - 1 ? 0 : rnd.Next(0, 2))
                    .HasMaxFloorOf(instanceMaxFloor)
                    .DistanceToCalledFloor(null)
                    .HasCurrentWeightKGOf((rnd.Next(11)) * 70)
                    .HasMaxWeightKGOf(700);

                allLifts.Add(newLift);
            }
            return allLifts;
        }

        public static String[][] LinkLifts(List<Lift> allLifts, String[][] buildingStructure, int floors, int lifts)
        {
            //Displays directions of lifts
            for (int i = 0; i < lifts; i++)
            {
                int floor =
            (from lift in allLifts
             where lift.ID == i
             select lift.CurrentFloor).First();

                int direction =
            (from lift in allLifts
             where lift.ID == i
             select lift.Direction).First();

                if (direction == 0)
                {
                    buildingStructure[floor][i] = "[v] ";
                }
                else if (direction == 1)
                {
                    buildingStructure[floor][i] = "[^] ";
                }
            }
            return buildingStructure;
        }

        public static void CalculateDistancesToCalledFloor(List<Lift> allLifts, int personCurrentFloor, int personCalledFloor, int totalFloors)
        {
            foreach (var lift in allLifts)
            {
                int personCalledDirection = personCurrentFloor - personCalledFloor > 0 ? 0 : 1;
                bool movingSameDirection = lift.Direction == personCalledDirection;

                if (lift.Active && personCalledFloor <= lift.MaxFloor)
                {
                    if (movingSameDirection && lift.Direction == 1)
                    {
                        if (personCurrentFloor > lift.CurrentFloor)
                        {
                            lift.DistanceToCalledFloor = Math.Abs(personCurrentFloor - lift.CurrentFloor);
                        }
                        else if (personCurrentFloor < lift.CurrentFloor)
                        {
                            lift.DistanceToCalledFloor = (Math.Abs(lift.CurrentFloor - (totalFloors - 1)) + (totalFloors - 1) + personCurrentFloor);
                        }
                        else if (personCurrentFloor == lift.CurrentFloor)
                        {
                            lift.DistanceToCalledFloor = 0;
                        }
                    }
                    else if (movingSameDirection && lift.Direction == 0)
                    {
                        if (personCurrentFloor < lift.CurrentFloor)
                        {
                            lift.DistanceToCalledFloor = Math.Abs(personCurrentFloor - lift.CurrentFloor);
                        }
                        else if (personCurrentFloor > lift.CurrentFloor)
                        {
                            lift.DistanceToCalledFloor = (lift.CurrentFloor + (totalFloors - 1) + Math.Abs((totalFloors - 1) - personCurrentFloor));
                        }
                        else if (personCurrentFloor == lift.CurrentFloor)
                        {
                            lift.DistanceToCalledFloor = 0;
                        }
                    }
                    else if (!movingSameDirection && lift.Direction == 1)
                    {
                        lift.DistanceToCalledFloor = Math.Abs(lift.CurrentFloor - (totalFloors - 1)) + Math.Abs(personCurrentFloor - (totalFloors - 1));
                    }
                    else if (!movingSameDirection && lift.Direction == 0)
                    {
                        lift.DistanceToCalledFloor = lift.CurrentFloor + personCurrentFloor;
                    }
                }
                else
                {
                    lift.DistanceToCalledFloor = null;
                }


            }
        }

        public static int ChooseLift(List<Lift> allLifts)
        {
            int? min = (from lift in allLifts
                        where lift.DistanceToCalledFloor != null && lift.CurrentWeightKG < lift.MaxWeightKG
                        select lift.DistanceToCalledFloor).Min();

            int floor = (from lift in allLifts
                         where lift.DistanceToCalledFloor != null && lift.CurrentWeightKG < lift.MaxWeightKG && lift.DistanceToCalledFloor == min
                         select lift.ID).First();

            return floor;
        }

        public static void NaturalLiftMovement(List<Lift> allLifts, String[][] buildingStructure, int totalFloors)
        {
            Random rnd = new Random();
            foreach (var lift in allLifts)
            {
                if (lift.Active)
                {
                    if (lift.Direction == 1)
                    {
                        //Allow lift movement in same direction and clear old marker.
                        buildingStructure[lift.CurrentFloor][lift.ID] = "[ ] ";
                        lift.CurrentFloor = rnd.Next(lift.CurrentFloor, lift.MaxFloor);
                    }
                    else
                    {
                        //updates markers
                        buildingStructure[lift.CurrentFloor][lift.ID] = "[ ] ";
                        lift.CurrentFloor = rnd.Next(0, lift.CurrentFloor);
                    }
                    //Switch direction if lift hits bottom/top floor
                    lift.Direction = lift.CurrentFloor == 0 || lift.CurrentFloor == (lift.MaxFloor - 1) ? Utilities.SwitchDirection(lift) : lift.Direction;
                }
            }
        }

        public static void NaturalPeopleMovement(List<Lift> allLifts)
        {
            Random rnd = new Random();
            foreach (var lift in allLifts)
            {
                lift.CurrentWeightKG = (rnd.Next(11)) * 70;
            }
        }
    }
}
