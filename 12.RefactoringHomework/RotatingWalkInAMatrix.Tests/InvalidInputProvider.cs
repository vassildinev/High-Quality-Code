namespace RotatingWalkInAMatrix.Tests
{
    using WalkInAMatrix.InputProviders.Contracts;

    public class InvalidInputProvider : IInputProvider
    {
        public InvalidInputProvider()
        {
        }

        public int ReadInteger()
        {
            return -5;
        }
    }
}
