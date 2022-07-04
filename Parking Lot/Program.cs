using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> car = new HashSet<string>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] inputs = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                //string[] param = Regex.Split(command, ", "); //this is the same as top one
                string action = inputs[0];
                string carNumbers = inputs[1];

                if (action == "IN")
                {
                    car.Add(carNumbers);
                }
                else if (action == "OUT")
                {
                    car.Remove(carNumbers);
                }
            }
            if (car.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (string carNumbers in car)
                    Console.WriteLine(carNumbers);
            }
        }
    }
}
