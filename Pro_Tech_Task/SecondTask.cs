using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PRO_Tech;

namespace PRO_Tech
{
    public class SecondTask : FirstTask
    {
        /* Необходимо начать проверять входящую строку, чтобы в ней были только буквы из английского алфавита в нижнем регистре
         * qweQWEЙЦУ -> Ошибка
         * qwe -> ewqqwe
         */
        public static bool result;
        public static void Print(string inputString)
        {
            result = isNoUpperEngChars(inputString); // вызов метода отвечающий за проверку на наличие не подходящих символов
            if (!result) // проверка на наличие ошибочных символов в хэш result
            {
                Console.WriteLine($"Ошибочные символы: {GetUpperNoEngChars(inputString)}"); // если в списке есть символы - выводим их
            }
            else
            {
                Console.WriteLine($"Обработанная строка: {outputString}"); // если ошибочных символов нет - выводим обработанную строку из FirstTask
            }
        }
        public static bool isNoUpperEngChars(string inputString) // Выполняем проверку на наличие неподходящих символов 
        {
            string upperEngChars = GetUpperNoEngChars(inputString);
            if ((string.IsNullOrEmpty(upperEngChars))) // Если коллекция ХэшСэт пуста, то
            {
                return result = true; // Возвращаем истину
            }
            return result = false; // Вовращаем ложь
        }

        static string GetUpperNoEngChars(string inputString)
        {

            HashSet<char> result = new HashSet<char>(); // Создаём Хэш коллекцию
            foreach (char c in inputString)
            {
                if (!Regex.IsMatch(c.ToString(), @"[a-z]")) // С помощью цикла находим символы НЕ англиского регистра
                {
                    result.Add(c); // Добавляем эти символы в коллекцию
                }
            }
            return new string(result.ToArray()); // Преобразуем коллекцию в новую строку
        }
    }
}
