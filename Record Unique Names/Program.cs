using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < numberOfNames; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            foreach (string name in names)
                Console.WriteLine(name);

        }
    }
}
