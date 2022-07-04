using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            foreach (char c in input)
            {
                if (!symbols.ContainsKey(c))
                {
                    symbols[c] = 1;
                }
                else
                {
                    symbols[c]++;
                }
            }

            foreach (var c in symbols)
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }
        }
    }
}
