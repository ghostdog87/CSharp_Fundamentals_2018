using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Engine
    {

        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public string Model { get => model; set => model = value; }
        public int Power { get => power; set => power = value; }
        public int Displacement { get => displacement; set => displacement = value; }
        public string Efficiency { get => efficiency; set => efficiency = value; }

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("  {0}:\n", this.Model);
            sb.AppendFormat("    Power: {0}\n", this.Power);
            sb.AppendFormat("    Displacement: {0}\n", this.Displacement == -1 ? "n/a" : this.Displacement.ToString());
            sb.AppendFormat("    Efficiency: {0}\n", this.Efficiency);

            return sb.ToString();
        }
    }
}
