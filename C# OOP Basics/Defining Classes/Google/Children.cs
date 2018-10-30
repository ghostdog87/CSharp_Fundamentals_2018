using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Children
    {
        //<childName> <childBirthday>
        public string ChildName { get; set; }
        public string ChildBirthday { get; set; }

        public Children(string childName, string childBirthday)
        {
            ChildName = childName;
            ChildBirthday = childBirthday;
        }
    }
}
