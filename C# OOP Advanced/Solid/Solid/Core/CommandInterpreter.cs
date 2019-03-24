using Solid.Appenders;
using Solid.Appenders.Contracts;
using Solid.Core.Contracts;
using Solid.Layouts;
using Solid.Layouts.Contracts;
using Solid.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Core
{
    public class CommandInterpreter : ICommandInterprete
    {
        private ICollection<IAppender> appenders;
        private AppenderFactory appenderFactory;
        private LayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {
            ILayout layout = this.layoutFactory.CreateLayout(args[1]);
            IAppender appender = this.appenderFactory.CreateAppender(args[0], layout);

            ReportLevel reportLevel = ReportLevel.INFO;
            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2], true);
            }
            appender.ReportLevel = reportLevel;
            appenders.Add(appender);
        }

        public void Print()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }

        public void AddMessage(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0], true);
            string dateTime = args[1];
            string message = args[2];

            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }
    }
}
