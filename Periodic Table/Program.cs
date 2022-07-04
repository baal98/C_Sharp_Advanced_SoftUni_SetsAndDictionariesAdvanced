using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                foreach (string element in input)
                elements.Add(element);
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
