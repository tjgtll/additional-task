using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace polidrom
{
    class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public List<double> Numbers { get; set; }

    }

    class Program
    {
        public const string muneMessage = "\nМеню:\n1 - создание нового JSON файла\n2 - чтение JSON файла\n3 - модификация элемента JSON\n4 - удаление элемента в JSON\nq - выход";

        public static void Load(List<Person> obj)
        {
            File.WriteAllText("person.json", JsonConvert.SerializeObject(obj));
        }

        public static void OutputAllPerson(List<Person> obj)
        {
            for (int i = 0; i < obj.Count; i++)
            {
                Console.Write($"{i + 1 + "." + obj[i].Name,-22}:");
                for (int j = 0; j < obj[i].Numbers.Count; j++)
                {
                    Console.Write($"|{obj[i].Numbers[j],-3}| ");
                }
                Console.WriteLine();
            }
        }

        public static void Create()
        {
            List<Person> ob = new List<Person>();
            int n;
            Console.WriteLine("/nВведите количиство учащихся");
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out n))
                {
                    break;
                }
                else Console.WriteLine("Неверный ввод!");
            }

            for (int i = 0; i < n; i++)
            {
                Person bufferObj = new Person();

                Console.WriteLine("Введите имя");
                bufferObj.Name = Console.ReadLine();
                Console.WriteLine("Введите количество оценок");
                int m;
                while (true)
                {
                    if (Int32.TryParse(Console.ReadLine(), out m))
                    {
                        break;
                    }
                    else Console.WriteLine("Неверный ввод!");
                }
                List<double> Numbers = new List<double>();
                for (int j = 0; j < m; j++)
                {
                    double output;
                    while (true)
                    {
                        if (Double.TryParse(Console.ReadLine(), out output))
                        {
                            break;
                        }
                        else Console.WriteLine("Неверный ввод!");
                    }
                    Numbers.Add(output);
                }
                bufferObj.Numbers = Numbers;
                ob.Add(bufferObj);
            }
            Load(ob);
        }

        public static void Read()
        {
            Console.WriteLine();
            var obj = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText("person.json"));

            OutputAllPerson(obj);
        }

        public static void Update_person_number(int n, List<Person> obj)
        {
            bool exit=false;
            
            while(exit!=true)
            {
                Console.WriteLine("\nМеню изменений оценок: \n1 - Добавить новые числа\n2 - Изменить существующие\n3 - Удалить\nq - Для выхода из меню");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Update_person_number_add(n, obj);
                        break;
                    case ConsoleKey.D2:
                        Update_person_number_change(n, obj);
                        break;
                    case ConsoleKey.D3:
                        Update_person_number_delet(n, obj);
                        break;
                    case ConsoleKey.Q:
                        exit = !exit;
                        break;
                }
            }
        }

        public static void Update_person_number_add(int n, List<Person> obj)
        { 
            Console.Write($"\n{n + "." + obj[n-1].Name,-22}:");
            for (int j = 0; j<obj[n - 1].Numbers.Count; j++)
            {
                Console.Write($"|{obj[n-1].Numbers[j],-3}| ");
            }
            Console.WriteLine("\nВведите оценку которую хотите добваить");
            double b;
            while (true)
            {
                if (Double.TryParse(Console.ReadLine(), out b))
                {
                    obj[n - 1].Numbers.Add(b);
                    Console.WriteLine($"Добавленно оценка {b} учащегося {obj[n - 1].Name}\nq - Для выхода из добавления оценок\nИли введите еще число которое хотите добваить");
                    break;
                }
                else Console.WriteLine("Неверный ввод!");
            }
        }

        public static void Update_person_number_change(int n, List<Person> obj)
        {
            Console.Write($"\n{n + "." + obj[n - 1].Name,-22}:");
            for (int j = 0; j < obj[n - 1].Numbers.Count; j++)
            {
                Console.Write($"|{obj[n - 1].Numbers[j],-3}| ");
            }
            Console.WriteLine("\nВведите номер оценки которую хотите изменить");

            int index;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out index) && index <= obj[n-1].Numbers.Count && index >= 1) break;
                else Console.WriteLine($"Неверный ввод, доступны целочисленные значения от 1 до {obj[n-1].Numbers.Count}");
            }
            Console.WriteLine($"Выбранное число {obj[n - 1].Numbers[index-1]}");

            Console.WriteLine("Введите новое число");
            double number;
            while (true)
            {
                if (Double.TryParse(Console.ReadLine(), out number) && number <= 10 && index >= 0) break;
                else Console.WriteLine($"Неверный ввод, доступны вещественные значения от 1 до 10");
            }

            obj[n - 1].Numbers[index - 1] = number;

            Console.Write($"\n{n + "." + obj[n - 1].Name,-22}:");
            for (int j = 0; j < obj[n - 1].Numbers.Count; j++)
            {
                Console.Write($"|{obj[n - 1].Numbers[j],-3}| ");
            }

            Load(obj);
        }

        public static void Update_person_number_delet(int n,List<Person> obj)
        {
            Console.Write($"\n{n + "." + obj[n - 1].Name,-22}:");
            for (int j = 0; j < obj[n - 1].Numbers.Count; j++)
            {
                Console.Write($"|{obj[n - 1].Numbers[j],-3}| ");
            }
            Console.WriteLine("\nВведите номер оценки которую хотите удалить");

            int index;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out index) && index <= obj[n - 1].Numbers.Count && index >= 1) break;
                else Console.WriteLine($"Неверный ввод, доступны целочисленные значения от 1 до {obj[n - 1].Numbers.Count}");
            }
            Console.WriteLine($"Выбранное число {obj[n - 1].Numbers[index - 1]}");

            obj[n - 1].Numbers.RemoveAt(index - 1);

            Console.Write($"\n{n + "." + obj[n - 1].Name,-22}:");
            for (int j = 0; j < obj[n - 1].Numbers.Count; j++)
            {
                Console.Write($"|{obj[n - 1].Numbers[j],-3}| ");
            }

            Load(obj);
        }

        public static void Update()
        {
            Console.WriteLine();
            var obj = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText("person.json"));

            bool exit = false;
            while (exit != true)
            {
                OutputAllPerson(obj);

                Console.WriteLine("Введите номер записи ");
                int n;
                while (true)
                {
                    if (Int32.TryParse(Console.ReadLine(), out n) && n <= obj.Count && n >= 1) break;
                    else Console.WriteLine($"Неверный ввод, доступны целочисленные значения от 1 до {obj.Count}");
                }

                Console.WriteLine("Меню изменений: \n1 - Имя учащегося\n2 - Оценки учащегося\nq - Для выхода из меню записи");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("\nВведите новое имя учащегося");
                        obj[n - 1].Name = Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Update_person_number(n, obj);
                        break;
                    case ConsoleKey.Q:
                        exit = !exit;
                        break;
                }
                Console.WriteLine();
            }
            Load(obj);
        }

        public static void Delete()
        {
            Console.WriteLine();
            var obj = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText("person.json"));
            OutputAllPerson(obj);
            Console.WriteLine("Введите номер записи ");
            int n;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out n) && n <= obj.Count && n >= 1) break;
                else Console.WriteLine($"Неверный ввод, доступны целочисленные значения от 1 до {obj.Count}");
            }
            obj.RemoveAt(n - 1);
            OutputAllPerson(obj);
            Load(obj);
        }

        static void Main(string[] args)
        {
            bool exit = false;
            while(exit!=true)
            {
                Console.WriteLine(muneMessage);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Create();
                        break;
                    case ConsoleKey.D2:
                        Read();
                        break;
                    case ConsoleKey.D3:
                        Update();
                        break;
                    case ConsoleKey.D4:
                        Delete();
                        break;
                    case ConsoleKey.Q:
                        exit = !exit;
                        break;
                }
            }
        }
    }
}   
