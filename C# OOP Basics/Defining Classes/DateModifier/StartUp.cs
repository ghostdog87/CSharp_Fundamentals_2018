using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DateTime date1 = DateTime.Parse( Console.ReadLine());
            DateTime date2 = DateTime.Parse(Console.ReadLine());

            DateModifier dates = new DateModifier(date1,date2);
            int result = dates.CalculateDifference();
            Console.WriteLine(result);
        }
    }
}
