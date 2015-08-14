namespace WalkInAMatrix.Engine
{
    using Contracts;
    using InputProviders.Contracts;
    using MatrixOperators.Contracts;
    using Renderers.Contracts;

    public class MatrixWalkEngine : IMatrixWalkEngine
    {
        public void Run(IInputProvider consoleInputProvider, IMatrixOperator matrixOperator, IRenderer consoleRenderer)
        {
            int lengthOfMatrix = consoleInputProvider.ReadInteger();

            int[,] matrix = matrixOperator.GetNewEmptySquareMatrix(lengthOfMatrix);
            matrixOperator.Fill(matrix);

            consoleRenderer.RenderMatrix(matrix);
        }
    }
}
