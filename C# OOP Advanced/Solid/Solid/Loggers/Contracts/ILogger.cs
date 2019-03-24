using Solid.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Loggers.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime, string message);

        void Info(string dateTime, string message);
    }
}
