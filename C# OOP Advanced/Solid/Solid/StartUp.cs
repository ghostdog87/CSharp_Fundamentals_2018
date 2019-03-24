using Solid.Appenders;
using Solid.Appenders.Contracts;
using Solid.Core;
using Solid.Layouts;
using Solid.Layouts.Contracts;
using Solid.Loggers;
using Solid.Loggers.Contracts;
using Solid.Loggers.Enums;
using System;

namespace Solid
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
