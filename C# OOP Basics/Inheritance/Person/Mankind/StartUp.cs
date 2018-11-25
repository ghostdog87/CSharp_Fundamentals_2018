using System;

namespace Mankind
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] studentInput = Console.ReadLine().Split();
            string[] workerInput = Console.ReadLine().Split();

            string studentFirstName = studentInput[0];
            string studentLastName = studentInput[1];
            string facultyNumber = studentInput[2];

            string workerFirstName = workerInput[0];
            string workerLastName = workerInput[1];
            decimal weekSalary = decimal.Parse(workerInput[2]);
            decimal workingHours = decimal.Parse(workerInput[3]);

            try
            {
                Student student = new Student(studentFirstName, studentLastName, facultyNumber);               
                Console.WriteLine($"First Name: {student.FirstName}");
                Console.WriteLine($"Last Name: {student.LastName}");
                Console.WriteLine($"Faculty number: {student.FacultyNumber}");
                Console.WriteLine();
                Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, workingHours);
                Console.WriteLine($"First Name: {worker.FirstName}");
                Console.WriteLine($"Last Name: {worker.LastName}");
                Console.WriteLine($"Week Salary: {worker.WeekSalary:f2}");
                Console.WriteLine($"Hours per day: {worker.WorkingHours:f2}");
                Console.WriteLine($"Salary per hour: {worker.SalaryPerHour():f2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
