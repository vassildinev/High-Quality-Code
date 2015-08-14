
namespace WalkInAMatrix.MatrixOperators
{
    using Contracts;
    using Common;
    using System;

    public class SimpleMatrixOperator : IMatrixOperator
    {
        public SimpleMatrixOperator()
        {

        }

        public bool CurrentWalkingCycleCanContinue(int[,] matrix, int currentX, int currentY)
        {
            var radiusToCheck = 1;
            for (int row = currentX - radiusToCheck; row <= currentX + radiusToCheck; row++)
            {
                for (int col = currentY - radiusToCheck; col <= currentY + radiusToCheck; col++)
                {
                    var currentCellFromProximityRow = row;
                    var currentCellFromProximityCol = col;

                    var isCurrentCellFromProximityOutOfMatrixOnYAxis = (currentCellFromProximityRow > matrix.GetLength(0) - 1 || currentCellFromProximityRow < 0);
                    var isCurrentCellFromProximityOutOfMatrixOnXAxis = (currentCellFromProximityCol > matrix.GetLength(1) - 1 || currentCellFromProximityCol < 0);
                    var isCurrentCell = (row == currentX && col == currentY);
                    var isCurrentCellFromProximityValid = !(isCurrentCellFromProximityOutOfMatrixOnXAxis || isCurrentCellFromProximityOutOfMatrixOnYAxis || isCurrentCell);


                    if (isCurrentCellFromProximityValid)
                    {
                        var isCurrentCellFromProximityAvailable = matrix[currentCellFromProximityRow, currentCellFromProximityCol] == 0;
                        if (isCurrentCellFromProximityAvailable)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public int[] GetNextStartingEmptyCellCoordinates(int[,] matrix)
        {
            if(matrix == null)
            {
                throw new ArgumentNullException();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        return new int[Constants.NumberOfAxes] { row, col };
                    }
                }
            }

            return null;
        }

        public int[,] GetNewEmptySquareMatrix(int lengthOfMatrix)
        {
            if(lengthOfMatrix < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new int[lengthOfMatrix, lengthOfMatrix];
        }

        public void Fill(int[,] matrix)
        {
            var currentDirectionIndex = 0;
            var startingDirection = Constants.Directions[currentDirectionIndex];

            int currentStepValue = 1;
            int currentX = 0;
            int currentY = 0;
            int currentWalkingDirectionX = startingDirection[0];
            int currentWalkingDirectionY = startingDirection[1];

            var lengthOfMatrix = matrix.GetLength(0);

            while (true)
            {
                while (true)
                {
                    matrix[currentX, currentY] = currentStepValue;

                    if (!CurrentWalkingCycleCanContinue(matrix, currentX, currentY))
                    {
                        ++currentStepValue;
                        break;
                    }

                    var isOutOfMatrixOnXAxis = currentX + currentWalkingDirectionX >= lengthOfMatrix || currentX + currentWalkingDirectionX < 0;
                    var isOutOfMatrixOnYAxis = currentY + currentWalkingDirectionY >= lengthOfMatrix || currentY + currentWalkingDirectionY < 0;
                    var nextCellIsAvailable = (isOutOfMatrixOnXAxis || isOutOfMatrixOnYAxis) ?
                                             false : matrix[currentX + currentWalkingDirectionX, currentY + currentWalkingDirectionY] == 0;

                    if (!nextCellIsAvailable)
                    {
                        while (!nextCellIsAvailable)
                        {
                            ++currentDirectionIndex;
                            currentDirectionIndex %= Constants.NumberOfDirections;
                            var newDirection = Constants.Directions[currentDirectionIndex];
                            currentWalkingDirectionX = newDirection[0];
                            currentWalkingDirectionY = newDirection[1];

                            isOutOfMatrixOnXAxis = currentX + currentWalkingDirectionX >= lengthOfMatrix || currentX + currentWalkingDirectionX < 0;
                            isOutOfMatrixOnYAxis = currentY + currentWalkingDirectionY >= lengthOfMatrix || currentY + currentWalkingDirectionY < 0;
                            nextCellIsAvailable =
                                (isOutOfMatrixOnXAxis || isOutOfMatrixOnYAxis) ?
                                false : matrix[currentX + currentWalkingDirectionX, currentY + currentWalkingDirectionY] == 0;
                        }
                    }

                    currentX += currentWalkingDirectionX;
                    currentY += currentWalkingDirectionY;
                    currentStepValue++;
                }

                var nextStartingEmptyCellCoordinates = GetNextStartingEmptyCellCoordinates(matrix);

                if (nextStartingEmptyCellCoordinates == null)
                {
                    break;
                }

                currentX = nextStartingEmptyCellCoordinates[0];
                currentY = nextStartingEmptyCellCoordinates[1];
                currentWalkingDirectionX = startingDirection[0];
                currentWalkingDirectionY = startingDirection[1];

            }
        }
    }
}
