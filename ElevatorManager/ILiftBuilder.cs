using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    interface ILiftBuilder
    {
        LiftBuilder WithID(int id);
        LiftBuilder IsActive(bool active);
        LiftBuilder HasCurrentFloorOf(int currentFloor);
        LiftBuilder HasDirectionOf(int direction);
        LiftBuilder HasMaxFloorOf(int maxFloor);
        LiftBuilder DistanceToCalledFloor(int? distanceToCalledFloor);
        LiftBuilder HasCurrentWeightKGOf(int currentWeight);
        LiftBuilder HasMaxWeightKGOf(int maxWeight);
    }
}
