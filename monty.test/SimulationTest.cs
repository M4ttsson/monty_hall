using System;
using System.Linq;
using monty.core;
using Xunit;

namespace monty.test
{
    public class SimulationTest
    {

        [Theory]
        [InlineData(1, 0, true)]
        [InlineData(2, 1, false)]
        [InlineData(5, 2, true)]
        [InlineData(15, 0, true)]
        [InlineData(20, 1, false)]
        public void TestRunSeveralSimulations(int numberOfSimulations, int chosenDoor, bool changeDoor)
        {
            Simulation sim = new Simulation();
            sim.Run(numberOfSimulations, chosenDoor, changeDoor);

            Assert.Equal(numberOfSimulations, sim.WonCars + sim.WonGoats);
        }

        [Fact]
        public void TestProofOfMontyProblem()
        {
            Simulation simSwitch = new Simulation();
            simSwitch.Run(100, 0, true);

            Simulation simStay = new Simulation();
            simStay.Run(100, 0, false);

            // Check so win is more than 50% according to monty problem
            Assert.InRange(simSwitch.WonCars, 51, 100);
            
            // Check so switching door results in more cars than not switching
            Assert.True(simSwitch.WonCars > simStay.WonCars);
        }

        [Fact]
        public void SimulationChangeDoor()
        {
            Simulation sim = new Simulation();
            sim.Run(100, 1, true);

            // Make sure more cars is won when switching doors
            Assert.True(sim.WonCars > sim.WonGoats);
        }

        [Fact]
        public void SimulationDontChangeDoor()
        {
            Simulation sim = new Simulation();
            sim.Run(100, 1, false);
            
            // could probably go either way so just count total
            Assert.Equal(100, sim.WonCars + sim.WonGoats);
        }

        [Fact]
        public void SimulationNegativeNumber()
        {
            Simulation sim = new Simulation();
            
            Assert.Throws<ArgumentOutOfRangeException>(() => sim.Run(-10, 0, true));
        }

        [Fact]
        public void SimulationInvalidDoor()
        {
            Simulation sim = new Simulation();
            Assert.Throws<ArgumentOutOfRangeException>(() => sim.Run(10, -5, true));
        }
    }

}