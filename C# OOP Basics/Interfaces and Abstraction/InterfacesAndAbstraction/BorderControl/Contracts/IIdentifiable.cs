using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IIdentifiable
    {
        //<model> <id>

        string Id { get; }
    }
}
