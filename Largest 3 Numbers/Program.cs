using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[] sortedIntegers = integers.OrderByDescending(n => n).Take(3).ToArray();

            Console.WriteLine(String.Join(" ", sortedIntegers));
        }
    }
}
