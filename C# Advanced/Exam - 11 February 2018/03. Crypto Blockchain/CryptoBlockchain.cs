using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Crypto_Blockchain
{
    class CryptoBlockchain
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            string sentence = string.Empty;

            for (int i = 0; i < numberOfRows; i++)
            {
                string currentRow = Console.ReadLine();
                sentence += currentRow;
            }

            string pattern = @"([\[]{1}[\S\s+][^\[|\{|\}|\]]+[\]]{1}|[\{]{1}[\S\s+][^\[|\{|\}|\]]+[\}]{1})";
            string pattern2 = @"[\d]+";

            string result = string.Empty;

            foreach (Match blocks in Regex.Matches(sentence, pattern))
            {
                string currentBlock = blocks.ToString();
                
                foreach (Match numbers in Regex.Matches(currentBlock, pattern2))
                {
                    string currentNumber = numbers.ToString();

                    if (currentNumber.Length % 3 != 0)
                    {
                        continue;
                    }

                    string word = string.Empty;
                    for (int i = 0; i < currentNumber.Length; i += 3)
                    {
                        char currentNum = (char)(int.Parse(currentNumber[i].ToString() + currentNumber[i + 1].ToString() + currentNumber[i + 2].ToString()) - currentBlock.Length);
                        word += currentNum;                     
                    }
                    result += word;
                }              
            }
            Console.WriteLine(result);
        }
    }
}
