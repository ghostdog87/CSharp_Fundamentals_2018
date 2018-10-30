using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Engine
    {
        //<EngineSpeed> <EnginePower>

        private int engineSpeed;
        private int enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            EnginePower = enginePower;
            EngineSpeed = engineSpeed;
        }

        public int EnginePower
        {
            get { return enginePower; }
            set { enginePower = value; }
        }

        public int EngineSpeed
        {
            get { return engineSpeed; }
            set { engineSpeed = value; }
        }

    }
}
