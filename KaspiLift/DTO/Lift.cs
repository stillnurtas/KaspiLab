using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KaspiLift.DTO
{
    class Lift
    {
        public int WeightLimit { get; private set; }
        public int CurrentWeight { get; set; }
        public int CurrentFloor { get; set; }
        public List<Passenger> Passengers { get; set; }
        public bool isClosed { get; set; } = true;

        public Lift(int weightLimit, int currentFloor)
        {
            WeightLimit = weightLimit;
            CurrentFloor = currentFloor;
            Passengers = new List<Passenger>();
        }

        public void LiftMove(int targetFloor, string direction)
        {
            if (direction == "down")
            {
                for (int floor = CurrentFloor; floor >= targetFloor; floor--)
                {
                    Console.WriteLine($"Lift on {floor} floor");
                }
                CurrentFloor = targetFloor;
            }
            else
            {
                for (int floor = 1; floor <= targetFloor; floor++)
                {
                    Console.WriteLine($"Lift on {floor} floor");
                    var outgoingPassengers = Passengers.Where(p => p.SelectedFloor == floor).ToList();
                    if (outgoingPassengers != null)
                    {
                        foreach (var passenger in outgoingPassengers)
                        {
                            Console.WriteLine($"Passenger {passenger.Name} out in {floor} floor");
                        }
                    }
                }
            }
        }

        public void CloseOrOpenDoor()
        {

        }

        public bool CheckWeightOverload()
        {
            return CurrentWeight > WeightLimit ? true : false;
        }
    }
}
