using Solid.Appenders.Contracts;
using Solid.Layouts;
using Solid.Layouts.Contracts;
using Solid.Loggers;
using Solid.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Appenders
{
    public class AppenderFactory
    {
        public IAppender CreateAppender(string appenderType, ILayout layout)
        {
            string appenderTypeToLower = appenderType.ToLower();

            switch (appenderTypeToLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
