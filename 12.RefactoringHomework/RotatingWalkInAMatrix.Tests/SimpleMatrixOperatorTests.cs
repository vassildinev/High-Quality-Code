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
            int lengthOfMatrix = inputProvider.ReadInteger();

            var matrixOperator = new SimpleMatrixOperator();
            int[,] matrix = matrixOperator.GetNewEmptySquareMatrix(lengthOfMatrix);

            Assert.AreEqual(lengthOfMatrix, matrix.GetLength(dimension: 0));
            Assert.AreEqual(lengthOfMatrix, matrix.GetLength(dimension: 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SimpleMatrixOperatorTest_GetNewEmptySquareMatrixShouldThroWhenInvalidDataProvided()
        {
            var inputProvider = new InvalidInputProvider();
            int lengthOfMatrix = inputProvider.ReadInteger();

            var matrixOperator = new SimpleMatrixOperator();
            int[,] matrix = matrixOperator.GetNewEmptySquareMatrix(lengthOfMatrix);
        }

        [TestMethod]
        public void SimpleMatrixOperatorTest_GetNextStartingEmptyCellCoordinatesShouldReturnCorrectCoordinatesWhenThereIsACellAvailable()
        {
            const int LengthOfMatrix = 4;
            var matrix = new int[LengthOfMatrix, LengthOfMatrix]
            {
                { 1, 2, 3, 4 },
                { 5, 0, 5, 5 },
                { 1, 1, 1, 1 },
                { 0, 0, 0, 0 }
            };

            var matrixOperator = new SimpleMatrixOperator();
            int[] result = matrixOperator.GetNextStartingEmptyCellCoordinates(matrix);

            Assert.AreEqual(expected: 1, actual: result[0]);
            Assert.AreEqual(expected: 1, actual: result[1]);
        }

        [TestMethod]
        public void SimpleMatrixOperatorTest_GetNextStartingEmptyCellCoordinatesShouldReturnNullWhenNoCellIsAvailable()
        {
            const int LengthOfMatrix = 4;
            var matrix = new int[LengthOfMatrix, LengthOfMatrix]
            {
                { 1, 2, 3, 4 },
                { 5, 2, 5, 5 },
                { 1, 1, 1, 1 },
                { 3, 3, 3, 3 }
            };

            var matrixOperator = new SimpleMatrixOperator();
            int[] result = matrixOperator.GetNextStartingEmptyCellCoordinates(matrix);

            Assert.AreEqual(expected: null, actual: result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SimpleMatrixOperatorTest_GetNextStartingEmptyCellCoordinatesShouldThrowWhenMatrixIsNull()
        {
            var matrixOperator = new SimpleMatrixOperator();
            int[] result = matrixOperator.GetNextStartingEmptyCellCoordinates(matrix: null);
        }

        [TestMethod]
        public void SimpleMatrixOperatorTest_CurrentWalkingCycleCanContinueShouldReturnTrueWhenCellIsAvailable()
        {
            const int LengthOfMatrix = 4;
            var matrix = new int[LengthOfMatrix, LengthOfMatrix]
            {
                { 1, 2, 3, 4 },
                { 5, 0, 5, 5 },
                { 1, 1, 1, 1 },
                { 3, 3, 3, 3 }
            };

            var matrixOperator = new SimpleMatrixOperator();
            bool result = matrixOperator.CurrentWalkingCycleCanContinue(matrix, currentX: 0, currentY: 0);

            Assert.AreEqual(expected: true, actual: result);
        }

        [TestMethod]
        public void SimpleMatrixOperatorTest_CurrentWalkingCycleCanContinueShouldReturnFalseWhenCellIsNotAvailableInside()
        {
            const int LengthOfMatrix = 4;
            var matrix = new int[LengthOfMatrix, LengthOfMatrix]
            {
                { 1, 2, 3, 4 },
                { 5, 5, 5, 5 },
                { 1, 1, 1, 1 },
                { 3, 3, 3, 3 }
            };

            var matrixOperator = new SimpleMatrixOperator();
            bool result = matrixOperator.CurrentWalkingCycleCanContinue(matrix, currentX: 0, currentY: 0);

            Assert.AreEqual(expected: false, actual: result);
        }

        [TestMethod]
        public void SimpleMatrixOperatorTest_CurrentWalkingCycleCanContinueShouldReturnFalseWhenCellIsNotAvailableOutside()
        {
            const int LengthOfMatrix = 4;
            var matrix = new int[LengthOfMatrix, LengthOfMatrix]
            {
                { 1, 2, 3, 4 },
                { 5, 5, 5, 5 },
                { 1, 1, 1, 1 },
                { 3, 3, 3, 3 }
            };

            var matrixOperator = new SimpleMatrixOperator();
            bool result = matrixOperator.CurrentWalkingCycleCanContinue(matrix, currentX: 100, currentY: 100);

            Assert.AreEqual(expected: false, actual: result);
        }

        [TestMethod]
        public void SimpleMatrixOperatorTest_FillShouldCorrectlyFillTheMatrix()
        {
            const int LengthOfMatrix = 6;
            var matrix = new int[LengthOfMatrix, LengthOfMatrix]
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

            string result = "";

            for(var row = 0; row < LengthOfMatrix; row++)
            {
                for(var col = 0; col < LengthOfMatrix; col++)
                {
                    result += (matrix[row, col] + "  ");
                }
            }

            result = result.TrimEnd();

            string expected = "1  16  17  18  19  20  15  2  27  28  29  21  14  31  3  26  30  22  13  36  32  4  25  23  12  35  34  33  5  24  11  10  9  8  7  6";

            Assert.AreEqual(expected, result);
        }
    }
}
