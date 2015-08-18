namespace WalkInAMatrix
{
    using InputProviders;
    using MatrixOperators;
    using Renderers;
    using Engine;

    public class EntryPoint
    {
        public static void Main()
        {
            var consoleInputProvider = new ConsoleInputProvider();
            var matrixOperator = new SimpleMatrixOperator();
            var consoleRenderer = new ConsoleRenderer();

            var matrixWalkEngine = new MatrixWalkEngine();
            matrixWalkEngine.Run(consoleInputProvider, matrixOperator, consoleRenderer);
        }
    }
}
