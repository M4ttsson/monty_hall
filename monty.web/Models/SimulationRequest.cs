using System;

namespace monty.web
{
    public class SimulationRequest
    {
        public int NumOfSimulations { get; set; }
        public int ChosenDoor { get; set; }
        public bool ChangeDoor { get; set; }
    }
}