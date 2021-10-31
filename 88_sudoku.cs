using System;
using System.IO;
using System.Collections.Generic;

namespace _88
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream input = new FileStream("input.txt", FileMode.Open);
            StreamReader reader = new StreamReader(input);
            int n = Int32.Parse(reader.ReadLine());
            int N = n * n;

            int[,] array = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string[] line = reader.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                    array[i, j] = Int32.Parse(line[j]);
            }

            if (checkRaws(array, N) && checkColumns(array, N) && checkSquares(array, N, n))
                printTheResult(true);
            else
                printTheResult(false);
        }

        public static bool checkRaws(int[,] array, int N) {
            for (int i = 0; i < N; i++)
            {
                List<int> line = new List<int>();
                for (int j = 0; j < N; j++)
                    line.Add(array[i, j]);
                if (!isCorrect(line, N))
                    return false;
            }
            return true;
        }
        public static bool checkColumns(int[,] array, int N) {
            for (int i = 0; i < N; i++)
            {
                List<int> line = new List<int>();
                for (int j = 0; j < N; j++)
                    line.Add(array[j, i]);
                if (!isCorrect(line, N))
                    return false;
            }
            return true;
        }
        public static bool checkSquares(int[,] array, int N, int n) {
            for (int x = 1; x <= n; x++)
            {
                for (int y = 1; y <= n; y++)
                {
                    List<int> square = new List<int>();
                    for (int i = n * (x - 1); i < n * x; i++)
                        for (int j = n * (y - 1); j < n * y; j++)
                            square.Add(array[j, i]);
                    if (!isCorrect(square, N))
                        return false;
                }
            }
            return true;
        }

        public static bool isCorrect(List<int> list, int N)
        {
            list.Sort();
            if (list.Count == N)
            {
                for (int i = 0; i < list.Count; i++)
                    if (list[i] != i + 1)
                        return false;
                return true;
            }
            return false;
        }

        public static void printTheResult(bool result)
        {
            StreamWriter writer = new StreamWriter("output.txt");
            if (result)
                writer.WriteLine("Correct");
            else
                writer.WriteLine("Incorrect");
            writer.Close();
        }
    }
}
