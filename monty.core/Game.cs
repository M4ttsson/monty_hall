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

        private bool _isReady;
    
        // Just a const for now, easy to change later if more doors
        private const int _numOfDoors = 3;

        // TODO: Maybe option to insert when simulating due to default seed
        private Random rand;

        public Game()
        {
            Doors = new (Prize, bool)[_numOfDoors];
            rand = new Random();
        }

        public void Setup()
        {
            // hide the car, rest is default goats already as enum default = 0
            int carDoor = rand.Next(0, _numOfDoors); // 0 - 2
            Doors[carDoor] = (Prize.Car, false);
            _isReady = true;
        }

        // Main game method
        public Prize Run(int chosenDoor, bool changeDoor)
        {
            // 1. run setup if not done already (check with bool)
            // 2. open first door
            // 3. change door if so
            // 4. return prize

            // validate player door
            if (chosenDoor > _numOfDoors - 1 || chosenDoor < 0)
                throw new ArgumentOutOfRangeException(nameof(chosenDoor), "The chosen door exceeds number of doors or is below zero");
            
            if (!_isReady)
                Setup();

            int openedDoor = OpenGoatDoor(chosenDoor);

            if (changeDoor)
            {
                // Find the other door not selected by the player currently
                var otherDoor = Doors.Select((door, index) => new {door, index}).First(x => !x.door.isOpen && x.index != chosenDoor).index;
                chosenDoor = otherDoor;
            }

            Doors[chosenDoor].isOpen = true;
            return Doors[chosenDoor].prize;
            // TODO: Testing
        }

        public int OpenGoatDoor(int playerChoice)
        {
            // Find a random goat door to open
            int doorToOpen;
            int indexOfCar = Array.IndexOf(Doors, Doors.First(x => x.prize == Prize.Car));

            do 
            {
                doorToOpen = rand.Next(0, _numOfDoors);
            }
            while (doorToOpen == indexOfCar || doorToOpen == playerChoice);

            Doors[doorToOpen].isOpen = true;
            return doorToOpen;
        }
    }
}