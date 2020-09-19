using System;

namespace monty.core
{
    // class for the monty game simulation, run many games
    public class Simulation
    {
        public int WonGoats { get; private set; }
        public int WonCars { get; private set; }

        public void Run(int totalSimulations, int chosenDoor, bool changeDoor)
        {
            if (totalSimulations < 1)
                throw new ArgumentOutOfRangeException(nameof(totalSimulations), "Number of simulations is below 1!");

            for(int i = 0; i < totalSimulations; i++)
            {
                Game game = new Game();
                Prize prize = game.Run(chosenDoor, changeDoor);

                if (prize == Prize.Car)
                    WonCars++;
                else
                    WonGoats++;
                
            }
        }
    }
}