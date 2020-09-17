using System;
using System.Linq;
using monty.core;
using Xunit;

namespace monty.test
{
    public class GameTest
    {
        [Fact]
        public void TestSetup()
        {
            Game g = new Game(1, false);
            
            int goats = g.Doors.Count(x => x == Prize.Goat);
            int cars = g.Doors.Count(x => x == Prize.Car);
            
            Assert.Equal(2, goats);
            Assert.Equal(1, cars);
        }
    }
}
