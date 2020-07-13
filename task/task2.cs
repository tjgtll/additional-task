using System;
using System.Linq;


public class Program
{
    //Наверное проще пузырьком, но если прошлое было сделать квиксорт, то пусть и тут он тоже будет

    static void quicksort(string[] arrS, int min, int max)
    {

        if (min >= max) return;

        int i = min;
        int j = max;
        int p = arrS[(min + max) / 2].Length;

        while (i < j)
        {
            while (arrS[i].Length > p) i++;
            while (arrS[j].Length < p) j--;
            if (i <= j)
            {
                string buf = arrS[i];
                arrS[i] = arrS[j];
                arrS[j] = buf;
                i++;
                j--;
            }
        }

        //Console.WriteLine(max - min);
        //OutMessage(arrS);

        quicksort(arrS, min, j);
        quicksort(arrS, i, max);
    }

    static void OutMessage(string[] a)
    {
        Console.Write($"Массив: ");
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write($"{a[i]} ");
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        string[] testS1 = new string[] { "1234567", "123", "1", "12345678", "12", "1234", "12", "1234", "123", "123456", "12345678", "1234", "12345", "123556", "Петя", "Коля", "Владимир" };
        OutMessage(testS1);
        quicksort(testS1, 0, testS1.Length - 1);
        OutMessage(testS1);
        Console.ReadLine();
    }
}

