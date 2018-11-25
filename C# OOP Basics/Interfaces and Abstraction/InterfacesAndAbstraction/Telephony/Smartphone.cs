using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        
        public string Browsing(string site)
        {
            if (site.All(x => !char.IsDigit(x)))
            {
                return $"Browsing: {site}!";
            }
            return $"Invalid URL!";        
        }

        public string Calling(string phoneNumber)
        {
            if (phoneNumber.All(x => char.IsDigit(x)))
            {
                return $"Calling... {phoneNumber}";
            }
            return $"Invalid number!";            
        }
    }
}
