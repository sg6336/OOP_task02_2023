using System;

namespace LibrarySnail
{
    public static class MatrixHelper
    {
        public static int[,] FillMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];
            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(101);
                }
            }

            return matrix;
        }

        public static int GetMatrixTrace(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int trace = 0;

            int minDimension = Math.Min(rows, columns);
            for (int i = 0; i < minDimension; i++)
            {
                trace += matrix[i, i];
            }

            return trace;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(matrix[i, j] + "\t");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}