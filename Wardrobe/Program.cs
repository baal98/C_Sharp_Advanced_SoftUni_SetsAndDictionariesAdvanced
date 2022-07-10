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

        Dictionary<string, Dictionary<string, int>> dicClothes = new Dictionary<string, Dictionary<string, int>>();

        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] inputs = Console.ReadLine().Split(" -> ");

            if (!dicClothes.ContainsKey(inputs[0]))
            {
                Dictionary<string, int> clothes = new Dictionary<string, int>();
                for (int j = 0; j < inputs[1].Split(",").Length; j++)
                {
                    dicClothes[inputs[0]] = clothes;
                    if (!dicClothes[inputs[0]].ContainsKey(inputs[1].Split(",")[j]))
                    {
                        dicClothes[inputs[0]][inputs[1].Split(",")[j]] = 1;
                    }
                    else
                    {
                        dicClothes[inputs[0]][inputs[1].Split(",")[j]]++;
                    }
                }
            }
            else
            {
                for (int j = 0; j < inputs[1].Split(",").Length; j++)
                {
                    if (!dicClothes[inputs[0]].ContainsKey(inputs[1].Split(",")[j]))
                    {
                        dicClothes[inputs[0]][inputs[1].Split(",")[j]] = 1;
                    }
                    else
                    {
                        dicClothes[inputs[0]][inputs[1].Split(",")[j]]++;
                    }
                }
            }
        }
        string[] searchedItems = Console.ReadLine().Split();
        string searchedColour = searchedItems[0];
        string searchedClothe = searchedItems[1];

        foreach (var colour in dicClothes)
        {
            Console.WriteLine($"{colour.Key} clothes:");

            foreach (var clothe in dicClothes[colour.Key])
            {
                if (searchedColour == colour.Key && searchedClothe == clothe.Key)
                {
                    Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                }
                else
                {
                    Console.WriteLine($"* {clothe.Key} - {clothe.Value}");
                }
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

//namespace Wardrobe
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int numberOfInputs = int.Parse(Console.ReadLine());

//            Dictionary<string, Dictionary<string, int>> clothesDic = new Dictionary<string, Dictionary<string, int>>();

//            for (int i = 0; i < numberOfInputs; i++)
//            {
//                string[] inputs = Console.ReadLine().Split(" -> ");

//                string colour = inputs[0];
//                string[] clothesArr = inputs[1].Split(",");

//                for (int j = 0; j < clothesArr.Length; j++)
//                {
//                    string clothes = clothesArr[j];
//                    if (!clothesDic.ContainsKey(colour))
//                    {
//                        clothesDic[colour] = new Dictionary<string, int> { { clothes, 1 } };
//                    }
//                    else
//                    {
//                        if (!clothesDic[colour].ContainsKey(clothes))
//                        {
//                            clothesDic[colour][clothes] = 1;
//                        }
//                        else
//                        {
//                            clothesDic[colour][clothes]++;
//                        }
//                    }
//                }
//            }

//            string[] searchedClothes = Console.ReadLine().Split();
//            string searchedColour = searchedClothes[0];
//            string searchedWear = searchedClothes[1];

//            foreach (var colour in clothesDic)
//            {
//                bool isSearchedColour = false;
//                string colourName = colour.Key;
//                if (searchedColour == colourName)
//                {
//                    isSearchedColour = true;
//                }
//                string wear = "";
//                int wearNumber = 0;
//                Console.WriteLine($"{colour.Key} clothes:");

//                foreach (var item in colour.Value)
//                {
//                    bool isSearchedWear = false;
//                    wear = item.Key;
//                    wearNumber = item.Value;
//                    if (searchedWear == wear)
//                    {
//                        isSearchedWear = true;
//                    }
//                    if (isSearchedWear && isSearchedColour)
//                    {
//                        Console.WriteLine($"* {wear} - {wearNumber} (found!)");
//                        continue;
//                    }
//                    Console.WriteLine($"* {wear} - {wearNumber}");
//                }
//            }
//        }
//    }
//}
