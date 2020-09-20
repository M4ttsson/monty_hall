using System;

namespace monty.web
{
    public class SimulationRequest
    {
        public int NumOfSimulations { get; set; }
        public int ChosenDoor { get; set; }
        public bool ChangeDoor { get; set; }

        public bool Validate()
        {
            if (NumOfSimulations < 0)
                return false;
            if (ChosenDoor > 2 || ChosenDoor < 0)
                return false;
            return true;
        }
    }
}