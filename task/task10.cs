using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    { 
        static void Main(string[] args)
        {
            int[] arrI = { 1, 2, 6, 2, 1, 7, 12, 6, 8 };

            Console.WriteLine("Исконный массив: ");
            foreach (int a in arrI)
                Console.Write($"{a} ");

            Console.WriteLine("\nОтсортированный исходный массив: ");
            foreach (int s in arrI.OrderBy(t => -t))
                Console.Write($"{s} ");


            Console.WriteLine("\nНайти 3 самых больших значений в массиве ");
            foreach (int s in arrI.OrderBy(t => -t).Take(3))
                Console.Write($"{s} ");

            Console.WriteLine("\nИсключить из массива 2 наименьшие значения - то есть вернуть массив без 2 наименьших значений");

            foreach (int s in arrI.OrderBy(t => -t).Take(arrI.Length-2))
                Console.Write($"{s} ");

            
            int[] AmountEvenAndOdd = new int[] { arrI.Where(i => i % 2 == 0).Count(), arrI.Where(i => i % 2 == 1).Count() };
            Console.WriteLine("\nВернуть массив сумм четных и нечетных значений массива");
            Console.WriteLine($"{AmountEvenAndOdd[0]} {AmountEvenAndOdd[1]}");

            double average = arrI.OrderBy(t => -t).Skip(1).Take(arrI.Length - 2).Average();
            Console.WriteLine($"Подсчитать среднее значение для массива, исключая максимальное и минимальное число : {Math.Round(average, 3)} ");


            string Message = "Из строки удалить все гласные";
            Console.WriteLine(Message);
            char[] vowels = { 'а', 'о', 'и', 'е', 'ё', 'э', 'ы', 'у', 'ю', 'я', 'А', 'О', 'И', 'Е', 'Ё', 'Э', 'Ы', 'У', 'Ю', 'Я' };
            foreach (char s in Message.Where(l => !vowels.Contains(l)))
                Console.Write($"{s}");
        }
    }
}
