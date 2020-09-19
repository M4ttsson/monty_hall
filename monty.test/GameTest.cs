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
            Game g = new Game();
            g.Setup();
            
            int goats = g.Doors.Count(x => x.prize == Prize.Goat);
            int cars = g.Doors.Count(x => x.prize == Prize.Car);
            
            Assert.Equal(2, goats);
            Assert.Equal(1, cars);
        }

        [Fact]
        public void TestSetupIsOpen()
        {
            Game g = new Game();
            g.Setup();

            bool isOpen = g.Doors.Any(x => x.isOpen);

            Assert.False(isOpen);
        }

        [Fact]
        public void TestOpenFirstDoor()
        {
            Game g = new Game();
            g.Setup();

            g.OpenGoatDoor(0);

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
                g = new Game();
                g.Setup();
            } 
            while (g.Doors[chosenDoor].prize != Prize.Goat);
            
            Assert.Equal(Prize.Goat, g.Doors[chosenDoor].prize);

            // TODO: Not perfect test, since the random choice might choose correct door by chance.
            int door = g.OpenGoatDoor(chosenDoor);

            Assert.NotEqual(chosenDoor, door);
            Assert.False(g.Doors[chosenDoor].isOpen);
            Assert.False(g.Doors.First(x => x.prize == Prize.Car).isOpen);
        }

        [Fact] // will throw argumentoutofrange
        public void TestInvalidDoorChoice()
        {
            Game above = new Game();
            Game below = new Game();

            Assert.Throws<ArgumentOutOfRangeException>(() => above.Run(5, false));
            Assert.Throws<ArgumentOutOfRangeException>(() => below.Run(-5, false));
        }

        [Fact]
        public void TestReadyGame()
        {
            Game g = new Game();
            
            // should not be a car yet since setup not run
            Assert.Empty(g.Doors.Where(x => x.prize == Prize.Car));

            g.Run(0, false);

            Assert.NotEmpty(g.Doors.Where(x => x.prize == Prize.Car));
        }

        [Fact]
        public void TestRunGameGetPrize()
        {
            Game g = new Game();
            Game g2 = new Game();

            var prize1 = g.Run(0, false);
            var prize2 = g2.Run(1, true);
        }
    }
}
