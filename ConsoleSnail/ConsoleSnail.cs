using ConsoleSnail.Resources;
using LibrarySnail;
using Spectre.Console;

namespace ConsoleSnail
{
    internal class ConsoleSnail
    {
        static void Main(string[] args)
        {
            var root = new Tree("Task02");

            var DescStr1 = root.AddNode("Name");
            var DescStr1Child = DescStr1.AddNode("Snail");

            var DescStr2 = root.AddNode("Function");
            var DescStr2Child = DescStr2.AddNode(Messages.SecondStr);

            var DescStr3 = root.AddNode("Author");
            var DescStr3Child = DescStr3.AddNode("Oleksandr Leoshko");

            var DescStr4 = root.AddNode("Co-author");
            var DescStr4Child = DescStr4.AddNode("Maksyn Oganesyan");

            var DescStr5 = root.AddNode("Date");
            var DescStr5Child = DescStr5.AddNode("20.03.2023");

            var DescStr6 = root.AddNode("Copyright (c) 2023");

            var DescStr7 = root.AddNode("All rights reserved");

            AnsiConsole.Write(root);

            Console.WriteLine();

            Console.CursorVisible = true;
            ConsoleKeyInfo Button;

            //for (int i = 0; i < Messages.Greetings.Length; i++)
            //{
            //    Console.Write(Messages.Greetings[i]);
            //    System.Threading.Thread.Sleep(6);
            //}
            //Console.WriteLine();
            //Console.WriteLine();
            do
            {
                var obj = new Snail();
                int rows = 0, columns = 0;

                // Check input for rows
                bool checkRows = false;
                do
                {
                    Console.Write(Messages.RowValue + " ");
                    checkRows = int.TryParse(Console.ReadLine(), out rows);
                    if (!checkRows || rows < 1 || rows > 10)
                    {
                        Console.WriteLine(Messages.ValueError);
                        checkRows = false;
                    }
                } while (!checkRows);

                // Check input for columns
                bool checkColumns = false;
                do
                {
                    Console.Write(Messages.ColumnValue + " ");
                    checkColumns = int.TryParse(Console.ReadLine(), out columns);
                    if (!checkColumns || columns < 1 || columns > 10)
                    {
                        Console.WriteLine(Messages.ValueError);
                        checkColumns = false;
                    }
                } while (!checkColumns);

                // Create a new matrix with the specified number of rows and columns
                int[,] matrix = new int[rows, columns];

                // Create an array to keep track of used numbers and generate random numbers to fill the matrix
                bool[] usedNumbers = new bool[100];
                Random rand = new Random();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        int randomNum = rand.Next(100);
                        while (usedNumbers[randomNum])
                        {
                            randomNum = rand.Next(100);
                        }
                        usedNumbers[randomNum] = true;
                        matrix[i, j] = randomNum;
                    }
                }

                // Get the elements of the matrix in a spiral order
                int[] spiralArray = obj.ReadAsSpiral(matrix, out int[,] spiralMatrix);
                Console.WriteLine();
                Console.WriteLine(Messages.FirstResultStr);
                Console.WriteLine(string.Join(" ", spiralArray));

                Console.WriteLine();
                Console.WriteLine(Messages.SecondResultStr);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (i == j)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write($"{spiralMatrix[i, j],3} ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($"{spiralMatrix[i, j],3} ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                int diagonalSum = 0;
                for (int i = 0; i < Math.Min(rows, columns); i++)
                {
                    diagonalSum += spiralMatrix[i, i];
                }
                Console.WriteLine(Messages.DiagonalSum + " " + diagonalSum);
                Console.WriteLine();

                //AnsiConsole.Write(new BarChart()
                //    .Width(100)
                //    .Label("Sum of elements on main diagonal")
                //    .CenterLabel()
                //    .AddItem("Sum", (int)((diagonalSum * 100) / 955), Color.Green)
                //    );

                Console.WriteLine();
                Console.WriteLine(Messages.RestartOption);

                Button = Console.ReadKey();
                if (Button.Key == ConsoleKey.Spacebar)
                {
                    Environment.Exit(0);
                }
            } while (Button.Key == ConsoleKey.Enter);
        }
    }
}
