using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace RotatingWalkInAMatrix.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using WalkInAMatrix.MatrixOperators;

    [TestClass]
    public class SimpleMatrixOperatorTests
    {
        [TestMethod]
        public void SimpleMatrixOperatorTest_GetNewEmptySquareMatrixShouldReturnANewSquareMatrixWhenValidDataProvided()
        {
            var inputProvider = new ValidInputProvider();
            var lengthOfMatrix = inputProvider.ReadInteger();

            var matrixOperator = new SimpleMatrixOperator();
            var matrix = matrixOperator.GetNewEmptySquareMatrix(lengthOfMatrix);

            Assert.AreEqual(lengthOfMatrix, matrix.GetLength(0));
            Assert.AreEqual(lengthOfMatrix, matrix.GetLength(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SimpleMatrixOperatorTest_GetNewEmptySquareMatrixShouldThroWhenInvalidDataProvided()
        {
            var inputProvider = new InvalidInputProvider();
            var lengthOfMatrix = inputProvider.ReadInteger();

            var matrixOperator = new SimpleMatrixOperator();
            var matrix = matrixOperator.GetNewEmptySquareMatrix(lengthOfMatrix);
        }

        [TestMethod]
        public void SimpleMatrixOperatorTest_GetNextStartingEmptyCellCoordinatesShouldReturnCorrectCoordinatesWhenThereIsACellAvailable()
        {
            const int lengthOfMatrix = 4;
            var matrix = new int[lengthOfMatrix, lengthOfMatrix]
            {
                { 1, 2, 3, 4 },
                { 5, 0, 5, 5 },
                { 1, 1, 1, 1 },
                { 0, 0, 0, 0 }
            };

            var matrixOperator = new SimpleMatrixOperator();
            var result = matrixOperator.GetNextStartingEmptyCellCoordinates(matrix);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, result[1]);
        }

        [TestMethod]
        public void SimpleMatrixOperatorTest_GetNextStartingEmptyCellCoordinatesShouldReturnNullWhenNoCellIsAvailable()
        {
            const int lengthOfMatrix = 4;
            var matrix = new int[lengthOfMatrix, lengthOfMatrix]
            {
                { 1, 2, 3, 4 },
                { 5, 2, 5, 5 },
                { 1, 1, 1, 1 },
                { 3, 3, 3, 3 }
            };

            var matrixOperator = new SimpleMatrixOperator();
            var result = matrixOperator.GetNextStartingEmptyCellCoordinates(matrix);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SimpleMatrixOperatorTest_GetNextStartingEmptyCellCoordinatesShouldThrowWhenMatrixIsNull()
        {
            var matrixOperator = new SimpleMatrixOperator();
            var result = matrixOperator.GetNextStartingEmptyCellCoordinates(null);
        }

        [TestMethod]
        public void SimpleMatrixOperatorTest_CurrentWalkingCycleCanContinueShouldReturnTrueWhenCellIsAvailable()
        {
            const int lengthOfMatrix = 4;
            var matrix = new int[lengthOfMatrix, lengthOfMatrix]
            {
                { 1, 2, 3, 4 },
                { 5, 0, 5, 5 },
                { 1, 1, 1, 1 },
                { 3, 3, 3, 3 }
            };

            var matrixOperator = new SimpleMatrixOperator();
            var result = matrixOperator.CurrentWalkingCycleCanContinue(matrix, 0, 0);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void SimpleMatrixOperatorTest_CurrentWalkingCycleCanContinueShouldReturnFalseWhenCellIsNotAvailableInside()
        {
            const int lengthOfMatrix = 4;
            var matrix = new int[lengthOfMatrix, lengthOfMatrix]
            {
                { 1, 2, 3, 4 },
                { 5, 5, 5, 5 },
                { 1, 1, 1, 1 },
                { 3, 3, 3, 3 }
            };

            var matrixOperator = new SimpleMatrixOperator();
            var result = matrixOperator.CurrentWalkingCycleCanContinue(matrix, 0, 0);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SimpleMatrixOperatorTest_CurrentWalkingCycleCanContinueShouldReturnFalseWhenCellIsNotAvailableOutside()
        {
            const int lengthOfMatrix = 4;
            var matrix = new int[lengthOfMatrix, lengthOfMatrix]
            {
                { 1, 2, 3, 4 },
                { 5, 5, 5, 5 },
                { 1, 1, 1, 1 },
                { 3, 3, 3, 3 }
            };

            var matrixOperator = new SimpleMatrixOperator();
            var result = matrixOperator.CurrentWalkingCycleCanContinue(matrix, 100, 100);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SimpleMatrixOperatorTest_FillShouldCorrectlyFillTheMatrix()
        {
            const int lengthOfMatrix = 6;
            var matrix = new int[lengthOfMatrix, lengthOfMatrix]
            {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };

            var matrixOperator = new SimpleMatrixOperator();
            matrixOperator.Fill(matrix);

            var result = "";

            for(var row = 0; row < lengthOfMatrix; row++)
            {
                for(var col = 0; col < lengthOfMatrix; col++)
                {
                    result += (matrix[row, col] + "  ");
                }
            }

            result = result.TrimEnd();

            var expected = "1  16  17  18  19  20  15  2  27  28  29  21  14  31  3  26  30  22  13  36  32  4  25  23  12  35  34  33  5  24  11  10  9  8  7  6";

            Assert.AreEqual(expected, result);
        }
    }
}
