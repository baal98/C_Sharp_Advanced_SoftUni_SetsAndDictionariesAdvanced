using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class VLoggers
{
    public VLoggers(string name, SortedSet<string> followers, SortedSet<string> following)
    {
        this.Name = name;
        this.Followers = new SortedSet<string>();
        this.Following = new SortedSet<string>();
    }
    public string Name { get; set; }
    public SortedSet<string> Followers { get; set; }
    public SortedSet<string> Following { get; set; }

}
internal class Program
{
    static void Main()
    {
        Dictionary<string, VLoggers> dicTheVLogger = new Dictionary<string, VLoggers>();

        string command;

        while ((command = Console.ReadLine()) != "Statistics")
        {
            string[] inputs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string vLoggerName = inputs[0];
            VLoggers vLogger = new VLoggers(vLoggerName, new SortedSet<string>(), new SortedSet<string>());

            if (inputs[1].ToLower() == "followed" && inputs.Length == 3)
            {
                string followersName = inputs[2];

                if (dicTheVLogger.ContainsKey(vLoggerName)
                    && dicTheVLogger.ContainsKey(followersName)
                    && followersName != vLoggerName
                    && !dicTheVLogger[vLoggerName].Following.Contains(followersName))
                {
                    dicTheVLogger[vLoggerName].Following.Add(followersName);
                    dicTheVLogger[followersName].Followers.Add(vLoggerName);
                }
            }
            else if (inputs[1].ToLower() == "joined")
            {
                if (!dicTheVLogger.ContainsKey(vLoggerName))
                {
                    dicTheVLogger[vLoggerName] = vLogger;
                }
            }
        }
        Console.WriteLine($"The V-Logger has a total of {dicTheVLogger.Count} vloggers in its logs.");

        int countVLoggers = 1;

        foreach (var vLoggerName in dicTheVLogger
            .OrderByDescending(x => x.Value.Followers.Count)
            .ThenBy(x => x.Value.Following.Count))
        {
            if (countVLoggers == 1)
            {
                Console.WriteLine($"{countVLoggers}. {vLoggerName.Key} : {vLoggerName.Value.Followers.Count} followers, {vLoggerName.Value.Following.Count} following");
                foreach (var vLogger in vLoggerName.Value.Followers)
                {
                    Console.WriteLine($"*  {vLogger}");
                }
            }
            else
            {
                Console.WriteLine($"{countVLoggers}. {vLoggerName.Key} : {vLoggerName.Value.Followers.Count} followers, {vLoggerName.Value.Following.Count} following");
            }
            countVLoggers++;
        }
    }
}
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace The_V_Logger
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Dictionary<string, HashSet<string>> dicVLoggers
//                = new Dictionary<string, HashSet<string>>();

//            string command;

//            while ((command = Console.ReadLine()) != "Statistics")
//            {
//                HashSet<string> setFollowingVlogger = new HashSet<string>();
//                if (command.Contains("joined"))
//                {
//                    Regex regex = new Regex(@"^\b([A-Za-z]+)\sjoined\b");
//                    Match match = regex.Match(command);
//                    string matched = match.ToString();
//                    string[] inputs = matched.Split(" ");
//                    string vloggername = inputs[0];

//                    if (!dicVLoggers.ContainsKey(vloggername))
//                    {
//                        dicVLoggers[vloggername] = new HashSet<string>();
//                    }
//                }
//                else if (command.Contains("followed"))
//                {
//                    Regex regex = new Regex(@"^(?'firstVlogger'[A-Za-z]+)\sfollowed\s(?'secondVlogger'[A-Za-z]+)$");
//                    MatchCollection matches = regex.Matches(command);
//                    string followingVlogger = "";
//                    string followedVlogger = "";

