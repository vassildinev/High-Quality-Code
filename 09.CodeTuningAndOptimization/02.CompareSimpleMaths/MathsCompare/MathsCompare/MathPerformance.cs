namespace MathsCompare
{
    using System;
    using System.Diagnostics;

    public class MathPerformance
    {
        public static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            CompareInts();
            CompareLongs();
            CompareFloats();
            CompareDoubles();
            CompareDecimals();

        }

        private static void CompareDecimals()
        {
            var stopwatch = new Stopwatch();
            decimal number = 0M;

            Console.WriteLine("--------------------------------");
            // Addition
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i + 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Decimals addition = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Subtraction
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i - 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Decimals subtraction = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Increment
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number++;
            }
            stopwatch.Stop();
            Console.WriteLine("Decimals increment = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Multiplication
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i * 2;
            }
            stopwatch.Stop();
            Console.WriteLine("Decimals multiplication = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Division
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i / 2; ;
            }
            stopwatch.Stop();
            Console.WriteLine("Decimals division = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("--------------------------------");
        }

        private static void CompareDoubles()
        {
            var stopwatch = new Stopwatch();
            double number = 0;

            Console.WriteLine("--------------------------------");
            // Addition
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i + 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Doubles addition = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Subtraction
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i - 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Doubles subtraction = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Increment
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number++;
            }
            stopwatch.Stop();
            Console.WriteLine("Doubles increment = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Multiplication
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i * 2;
            }
            stopwatch.Stop();
            Console.WriteLine("Doubles multiplication = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Division
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i / 2; ;
            }
            stopwatch.Stop();
            Console.WriteLine("Doubles division = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("--------------------------------");
        }

        private static void CompareFloats()
        {
            var stopwatch = new Stopwatch();
            float number = 0;

            Console.WriteLine("--------------------------------");
            // Addition
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i + 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Floats addition = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Subtraction
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i - 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Floats subtraction = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Increment
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number++;
            }
            stopwatch.Stop();
            Console.WriteLine("Floats increment = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Multiplication
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i * 2;
            }
            stopwatch.Stop();
            Console.WriteLine("Floats multiplication = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Division
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i / 2; ;
            }
            stopwatch.Stop();
            Console.WriteLine("Floats division = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("--------------------------------");
        }

        private static void CompareLongs()
        {
            var stopwatch = new Stopwatch();
            long number = 0;

            Console.WriteLine("--------------------------------");
            // Addition
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i + 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Longs addition = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Subtraction
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i - 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Longs subtraction = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Increment
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number++;
            }
            stopwatch.Stop();
            Console.WriteLine("Longs increment = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Multiplication
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i * 2;
            }
            stopwatch.Stop();
            Console.WriteLine("Longs multiplication = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Division
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i / 2; ;
            }
            stopwatch.Stop();
            Console.WriteLine("Longs division = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("--------------------------------");
        }

        private static void CompareInts()
        {
            var stopwatch = new Stopwatch();
            int number = 0;

            Console.WriteLine("--------------------------------");
            // Addition
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i + 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Ints addition = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Subtraction
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i - 1;
            }
            stopwatch.Stop();
            Console.WriteLine("Ints subtraction = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Increment
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number++;
            }
            stopwatch.Stop();
            Console.WriteLine("Ints increment = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Multiplication
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i * 2;
            }
            stopwatch.Stop();
            Console.WriteLine("Ints multiplication = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Division
            stopwatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                number = i / 2; ;
            }
            stopwatch.Stop();
            Console.WriteLine("Ints division = {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("--------------------------------");
        }
    }
}
