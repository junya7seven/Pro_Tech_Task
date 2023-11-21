using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PPRO_Tech;
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
        public static string? modString;
        public static void Main(string[] args)
        {
            Console.Write("Введите строку: ");

            inputString = Console.ReadLine().Replace(" ", ""); // Входящая строка + удаление всех пробелов
            GetIfNull(ref inputString);
            modString = StringSplit(inputString);
            SecondTask.Print(inputString);
            isOutProgramm();
            ThirdTask.CountPrint(modString.ToArray());
            FourthTask.PrintLargSubstring(modString);
            FiftTask.PrintSort();
            Console.WriteLine();
            GetRandomNum randomNum = new GetRandomNum();
            GetRandomNum.RandomNumb();
            randomNum.CutElement(modString);
        }
        // Проверка переменной отвечающей за проверку входной строки на наличие англ символов нижнего регистра + завершение программы
        private static void isOutProgramm()
        {
            if (!SecondTask.isErrChars)
            {
                Environment.Exit(0);
                Console.WriteLine("Программа была завершена");
            }
        }
        // Если входящая строка пуста, то она заменяется на teststring и продолжает работу
        private static void GetIfNull(ref string inputString) 
        {
            if (inputString.Length == 0)
            {
                Console.WriteLine("Строка пуста, была проведена замена на: 'teststring'");
                inputString = "teststring";
            }
        }

        public static string StringSplit(string inputString)
        {
            int split = inputString.Length / 2; // Получение значение соответствующее половины длину строки
            string strResult = " ";
            if (inputString.Length % 2 == 0)
            {
                string first = new string(inputString.Substring(0, split).Reverse().ToArray()); // деление на 1 подстроку с 0 символа до половины строки + переворачивание 
                string second = new string(inputString.Substring(split).Reverse().ToArray()); // деление на 2 подстроку с половины строки до конца + переворачивание 
                strResult = string.Concat(first, second); // соединение двух подстрок
            }
            else
            {
                strResult = new string(inputString.Reverse().ToArray()); // переворачивание входящей строки
                strResult = string.Concat(strResult, inputString); // соединение перевёрнутой строки с входящей
            }
            return strResult;


        }
    }
}
