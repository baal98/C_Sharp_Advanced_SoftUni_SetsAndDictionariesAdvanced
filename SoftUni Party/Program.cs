//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace SoftUni_Party
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            HashSet<string> vipCards = new HashSet<string>();

//            string command;
//            bool isTrue = false;
//            while ((command = Console.ReadLine()) != "END")
//            {
//                if (command == "PARTY")
//                {
//                    while (true)
//                    {
//                        if (command == "END")
//                        {
//                            isTrue = true;
//                            break;
//                        }
//                        if (vipCards.Contains(command))
//                        {
//                            vipCards.Remove(command);
//                        }
//                        command = Console.ReadLine();
//                    }
//                }
//                else if(command.Length == 8 && command != "PARTY")
//                {
//                    vipCards.Add(command);
//                }
//                if (isTrue)
//                {
//                    break;
//                }
//            }
//            Console.WriteLine(vipCards.Count);

//            HashSet<string> regularCards = new HashSet<string>();
//            foreach (var card in vipCards)
//            {
//                if (!IsDigit(card))
//                {
//                    regularCards.Add(card);
//                    vipCards.Remove(card);
//                }
//            }
//            foreach (string card in vipCards)
//            {
//                Console.WriteLine(card);
//            }
//            foreach (string card in regularCards)
//            {
//                Console.WriteLine(card);
//            }
//        }
//        static bool IsDigit(string card)
//        {
//            if (card.StartsWith("0"))
//            {
//                return true;
//            }
//            else if (card.StartsWith("1"))
//            {
//                return true;
//            }
//            else if (card.StartsWith("2"))
//            {
//                return true;
//            }
//            else if (card.StartsWith("3"))
//            {
//                return true;
//            }
//            else if (card.StartsWith("4"))
//            {
//                return true;
//            }
//            else if (card.StartsWith("5"))
//            {
//                return true;
//            }
//            else if (card.StartsWith("6"))
//            {
//                return true;
//            }
//            else if (card.StartsWith("7"))
//            {
//                return true;
//            }
//            else if (card.StartsWith("8"))
//            {
//                return true;
//            }
//            else if (card.StartsWith("9"))
//            {
//                return true;
//            }
//            return false;
//        }
//    }
//}


using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            string command;


            while ((command = Console.ReadLine()) != "PARTY")
            {
                //isValid
                if (command.Length != 8)
                {
                    continue;
                }
                else
                {
                    //isVIP
                    if (IsReservationVipType(command))
                    {
                        vipGuests.Add(command);
                    }
                    else
                    {
                        regularGuests.Add(command);
                    }
                }
            }

            while ((command = Console.ReadLine()) != "END")
            {
                if (vipGuests.Contains(command))
                {
                    vipGuests.Remove(command);
                }
                else if (regularGuests.Contains(command))
                {
                    regularGuests.Remove(command);
                }
            }
            var totalCount = vipGuests.Count + regularGuests.Count;
            Console.WriteLine(totalCount);

            foreach (var item in vipGuests)
            {
                Console.WriteLine(item);
            }

            foreach (var item in regularGuests)
            {
                Console.WriteLine(item);
            }
        }
        static bool IsReservationVipType(string command)
        {
            if (char.IsDigit(command[0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

