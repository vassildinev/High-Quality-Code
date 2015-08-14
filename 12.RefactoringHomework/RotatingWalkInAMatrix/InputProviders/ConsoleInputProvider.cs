namespace WalkInAMatrix.InputProviders
{
    using Contracts;
    using System;

    public class ConsoleInputProvider : IInputProvider
    {
        public ConsoleInputProvider()
        {

        }

        public int ReadInteger()
        {
            var number = int.Parse(Console.ReadLine());

            return number;
        }
    }
}
