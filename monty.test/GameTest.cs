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

            g.OpenGoatDoor();

            var openDoor = g.Doors.First(x => x.isOpen);
            Assert.Equal(Prize.Goat, openDoor.prize);
        }

        [Fact]
        public void TestOpenFirstDoorNotPlayerDoor()
        {
            Game g;
            int chosenDoor = 0;

            // Make sure we have a goat door
            do 
            {
                g = new Game(chosenDoor, false);
                g.Setup();
            } 
            while (g.Doors[chosenDoor].prize != Prize.Goat);
            
            Assert.Equal(Prize.Goat, g.Doors[chosenDoor].prize);

            // TODO: Not perfect test, since the random choice might choose correct door by chance.
            g.OpenGoatDoor();

            Assert.False(g.Doors[chosenDoor].isOpen);
        }

        [Fact] // will throw argumentoutofrange
        public void TestInvalidDoorChoice()
        {
            Game above = new Game(5, false);
            Game below = new Game(-5, false);

            Assert.Throws<ArgumentOutOfRangeException>(() => above.Setup());
            Assert.Throws<ArgumentOutOfRangeException>(() => below.Setup());
        }
    }
}
