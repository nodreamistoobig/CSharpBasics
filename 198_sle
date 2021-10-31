using System;
using System.IO;

namespace _198
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream input = new FileStream("input.txt", FileMode.Open);
            StreamReader reader = new StreamReader(input);
            int n = Int32.Parse(reader.ReadLine());

            int[,] array = new int[n, n];
            int[] b_array = new int[n];
            string result ="";
            for (int i = 0; i < n; i++)
            {
                string[] line = reader.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = Int32.Parse(line[j]);
                }
                b_array[i] = Int32.Parse(line[n]);
            }

            int def = definder(array, n);
            int[] defs = new int[n];

            for (int k = 0; k < n; k++)
            {
                int[,] inter_array = new int[n,n];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        inter_array[i, j] = array[i, j];
                for (int i = 0; i < n; i++)
                    inter_array[i, k] = b_array[i];
                defs[k] = definder(inter_array, n);
                result += defs[k]/def + " ";
            }

            StreamWriter writer = new StreamWriter("output.txt");
            writer.WriteLine(result);
            writer.Close();
        }

        static int definder(int[,] array, int n)
        {
            int result = 0;
            if (n == 1)
                return array[0, 0];
            else if (n == 2)
                return array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0];
            else if (n == 3)
            {
                int d1 = array[0, 0] * array[1, 1] * array[2, 2];
                int tr11 = array[0, 1] * array[1, 2] * array[2, 0];
                int tr12 = array[0, 2] * array[1, 0] * array[2, 1];

                int d2 = array[0, 2] * array[1, 1] * array[2, 0];
                int tr21 = array[0, 1] * array[1, 0] * array[2, 2];
                int tr22 = array[0, 0] * array[1, 2] * array[2, 1];

                return d1 + tr11 + tr12 - d2 - tr21 - tr22;
            }
            else
            {
                for (int k=0; k<n; k++)
                {
                    int gap = 0;
                    int[,] inter_array = new int[n - 1, n - 1];
                    for (int i = 1; i < n; i++)
                    {
                        for (int j = 0; j < n-1; j++)
                        {
                            if (j == k)
                                gap = 1;
                            inter_array[i-1, j] = array[i, j+gap];
                        }
                        gap = 0;
                    }
                    int sign = (k+1) % 2;
                    if (sign == 0)
                        result += array[0, k] * definder(inter_array, n - 1);
                    else
                        result -= array[0, k] * definder(inter_array, n - 1);
                }
                    
            }
            return result;
                
        }
    }
}
