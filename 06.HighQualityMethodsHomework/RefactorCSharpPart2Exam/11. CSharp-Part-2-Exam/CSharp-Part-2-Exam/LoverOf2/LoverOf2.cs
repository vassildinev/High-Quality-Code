//-----------------------------------------------------------------------
// <copyright file="LoverOf2.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CSharpPart2Exam
{
    using System;
    using System.Linq;
    using System.Numerics;

    /// <summary>
    /// Class for the solution of the task Lover of 2 in the CSharp Part 2 Exam in TA 2015
    /// </summary>
    public class LoverOf2
    {
        /// <summary>
        /// Entry point for the solution
        /// </summary>
        public static void Main()
        {
            int matrixRows = int.Parse(Console.ReadLine());
            int matrixCols = int.Parse(Console.ReadLine());
            int numberOfPawnPositions = int.Parse(Console.ReadLine());
            int[] codedPawnPositions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int positionDeterminingCoefficient = Math.Max(matrixRows, matrixCols);
            BigInteger[,] matrix = new BigInteger[matrixRows, matrixCols];
            BigInteger gatheredPoints = 0;

            FillMatrix(matrix);

            // Start position
            int currentPawnR = matrixRows - 1;
            int currentPawnC = 0;

            // Include start position in gathered points and specify the cell as visited(i.e. assign it value 0)
            gatheredPoints += matrix[currentPawnR, currentPawnC];
            matrix[currentPawnR, currentPawnC] = 0;

            for (int i = 0; i < numberOfPawnPositions; i++)
            {
                int currentCodedPawnPosition = codedPawnPositions[i];
                int nextPawnR = (currentCodedPawnPosition / positionDeterminingCoefficient) % matrixRows;
                int nextPawnC = (currentCodedPawnPosition % positionDeterminingCoefficient) % matrixCols;

                // Gather points along the same column first
                for (int row = Math.Min(currentPawnR, nextPawnR); row <= Math.Max(currentPawnR, nextPawnR); row++)
                {
                    gatheredPoints += matrix[row, currentPawnC];
                    matrix[row, currentPawnC] = 0;
                }

                currentPawnR = nextPawnR;

                // Then gather points along the same row
                for (int col = Math.Min(currentPawnC, nextPawnC); col <= Math.Max(currentPawnC, nextPawnC); col++)
                {
                    gatheredPoints += matrix[currentPawnR, col];
                    matrix[currentPawnR, col] = 0;
                }

                // Pawn has moved, all points for current move have been collected and the new position must be set
                currentPawnC = nextPawnC;
            }

            Console.WriteLine(gatheredPoints);
        }

        /// <summary>
        /// Fills a 2-dimensional array of BigIntegers with powers of 2
        /// following a predefined pattern
        /// </summary>
        /// <param name="matrix">2-dimensional array of BigIntegers to fill</param>
        private static void FillMatrix(BigInteger[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[matrix.GetLength(0) - 1 - row, col] = Power(2, row + col);
                }
            }
        }

        /// <summary>
        /// Raises an unsigned 64-bit-integer to a power
        /// </summary>
        /// <param name="number">Unsigned 64-bit-integer to raise</param>
        /// <param name="power">Unsigned 32-bit-integer to raise to</param>
        /// <returns>Result as BigInteger</returns>
        private static BigInteger Power(ulong number, int power)
        {
            BigInteger result = 1;

            // Multiply number "power" times
            for (int i = 0; i < power; i++)
            {
                result *= number;
            }

            return result;
        }

        /// <summary>
        /// Writes a 2-dimensional array of BigIntegers on the console.
        /// Each row is separated by a new line 
        /// and each number on a line by a single tab
        /// </summary>
        /// <param name="matrix">2-dimensional array of BigIntegers</param>
        private static void PrintMatrix(BigInteger[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }
    }
}