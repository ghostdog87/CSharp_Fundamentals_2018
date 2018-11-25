using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();
            Smartphone phone = new Smartphone();

            foreach (var phoneNumber in phoneNumbers)
            {               
                Console.WriteLine(phone.Calling(phoneNumber));
            }

            foreach (var site in sites)
            {
                Console.WriteLine(phone.Browsing(site));
            }
        }
    }
}
