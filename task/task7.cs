using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();


            Console.WriteLine("Введите количество пар");
            int n;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out n))
                    break;
                else
                    Console.WriteLine("Неверный ввод");
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1} пару");
                Console.WriteLine("Введите ключ: ");
                string KeyS = Console.ReadLine();
                Console.WriteLine("Введите значение: ");
                string NameS = Console.ReadLine();
                keyValuePairs.Add(KeyS, NameS);
            }

            foreach (KeyValuePair<string, string> keyValue in keyValuePairs)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }

            Console.WriteLine("Введите ключ");

            //string key = keyValuePairs.FirstOrDefault(x => x.Key == Console.ReadLine()).Value;
            string value = Console.ReadLine();
            string key = "";

            if (keyValuePairs.TryGetValue(value, out key))
            {
                Console.WriteLine($"Приветствую {key}");
            }
            else
            {
                Console.WriteLine("Такого ключа нет");
            }

            Console.WriteLine();
        }
    }
}
