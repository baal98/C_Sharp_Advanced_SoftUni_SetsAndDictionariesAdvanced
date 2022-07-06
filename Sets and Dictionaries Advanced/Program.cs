using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sets_and_Dictionaries_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            Dictionary<double, int> dictionaryDoubles = new Dictionary<double, int>();

            for (int i = 0; i < inputs.Length; i++)
            {
                double ellement = double.Parse(inputs[i]);
                int counter = 1;

                if (!dictionaryDoubles.ContainsKey(ellement))
                {
                    dictionaryDoubles[ellement] = counter;
                }
                else
                {
                    dictionaryDoubles[ellement] += counter;
                }
            }

            foreach(var d in dictionaryDoubles)
            {
                Console.WriteLine($"{d.Key} - {d.Value} times");
            }
        }
    }
}
