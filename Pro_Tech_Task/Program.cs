using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PRO_Tech;

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
        public static string? inputString;
        public static string? outputString;
        public static void Main(string[] args)
        {
            Console.Write("Введите строку: ");

            inputString = Console.ReadLine().Replace(" ", ""); // Входящая строка + удаление всех пробелов
            outputString = StringSplit(inputString);
            SecondTask.Print(inputString);
            ThirdTask.CountPrint(outputString.ToArray());
            FourthTask.PrintLargSubstring(outputString);


        }

        public static string StringSplit(string inputString)
        {
            inputString = inputString.Replace(" ", ""); // Удаление всех пробелов
            int split = inputString.Length / 2; // Получение значение соответствующее половины длину строки
            string result = " ";
            if (inputString.Length % 2 == 0)
            {
                string first = new string(inputString.Substring(0, split).Reverse().ToArray()); // деление на 1 подстроку с 0 символа до половины строки + переворачивание 
                string second = new string(inputString.Substring(split).Reverse().ToArray()); // деление на 2 подстроку с половины строки до конца + переворачивание 
                result = string.Concat(first, second); // соединение двух подстрок
            }
            else
            {
                result = new string(inputString.Reverse().ToArray()); // переворачивание входящей строки
                result = string.Concat(result, inputString); // соединение перевёрнутой строки с входящей
            }
            return result;
        }
    }
}
