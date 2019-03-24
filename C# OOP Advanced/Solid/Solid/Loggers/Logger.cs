using Solid.Appenders.Contracts;
using Solid.Loggers.Contracts;
using Solid.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender consoleAppender;
        private readonly IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender) : this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }

        internal void Critical(string dateTime, string message)
        {
            this.consoleAppender?.Append(dateTime, ReportLevel.CRITICAL, message);
            this.fileAppender?.Append(dateTime, ReportLevel.CRITICAL, message);
        }

        internal void Warning(string dateTime, string message)
        {
            this.consoleAppender?.Append(dateTime, ReportLevel.WARNING, message);
            this.fileAppender?.Append(dateTime, ReportLevel.WARNING, message);
        }

        internal void Fatal(string dateTime, string message)
        {
            this.consoleAppender?.Append(dateTime, ReportLevel.FATAL, message);
            this.fileAppender?.Append(dateTime, ReportLevel.FATAL, message);
        }

        public void Error(string dateTime, string message)
        {
            this.consoleAppender?.Append(dateTime, ReportLevel.ERROR, message);
            this.fileAppender?.Append(dateTime, ReportLevel.ERROR, message);
        }

        public void Info(string dateTime, string message)
        {
            this.consoleAppender?.Append(dateTime, ReportLevel.INFO, message);
            this.fileAppender?.Append(dateTime, ReportLevel.INFO, message);
        }
    }
}
