using System;
using System.Collections.Generic;
using System.Text;

namespace KaspiLift.DTO
{
    class Building
    {
        public int NumberOfFloors { get; private set; }
        public Lift Lift { get; private set; }

        public Building(int numberOfFloors, Lift lift)
        {
            NumberOfFloors = numberOfFloors;
            Lift = lift;
        }

        public bool CheckAvailableLift()
        {
            return Lift.CurrentFloor == 1 ? true : false;
        }
    }
}
