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
            string text = System.IO.File.ReadAllText(@"C:\Users\Astghik\Desktop\math.txt");
            string mathExp =  @"(\d{1,})(\+|\-|\*|\/)(\d{1,})";
            string group;
            int result;
            foreach (Match match in Regex.Matches(text, mathExp))
            {
                group = match.Groups[2].ToString();

                switch (group)
                {
                    case "+":
                        result = Int32.Parse(match.Groups[1].Value) + Int32.Parse(match.Groups[3].Value);
                        text = text.Replace(match.Value, match.Value + "=" + result.ToString());
                        break;
                    case "-":
                        result = Int32.Parse(match.Groups[1].Value) - Int32.Parse(match.Groups[3].Value);
                        text = text.Replace(match.Value, match.Value + "=" + result.ToString());
                        break;
                    case "*":
                        result = Int32.Parse(match.Groups[1].Value) * Int32.Parse(match.Groups[3].Value);
                        text = text.Replace(match.Value, match.Value + "=" + result.ToString());
                        break;
                    case "/":
                        result = Int32.Parse(match.Groups[1].Value) / Int32.Parse(match.Groups[3].Value);
                        text = text.Replace(match.Value, match.Value + "=" + result.ToString());
                        break;
                }

            }
            Console.WriteLine(text);
        }
        static void  Task1() 
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Astghik\Desktop\licenseplates.txt");
            string pattern =  @"\d{2}[A-Z]{2}\d{3}";
            foreach (Match match in Regex.Matches(text, pattern))
            {
                Console.Write(match + " ");


            }
            Console.WriteLine();
        }

        static void Task2()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Astghik\Desktop\userdata.txt");
            string pattern = @"[A-Z]{2}\d{7}";
            string patternDig = @"\d{7}";
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
 