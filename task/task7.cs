using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static public string OutMessage(string s, Dictionary<string, string> keyValuePairs)
        {
            string OutS = s;

            foreach (KeyValuePair<string, string> keyValue in keyValuePairs)
            {
                OutS = OutS.Replace("{"+keyValue.Key+"}", keyValue.Value);
            }

            return OutS;
        }

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

            Console.WriteLine("Введите сообщение");

            Console.WriteLine(OutMessage(Console.ReadLine(), keyValuePairs));

            Console.WriteLine();
        }
    }
}
