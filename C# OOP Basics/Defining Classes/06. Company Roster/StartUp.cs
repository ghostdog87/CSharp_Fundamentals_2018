using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];

                Employee emp = new Employee(name, salary, position, department);

                if (input.Length == 5)
                {
                    if (input[4].Contains("@"))
                    {
                        emp.Email = input[4];
                    }
                    else
                    {
                        emp.Age = int.Parse(input[4]);
                    }
                }
                else if (input.Length == 6)
                {
                    emp.Email = input[4];
                    emp.Age = int.Parse(input[5]);
                }

                employees.Add(emp);
            }

            var highestSalaries = employees.GroupBy(x => x.Department)
                                           .ToDictionary(x => x.Key, y=>y.Select(z =>z))
                                           .OrderByDescending(x =>x.Value.Average(y =>y.Salary)).FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {highestSalaries.Key}");

            foreach (var item in highestSalaries.Value.OrderByDescending(x=>x.Salary))
            {
                Console.WriteLine($"{item.Name} {item.Salary:F2} {item.Email} {item.Age}");
            }
        }
    }
}
