using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfUsers = int.Parse(Console.ReadLine());
            HashSet<string> users = new HashSet<string>();

            for (int i = 0; i < numberOfUsers; i++)
            {
                string user = Console.ReadLine();
                users.Add(user);
            }
            foreach (string user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}
