using LibrarySnail;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MatrixHelperTests
    {
        [Test]
        public void GetMatrixTrace_SquareMatrix_ReturnsCorrectTrace()
        {
            int[,] matrix = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            int trace = MatrixHelper.GetMatrixTrace(matrix);

            Assert.AreEqual(15, trace);
        }

        [Test]
        public void GetMatrixTrace_RectangleMatrix_ReturnsCorrectTrace()
        {
            int[,] matrix = {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 }
            };

            int trace = MatrixHelper.GetMatrixTrace(matrix);

            Assert.AreEqual(18, trace);
        }
    }
}