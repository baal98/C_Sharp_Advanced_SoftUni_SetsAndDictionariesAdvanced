using System;
using System.Collections.Generic;
using System.Linq;

class User
{
    public User(string name, Dictionary<string, int> languagesPoints)
    {
        this.Name = name;
        this.LanguagesPoints = languagesPoints;
    }

    public string Name { get; set; }
    public Dictionary<string, int> LanguagesPoints { get; set; }

}
class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, User> dicUsers = new Dictionary<string, User>();
        Dictionary<string, int> dicLanguages = new Dictionary<string, int>();

        string command;

        while ((command = Console.ReadLine()) != "exam finished")
        {
            var inputs = command.Split('-');

            string name = inputs[0];
            string language = inputs[1];
            if (inputs[1] == "banned")
            {
                if (dicUsers.ContainsKey(name))
                {
                    dicUsers.Remove(name);
                }
                continue;
            }

            int point = int.Parse(inputs[2]);

            User user = new User(name, new Dictionary<string, int> { { language, point } });

            if (!dicLanguages.ContainsKey(language))
            {
                dicLanguages[language] = 1;
            }
            else
            {
                dicLanguages[language]++;
            }
            if (!dicUsers.ContainsKey(name))
            {
                dicUsers[name] = user;
            }
            else
            {
                if (!dicUsers[name].LanguagesPoints.ContainsKey(language))
                {
                    dicUsers[name].LanguagesPoints.Add(language, point);
                }
                else
                {
                    if (dicUsers[name].LanguagesPoints[language] < point)
                    {
                        dicUsers[name].LanguagesPoints[language] = point;
                    }
                }
            }
        }
        if (dicUsers.Count > 0)
        {
            Console.WriteLine("Results:");
            foreach (var user in dicUsers.OrderByDescending(x => x.Value.LanguagesPoints.Values.Sum()).ThenBy(x => x.Value.Name))
            {
                int sumPoints = 0;
                foreach (var language in user.Value.LanguagesPoints)
                {
                    sumPoints += language.Value;
                }
                Console.WriteLine($"{user.Value.Name} | {sumPoints}");
            }
            Console.WriteLine("Submissions:");
            foreach (var language in dicLanguages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace _09._SoftUni_Exam_Results
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Dictionary<string, int> participantsInTheContest = new Dictionary<string, int>();

//            Dictionary<string, int> languagesAndNumerOfSubmitions = new Dictionary<string, int>();

//            string command;

//            while ((command = Console.ReadLine()) != "exam finished")
//            {
//                string[] input = command.Split('-');
//                string userName = input[0];

//                if (input[1] == "banned")
//                {
//                    participantsInTheContest.Remove(userName);
//                    continue;
//                }

//                string language = input[1];
//                int points = int.Parse(input[2]);

//                if (!participantsInTheContest.ContainsKey(userName))
//                {
//                    participantsInTheContest.Add(userName, points);
//                }
//                else
//                {
//                    if (participantsInTheContest[userName] < points)
//                    {
//                        participantsInTheContest[userName] = points;
//                    }
//                }

//                if (!languagesAndNumerOfSubmitions.ContainsKey(language))
//                {
//                    languagesAndNumerOfSubmitions.Add(language, 0);
//                }

//                languagesAndNumerOfSubmitions[language]++;

//            }

//            var orderedUsersDict = participantsInTheContest.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

//            Console.WriteLine("Results:");

//            foreach (var participant in orderedUsersDict)
//            {
//                Console.WriteLine($"{participant.Key} | {participant.Value}");
//            }

//            var orderedLanguageDict = languagesAndNumerOfSubmitions.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

//            Console.WriteLine("Submissions:");

//            foreach (var language in orderedLanguageDict)
//            {
//                Console.WriteLine($"{language.Key} - {language.Value}");
//            }
//        }
//    }
//}