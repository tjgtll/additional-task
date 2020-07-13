using System;

namespace ConsoleApp27
{
    class Program
    {   
        static public void OutMap(byte[,] map)
        {
            for (int y = 0; y < map.GetUpperBound(0) + 1; y++)
            {

                for (int x = 0; x < map.GetUpperBound(1) + 1; x++)
                {
                    if (map[y, x] == 1)
                        Console.Write("{0,-3}", "[]");
                    else
                        Console.Write("{0,-3}", " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static public void OutMap(int[,] map, byte[,] mapB)
        {
            for (int y = 0; y < map.GetUpperBound(0) + 1; y++)
            {

                for (int x = 0; x < map.GetUpperBound(1) + 1; x++)
                {
                    if (mapB[y, x] == 1)
                        Console.Write("{0,-3}", "[]");
                    else
                        Console.Write("{0,-3}", map[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Li(byte[,] map, byte startX, byte startY, byte endX, byte endY)
        {
            byte i = 1;
            if (map[startX, startY] == 1)
            {
                Console.WriteLine("Неверные кординаты старта");
                return;
            }
            if (map[endX, endY] == 1)
            {
                Console.WriteLine("Неверные кординаты финиша");
                return;
            }

            int[,] mapNumber = new int[map.GetUpperBound(0) + 1, map.GetUpperBound(1) + 1];
            Point(i, startX, startY, endX, endY, map, mapNumber);
            Console.WriteLine("Лабиритн ");
            OutMap(map);
            Console.WriteLine("Результат работы алгоритма");
            OutMap(mapNumber, map);
            Console.WriteLine("Лабиритн c прорисованным путем");
            Way(startX, startY, endX, endY, mapNumber, map);
            Console.WriteLine();
        }

        static void Point(byte i, int startX, int startY, byte endX, byte endY, byte[,] map, int[,] mapNumber)
        {
            i++;
            mapNumber[startX, startY] = i;
            if (startX == endX && startY == endY)
            {
                return;
            }
            if (map[startX - 1, startY] != 1 && (mapNumber[startX - 1, startY] == 0 || mapNumber[startX - 1, startY] > i)) Point(i, startX - 1, startY, endX, endY, map, mapNumber);
            if (map[startX + 1, startY] != 1 && (mapNumber[startX + 1, startY] == 0 || mapNumber[startX + 1, startY] > i)) Point(i, startX + 1, startY, endX, endY, map, mapNumber);
            if (map[startX, startY + 1] != 1 && (mapNumber[startX, startY + 1] == 0 || mapNumber[startX, startY + 1] > i)) Point(i, startX, startY + 1, endX, endY, map, mapNumber);
            if (map[startX, startY - 1] != 1 && (mapNumber[startX, startY - 1] == 0 || mapNumber[startX, startY - 1] > i)) Point(i, startX, startY - 1, endX, endY, map, mapNumber);
        }

        static void Way(byte startX, byte startY, byte endX, byte endY, int[,] mapNumber, byte[,] map)
        {
            int[,] wayXY = new int[mapNumber[endX, endY] - 1, 2];
            wayXY[0, 1] = endX;
            wayXY[0, 0] = endY;
            FindWay(0, wayXY, mapNumber);
            OutAnswerMap(map, wayXY);
        }

        static void FindWay(int i, int[,] wayXY, int[,] mapNumber)
        {

            if (mapNumber[wayXY[i, 1] - 1, wayXY[i, 0]] == mapNumber[wayXY[i, 1], wayXY[i, 0]] - 1)
            {
                wayXY[i + 1, 1] = wayXY[i, 1] - 1;
                wayXY[i + 1, 0] = wayXY[i, 0];
                FindWay(i + 1, wayXY, mapNumber);
                return;
            }
            if (mapNumber[wayXY[i, 1] + 1, wayXY[i, 0]] == mapNumber[wayXY[i, 1], wayXY[i, 0]] - 1)
            {
                wayXY[i + 1, 1] = wayXY[i, 1] + 1;
                wayXY[i + 1, 0] = wayXY[i, 0];
                FindWay(i + 1, wayXY, mapNumber);
                return;
            }
            if (mapNumber[wayXY[i, 1], wayXY[i, 0] - 1] == mapNumber[wayXY[i, 1], wayXY[i, 0]] - 1)
            {
                wayXY[i + 1, 1] = wayXY[i, 1];
                wayXY[i + 1, 0] = wayXY[i, 0] - 1;
                FindWay(i + 1, wayXY, mapNumber);
                return;
            }
            if (mapNumber[wayXY[i, 1], wayXY[i, 0] + 1] == mapNumber[wayXY[i, 1], wayXY[i, 0]] - 1)
            {
                wayXY[i + 1, 1] = wayXY[i, 1];
                wayXY[i + 1, 0] = wayXY[i, 0] + 1;
                FindWay(i + 1, wayXY, mapNumber);
                return;
            }
        }

        static void OutAnswerMap(byte[,] map, int[,] wayXY)
        {
            string[,] AnswerMap = new string[map.GetUpperBound(0) + 1, map.GetUpperBound(1) + 1];
            for (int y = 0; y < map.GetUpperBound(0) + 1; y++)
            {
                for (int x = 0; x < map.GetUpperBound(1) + 1; x++)
                {
                    AnswerMap[y, x] = Convert.ToString(map[y, x]);
                }
            }

            AnswerMap[wayXY[0, 1], wayXY[0, 0]] = "E";
            AnswerMap[wayXY[wayXY.GetUpperBound(0), 1], wayXY[wayXY.GetUpperBound(0), 0]] = "S";

            for (int i = 1; i < wayXY.GetUpperBound(0); i++)
            {
                AnswerMap[wayXY[i, 1], wayXY[i, 0]] = "+";
            }

            for (int y = 0; y < AnswerMap.GetUpperBound(0) + 1; y++)
            {

                for (int x = 0; x < AnswerMap.GetUpperBound(1) + 1; x++)
                {
                    if (map[y, x] == 1)
                        Console.Write("{0,-3}", "[]");
                    else
                        if (AnswerMap[y, x] == "0") Console.Write("{0,-3}", " ");
                    else Console.Write("{0,-3}", AnswerMap[y, x]);
                    
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            byte[,] map =
            {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 0, 1, 0, 0, 0, 0, 0, 0, 1},
            { 1, 1, 0, 1, 1, 0, 1, 0, 0, 1},
            { 1, 0, 1, 0, 1, 0, 0, 1, 0, 1},
            { 1, 0, 1, 1, 0, 1, 0, 0, 0, 1},
            { 1, 0, 1, 1, 0, 1, 0, 0, 0, 1},
            { 1, 0, 0, 0, 1, 0, 1, 0, 0, 1},
            { 1, 0, 1, 0, 0, 0, 0, 0, 0, 1},
            { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            };

            Li(map, 1, 3, 8, 1);
            Console.WriteLine();
        }
    }
}
