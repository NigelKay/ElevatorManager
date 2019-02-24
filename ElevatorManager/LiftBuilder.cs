using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorManager
{
    public class LiftBuilder : ILiftBuilder
    {
        private int _id;
        private bool _active;
        private int _currentFloor;
        private int _direction;
        private int _maxFloor;
        private int? _distanceToCalledFloor;
        private int _currentWeightKG;
        private int _maxWeightKG;

        public LiftBuilder WithID(int id)
        {
            _id = id;
            return this;
        }

        public LiftBuilder IsActive(bool active)
        {
            _active = active;
            return this;
        }

        public LiftBuilder HasCurrentFloorOf(int currentFloor)
        {
            _currentFloor = currentFloor;
            return this;
        }

        public LiftBuilder HasDirectionOf(int direction)
        {
            _direction = direction;
            return this;
        }

        public LiftBuilder HasMaxFloorOf(int maxFloor)
        {
            _maxFloor = maxFloor;
            return this;
        }

        public LiftBuilder DistanceToCalledFloor(int? distanceToCalledFloor)
        {
            _distanceToCalledFloor = distanceToCalledFloor;
            return this;
        }

        public LiftBuilder HasCurrentWeightKGOf(int currentWeight)
        {
            _currentWeightKG = currentWeight;
            return this;
        }

        public LiftBuilder HasMaxWeightKGOf(int maxWeight)
        {
            _maxWeightKG = maxWeight;
            return this;
        }

        public Lift BuildLift()
        {
            return new Lift()
            {
                ID = _id,
                Active = _active,
                CurrentFloor = _currentFloor,
                Direction = _direction,
                MaxFloor = _maxFloor,
                DistanceToCalledFloor = _distanceToCalledFloor,
                CurrentWeightKG = _currentWeightKG,
                MaxWeightKG = _maxWeightKG
            };
        }

        public static implicit operator Lift(LiftBuilder liftBuilder)
        {
            return liftBuilder.BuildLift();
        }
    }
}
