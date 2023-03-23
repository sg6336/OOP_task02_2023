using LibrarySnail;

namespace LibrarySnailTest
{
    [TestFixture]
    public class SnailTests
    {
        private Snail _snail;
        [SetUp]
        public void Setup()
        {
            _snail = new Snail();
        }

        [Test]
        public void ReadAsSpiral_MatrixWithOneElement()
        {
            int[,] matrix = new int[,] { { 5 } };
            int[,] spiralMatrix;
            int[] expected = new int[] { 5 };
            int[] actual = _snail.ReadAsSpiral(matrix, out spiralMatrix);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ReadAsSpiral_SquareMatrix()
        {
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] spiralMatrix;
            int[] expected = new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            int[] actual = _snail.ReadAsSpiral(matrix, out spiralMatrix);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ReadAsSpiral_RectangularMatrix()
        {
            int[,] matrix = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
            int[,] spiralMatrix;
            int[] expected = new int[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 };
            int[] actual = _snail.ReadAsSpiral(matrix, out spiralMatrix);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ReadAsSpiral_MatrixWithRepeatedElements()
        {
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            int[,] spiralMatrix;
            int[] expected = new int[] { 1, 2, 3, 3, 3, 2, 1, 1, 2 };
            int[] actual = _snail.ReadAsSpiral(matrix, out spiralMatrix);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}