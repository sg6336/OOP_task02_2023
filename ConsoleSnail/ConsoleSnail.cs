using ConsoleSnail.Resources;
using LibrarySnail;
using Spectre.Console;
using GitSyncing;

namespace ConsoleSnail
{
    public class Program
    {

        private int rows;
        private int columns;
        private int[,] matrix;

        public int Rows
        {
            get { return rows; }
            set { rows = value; }

        }
        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        public int[,] Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        public void Run()
        {
            Console.CursorVisible = true;
            ConsoleKeyInfo Button;
            do
            {
                GreetTree();

                SetRows();
                SetColumns();

                NewMatrix();

                RandomNumbers();

                SpiralOrder();

                HighlightDiagonal();

                DiagonalSum();

                Console.WriteLine();
                Console.WriteLine(Messages.RestartOption);

                Button = Console.ReadKey();
                if (Button.Key == ConsoleKey.Spacebar)
                {
                    Environment.Exit(0);
                }
            } while (Button.Key == ConsoleKey.Enter);
        }              // MAIN RUNNING FUNCTION
        private void SetRows()          //  Read value for rows from user input
        {
            bool checkRows;

            do
            {
                Console.Write(Messages.RowValue);
                checkRows = int.TryParse(Console.ReadLine(), out rows);
                if (!checkRows || rows < 1 || rows > 10)
                {
                    Console.WriteLine(Messages.ValueError);
                    checkRows = false;
                }
            } while (!checkRows);
        }
        private void SetColumns()       //  Read value for columns from user input
        {
            bool checkColumns;
            Console.WriteLine();

            do
            {
                Console.Write(Messages.ColumnValue);
                checkColumns = int.TryParse(Console.ReadLine(), out columns);
                if (!checkColumns || columns < 1 || columns > 10)
                {
                    Console.WriteLine(Messages.ValueError);
                    checkColumns = false;
                }
            } while (!checkColumns);
        }
        private static void GreetTree() // Print Welcome message
        {
            var root = new Tree(Messages.TaskNum);                              //TaskNum

            var DescStr1 = root.AddNode(Messages.TaskNameNode);                 // TaskNameNode
            var DescStr1Child = DescStr1.AddNode(Messages.TaskName);            // TaskName

            var DescStr2 = root.AddNode(Messages.TaskDescNode);                 // TaskDescNode
            var DescStr2Child = DescStr2.AddNode(Messages.TaskDesc);            //TaskDesc

            var DescStr3 = root.AddNode(Messages.AuthorNameNode);               //AuthorNameNode
            var DescStr3Child = DescStr3.AddNode(Messages.AuthorName);          // AuthorName

            var DescStr4 = root.AddNode(Messages.CoAuthorNameNode);             // CoAuthorNameNode
            var DescStr4Child = DescStr4.AddNode(Messages.CoAuthorName);        //CoAuthorName

            var DescStr5 = root.AddNode(Messages.CreatedDateNode);              //CreatedDateNode
            var DescStr5Child = DescStr5.AddNode(Messages.CreatedDate);         //CreatedDate

            var DescStr6 = root.AddNode(Messages.UpdatedDateNode);              //CreatedDateNode
            var DescStr6Child = DescStr6.AddNode(GitSync.GetLastUpdateDate());  //CreatedDate

            var DescStr7 = root.AddNode(Messages.RightsInfo1);                  //RightsInfo1

            var DescStr8 = root.AddNode(Messages.RightsInfo2);                  //RightsInfo2

            AnsiConsole.Write(root);
            Console.WriteLine();
        } 
        private void NewMatrix()        //  Create a new matrix with the specified number of rows and columns
        {
            matrix = new int[rows, columns];
        }             
        private void RandomNumbers()    //  Create an array to keep track of used numbers and generate random numbers to fill the matrix
        {
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
        }         
        private void SpiralOrder()      //  Place all numbers in spiral order
        {
            var obj = new Snail();
            int[] spiralArray = obj.ReadAsSpiral(matrix);
            Console.WriteLine();
            Console.WriteLine(Messages.FirstResultStr);
            Console.WriteLine(string.Join(" ", spiralArray));
            Console.WriteLine();
            Console.WriteLine(Messages.SecondResultStr);
        }           
        private void HighlightDiagonal()//  Function to highlight main diagonal
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"{matrix[i, j],3} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"{matrix[i, j],3} ");
                    }
                }
                Console.WriteLine();

            }
        }     
        private void DiagonalSum()      //  Function to find sum of elements on main diagonal
        {
            Console.WriteLine();
            int diagonalSum = 0;
            for (int i = 0; i < Math.Min(rows, columns); i++)
            {
                diagonalSum += matrix[i, i];
            }
            Console.WriteLine(Messages.DiagonalSum + diagonalSum);
        }



    }
}
