using Solid.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solid.Loggers
{
    public class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string message)
        {

            this.Size += message.Where(x => char.IsLetter(x)).Sum(x => x);
        }
    }
}
