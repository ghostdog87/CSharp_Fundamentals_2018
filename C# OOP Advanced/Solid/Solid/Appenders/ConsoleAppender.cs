using Solid.Appenders.Contracts;
using Solid.Layouts.Contracts;
using Solid.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private readonly ILayout layout;
        private int messageCount;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            
            if (this.ReportLevel <= reportLevel)
            {
                
                Console.WriteLine(string.Format(this.layout.Format, dateTime, reportLevel, message));
                this.messageCount++;
            }           
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}" +
                $", Report level: {this.ReportLevel}, Messages appended: {this.messageCount}";
        }
    }
}
