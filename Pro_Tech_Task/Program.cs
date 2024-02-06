using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PRO_Tech;
using Pro_Tech_Task;

namespace PRO_Tech
{
    public class FirstTask
    {
        /*    Создать приложение, которое на вход будет получать строку.
         *    Четная строка - программа должна разделить её на две подстроки, каждую подстроку перевернуть и соединять обратно обе подстроки в одну строку.
         *    Нечетная строка - программа должна перевернуть эту строку и к ней добавить изначальную строку, которую ввёл пользователь.
         *    a -> aa
         *    abcdef -> cbafed
         *    abcde -> edcbaabcde
        */

        async static Task Main(string[] args)
        {
            string s = "asdasdad";
            await Console.Out.WriteLineAsync(s);
            RandomNumber rnd = new RandomNumber();
            StringOperation oper = new StringOperation(s);
            Sort sort = new Sort();
            oper.Print();
            sort.ChooseSort(s);

            await Console.Out.WriteLineAsync(await rnd.RemoveChar(s));
        }
    }
    class StringOperation
    {
        private bool check = false;

        public string InputString { get; set; }
        public StringOperation(string inputString)
        {
            this.InputString = inputString;
        }

        public void Print()
        {
            List<char> list = new List<char>(isTrueString());
            Dictionary<char,int> dict = new Dictionary<char,int>(CountPrint());
            string result = StringSplit();
            string largSubstring = FindLargestVowelSubstring(result);
            if(check)
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
            }
        }

        private HashSet<char> isTrueString()
        {
            HashSet<char> result = new HashSet<char>();
            foreach(char c in InputString)
            {
                if (!Regex.IsMatch(c.ToString(), @"[a-z]"))
                {
                    
                    result.Add(c);
                }
            }
            if(result.Count > 0)
            {
                check = true;
            }
            return result;
        }

        private string StringSplit()
        {
            StringBuilder result = new StringBuilder();

            if (InputString.Length % 2 == 0)
            {
                foreach (char c in InputString.Substring(0, InputString.Length / 2).ToCharArray().Reverse())
                {
                    result.Append(c);
                }
                foreach (char c in InputString.Substring(InputString.Length / 2).ToCharArray().Reverse())
                {
                    result.Append(c);
                }
            }
            else
            {
                foreach (char c in InputString.ToCharArray().Reverse())
                {
                    result.Append(c);
                }
                result.Append(InputString);
            }

            return result.ToString();
        }


        private Dictionary<char,int> CountPrint()
        {
            Dictionary<char, int> charCount = new Dictionary<char,int>();
            foreach (var item in InputString)
            {
                if(charCount.ContainsKey(item))
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

        private string FindLargestVowelSubstring(string InputString)
        {
            string pattern = @"[aeiouy]";
            MatchCollection matches = Regex.Matches(InputString, pattern);
            string vowels = string.Concat(matches.Select(m => m.Value));

            if (string.IsNullOrEmpty(vowels))
            {
                return string.Empty;
            }

            int maxSubstringLength = 0;
            string largestSubstring = string.Empty;

            foreach (Match match in matches)
            {
                int startIndex = match.Index;
                int endIndex = InputString.LastIndexOf(match.Value);

                if (endIndex - startIndex + 1 > maxSubstringLength)
                {
                    maxSubstringLength = endIndex - startIndex + 1;
                    largestSubstring = InputString.Substring(startIndex, maxSubstringLength);
                }
            }

            return largestSubstring;
        }
    }
}
