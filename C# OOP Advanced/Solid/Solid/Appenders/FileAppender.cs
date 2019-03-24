using Solid.Appenders.Contracts;
using Solid.Layouts.Contracts;
using Solid.Loggers.Contracts;
using Solid.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solid.Appenders
{
    public class FileAppender : IAppender
    {
        private const string path = "../../../log.txt";
        private readonly ILayout layout;
        private readonly ILogFile file;
        private int messageCount;

        public FileAppender(ILayout layout, ILogFile file)
        {
            this.layout = layout;
            this.file = file;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            
            if (this.ReportLevel <= reportLevel)
            {
                
                string content = string.Format(this.layout.Format, dateTime, reportLevel, message) + "\n";
                File.AppendAllText(path, content);
                this.file.Write(content);
                this.messageCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, " +
                $"Report level: {this.ReportLevel}, Messages appended: {this.messageCount}, File size: {this.file.Size}";
        }
    }
}
