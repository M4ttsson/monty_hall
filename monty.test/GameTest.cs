using System;
using System.Linq;
using monty.core;
using Xunit;

namespace monty.test
{
    public class GameTest
    {
        [Fact]
        public void TestSetupPrize()
        {
            Game g = new Game(1, false);
            g.Setup();
            
            int goats = g.Doors.Count(x => x.prize == Prize.Goat);
            int cars = g.Doors.Count(x => x.prize == Prize.Car);
            
            Assert.Equal(2, goats);
            Assert.Equal(1, cars);
        }

        [Fact]
        public void TestSetupIsOpen()
        {
            Game g = new Game(0, true);
            g.Setup();

            bool isOpen = g.Doors.Any(x => x.isOpen);

            Assert.False(isOpen);
        }

        [Fact]
        public void TestOpenFirstDoor()
        {
            Game g = new Game(0, false);
            g.Setup();

            g.OpenFirstDoor();

            var openDoor = g.Doors.First(x => x.isOpen);
            Assert.Equal(Prize.Goat, openDoor.prize);
        }

        [Fact] // will throw argumentoutofrange
        public void TestInvalidDoorChoice()
        {

        }
    }
}
