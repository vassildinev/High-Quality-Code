namespace WalkInAMatrix.Renderers
{
    using System;
    using Contracts;

    public class ConsoleRenderer : IRenderer
    {
        public void RenderMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,-3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
