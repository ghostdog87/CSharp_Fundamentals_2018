using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Parents
    {
        //<parentName> <parentBirthday>
        public string ParentName { get; set; }
        public string ParentBirthday { get; set; }

        public Parents(string parentName, string parentBirthday)
        {
            ParentName = parentName;
            ParentBirthday = parentBirthday;
        }
    }
}
