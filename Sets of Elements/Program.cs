using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            for (int i = 0; i < (inputs[0] + inputs[1]); i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (i < inputs[0])
                {
                    set1.Add(input);
                    continue;
                }
                set2.Add(input);
            }
            set1.IntersectWith(set2);
            Console.WriteLine(string.Join(" ", set1));
        }
    }
}
