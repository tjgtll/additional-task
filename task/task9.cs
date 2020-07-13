using System;
using System.Collections.Generic;

namespace polidrom
{
    class Program
    {
        public static bool Pal(string s)
        {
            List<char> arr = new List<char>() { };
            for (int i = 0; i < s.Length; i++)
            {
                if (arr.Remove(s[i]) != true)
                {
                    arr.Add(s[i]);
                }
            }
            if (arr.Count <= 1) return true;
            else return false;
        }

        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int x = 0; x < t; x++)
            {

                int y = 0;

                string[] s = Console.ReadLine().Split(' ');
                int N = Convert.ToInt32(s[0]);
                int Q = Convert.ToInt32(s[1]);
                string word = Console.ReadLine();
                for (int j = 0; j < Q; j++)
                {
                    s = Console.ReadLine().Split(' ');
                    int Li = Convert.ToInt32(s[0]);
                    int Ri = Convert.ToInt32(s[1]);
                    if (Pal(word.Substring(Li - 1, Ri - Li + 1)) == true || (Li == Ri)) y++;
                }
                Console.WriteLine($"Case #{x + 1}: {y}");
            }

        }
    }
}
