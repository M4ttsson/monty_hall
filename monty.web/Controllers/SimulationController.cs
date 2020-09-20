using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            // remove later
            return "SimulationController";
        }

        [HttpPost]
        public async Task<ActionResult<SimulationResponse>> Post([FromBody]SimulationRequest simReq)
        {
            // Validate params!
            if(!simReq.Validate())
                return BadRequest();

            // TODO: Setup logging with path?
            _logger.LogDebug("simulations: " + simReq.NumOfSimulations);
            
            Simulation sim = new Simulation();
            
            try
            {
                // run in background just in case it takes time
                await Task.Run(() => sim.Run(simReq.NumOfSimulations, simReq.ChosenDoor, simReq.ChangeDoor));
                _logger.LogDebug($"Simulation done, cars {sim.WonCars}, goats {sim.WonGoats}");
                return Ok(new SimulationResponse() { Cars = sim.WonCars, Goats = sim.WonGoats});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when running simulation");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }

}