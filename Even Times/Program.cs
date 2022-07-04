using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbersAndCount = new Dictionary<int, int>();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (numbersAndCount.ContainsKey(number))
                {
                    numbersAndCount[number]++;
                }
                else
                {
                    numbersAndCount.Add(number, 1);
                }
            }

            var evenTimesNumber = numbersAndCount.First(kvp => kvp.Value % 2 == 0).Key;

            Console.WriteLine(evenTimesNumber);
        }
    }
}
