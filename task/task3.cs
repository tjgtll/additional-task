using System;
using System.Collections.Generic;
using System.Linq;

namespace polidrom
{
    public class queue
    {
        public string Value { get; set; }

        public int Key { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<queue> ListQueue = new List<queue>();
            bool exit = false;
            while ( exit != true)
            {
                Console.WriteLine("1 - добавить в очередь\n2 - удалить из очереди по приоритету\n3 - выход");
                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:

                        Console.WriteLine("\nВведите значение");
                        string value = Console.ReadLine();

                        Console.WriteLine("Введите приоритет");
                        int key;

                        while (true)
                        {
                            if (Int32.TryParse(Console.ReadLine(), out key))
                                break;
                            else
                                Console.WriteLine("Неверный ввод!");
                        }

                        ListQueue.Add(new queue() { Value = value, Key = key });
                        break;

                    case ConsoleKey.D2:
                        if (ListQueue.Count != 0)
                        {
                            var itemToRemove = ListQueue.OrderBy(r => -r.Key).First();
                            Console.WriteLine($"\nВыполнен: {itemToRemove.Value} имея приоритет {itemToRemove.Key}");

                            ListQueue.Remove(itemToRemove);
                        }
                        else Console.WriteLine("\nОчередб пуста");
                        break;

                    case ConsoleKey.D3:
                        exit = true;
                        break;
                    default:
                        break;

                }
            Console.WriteLine();
        }
           
            Console.WriteLine();
        }
    }
}
