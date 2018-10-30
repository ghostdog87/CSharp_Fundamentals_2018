using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise8
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string,int>> students = new SortedDictionary<string, Dictionary<string, int>>();

            string firstInput = Console.ReadLine();

            while (firstInput != "end of contests")
            {
                //Part One Interview:success
                string contest = firstInput.Split(":", StringSplitOptions.RemoveEmptyEntries)[0];
                string password = firstInput.Split(":", StringSplitOptions.RemoveEmptyEntries)[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }

                firstInput = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "end of submissions")
            {
                string[] currentInput = secondInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = currentInput[0];
                string password = currentInput[1];
                string user = currentInput[2];
                int points = int.Parse(currentInput[3]);

                if (!contests.ContainsKey(contest))
                {
                    secondInput = Console.ReadLine();
                    continue;
                }
                else if (contests[contest] != password)
                {
                    secondInput = Console.ReadLine();
                    continue;
                }

                if (!students.ContainsKey(user))
                {
                    students.Add(user, new Dictionary<string, int>());
                }

                if (!students[user].ContainsKey(contest))
                {
                    students[user].Add(contest, points);
                }
                else
                {
                    if (students[user][contest] < points)
                    {
                        students[user][contest] = points;
                    }
                }
                secondInput = Console.ReadLine();
            }

            int maxPoints = int.MinValue;
            string bestStudent = string.Empty;

            foreach (var student in students)
            {
                int currentPoints = 0;
                foreach (var points in student.Value)
                {
                    currentPoints += points.Value;
                }
                if (currentPoints > maxPoints)
                {
                    maxPoints = currentPoints;
                    bestStudent = student.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestStudent} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in students)
            {
                Console.WriteLine(student.Key);
                foreach (var contest in student.Value.OrderByDescending(x =>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
