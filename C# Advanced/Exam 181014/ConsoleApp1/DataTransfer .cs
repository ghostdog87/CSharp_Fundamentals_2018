using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(s:){1}([\S ]+[^;r])(;r:){1}([\S ]+)(;m--){1}([""][a-zA-Z ]+[""])";


            int input = int.Parse(Console.ReadLine());


            int dataTransfered = 0;
            for (int i = 0; i < input; i++)
            {
                string currentInput = Console.ReadLine();

                foreach (Match validTexts in Regex.Matches(currentInput, pattern))
                {
                    string sender = validTexts.Groups[2].ToString();
                    string receiver = validTexts.Groups[4].ToString();
                    string message = validTexts.Groups[6].ToString();

                    string pattern2 = @"[A-Za-z\s]";

                    string senderText = string.Empty;
                    string receiverText = string.Empty;

                    foreach (Match getText in Regex.Matches(sender, pattern2))
                    {
                        senderText += getText;
                    }
                    
                    foreach (Match getText in Regex.Matches(receiver, pattern2))
                    {
                        receiverText += getText;
                    }

                    for (int eachChar = 0; eachChar < sender.Length; eachChar++)
                    {
                        if (char.IsDigit(sender[eachChar]))
                        {
                            
                            dataTransfered += (int)Char.GetNumericValue(sender[eachChar]);
                        }
                    }                   

                    for (int eachChar = 0; eachChar < receiver.Length; eachChar++)
                    {
                        if (char.IsDigit(receiver[eachChar]))
                        {
                            dataTransfered += (int)Char.GetNumericValue(receiver[eachChar]);
                        }
                    }

                    Console.WriteLine($"{senderText} says {message} to {receiverText}");


                }
            }
            Console.WriteLine($"Total data transferred: {dataTransfered}MB");
            
        }
    }
}
