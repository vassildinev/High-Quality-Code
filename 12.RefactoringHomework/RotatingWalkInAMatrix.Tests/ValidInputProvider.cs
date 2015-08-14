namespace RotatingWalkInAMatrix.Tests
{
    using WalkInAMatrix.InputProviders.Contracts;

    public class ValidInputProvider : IInputProvider
    {
        public ValidInputProvider()
        {
        }

        public int ReadInteger()
        {
            return 5;
        }
    }
}
