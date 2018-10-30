using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private double rating;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            Rating = 0;
            Players = new List<Player>();
        }

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        public double Rating
        {
            get { return AverageTeamStats(); }
            set { rating = value; }
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

        public void AddPlayer(Player player)
        {
            if (player.Stats.Endurance != 0)
            {
                Players.Add(player);
            }
        }

        public void RemovePlayer(string name)
        {
            if (Players.Any(x => x.Name == name))
            {
                Players.Remove(Players.FirstOrDefault(x => x.Name == name));
            }
            else
            {
                Exception ex = new ArgumentException($"Player {name} is not in {this.Name} team.");
                Console.WriteLine(ex.Message);
            }
        }

        public double AverageTeamStats()
        {
            if (this.Players.Count > 0)
            {
                return this.Players.Sum(x => x.AveragePlayerStats()) / this.Players.Count;
            }
            return 0;
        }

    }
}
