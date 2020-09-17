using System;

namespace monty.core
{
    // Main class for the monty game simulation
    public class Simulation
    {
        public int NumSimulationsTotal { get; private set; }
        public int ChosenDoor { get; private set; }
        public int WonGoats { get; private set; }
        public int WonCars { get; private set; }

        public bool IsDoorChange { get; private set; }

        public Simulation(int chosenDoor, int totalSimulations, bool isDoorChange)
        {
            ChosenDoor = chosenDoor;
            NumSimulationsTotal = totalSimulations;
            IsDoorChange = isDoorChange;
        }
    }
}