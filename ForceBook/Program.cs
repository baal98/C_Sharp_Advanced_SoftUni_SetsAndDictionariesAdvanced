//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace ForceBook
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Dictionary<string, List<string>> forcesDict = new Dictionary<string, List<string>>();

//            string input;
//            char possibleCharDelimiter = '|';

//            while ((input = Console.ReadLine()) != "Lumpawaroo")
//            {

//                string[] splittedInput;

//                if (input.Contains(possibleCharDelimiter))
//                {
//                    splittedInput = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

//                    string forceSide = splittedInput[0];

//                    string forceUser = splittedInput[1];

//                    if (!forcesDict.ContainsKey(forceSide))
//                    {
//                        forcesDict.Add(forceSide, new List<string> { { forceUser } });
//                    }
//                    else
//                    {
//                        if (!forcesDict[forceSide].Contains(forceUser))
//                        {
//                            forcesDict[forceSide].Add(forceUser);
//                        }
//                    }
//                }
//                else
//                {
//                    splittedInput = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

//                    string forceUser = splittedInput[0];

//                    string forceSide = splittedInput[1];

//                    foreach (var side in forcesDict)//Light
//                    {
//                        var currentListOfUsers = side.Value;//List of user

//                        foreach (var user in currentListOfUsers)// minavash prez vsichki uzseri
//                        {
//                            if (user == forceUser)
//                            {
//                                forcesDict[side.Key].Remove(forceUser);
//                                break;
//                            }
//                        }
//                    }

//                    if (!forcesDict.ContainsKey(forceSide))
//                    {
//                        forcesDict.Add(forceSide, new List<string>());
//                    }
//                    forcesDict[forceSide].Add(forceUser);
//                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

//                }
//            }

//            foreach (var side in forcesDict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
//            {
//                var currentForceSide = side.Key;
//                var currentForceSideMembers = side.Value.Count;

//                if (currentForceSideMembers == 0)
//                {
//                    continue;
//                }

//                Console.WriteLine($"Side: {currentForceSide}, Members: {currentForceSideMembers}");

//                foreach (var member in side.Value.OrderBy(x => x))
//                {
//                    Console.WriteLine($"! {member}");
//                }

//            }
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ForceBook
{
    public class ForceBook
    {
        public static void Main()
        {
            Dictionary<string, SortedSet<string>> forces = new Dictionary<string, SortedSet<string>>();
            Dictionary<string, string> userByForces = new Dictionary<string, string>();

            string pattern1 = @"(?'side'.+?) (?:\|) (?'user'.+)";
            string pattern2 = @"(?'user'.+?) (?:\->) (?'side'.+)";
            Regex p1 = new Regex(pattern1);
            Regex p2 = new Regex(pattern2);

            string command;

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                if (p1.IsMatch(command))
                {
                    MatchCollection m = p1.Matches(command);
                    string side = string.Empty;
                    string user = string.Empty;

                    foreach (Match match in m)
                    {
                        side = match.Groups["side"].Value;
                        user = match.Groups["user"].Value;
                    }

                    if (!userByForces.ContainsKey(user))
                    {
                        userByForces[user] = side;

                        if (!forces.ContainsKey(side))
                        {
                            forces.Add(side, new SortedSet<string>());
                        }
                        forces[side].Add(user);
                    }

                }

                else if (p2.IsMatch(command))
                {
                    MatchCollection m = p2.Matches(command);
                    string side = string.Empty;
                    string user = string.Empty;

                    foreach (Match match in m)
                    {
                        side = match.Groups["side"].Value;
                        user = match.Groups["user"].Value;
                    }

                    if (!userByForces.ContainsKey(user))
                    {
                        Console.WriteLine($"{user} joins the {side} side!");
                        userByForces[user] = side;
                        if (!forces.ContainsKey(side))
                        {
                            forces.Add(side, new SortedSet<string>());
                        }
                        forces[side].Add(user);
                    }
                    else
                    {
                        string oldSide = userByForces[user];
                        if (oldSide != side)
                        {
                            forces[userByForces[user]].Remove(user);
                            if (!forces.ContainsKey(side))
                            {
                                forces.Add(side, new SortedSet<string>());
                            }
                            forces[side].Add(user);
                            userByForces[user] = side;
                            Console.WriteLine($"{user} joins the {side} side!");
                        }
                    }
                }
            }

            var orderedForces = forces.OrderByDescending(f => f.Value.Count).ThenBy(name => name.Key);
            foreach (var force in orderedForces)
            {
                if (force.Value.Any())
                {
                    Console.WriteLine($"Side: {force.Key}, Members: {force.Value.Count}");
                    foreach (var name in force.Value)
                    {
                        Console.WriteLine($"! {name}");
                    }
                }
            }
        }
    }
}