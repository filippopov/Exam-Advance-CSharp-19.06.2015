using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Rage_Quit
{
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([^\d]+)(\d+)";
            StringBuilder sb = new StringBuilder();
            HashSet<char> symbols = new HashSet<char>();
            MatchCollection matchs = Regex.Matches(input, pattern);

            foreach (var match in matchs)
            {
                Regex regex = new Regex(pattern);

                Match secondMatch = regex.Match(match.ToString());

                string text = secondMatch.Groups[1].ToString();
                int count = int.Parse(secondMatch.Groups[2].ToString());
                text = text.ToUpper();

                for (int i = 0; i < count; i++)
                {
                    sb.Append(text);
                }

               
            }

            string result = sb.ToString();
            for (int i = 0; i < result.Length; i++)
            {
                symbols.Add(result[i]);
            }

            Console.WriteLine($"Unique symbols used: {symbols.Count}");
            Console.WriteLine(result);
        }
    }
}
