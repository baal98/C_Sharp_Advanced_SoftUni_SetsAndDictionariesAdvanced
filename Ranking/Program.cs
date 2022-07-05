using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Student
{
    public Student(string name, Dictionary<string, int> content, string password, int totalPoints)
    {
        this.Name = name;
        this.Content = content;
        this.Password = password;
        this.TotalPoints = totalPoints;
    }

    public string Name { get; set; }
    public Dictionary<string, int> Content { get; set; }
    public string Password { get; set; }
    public int TotalPoints { get; set; }
}
internal class Program
{
    static void Main()
    {
        Dictionary<string, string> dicContent = new Dictionary<string, string>();

        string command;

        while ((command = Console.ReadLine()) != "end of contests")
        {
            string[] inputs = command.Split(':', StringSplitOptions.RemoveEmptyEntries);
            string contest = inputs[0];
            string passwordContest = inputs[1];

            if (!dicContent.ContainsKey(contest))
            {
                dicContent[contest] = passwordContest;
            }
        }

        SortedDictionary<string, Student> dicStudents = new SortedDictionary<string, Student>();

        while ((command = Console.ReadLine()) != "end of submissions")
        {
            string[] input = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

            if (input.Length != 4)
            {
                continue;
            }
            string contest = input[0];
            string password = input[1];
            string username = input[2];
            int points = int.Parse(input[3]);

            if (!IsValidContent(contest, password, dicContent))
            {
                continue;
            }
            Student student = new Student(username, new Dictionary<string, int> { { contest, points } }, password, 0);

            if (!dicStudents.ContainsKey(student.Name))
            {
                dicStudents[student.Name] = student;
                student.TotalPoints = points;
            }
            else
            {
                if (dicStudents[student.Name].Content.ContainsKey(contest) && dicStudents[student.Name].Content[contest] < points)
                {
                    student.TotalPoints += points - dicStudents[student.Name].Content[contest];
                    dicStudents[student.Name].Content[contest] = points;
                }
                if (!dicStudents[student.Name].Content.ContainsKey(contest))
                {
                    dicStudents[student.Name].Content.Add(contest, points);
                    student.TotalPoints += points;
                }
            }

        }

        int maxPoint = 0;
        string bestStudent = "";

        foreach (var student in dicStudents.Values)
        {
            int sum = 0;
            foreach (var pair in student.Content)
            {
                sum += pair.Value;
            }
            if (sum > maxPoint)
            {
                maxPoint = sum;
                bestStudent = student.Name;
            }
        }

        Console.WriteLine($"Best candidate is {bestStudent} with total {maxPoint} points.");
        Console.WriteLine("Ranking:");

        foreach (var kvp in dicStudents)
        {
            Console.WriteLine(kvp.Key);
            foreach (var contest in kvp.Value.Content.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
            }
        }
    }

