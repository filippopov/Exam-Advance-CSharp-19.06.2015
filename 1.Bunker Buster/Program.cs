using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Bunker_Buster
{
    class Program
    {
        private static int[,] matrix;

        private static List<string> inputLifeBunkers;

        private static string line;
        static void Main(string[] args)
        {
            inputLifeBunkers = new List<string>();
            int[] rowsAndCols =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            matrix = new int[rowsAndCols[0], rowsAndCols[1]];
            for (int i = 0; i < rowsAndCols[0]; i++)
            {
                inputLifeBunkers.Add(Console.ReadLine());
            }

            FullMatrix();

            line = Console.ReadLine();
            while (true)
            {
                string[] cordinatsWithDamige = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(cordinatsWithDamige[0]);
                int col = int.Parse(cordinatsWithDamige[1]);
                char asciiChar = char.Parse(cordinatsWithDamige[2]);
                int weight = (int)asciiChar;
                double wave = Math.Round((double)weight / 2, MidpointRounding.AwayFromZero);

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (CheckPosition(i, j, row, col))
                        {
                            matrix[i, j] -= (int)wave;
                        }

                        
                    }
                }

                matrix[row, col] -= (int)(weight - wave);

                line = Console.ReadLine();
                if (line == "cease fire!")
                {
                    break;
                }
            }
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] <= 0)
                    {
                        counter++;
                    }
                }
            }

            int rowNumber = rowsAndCols[0];
            int colNumbers = rowsAndCols[1];
            double result = (double)counter/((double)rowNumber * (double)colNumbers)*100;
            Console.WriteLine($"Destroyed bunkers: {counter}");
            Console.WriteLine("Damage done: {0:F1} %",result);

        }

        private static bool CheckPosition(int i, int j, int row, int col)
        {
            bool isWave = (i==row||i == row - 1 || i == row + 1) && (j==col||j == col - 1 || j == col + 1);
            return isWave;
        }

        private static void FullMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] temp =
                    inputLifeBunkers[row].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = temp[col];
                }
            }
        }
    }
}
