using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO_Tech
{
    class ThirdTask : SecondTask
    {
        /* Вывести информацио о том, сколько раз повторялся каждый символ в обработанной строке.
         * qwe -> ewqqwe -> q-2 w-2 e-2
         * qweEWУЦ12 -> не подходящие символы: EWУЦ12
         */

        public static void CountPrint(char[] inputString)
        {
            Dictionary<char, int> characterCount = new Dictionary<char, int>(); // Создаём коллекцию из пары ключей для символа и его количества в обработанной строке
            foreach (char c in inputString) // Проходимся по каждому символу в строке
            {
                if (characterCount.ContainsKey(c)) // Если символ уже есть в словаре, увеличиваем его счетчик
                {
                    characterCount[c]++;
                }
                else
                {
                    characterCount[c] = 1; // Если символа нет в словаре, добавляем его со счетчиком 1
                }
            }

            if (result) // Если условия из второго класса подходят под задачу, то выводим результат
            {
                foreach (var pair in characterCount)
                {
                    Console.WriteLine($"Символ '{pair.Key}' встречается {pair.Value} раз.");
                }
            }
        }
    }
}