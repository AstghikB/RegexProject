using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace regex
{
    class Program
    {
        static void Main(string[] args)
        {
            Task3();
            Console.WriteLine("************************************************");
            Console.WriteLine( );
            Task1();
            Console.WriteLine();
            Console.WriteLine("************************************************");
            Task2();
        }


        static void Task3()
        {
            string text = System.IO.File.ReadAllText(@"files/math.txt");
            string mathExp =  @"(\d{1,})(\+|\-|\*|\/)(\d{1,})";
            var actions = new Dictionary<string, Func<string, string, int>>();
            actions.Add("+", (s1, s2) =>
            {
                return int.Parse(s1) + int.Parse(s2);
            });
            actions.Add("-", (s1, s2) =>
            {
                return int.Parse(s1) - int.Parse(s2);
            });
            actions.Add("/", (s1, s2) =>
            {
                return int.Parse(s1) - int.Parse(s2);
            });
            actions.Add("*", (s1, s2) =>
            {
                return int.Parse(s1) * int.Parse(s2);
            });
            foreach (Match match in Regex.Matches(text, mathExp))
            {
                var group = match.Groups[2].ToString();
                var result = actions[group](match.Groups[1].Value, match.Groups[3].Value);
                Console.WriteLine($"{match.Value}={result}");
            }

        }
        static void  Task1() 
        {
            string text = System.IO.File.ReadAllText(@"files/licenseplates.txt");
            string pattern =  @"\d{2}[A-Z]{2}\d{3}";
            foreach (Match match in Regex.Matches(text, pattern))
            {
                Console.Write(match + " ");


            }
            Console.WriteLine();
        }

        static void Task2()
        {
            string text = System.IO.File.ReadAllText(@"files/userdata.txt");
            string pattern = @"[A-Z]{2}\d{7}";
            Regex reg = new Regex(pattern); 
            Regex regDig = new Regex(pattern);
            foreach (Match match in reg.Matches(text))
            {

                text = text.Replace(match.ToString(), match.Value.Substring(0, 2).ToString()+"*******");
            }

            Console.WriteLine(text);

        }
    }
}
 