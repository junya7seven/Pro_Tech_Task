using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using PRO_Tech;
using System.Security.Cryptography;
using System.Reflection;

namespace PRO_Tech
{
    /* Получить рандомное число с сайта с помощью его API
     * Удалить символ в обработанной строке по индексу рандомного числа
     * Рандомное число - 5
     * teststring --> testsring - удален пятый символ 
    */
    class GetRandomNum
    {
        public static string randomNumber;
        public static int index;
        public static void  RandomNumb()
        {
            FirstTask firstTask = new FirstTask(); // Создание экземпляра класса
            int maxNumb = FirstTask.modString.Length-1; // Получении длины строки из обработанной строки
            int minNumb = 0;
            // Запрос случайного числа
            using var httpClient = new HttpClient(); 
            string apiUrl = $"https://www.random.org/integers/?num=1&min={minNumb}&max={maxNumb}&col=1&base=10&format=plain&rnd=new";

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result; // Выполнение GET запроса к API

                if (response.IsSuccessStatusCode)
                {
                    // Успешный запрос
                    randomNumber = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Сгенерированное случайное число от 0 до {maxNumb+1} : " + randomNumber);
                }
                else
                {
                    // Не успешный запрос
                    throw new Exception("Не удалось получить число. Код ошибки: " + response.StatusCode);
                }
            }
            // Обработка ошибки с выполнением HTTP - запроса
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Ошибка при выполнении запроса: " + ex.Message);
            }

            catch (Exception ex)
            {
                // Обработка и вывод сообщения об ошибки запроса
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка");
            }
        }
        // Метод для удаления символа из строки по случайному запрошенному индексу
        public void CutElement(string outputString)
        {
            // Если получилось преобразовать рандомное число без ошибок
            if (isIndex(randomNumber,out index))
            {
                // Проверка, что индекс находится в допустимых пределах строки
                if (index < 0 || index > outputString.Length - 1)
                {
                    Console.WriteLine("Случайное число не входил в пределы длины строки");
                }
                else
                {
                    Console.WriteLine($"Удаление символа по индексу - {index}");
                    string cutStr = outputString.Remove(index-1, 1); // Удаление символа из строки + вывод результата
                    Console.WriteLine($"{outputString} ---> {cutStr}");
                }
            }
            // Если по каким-то причинам не удалось получить рандомное число с сайта, то вызов метода с использованием Random
            else
            {
                Console.WriteLine("Не удалось получить случайное число с random.org - было получено случайное число средствами .Net ");
                CutElementRnd(FirstTask.modString);
            }
        }
        public void CutElementRnd(string outputString)
        {
            Random rnd = new Random(); // Создание рандомного числа
            int indexRnd = rnd.Next(0, outputString.Length - 1); // Получение рандомного числа
            Console.WriteLine($"Случайное число: {indexRnd}");
            string cutStr = outputString.Remove(indexRnd-1, 1); // Удаление символа из строки + результат
            Console.WriteLine($"{outputString} ---> {cutStr}");
        }
        // Попытка преобразовать полученное число в index integer 
        private static bool isIndex(string randomNumber, out int index)
        {
            if (int.TryParse(randomNumber,out index))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
