using System;
using System.Collections.Generic;
using System.Text;

namespace KaspiLift.DTO
{
    class Passenger
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int SelectedFloor { get; set; }

        public Passenger(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public void EnterInLift(Lift exemplarOfLift, Passenger passenger)
        {
            if (exemplarOfLift.CurrentWeight + passenger.Weight <= exemplarOfLift.WeightLimit)
            {
                exemplarOfLift.Passengers.Add(passenger);
                Console.WriteLine($"{passenger.Name} entered in lift");
            }
            else
            {
                Console.WriteLine($"Too fat!");
            }
        }

        public void SelectFloor(int floor, Passenger passenger)
        {
            passenger.SelectedFloor = floor;
            Console.WriteLine($"{passenger.Name} selected {floor} floor");
        }
    }
}
