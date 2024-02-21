using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_Tech_Task.StringOper
{
    public class Sort
    {

        public void ChooseSort(string input)
        {
            Console.WriteLine("Выберите сортировку 1-QuickSort 2-TreeSort");
            string choose = Console.ReadLine();
            if (choose == "1")
            {
                string QuickSorted = QuickSort(input);
                Console.WriteLine($"{QuickSorted} - Быстрая сортировка");
            }
            else if (choose == "2")
            {
                string TreeSorted = TreeSort(input);
                Console.WriteLine($"{TreeSorted} - Сортировка деревом");
            }
            else
            {
                Console.WriteLine("Сортировка не выбрана");
            }
        }
        public string QuickSort(string input)
        {
            char[] charArray = input.ToCharArray();
            QuickSort(charArray, 0, charArray.Length - 1);
            return new string(charArray);
        }

        public void QuickSort(char[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        public int Partition(char[] arr, int low, int high)
        {
            char pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1;
        }

        public void Swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public string TreeSort(string input)
        {
            char[] charArray = input.ToCharArray();
            for (int i = 1; i < charArray.Length; ++i)
            {
                char key = charArray[i];
                int j = i - 1;

                while (j >= 0 && charArray[j] > key)
                {
                    charArray[j + 1] = charArray[j];
                    j = j - 1;
                }
                charArray[j + 1] = key;
            }
            return new string(charArray);
        }
    }
}
