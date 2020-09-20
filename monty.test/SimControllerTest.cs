using System;
using System.Linq;
using monty.core;
using monty.web.Controllers;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace monty.test
{
    public class SimControllerTest
    {

        [Fact]
        public async void PostSimulation()
        {
            var mockLogger = new Mock<ILogger<SimulationController>>();
            SimulationController simcon = new SimulationController(mockLogger.Object);
            var result = await simcon.Post(new web.SimulationRequest() {
                ChangeDoor = false,
                ChosenDoor = 0,
                NumOfSimulations = 10
            });

            Assert.Equal(10, result.Value.Cars + result.Value.Goats);
        }

        [Fact]
        public async void PostSimulationInvalid()
        {
            var mockLogger = new Mock<ILogger<SimulationController>>();
            SimulationController simcon = new SimulationController(mockLogger.Object);
            var result = await simcon.Post(new web.SimulationRequest() {
                ChangeDoor = false,
                ChosenDoor = -1,
                NumOfSimulations = -1
            });

            Assert.IsType<BadRequestResult>(result.Result);
        }
    }

}