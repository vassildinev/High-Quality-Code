namespace WalkInAMatrix.Engine.Contracts
{
    using InputProviders.Contracts;
    using MatrixOperators.Contracts;
    using Renderers.Contracts;

    public interface IMatrixWalkEngine
    {
        void Run(IInputProvider consoleInputProvider, IMatrixOperator matrixOperator, IRenderer consoleRenderer);
    }
}
