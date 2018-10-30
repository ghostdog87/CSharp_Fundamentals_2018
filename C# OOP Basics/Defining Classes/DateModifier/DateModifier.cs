using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        private TimeSpan differenceBetweenDates;
        private DateTime date1;
        private DateTime date2;

        public DateModifier(DateTime date1, DateTime date2)
        {
            this.Date1 = date1;
            this.Date2 = date2;
        }

        public DateTime Date1 { get => date1; set => date1 = value; }
        public DateTime Date2 { get => date2; set => date2 = value; }
        public TimeSpan DifferenceBetweenDates { get => differenceBetweenDates; set => differenceBetweenDates = value; }

        public int CalculateDifference()
        {
            TimeSpan difference = this.Date1 - this.Date2;
            int days = Math.Abs(difference.Days);
            return days;
        }
    }
}
