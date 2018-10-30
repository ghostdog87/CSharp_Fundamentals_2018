using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        public Stats(double endurance, double sprint, double dribble, double passing, double shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public double Shooting
        {
            get { return shooting; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Exception ex = new ArgumentException("Shooting should be between 0 and 100.");
                    Console.WriteLine(ex.Message);
                }
                shooting = value;
            }
        }

        public double Passing
        {
            get { return passing; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Exception ex = new ArgumentException("Passing should be between 0 and 100.");
                    Console.WriteLine(ex.Message);
                }
                passing = value;
            }
        }

        public double Dribble
        {
            get { return dribble; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Exception ex = new ArgumentException("Dribble should be between 0 and 100.");
                    Console.WriteLine(ex.Message);
                }
                dribble = value;
            }
        }

        public double Sprint
        {
            get { return sprint; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Exception ex = new ArgumentException("Sprint should be between 0 and 100.");
                    Console.WriteLine(ex.Message);
                }
                sprint = value;
            }
        }

        public double Endurance
        {
            get { return endurance; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Exception ex = new ArgumentException("Endurance should be between 0 and 100.");
                    Console.WriteLine(ex.Message);
                }
                endurance = value;
            }
        }

    }
}
