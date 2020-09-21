using System;
using System.ComponentModel.DataAnnotations;

namespace monty.web
{
    public class SimulationRequest
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int NumOfSimulations { get; set; }

        [Required]
        [Range(0, 2)]
        public int ChosenDoor { get; set; }
        public bool ChangeDoor { get; set; }
    }
}