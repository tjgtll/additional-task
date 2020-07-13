using System;
using System.Linq;

namespace console
{
    class Program
    {
        static void quicksort(int[] arr, int min, int max)
        {
            
            if (min >= max ) return;
            
            int i = min;
            int j = max;
            int p = arr[(min + max) / 2];

            while (i < j)
            {
                while (arr[i] < p) i++;
                while (arr[j] > p) j--;
                if (i <= j)
                {
                    int buf = arr[i];
                    arr[i] = arr[j];
                    arr[j] = buf;
                    i++;
                    j--;
                }
            }
            
            quicksort(arr, min, j);

            quicksort(arr, i, max);
        }

        static void Main(string[] args)
        {
            int[] a = new int[] { 3, 5, 7, 8, 4, 2, 1, 9, 6};

            quicksort(a, 0, a.Length - 1);
            Console.WriteLine();
        }
    }
}
