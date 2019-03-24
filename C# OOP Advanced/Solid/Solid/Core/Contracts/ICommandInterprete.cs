using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Core.Contracts
{
    public interface ICommandInterprete
    {
        void AddAppender(string[] args);

        void AddMessage(string[] args);
    }
}