//                    foreach (Match match in matches)
//                    {
//                        followingVlogger = match.Groups["firstVlogger"].Value;
//                        followedVlogger = match.Groups["secondVlogger"].Value;
//                    }
//                    if (dicVLoggers.ContainsKey(followingVlogger) && dicVLoggers.ContainsKey(followedVlogger) && followingVlogger != followedVlogger)
//                    {
//                        dicVLoggers[followedVlogger].Add(followingVlogger);
//                    }
//                }

//            }
//            Console.WriteLine($"The V-Logger has a total of {dicVLoggers.Count} vloggers in its logs.");
//            bool isMostFamous = true;

//            foreach (var dicVLogger in dicVLoggers.OrderByDescending(x => x.Value.Count).ThenByDescending(x => x.Value.Contains(x.Key)))
//            {
//                int countFollowing = 0;
//                SortedSet<string> follower = new SortedSet<string>();
//                foreach (var vlogger in dicVLoggers)
//                {
//                    if (vlogger.Value.Contains(dicVLogger.Key))
//                    {
//                        countFollowing++;
//                    }
//                }
//                Console.WriteLine($"{dicVLogger.Key} : {dicVLogger.Value.Count} followers, {countFollowing} following");
//                if (isMostFamous)
//                {
//                    foreach (var item in dicVLogger.Value.OrderBy(x => x))
//                    {
//                        Console.WriteLine($"* {item}");
//                    }
//                    isMostFamous = false;
//                }

//            }
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace _07._The_V_Logger
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Dictionary<string, List<string>> vLoggers = new Dictionary<string, List<string>>();

//            Dictionary<string, int[]> numberOfFollowersDicr = new Dictionary<string, int[]>();

//            string vloggerInput = Console.ReadLine();

//            while (vloggerInput != "Statistics")
//            {
//                string[] splittedInput = vloggerInput.Split(' ');
//                string userName = splittedInput[0];
//                string command = splittedInput[1];

//                if (command.ToLower() == "joined")
//                {
//                    if (!vLoggers.ContainsKey(userName))
//                    {
//                        vLoggers[userName] = new List<string>();
//                        numberOfFollowersDicr[userName] = new int[2];
//                    }
//                }
//                else if (command.ToLower() == "followed")
//                {
//                    string userToFollow = splittedInput[2];
//                    if (vLoggers.ContainsKey(userName) && vLoggers.ContainsKey(userToFollow))
//                    {
//                        if (!vLoggers[userToFollow].Contains(userName) && userName != userToFollow)
//                        {
//                            vLoggers[userToFollow].Add(userName);
//                            numberOfFollowersDicr[userToFollow][0]++;
//                            numberOfFollowersDicr[userName][1]++;
//                        }
//                    }
//                }

//                vloggerInput = Console.ReadLine();
//            }

//            Console.WriteLine($"The V-Logger has a total of {vLoggers.Count} vloggers in its logs.");

//            Dictionary<string, int[]> orderedUserAndFollowers = numberOfFollowersDicr.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Value[1]).ToDictionary(x => x.Key, x => x.Value);

//            int raiting = 1;
//            string userToBeRemoved = "";

//            foreach (var vlogger in orderedUserAndFollowers)
//            {
//                userToBeRemoved = vlogger.Key;
//                Console.WriteLine($"{raiting}. {userToBeRemoved} : {vlogger.Value[0]} followers, {vlogger.Value[1]} following");
//                raiting++;

//                if (vLoggers[vlogger.Key].Count > 0)
//                {
//                    foreach (var follower in vLoggers[vlogger.Key].OrderBy(x => x))
//                    {
//                        Console.WriteLine($"*  {follower}");
//                    }
//                }
//                break;
//            }

//            orderedUserAndFollowers.Remove(userToBeRemoved);

//            foreach (var kvp in orderedUserAndFollowers)
//            {
//                Console.WriteLine($"{raiting}. {kvp.Key} : {kvp.Value[0]} followers, {kvp.Value[1]} following");
//                raiting++;
//            }


//        }
//    }
//}