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
        public (Prize prize, bool isOpen)[] Doors { get; private set; }

        private int _chosenDoor;
        private bool _isDoorChange;
        private bool _isReady;
    
        // Just a const for now, easy to change later if more doors
        private const int _numOfDoors = 3;

        private Random rand;

        // TODO: Consider moving isDoorChange to Run() instead, maybe chosenDoor as well
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
            if (_chosenDoor > _numOfDoors - 1 || _chosenDoor < 0)
                throw new ArgumentOutOfRangeException("chosenDoor", "The chosen door exceeds number of doors");

            // hide the car, rest is default goats already as enum default = 0
            int carDoor = rand.Next(0, _numOfDoors); // 0 - 2
            Doors[carDoor] = (Prize.Car, false);
            _isReady = true;
        }

        // Main game method
        public Prize Run()
        {
            // 1. run setup if not done already (check with bool)
            // 2. open first door
            // 3. change door if so
            // 4. return prize
            
            if (!_isReady)
                Setup();

            int openedDoor = OpenGoatDoor();

            if (_isDoorChange)
            {
                var otherDoor = Doors.Select((door, index) => new {door, index}).First(x => !x.door.isOpen && x.index != _chosenDoor).index;
                _chosenDoor = otherDoor;
            }

            Doors[_chosenDoor].isOpen = true;
            return Doors[_chosenDoor].prize;
            // TODO: Testing
        }

        public int OpenGoatDoor()
        {
            // Find a random goat door to open
            int doorToOpen;
            int indexOfCar = Array.IndexOf(Doors, Doors.First(x => x.prize == Prize.Car));

            do 
            {
                doorToOpen = rand.Next(0, _numOfDoors);
            }
            while (doorToOpen == indexOfCar || doorToOpen == _chosenDoor);

            Doors[doorToOpen].isOpen = true;
            return doorToOpen;
        }
    }
}