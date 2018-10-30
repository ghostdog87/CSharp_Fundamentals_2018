using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise7
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            var bloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                if (input.IndexOf(" joined The V-Logger") > -1)
                {
                    string username = input.Split(" joined The V-Logger", StringSplitOptions.RemoveEmptyEntries)[0];

                    if (!bloggers.ContainsKey(username))
                    {
                        bloggers.Add(username,new Dictionary<string, SortedSet<string>>());
                        bloggers[username].Add("following", new SortedSet<string>());
                        bloggers[username].Add("follower", new SortedSet<string>());
                    }
                }
                else
                {
                    string firstUser = input.Split(" followed ",StringSplitOptions.RemoveEmptyEntries)[0];
                    string secondUser = input.Split(" followed ", StringSplitOptions.RemoveEmptyEntries)[1];

                    if (!bloggers.ContainsKey(firstUser) || !bloggers.ContainsKey(secondUser) || firstUser == secondUser)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    var followers = new SortedSet<string>();
                    var following = new SortedSet<string>();


                    bloggers[firstUser]["following"].Add(secondUser);

                    bloggers[secondUser]["follower"].Add(firstUser);

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {bloggers.Count} vloggers in its logs.");

            var result = bloggers.OrderByDescending(x => x.Value["follower"].Count)
                                 .ThenBy(x => x.Value["following"].Count);

            bool isFirstVlogger = true;
            int counter = 1;
            foreach (var user in result)
            {
                Console.WriteLine($"{counter}. {user.Key} : {user.Value["follower"].Count} followers, {user.Value["following"].Count} following");
                if (isFirstVlogger)
                {
                    foreach (var follow in user.Value["follower"])
                    {
                        Console.WriteLine($"*  {follow}");
                    }
                    isFirstVlogger = false;
                }
                counter++;
            }
        }
    }
}
