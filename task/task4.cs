using System;
using System.Linq;


public class Program
{
    static int Evclid(int a, int b)
    {
        //a > b всегда

        if (a % b == 0)
        {
            return b;
        }
        else return Evclid(b, a % ((a / b) * b));
        // a mod ( ( a div b ) * b )
    }

    static int NOD(int a, int b)
    {
        if (b > a) return Evclid(b, a);
        else return Evclid(a, b);
    }

    static int EvclidBin(int a, int b)
    {
        if (b == 0) return a;
        if (a == b) return a;
        if (b == 1) return b;
        if (a % 2 == 0 && b % 2 == 0)
        {
            return 2 * EvclidBin(a / 2, b / 2);
        }
        if (a % 2 == 0 && b % 2 == 1)
        {
            return NODbin(a / 2, b);
        }

        if (a % 2 == 1 && b % 2 == 0)
        {
            return NODbin(a, b / 2);
        }
        return NODbin((a - b) / 2, b);

    }

    static int NODbin(int a, int b)
    {
        if (b > a) return EvclidBin(b, a);
        else return EvclidBin(a, b);
    }

    public static void Main()
    {
        int x, y;

        Console.WriteLine("Введите значения x и y для поиска НОД");
        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out x) & Int32.TryParse(Console.ReadLine(), out y))
                break;
            else
                Console.WriteLine("Неверный ввод");
        }

        Console.WriteLine($"Бинарный алгоритм Евклида: {NODbin(x, y)}");
        Console.WriteLine($"Алгоритм Евклида: {NOD(x, y)}");
    }
}
