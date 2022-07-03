using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());

        var dicContinents = new Dictionary<string, Dictionary<string, List<string>>>();

        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');

            string continent = inputs[0];
            string country = inputs[1];
            string city = inputs[2];

            if (!dicContinents.ContainsKey(continent))
            {
                dicContinents[continent] = new Dictionary<string, List<string>>();
                dicContinents[continent].Add(country, new List<string>());
                dicContinents[continent][country].Add(city);
            }
            else if (!dicContinents[continent].ContainsKey(country))
            {
                dicContinents[continent][country] = new List<string>();
                dicContinents[continent][country].Add(city);
            }
            else
            {
                dicContinents[continent][country].Add(city);
            }
        }
        foreach (var continent in dicContinents)
        {
            Console.WriteLine($"{continent.Key}:");
            foreach (var country in dicContinents[continent.Key])
            {
                Console.WriteLine($"\t{country.Key} -> {string.Join(", ", country.Value)}");
            }
        }
    }
}
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace Cities_by_Continent_and_Country
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int numberOfInputs = int.Parse(Console.ReadLine());

//            Dictionary<string, Dictionary<string, List<string>>> dicContinents = new Dictionary<string, Dictionary<string, List<string>>>();

//            for (int i = 0; i < numberOfInputs; i++)
//            {
//                List<string> inputs = Console.ReadLine().Split().ToList();

//                string continents = inputs[0];
//                string country = inputs[1];
//                string city = inputs[2];

//                if (!dicContinents.ContainsKey(continents))
//                {

//                    dicContinents.Add(continents, new Dictionary<string, List<string>> { {country, new List<string> { city} } });
//                }
//                else
//                {
//                    if (!dicContinents[continents].ContainsKey(country))
//                    {
//                        dicContinents[continents].Add(country, new List<string> { city });
//                    }
//                    else
//                    {
//                        dicContinents[continents][country].Add(city);
//                    }
//                }

//            }

//            foreach (var continent in dicContinents)
//            {
//                Console.WriteLine(continent.Key + ":");

//                foreach (var country in dicContinents[continent.Key])
//                {
//                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
//                }

//            }
//        }
//    }
//}
