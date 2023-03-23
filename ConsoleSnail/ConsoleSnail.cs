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
                    Console.Write(Messages.RowValue);
                    checkRows = int.TryParse(Console.ReadLine(), out rows);
                    if (!checkRows)
                    {
                        Console.WriteLine(Messages.RowValueError);
                    }
                } while (!checkRows);

                // Check input for columns
                bool checkColumns = false;
                do
                {
                    Console.Write(Messages.ColumnValue);
                    checkColumns = int.TryParse(Console.ReadLine(), out columns);
                    if (!checkColumns)
                    {
                        Console.WriteLine(Messages.ColumnValueError);
                    }
                } while (!checkColumns);

                int[,] matrix = new int[rows, columns];

                Console.WriteLine();

                int i = 0;
                int j = 0;
                for (i = 0; i < rows; i++)
                {
                    Console.WriteLine($"Enter elements of {i + 1} row separated by spaces: ");
                    string[] rowElements = Console.ReadLine().Split(' ');

                    // Input validation for row elements
                    if (rowElements.Length != columns)
                    {
                        Console.WriteLine($"Invalid input. Please enter {columns} integer values for {i + 1} row.");
                        i--;
                        continue;
                    }

                    for (j = 0; j < columns; j++)
                    {
                        if (!int.TryParse(rowElements[j], out matrix[i, j]))
                        {
                            Console.WriteLine($"Invalid input. Please enter an integer value for {i + 1}row and {j + 1} column.");
                            j--;
                        }
                    }
                }

                int[] spiralArray = obj.ReadAsSpiral(matrix, out int[,] spiralMatrix);
                Console.WriteLine();
                Console.WriteLine(Messages.FirstResultStr);
                Console.WriteLine(string.Join(" ", spiralArray));

                Console.WriteLine();
                Console.WriteLine(Messages.SecondResultStr);
                for (i = 0; i < rows; i++)
                {
                    for (j = 0; j < columns; j++)
                    {
                        Console.Write($"{spiralMatrix[i, j],3} ");
                    }
                    Console.WriteLine();
                }

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
