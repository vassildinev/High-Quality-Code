namespace AdvancedMaths
{
    using System;
    using System.Diagnostics;

    public class CompareAdvancedMaths
    {
        public static void Main()
        {
            var stopwatch = new Stopwatch();
            CompareSquareRoot(stopwatch);
            //CompareNaturalLogarithm(stopwatch);
            //CompareSinus(stopwatch);
        }

        private static void CompareSinus(Stopwatch stopwatch)
        {
            Console.WriteLine("----------Sinus------------");
            stopwatch.Start();
            for (int i = 0; i < 10000000; i++)
            {
                Math.Sin(i);
            }
            stopwatch.Stop();
            Console.WriteLine("Integers: {0} ms", stopwatch.ElapsedMilliseconds);

            stopwatch.Start();
            for (double i = 0; i < 10000000; i++)
            {
                Math.Sin(i / 3);
            }
            stopwatch.Stop();
            Console.WriteLine("Doubles: {0} ms", stopwatch.ElapsedMilliseconds);

            stopwatch.Start();
            for (decimal i = 0; i < 10000000; i++)
            {
                Math.Sin((double)(i / 3));
            }
            stopwatch.Stop();
            Console.WriteLine("Decimals: {0} ms", stopwatch.ElapsedMilliseconds);
        }

        private static void CompareNaturalLogarithm(Stopwatch stopwatch)
        {
            Console.WriteLine("----------Natural logarithm------------");
            stopwatch.Start();
            for (int i = 0; i < 10000000; i++)
            {
                Math.Log(i, Math.E);
            }
            stopwatch.Stop();
            Console.WriteLine("Integers: {0} ms", stopwatch.ElapsedMilliseconds);

            stopwatch.Start();
            for (double i = 0; i < 10000000; i++)
            {
                Math.Log(i / 3, Math.E);
            }
            stopwatch.Stop();
            Console.WriteLine("Doubles: {0} ms", stopwatch.ElapsedMilliseconds);

            stopwatch.Start();
            for (decimal i = 0; i < 10000000; i++)
            {
                Math.Log((double)(i / 3), Math.E);
            }
            stopwatch.Stop();
            Console.WriteLine("Decimals: {0} ms", stopwatch.ElapsedMilliseconds);
        }

        private static void CompareSquareRoot(Stopwatch stopwatch)
        {
            Console.WriteLine("----------Square Root------------");
            stopwatch.Start();
            for (int i = 0; i < 10000000; i++)
            {
                Math.Sqrt(i);
            }
            stopwatch.Stop();
            Console.WriteLine("Integers: {0} ms", stopwatch.ElapsedMilliseconds);

            stopwatch.Start();
            for (double i = 0; i < 10000000; i++)
            {
                Math.Sqrt(i / 3);
            }
            stopwatch.Stop();
            Console.WriteLine("Doubles: {0} ms", stopwatch.ElapsedMilliseconds);

            stopwatch.Start();
            for (decimal i = 0; i < 10000000; i++)
            {
                Math.Sqrt((double)(i / 3));
            }
            stopwatch.Stop();
            Console.WriteLine("Decimals: {0} ms", stopwatch.ElapsedMilliseconds);
        }
    }
}