    private static bool IsValidContent(string contest, string password, Dictionary<string, string> dicContent)
    {
        if (dicContent.ContainsKey(contest))
        {
            if (dicContent[contest] == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace Ranking
//{
//    class User
//    {
//        public User(string name, int points, Dictionary<string, int> dic)
//        {
//            this.Name = name;
//            this.Points = points;
//            this.DictionaryContest = new Dictionary<string, int>();
//        }
//        public Dictionary<string, int> DictionaryContest { get; set; }
//        public string Name { get; set; }
//        public int Points { get; set; }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Dictionary<string, string> dicContest = new Dictionary<string, string>();

//            string command;

//            while ((command = Console.ReadLine()) != "end of contests")
//            {
//                string[] inputs = command.Split(':');
//                string contest = inputs[0];
//                string password = inputs[1];

//                if (IsValidInputs(contest) || IsValidInputs(password))
//                {
//                    continue;
//                }

//                if (!dicContest.ContainsKey(contest))
//                {
//                    dicContest.Add(contest, password);
//                }
//            }

//            Dictionary<string, User> dicUsers = new Dictionary<string, User>();

//            while ((command = Console.ReadLine()) != "end of submissions")
//            {
//                string[] inputs = command.Split("=>");
//                string contest = inputs[0];
//                string password = inputs[1];
//                string username = inputs[2];
//                int points = int.Parse(inputs[3]);

//                if (IsValidInputs(contest) || IsValidInputs(password) || IsValidInputs(username)
//                    || IsValidContents(contest, password, dicContest))
//                {
//                    continue;
//                }
//                Dictionary<string, int> contestDic = new Dictionary<string, int> { { contest, points } };
//                User user = new User(username, 0, contestDic);

//                if (!dicUsers.ContainsKey(username))
//                {
//                    user.DictionaryContest = contestDic;
//                    dicUsers.Add(username, user);
//                }
//                else
//                {
//                    if (!dicUsers[username].DictionaryContest.ContainsKey(contest))
//                    {
//                        dicUsers[username].DictionaryContest.Add(contest, points);
//                    }
//                    else
//                    {
//                        if (points > dicUsers[username].DictionaryContest[contest])
//                        {
//                            dicUsers[username].DictionaryContest[contest] = points;
//                        }
//                    }
//                }
//                dicUsers[username].Points += points;
//            }

//            foreach (var user in dicUsers.OrderByDescending(x => x.Value.Points))
//            {
//                Console.WriteLine($"Best candidate is {user.Key} with total {user.Value.Points} points.");
//                break;
//            }
//            Console.WriteLine("Ranking:");
//            foreach (var user in dicUsers.OrderBy(x => x.Value.Name))
//            {
//                Console.WriteLine(user.Key);
//                foreach (var contents in user.Value.DictionaryContest.OrderByDescending(x => x.Value))
//                {
//                    Console.WriteLine($"#  {contents.Key} -> {contents.Value}");
//                }
//            }
//        }
//        static bool IsValidInputs(string contest)
//        {
//            if (contest.Contains(':'))
//            {
//                return true;
//            }
//            else if (contest.Contains('='))
//            {
//                return true;
//            }
//            else if (contest.Contains('>'))
//            {
//                return true;
//            }
//            return false;
//        }
//        static bool IsValidContents(string contest, string password, Dictionary<string, string> dicUsers)

//        {
//            if (!dicUsers.ContainsKey(contest))
//            {
//                return true;
//            }
//            if (!dicUsers[contest].Contains(password))
//            {
//                return true;
//            }
//            return false;
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace SoftUni
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var command = Console.ReadLine();
//            var contestDictionary = new Dictionary<string, string>();

//            while (command != "end of contests")
//            {
//                AddContest(command, contestDictionary);

//                command = Console.ReadLine();
//            }

//            command = Console.ReadLine();
//            var userDictionary = new Dictionary<string, Dictionary<string, int>>();

//            while (command != "end of submissions")
//            {
//                AddStudentInfoForContest(command, contestDictionary, userDictionary);

//                command = Console.ReadLine();
//            }

//            PrintResult(userDictionary);
//        }

//        public static void AddContest(string command, Dictionary<string, string> contestDictionary)
//        {
//            var splittedComamndArrya = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
//            var contest = splittedComamndArrya[0];
//            var password = splittedComamndArrya[1];

//            if (!contestDictionary.ContainsKey(contest))
//            {
//                contestDictionary.Add(contest, password);
//            }
//            else
//            {
//                contestDictionary[contest] = password;
//            }
//        }

//        public static void AddStudentInfoForContest(string command, Dictionary<string, string> contestDictionary, Dictionary<string, Dictionary<string, int>> userDictionary)
//        {
//            var splittedComamndArrya = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
//            var contest = splittedComamndArrya[0];
//            var password = splittedComamndArrya[1];
//            var username = splittedComamndArrya[2];
//            var points = int.Parse(splittedComamndArrya[3]);

//            if (contestDictionary.ContainsKey(contest) && contestDictionary[contest] == password)
//            {
//                if (!userDictionary.ContainsKey(username))
//                {
//                    var userContestDictionary = new Dictionary<string, int> { { contest, points } };

//                    userDictionary.Add(username, userContestDictionary);
//                }
//                else
//                {
//                    if (!userDictionary[username].ContainsKey(contest))
//                    {
//                        userDictionary[username].Add(contest, points);
//                    }
//                    else
//                    {
//                        var oldPointForContest = userDictionary[username][contest];

//                        if (points > oldPointForContest)
//                        {
//                            userDictionary[username][contest] = points;
//                        }
//                    }
//                }
//            }
//        }

//        public static void PrintResult(Dictionary<string, Dictionary<string, int>> userDictionary)
//        {
//            var best = userDictionary.OrderByDescending(x => x.Value.Sum(y => y.Value)).First();

//            System.Console.WriteLine($"Best candidate is {best.Key} with total {best.Value.Sum(y => y.Value)} points.");
//            System.Console.WriteLine("Ranking: ");

//            foreach (var user in userDictionary.OrderBy(x => x.Key))
//            {
//                System.Console.WriteLine(user.Key);
//                foreach (var userContest in user.Value.OrderByDescending(x => x.Value))
//                {
//                    System.Console.WriteLine($"#  {userContest.Key} -> {userContest.Value}");
//                }
//            }
//        }
//    }
//}