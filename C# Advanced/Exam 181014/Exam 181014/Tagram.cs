using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_181014
{
    class Tagram
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input.StartsWith("ban "))
                {
                    string[] currentInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string user = currentInput[1];

                    if (users.ContainsKey(user))
                    {
                        users.Remove(user);
                    }
                }
                else
                {
                    //Katty->healthy-> 50
                    string[] currentInput = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string user = currentInput[0];
                    string tag = currentInput[1];
                    int likes = int.Parse(currentInput[2]);

                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, new Dictionary<string, int>());
                        users[user].Add("totalLikes", 0);
                    }
                    if (!users[user].ContainsKey(tag))
                    {
                        users[user].Add(tag, likes);
                        users[user]["totalLikes"] += likes;
                    }
                    else
                    {
                        users[user][tag] += likes;
                        users[user]["totalLikes"] += likes;
                    }
                }

                input = Console.ReadLine();
            }
            
            var result = users.OrderByDescending(x => x.Value["totalLikes"]).ThenBy(x => x.Value.Keys.Count);

            foreach (var user in result)
            {
                Console.WriteLine(user.Key);
                foreach (var tags in user.Value)
                {
                    if (tags.Key != "totalLikes")
                    {
                        Console.WriteLine($"- {tags.Key}: {tags.Value}");
                    }
                    
                }
            }
        }
    }
}
