using System;
using LibrarySnail;

namespace ConsoleSnail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of rows:");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of columns:");
            int columns = int.Parse(Console.ReadLine());

            int[,] matrix = MatrixHelper.FillMatrix(rows, columns);
            MatrixHelper.PrintMatrix(matrix);

            int trace = MatrixHelper.GetMatrixTrace(matrix);
            Console.WriteLine($"Matrix Trace: {trace}");

            Console.ReadLine();
        }
    }
}