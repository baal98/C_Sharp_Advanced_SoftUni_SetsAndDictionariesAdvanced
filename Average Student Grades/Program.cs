using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> dictionaryStudents = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] inputs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                string name = inputs[0];
                decimal grade = decimal.Parse(inputs[1]);

                if (!dictionaryStudents.ContainsKey(name))
                {
                    List<decimal> grades = new List<decimal>();
                    dictionaryStudents[name] = grades;
                    grades.Add(grade);
                }
                else
                {
                    dictionaryStudents[name].Add(grade);
                }

            }

            foreach (var name in dictionaryStudents)
            {
                Console.Write(name.Key + " -> ");
                foreach (var grade in name.Value)
                {
                    Console.Write($"{grade:F2} " );
                }
                Console.WriteLine($"(avg: {name.Value.Average():F2})");
            }
        }
    }
}
