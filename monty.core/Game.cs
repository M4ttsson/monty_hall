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
            // TODO: Add check for max limit
            _chosenDoor = chosenDoor;
            _isDoorChange = isDoorChange;
            Doors = new (Prize, bool)[_numOfDoors];
            rand = new Random();

            Setup();
        }

        public void Setup()
        {
            // hide the car, rest is default goats already as enum default = 0
            int carDoor = rand.Next(0, _numOfDoors); // 0 - 2
            Doors[carDoor] = (Prize.Car, false);
        }

        // Main game method
        public void Run()
        {
            
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