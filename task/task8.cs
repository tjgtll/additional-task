using System;
using System.Collections.Generic;

namespace skobki
{
    class Program
    {
        static void ChekS(string s)
        {
            List<char> a = new List<char>() { };
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') a.Add('(');
                if (s[i] == '{') a.Add('{');


                if (s[i] == '}' && a[a.Count - 1] == '{') a.RemoveAt(a.Count - 1);


                if (s[i] == ')' && a[a.Count - 1] == '(') a.RemoveAt(a.Count - 1);
            }
            if (a.Count == 0) Console.WriteLine($"{s} - ok");
            else Console.WriteLine($"{s} - неправильно ");
        }

        static void Main(string[] args)
        {
            // {()()}, {(())}
            Console.WriteLine("Введите строку со скобками");
            string s = Console.ReadLine();
            ChekS(s);

            Console.WriteLine();
        }
    }
}
