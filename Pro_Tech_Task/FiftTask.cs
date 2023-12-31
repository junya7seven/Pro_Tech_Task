﻿using PRO_Tech;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace PRO_Tech

{
    class FiftTask : SecondTask
    {
        /*
         * Реализовать две сортировки путём выбора пользователем 1. Быстрая сортировка 2. Сортировка деревом
         * В данной программе использовалась быстрая сортировка Хоара
         * a -> aa -> aa -> aa
         * abcdef -> cbafed -> afe -> aef
         * adcde - > edcbaabcde -> edcbaabcde -> aabbcccddee
        */


        // Проверка по заданию из класса SecondTask (строка должна содержать только англ. символы нижнего регистра)
        public static void PrintSort()
        {
            ChooseSort();
        }

        public static void ChooseSort()
        {
            char[] arr = modString.ToCharArray(); // Обработанная строка
            Console.WriteLine();
            Console.WriteLine("Введите выбор способа сортировка\n1.Быстрая сортировка QuickSort 2.Сортировка деревом TreeSort\n Нажмите 1 или 2 - Press 1 or 2");
            string choose = Console.ReadLine(); // Ввод выбора сортировки пользователем
            switch (modString)
            {
                case "1":
                    QuickSort.QuickSorts(arr, 0, arr.Length - 1); // Вызываем функцию QuickSort для сортировки массива
                    string sortedString = new string(arr);
                    Console.WriteLine($"Обработанная строка {modString}\n--->");
                    Console.WriteLine(sortedString);
                    break;
                case "2":
                    BinaryTree tree = new BinaryTree();
                    foreach (char c in arr)
                    {
                        tree.Insert(c);
                    }
                    Console.WriteLine($"Обработанная строка{modString}\n--->");
                    tree.InOrderTraversal();
                    break;
                default:
                    Console.WriteLine("Сортировка не была выбрана - выбрана QuickSort");
                    goto case "1";
            }
        }
    }
}
/////////// Быстрая сортировка
public class QuickSort
{
    public static void QuickSorts(char[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(arr, left, right); // Опорный элемент

            QuickSorts(arr, left, pivotIndex - 1); // Рекурсивная сортировка левой части
            QuickSorts(arr, pivotIndex + 1, right); // Рекурсивная сортировка правой части
        }
    }

    static int Partition(char[] arr, int left, int right)
    {
        char pivotValue = arr[right]; // Выбор опорного элемента (последний элемент в текущем подмассиве)
        int pivotIndex = left;

        for (int i = left; i < right; i++)
        {
            if (arr[i] < pivotValue) // Если элемент меньше опорного, перемещаем его влево
            {
                Swap(arr, i, pivotIndex);
                pivotIndex++;
            }
        }

        Swap(arr, pivotIndex, right); // Помещаем опорный элемент на его правильное место
        return pivotIndex; // Возвращаем индекс опорного элемента
    }

    static void Swap(char[] arr, int i, int j)
    {
        char temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
/////////// Сортировка деревом
class Node
{
    public char Value; // Данные узла (символ)
    public Node Left; // Левый дочерний узел
    public Node Right; // Правый дочерний узел

    public Node(char value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}
// Класс для бинарного дерева поиска
class BinaryTree
{
    private Node root; // Корневой узел дерева

    public BinaryTree()
    {
        root = null;
    }
    // Метод для вставки символа в дерево
    public void Insert(char value)
    {
        root = InsertRec(root, value);
    }
    // Рекурсивный метод для вставки символа в дерево
    private Node InsertRec(Node root, char value)
    {
        if (root == null)
        {
            root = new Node(value); // Создаем новый узел, если текущий узел пуст
            return root;
        }

        if (value < root.Value)
        {
            root.Left = InsertRec(root.Left, value); // Рекурсивная вставка в левое поддерево
        }
        else if (value > root.Value)
        {
            root.Right = InsertRec(root.Right, value); // Рекурсивная вставка в правое поддерево
        }

        return root;
    }
    // Метод для обхода дерева в порядке возрастания
    public void InOrderTraversal()
    {
        InOrderTraversal(root);
    }
    // Рекурсивный метод для обхода дерева в порядке возрастания
    private void InOrderTraversal(Node root)
    {
        if (root != null)
        {
            InOrderTraversal(root.Left); // Рекурсивный обход левого поддерева
            Console.Write(root.Value); // Выводим данные узла
            InOrderTraversal(root.Right); // Рекурсивный обход правого поддерева
        }
    }
}