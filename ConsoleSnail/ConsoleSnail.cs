using LibrarySnail;
using ConsoleSnail.Resources;

namespace ConsoleSnail
{
    internal class ConsoleSnail
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = true;
            ConsoleKeyInfo Button;
            Console.WriteLine(Messages.Greetings);
            Console.WriteLine();
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
