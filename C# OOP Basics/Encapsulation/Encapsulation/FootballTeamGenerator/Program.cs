using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Team> teams = new List<Team>();


            while (input != "END")
            {
            string[] currentInput = input.Split(";",StringSplitOptions.RemoveEmptyEntries);

                
                if (currentInput[0] == "Team")
                {
                    Team team = new Team(currentInput[1]);
                    teams.Add(team);
                }
                else if (currentInput[0] == "Add")
                {
                    string teamName = currentInput[1];
                    string playerName = currentInput[2];
                    double stats1 = double.Parse(currentInput[3]);
                    double stats2 = double.Parse(currentInput[4]);
                    double stats3 = double.Parse(currentInput[5]);
                    double stats4 = double.Parse(currentInput[6]);
                    double stats5 = double.Parse(currentInput[7]);
                    if (teams.Any(x => x.Name == teamName))
                    {
                        Team team = teams.FirstOrDefault(x => x.Name == teamName);
                        Stats playerStats = new Stats(stats1, stats2, stats3, stats4, stats5);
                        Player player = new Player(playerName, playerStats);
                        team.AddPlayer(player);
                    }
                    else
                    {
                        Exception ex = new ArgumentException($"Team {teamName} does not exist.");
                        Console.WriteLine(ex.Message);
                    }
                        
                }
                else if (currentInput[0] == "Remove")
                {
                    string teamName = currentInput[1];
                    string playerName = currentInput[2];
                    if (teams.Where(x => x.Name == teamName).Count() > 0)
                    {
                        Team team = teams.FirstOrDefault(x => x.Name == teamName);

                        team.RemovePlayer(playerName);
                    }
                }
                else if (currentInput[0] == "Rating")
                {
                    string teamName = currentInput[1];
                    if (teams.Any(x => x.Name == teamName))
                    {
                        if (teams.Where(x => x.Name == teamName).Count() > 0)
                        {
                            Team team = teams.FirstOrDefault(x => x.Name == teamName);
                            Console.WriteLine($"{team.Name} - {team.Rating:f0}");
                        }
                    }
                    else
                    {
                        Exception ex = new ArgumentException($"Team {teamName} does not exist.");
                        Console.WriteLine(ex.Message);
                    }
                }

                input = Console.ReadLine();
                
            }
        }
    }
}
