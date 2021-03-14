using System;
using System.Linq;
using KaspiLift.DTO;

namespace KaspiLift
{
    class Program
    {
        private static ProgramStep ProgramStatus { get; set; }
        private static bool SwitchON = true;
        static void Main(string[] args)
        {
            Building building = new Building(20, new Lift(400, 5));
            Passenger passenger = new Passenger("Nurtas", 80);
            var error = false;

            while (SwitchON)
            {
                switch (ProgramStatus)
                {
                    case ProgramStep.StarProgram:
                        if (!building.CheckAvailableLift())
                        {
                            building.Lift.LiftMove(1, "down");
                            Console.WriteLine("Lift arrived");
                        }
                        ProgramStatus = ProgramStep.EnterPassengers;
                        continue;
                    case ProgramStep.EnterPassengers:
                        building.Lift.isClosed = false;
                        if (building.Lift.Passengers.Count == 0) passenger.EnterInLift(building.Lift, passenger);
                        Console.WriteLine("Add one more passenger ? Yes/No");
                        var answer = Console.ReadLine().ToLower();
                        if (answer == "yes")
                        {
                            Console.WriteLine("Enter the name");
                            var name = Console.ReadLine();
                            Console.WriteLine("Enter the weight");
                            var weight = Convert.ToInt32(Console.ReadLine());
                            passenger.EnterInLift(building.Lift, new Passenger(name, weight));
                        }
                        else if (answer == "no")
                        {
                            ProgramStatus = ProgramStep.SelectFloor;
                            building.Lift.isClosed = true;
                        }
                        continue;
                    case ProgramStep.SelectFloor:
                        if (building.Lift.isClosed)
                        {
                            foreach (var person in building.Lift.Passengers)
                            {
                                Console.WriteLine($"Select the floor for {person.Name} (between 1 and {building.NumberOfFloors})");
                                var selectedFloor = Convert.ToInt32(Console.ReadLine());
                                if (selectedFloor > building.NumberOfFloors)
                                {
                                    Console.WriteLine("Wrong value");
                                    error = true;
                                    ProgramStatus = ProgramStep.SelectFloor;
                                    break;
                                }
                                else
                                {
                                    passenger.SelectFloor(selectedFloor, person);
                                    ProgramStatus = !error ? ProgramStep.DeliverPassengers : ProgramStep.SelectFloor;
                                }
                            }
                        }
                        continue;
                    case ProgramStep.DeliverPassengers:
                        var maxFloor = building.Lift.Passengers.Max(p => p.SelectedFloor);
                        building.Lift.LiftMove(maxFloor, "up");
                        ProgramStatus = ProgramStep.CloseProgram;
                        break;
                    case ProgramStep.CloseProgram:
                        SwitchON = false;
                        break;
                }
            }
        }
    }

    enum ProgramStep
    {
        StarProgram,
        EnterPassengers,
        SelectFloor,
        DeliverPassengers,
        CloseProgram
    }
}
