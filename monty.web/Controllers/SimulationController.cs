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

        [HttpPost]
        public string Post(int numOfSim, int chosenDoor, bool changeDoor)
        {
            // Validate params!
            
            Simulation sim = new Simulation();
            sim.Run(numOfSim, chosenDoor, changeDoor);
            return sim.WonCars + " " + sim.WonGoats;
        }
    }

}