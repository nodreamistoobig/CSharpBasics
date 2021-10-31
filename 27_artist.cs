using System;
using System.IO;

namespace _27
{
    class Program
    {
		static void Main(string[] args)
		{
			FileStream input = new FileStream("input.txt", FileMode.Open);
			StreamReader reader = new StreamReader(input);
			string[] line = reader.ReadLine().Split(' ');

			int x = Int32.Parse(line[0]);
			int y = Int32.Parse(line[1]);
			int n = Int32.Parse(reader.ReadLine());

			int[,] array = new int[x, y];
			int count = 0;

			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < y; j++)
				{
					array[i, j] = 0;
				}
			}

			for (int k = 0; k < n; k++)
			{
				line = reader.ReadLine().Split(' ');
				int x1 = Int32.Parse(line[0]);
				int y1 = Int32.Parse(line[1]);
				int x2 = Int32.Parse(line[2]);
				int y2 = Int32.Parse(line[3]);


				for (int i = y1; i < y2; i++)
					for (int j = x1; j < x2; j++)
						array[i, j] = 1;
			}


			for (int i = 0; i < x; i++)
				for (int j = 0; j < y; j++)
					if (array[i, j] == 0)
						count++;

			StreamWriter writer = new StreamWriter("output.txt");
			writer.WriteLine(count);
			writer.Close();
		}
    }
}
