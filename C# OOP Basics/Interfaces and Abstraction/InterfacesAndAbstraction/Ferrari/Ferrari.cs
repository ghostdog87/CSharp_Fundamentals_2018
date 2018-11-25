using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        public string Model { get; set; }
        public string Driver { get; set; }

        public Ferrari(string driver)
        {
            Model = "488-Spider";
            Driver = driver;
        }

        public string PushGas()
        {
            return "Zadu6avam sA!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }
    }
}
