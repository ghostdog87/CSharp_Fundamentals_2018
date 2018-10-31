using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            Name = name;
            Stats = stats;
        }

        public Stats Stats
        {
            get { return stats; }
            set { stats = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Exception ex = new ArgumentException("A name should not be empty.");
                    Console.WriteLine(ex.Message);
                }
                name = value;
            }
        }



        public double AveragePlayerStats()
        {
            return (stats.Dribble + stats.Endurance + stats.Passing + stats.Shooting + stats.Sprint) / 5;
        }
    }
}
