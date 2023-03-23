namespace LibrarySnail
{
    public class Snail
    {
        public int[] ReadAsSpiral(int[,] matrix, out int[,] spiralMatrix)
        {
            int width = matrix.GetLength(1);
            int height = matrix.GetLength(0);
            spiralMatrix = new int[height, width];
            var array = new int[width * height];
            int index = 0;
            int minX = 0;
            int maxX = width - 1;
            int minY = 0;
            int maxY = height - 1;
            while (true)
            {
                if (maxX - minX < 0)
                    break;
                for (int i = minX; i <= maxX; i++)
                {
                    array[index] = matrix[minY, i];
                    spiralMatrix[minY, i] = array[index++];
                }
                minY++;

                if (maxY - minY < 0)
                    break;
                for (int i = minY; i <= maxY; i++)
                {
                    array[index] = matrix[i, maxX];
                    spiralMatrix[i, maxX] = array[index++];
                }
                maxX--;

                if (maxX - minX < 0)
                    break;
                for (int i = maxX; i >= minX; i--)
                {
                    array[index] = matrix[maxY, i];
                    spiralMatrix[maxY, i] = array[index++];
                }
                maxY--;

                if (maxY - minY < 0)
                    break;
                for (int i = maxY; i >= minY; i--)
                {
                    array[index] = matrix[i, minX];
                    spiralMatrix[i, minX] = array[index++];
                }
                minX++;
            }
            return array;
        }
    }
}