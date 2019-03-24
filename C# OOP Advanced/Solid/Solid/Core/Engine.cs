using Solid.Appenders;
using Solid.Appenders.Contracts;
using Solid.Layouts;
using Solid.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Core
{
    public class Engine
    {
        private CommandInterpreter commandInterpreter;


        public Engine(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;

        }

        public void Run() {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                commandInterpreter.AddAppender(inputArgs);

            }

            string currentInput = Console.ReadLine();

            while (currentInput != "END")
            {
                string[] messageArgs = currentInput.Split("|");

                commandInterpreter.AddMessage(messageArgs);

                currentInput = Console.ReadLine();
            }

            commandInterpreter.Print();
        }
    }
}
