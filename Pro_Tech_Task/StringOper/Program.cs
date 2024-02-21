using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pro_Tech_Task.StringOper
{
    public class Program
    {
        /*    Создать приложение, которое на вход будет получать строку.
         *    Четная строка - программа должна разделить её на две подстроки, каждую подстроку перевернуть и соединять обратно обе подстроки в одну строку.
         *    Нечетная строка - программа должна перевернуть эту строку и к ней добавить изначальную строку, которую ввёл пользователь.
         *    a -> aa
         *    abcdef -> cbafed
         *    abcde -> edcbaabcde
        */

        static async Task Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string s = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s))
            {
                s = "teststring";
            }

            StringOperation oper = new StringOperation(s);
            Console.WriteLine(oper.InputString);


            await oper.Print();
        }
    }
    public class StringOperation
    {
        private bool check = false;
        public string InputString { get; set; }
        public string ModString { get; set; }
        public StringOperation(string? inputString)
        {
            InputString = inputString;
        }

        public async Task Print()
        {
            RandomNumber rnd = new RandomNumber();
            Sort sort = new Sort();

            List<char> list = new List<char>(isTrueString());
            string result = StringSplit();
            Dictionary<char, int> dict = new Dictionary<char, int>(CountPrint(ModString));

            string largSubstring = FindLargestVowelSubstring(ModString);
            if (check)
            {
                Console.WriteLine("Ошибочные символы:");
                foreach (char c in list)
                {
                    Console.WriteLine(c);
                }
            }
            else
            {
                Console.WriteLine($"Результат строки - {result}");
                Console.WriteLine($"Наибольшая подстрока - {largSubstring}");
                foreach (var pair in dict)
                {
                    Console.WriteLine($"Символ '{pair.Key}' встречается {pair.Value} раз.");
                }
                sort.ChooseSort(InputString);
                await Console.Out.WriteLineAsync(await rnd.RemoveChar(InputString));

            }
        }

        public HashSet<char> isTrueString()
        {
            HashSet<char> result = new HashSet<char>();
            foreach (char c in InputString)
            {
                if (!Regex.IsMatch(c.ToString(), @"[a-z]"))
                {

                    result.Add(c);
                }
            }
            if (result.Count > 0)
            {
                check = true;
            }
            return result;
        }

        public string StringSplit()
        {
            StringBuilder result = new StringBuilder();
            int split = InputString.Length / 2;
            if (InputString.Length % 2 == 0)
            {
                result.Append(InputString.Remove(split).Reverse().ToArray());
                result.Append(InputString.Remove(0, split).Reverse().ToArray());
                ModString = result.ToString();
                return result.ToString();
            }
            else
            {
                result.Append(InputString.Reverse().ToArray()).Append(InputString);
                ModString = result.ToString();
                return result.ToString();
            }
        }


        public Dictionary<char, int> CountPrint(string inputString)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (var item in inputString)
            {
                if (charCount.ContainsKey(item))
                {
                    charCount[item]++;
                }
                else
                {
                    charCount[item] = 1;
                }
            }
            return charCount;
        }

        public string FindLargestVowelSubstring(string inputString)
        {
            string pattern = @"[aeiouy]";
            int check = 0;
            int first = 0;
            int last = 0;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (Regex.IsMatch(inputString[i].ToString(), pattern))
                {
                    check++;
                    last = i;
                }
            }
            for (int i = 0; i < inputString.Length; i++)
            {
                if (Regex.IsMatch(inputString[i].ToString(), pattern))
                {

                    first = i;
                    break;
                }
            }
            if (check >= 1)
            {
                string result = inputString.Substring(first, last - first + 1);
                return result;
            }
            return "Гласных нет";
        }
    }
}
