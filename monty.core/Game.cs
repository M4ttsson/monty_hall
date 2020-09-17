using System;
using System.Linq;
using System.Runtime.CompilerServices;

// allow test project to see class
[assembly: InternalsVisibleTo("monty.test")]
namespace monty.core
{
    public enum Prize
    {
        Goat,
        Car
    }

    internal class Game
    {
        // innehåller dörrar, get slumpmässigt bakom en av de. metod för att öppna en dörr. Byta dörr. osv. Vinst. 
        // Simulering innehåller många Game. Run(). 
        
        internal Prize[] Doors { get; private set; }

        private int _chosenDoor;
        private bool _isDoorChange;
    
        // Just a const for now, easy to change later if more doors
        private const int _numOfDoors = 3;

        private Random rand;

        public Game(int chosenDoor, bool isDoorChange)
        {
            _chosenDoor = chosenDoor;
            _isDoorChange = isDoorChange;
            Doors = new Prize[_numOfDoors];
            rand = new Random();

            Setup();
        }

        public void Setup()
        {
            // hide the car, rest is default goats already as enum default = 0
            int carDoor = rand.Next(0, 3); // 0 - 2
            Doors[carDoor] = Prize.Car;
        }

        public void Run()
        {
            
        }
    }
}