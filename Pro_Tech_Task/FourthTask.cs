using PRO_Tech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PRO_Tech
{
    class FourthTask : SecondTask
    {
        /* необходимо найти в обработанной строке наибольшую подстроку, которая начинается и заканчивается на гласную букву из «aeiouy»
         * a -> aa -> aa
         * abcdef -> cbafed -> afe
         * adcde - > edcbaabcde -> edcbaabcde
        */

        public static void PrintLargSubstring(string inputString)
        {
            string resultConcat = FindSubstring(inputString);
            if (result)
            {
                Console.WriteLine($"Поиск самой длинной подстроки начинающуюся и заканчивающуюся на гласный символ: {resultConcat}");
            }
        }

        public static string FindSubstring(string inputString)
        {
            int firstIndex = -1; // Первый индекс гласного символа
            int lastIndex = -1; // Последний индекс гласного символа
            string resultConcat = ""; // Строка результата соединения
            for (int i = 0; i < inputString.Length; i++)
            {
                char c = inputString[i];
                if ("aeiouy".Contains(c) && firstIndex == -1)
                {
                    firstIndex = i;
                }
                if ("aeiouy".Contains(c))
                {
                    lastIndex = i;
                }
            }
            if (firstIndex != -1)
            {
                for (int j = firstIndex; j <= lastIndex; j++) // Цикл соединения строка Первый индекс гласного символа ++ Последнего гласного символа
                {
                    resultConcat += inputString[j];
                }
                return resultConcat;
            }
            else
            {
                return "Гласных нет";
            }
        }
    }
}
