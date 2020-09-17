using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace monty.core
{
    public enum Prize
    {
        Goat,
        Car
    }

    public class Game
    {
        // innehåller dörrar, get slumpmässigt bakom en av de. metod för att öppna en dörr. Byta dörr. osv. Vinst. 
        // Simulering innehåller många Game. Run(). 
        
        public (Prize prize, bool isOpen)[] Doors { get; private set; }

        private int _chosenDoor;
        private bool _isDoorChange;
    
        // Just a const for now, easy to change later if more doors
        private const int _numOfDoors = 3;

        private Random rand;

        public Game(int chosenDoor, bool isDoorChange)
        {
            _chosenDoor = chosenDoor;
            _isDoorChange = isDoorChange;
            Doors = new (Prize, bool)[_numOfDoors];
            rand = new Random();
        }

        public void Setup()
        {
            // validate player door
            if (_chosenDoor > _numOfDoors - 1)
                throw new ArgumentOutOfRangeException("chosenDoor", "The chosen door exceeds number of doors");

            // hide the car, rest is default goats already as enum default = 0
            int carDoor = rand.Next(0, _numOfDoors); // 0 - 2
            Doors[carDoor] = (Prize.Car, false);
        }

        // Main game method
        public void Run()
        {
            // 1. run setup if not done already (check with bool)
            // 2. open first door
            // 3. change door if so
            // 4. check what prize and return it
        }

        public void OpenFirstDoor()
        {
            // Find a random goat door to open
            int doorToOpen;
            do 
            {
                doorToOpen = rand.Next(0, _numOfDoors);
            }
            while (Doors[doorToOpen].prize == Prize.Car);

            Doors[doorToOpen].isOpen = true;
        }
    }
}