using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pro_Tech_Task.StringOper
{
    public class RandomNumber
    {
        public int? RandomNumb = null;
        async Task<int> GetRandomNumberAsync(string input)
        {
            int min = 0;
            int max = input.Length - 1;
            string apiUrl = $"https://www.random.org/integers/?num=1&min={min}&max={max}&col=1&base=10&format=plain&rnd=new";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        bool result = int.TryParse(responseBody, out int resultIndex);
                        return resultIndex;
                    }

                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
                }
            }
            return 0;
        }
        public async Task<string> RemoveChar(string input)
        {
            string result = "";
            int indexAsync = await GetRandomNumberAsync(input);
            if (indexAsync != 0)
            {
                result = $"{await RemoveCharAtIndex(input, indexAsync)} - API Число: {indexAsync}";
            }
            else
            {
                Random random = new Random();
                int index = random.Next(0, input.Length);
                result = $"{await RemoveCharAtIndex(input, index)} - Random Число: {index}";
            }
            return result;
        }
        public async Task<string> RemoveCharAtIndex(string input, int index)
        {
            if (index < 0 || index >= input.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            return input.Remove(index, 1);
        }
    }
}
