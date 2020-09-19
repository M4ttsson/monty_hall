using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using monty.core;

namespace monty.web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimulationController : ControllerBase
    {
        private readonly ILogger<SimulationController> _logger;

        public SimulationController(ILogger<SimulationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Simulation";
        }

        // TODO: Make async...
        [HttpPost]
        public SimulationResponse Post([FromBody]SimulationRequest simReq)
        {
            // Validate params!

            // TODO: Setup logging with path?
            _logger.LogDebug("simulations: " + simReq.NumOfSimulations);
            
            Simulation sim = new Simulation();
            sim.Run(simReq.NumOfSimulations, simReq.ChosenDoor, simReq.ChangeDoor);
            return new SimulationResponse() { Cars = sim.WonCars, Goats = sim.WonGoats};
        }
    }

}