namespace CompareAlgorithms
{
    using System;
    using System.Diagnostics;

    public class CompareSortingAlgorithms
    {
        public static void Main()
        {
            dynamic arr = 5;
            var stopwatch = new Stopwatch();
            var random = new Random();

            //TestInsertionSort(arr, stopwatch, random);
            //TestSelectionSort(arr, stopwatch, random);
            TestQuickSort(arr, stopwatch, random);
        }

        private static void TestInsertionSort(dynamic arr, Stopwatch stopwatch, Random random)
        {
            Console.WriteLine("***********************Insertion Sort***************************");
            // Random values
            Console.WriteLine("------------Random values---------------");

            Console.WriteLine("-----Int values-----");
            arr = new int[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = random.Next(-500000, 5000000);
            }

            stopwatch.Start();
            InsertionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----Double values-----");
            arr = new double[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = (double)random.Next(-5000000, 5000000) / 13;
            }

            stopwatch.Start();
            InsertionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----String values-----");
            arr = new string[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = random.Next(0, 5000000).ToString();
            }

            stopwatch.Start();
            InsertionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Sorted values
            Console.WriteLine("------------Sorted values---------------");

            Console.WriteLine("-----Int values-----");
            arr = new int[5000000];
            for (var i = 0; i < 5000000; i++)
            {
                arr[i] = i;
            }

            stopwatch.Start();
            InsertionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms - 500 times more values", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----Double values-----");
            arr = new double[5000000];
            for (var i = 0; i < 5000000; i++)
            {
                arr[i] = (double)i / 13;
            }

            stopwatch.Start();
            InsertionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms - 500 times more values", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----String values-----");
            arr = new string[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = i.ToString();
            }

            stopwatch.Start();
            InsertionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Reversed sort values
            Console.WriteLine("------------Reverse sort values---------------");

            Console.WriteLine("-----Int values-----");
            arr = new int[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = -i;
            }

            stopwatch.Start();
            InsertionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----Double values-----");
            arr = new int[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = -i;
            }

            stopwatch.Start();
            InsertionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----String values-----");
            arr = new string[10000];
            for (var i = 1; i < 10000; i++)
            {
                arr[10000 - i] = (DateTime.Now.Ticks + i).ToString();
            }

            stopwatch.Start();
            InsertionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }

        private static void TestSelectionSort(dynamic arr, Stopwatch stopwatch, Random random)
        {
            Console.WriteLine("***********************Selection Sort***************************");
            // Random values
            Console.WriteLine("------------Random values---------------");

            Console.WriteLine("-----Int values-----");
            arr = new int[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = random.Next(-5000000, 5000000);
            }

            stopwatch.Start();
            SelectionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----Double values-----");
            arr = new double[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = (double)random.Next(-5000000, 5000000) / 13;
            }

            stopwatch.Start();
            SelectionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----String values-----");
            arr = new string[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = random.Next(0, 5000000).ToString();
            }

            stopwatch.Start();
            SelectionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Sorted values
            Console.WriteLine("------------Sorted values---------------");

            Console.WriteLine("-----Int values-----");
            arr = new int[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = i;
            }

            stopwatch.Start();
            SelectionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----Double values-----");
            arr = new double[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = (double)i / 13;
            }

            stopwatch.Start();
            SelectionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----String values-----");
            arr = new string[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = i.ToString();
            }

            stopwatch.Start();
            SelectionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Reversed sort values
            Console.WriteLine("------------Reverse sort values---------------");

            Console.WriteLine("-----Int values-----");
            arr = new int[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = -i;
            }

            stopwatch.Start();
            SelectionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----Double values-----");
            arr = new int[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = -i;
            }

            stopwatch.Start();
            SelectionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----String values-----");
            arr = new string[10000];
            for (var i = 1; i <= 10000; i++)
            {
                arr[10000 - i] = (DateTime.Now.Ticks + i).ToString();
            }

            stopwatch.Start();
            SelectionSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }

        private static void TestQuickSort(dynamic arr, Stopwatch stopwatch, Random random)
        {
            Console.WriteLine("***********************QuickSort***************************");
            // Random values
            Console.WriteLine("------------Random values---------------");

            Console.WriteLine("-----Int values-----");
            arr = new int[100000];
            for (var i = 0; i < 100000; i++)
            {
                arr[i] = random.Next(-5000000, 5000000);
            }

            stopwatch.Start();
            QuickSort(arr, 0, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms - 10 times more numbers", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----Double values-----");
            arr = new double[100000];
            for (var i = 0; i < 100000; i++)
            {
                arr[i] = (double)random.Next(-5000000, 5000000) / 13;
            }

            stopwatch.Start();
            QuickSort(arr, 0, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms - 10 times more numbers", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----String values-----");
            arr = new string[100000];
            for (var i = 0; i < 100000; i++)
            {
                arr[i] = random.Next(0, 5000000).ToString();
            }

            stopwatch.Start();
            QuickSort(arr, 0, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms - 10 times more numbers", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Sorted values
            Console.WriteLine("------------Sorted values---------------");

            Console.WriteLine("-----Int values-----");
            arr = new int[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = i;
            }

            stopwatch.Start();
            QuickSort(arr, 0, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----Double values-----");
            arr = new double[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = (double)i / 13;
            }

            stopwatch.Start();
            QuickSort(arr, 0, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----String values-----");
            arr = new string[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = i.ToString();
            }

            stopwatch.Start();
            QuickSort(arr, 0, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            // Reversed sort values
            Console.WriteLine("------------Reverse sort values---------------");

            Console.WriteLine("-----Int values-----");
            arr = new int[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = -i;
            }

            stopwatch.Start();
            QuickSort(arr, 0, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----Double values-----");
            arr = new int[10000];
            for (var i = 0; i < 10000; i++)
            {
                arr[i] = -i;
            }

            stopwatch.Start();
            QuickSort(arr, 0, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            Console.WriteLine("-----String values-----");
            arr = new string[10000];
            for (var i = 1; i < 10000; i++)
            {
                arr[10000 - i] = (DateTime.Now.Ticks + i).ToString();
            }

            stopwatch.Start();
            QuickSort(arr, 0, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time: {0}ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }

        private static void InsertionSort(int[] arr)
        {
            int i, j, len;
            for (i = 1, len = arr.Length; i < len; i++)
            {
                j = i;
                while (j > 0 && arr[j - 1] > arr[j])
                {
                    Swap(arr, j - 1, j);
                    --j;
                }
            }
        }

        private static void InsertionSort(double[] arr)
        {
            int i, j, len;
            for (i = 1, len = arr.Length; i < len; i++)
            {
                j = i;
                while (j > 0 && arr[j - 1] > arr[j])
                {
                    Swap(arr, j - 1, j);
                    --j;
                }
            }
        }

        private static void InsertionSort(string[] arr)
        {
            int i, j, len;
            for (i = 1, len = arr.Length; i < len; i++)
            {
                j = i;
                while (j > 0 && string.Compare(arr[j - 1], arr[j]) == 1)
                {
                    Swap(arr, j - 1, j);
                    --j;
                }
            }
        }

        private static void SelectionSort(int[] arr)
        {
            int i, j, len;
            int iMin;

            for (j = 0, len = arr.Length; j < len; j++)
            {
                iMin = j;

                for (i = j + 1; i < len; i++)
                {
                    if (arr[i] < arr[iMin])
                    {
                        iMin = i;
                    }
                }

                if (iMin != j)
                {
                    Swap(arr, j, iMin);
                }
            }
        }

        private static void SelectionSort(double[] arr)
        {
            int i, j, len;
            int iMin;

            for (j = 0, len = arr.Length; j < len; j++)
            {
                iMin = j;

                for (i = j + 1; i < len; i++)
                {
                    if (arr[i] < arr[iMin])
                    {
                        iMin = i;
                    }
                }

                if (iMin != j)
                {
                    Swap(arr, j, iMin);
                }
            }
        }

        private static void SelectionSort(string[] arr)
        {
            int i, j, len;
            int iMin;

            for (j = 0, len = arr.Length; j < len; j++)
            {
                iMin = j;

                for (i = j + 1; i < len; i++)
                {
                    if (string.CompareOrdinal(arr[i], arr[iMin]) == -1)
                    {
                        iMin = i;
                    }
                }

                if (iMin != j)
                {
                    Swap(arr, j, iMin);
                }
            }
        }

        private static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotLocation = Partition(arr, low, high);
                QuickSort(arr, low, pivotLocation);
                QuickSort(arr, pivotLocation + 1, high);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[low];
            int leftWall = low;

            for (var i = low + 1; i < high; i++)
            {
                if (arr[i] < pivot)
                {
                    leftWall += 1;
                    Swap(arr, i, leftWall);
                }
            }

            Swap(arr, low, leftWall);

            return leftWall;
        }

        private static void QuickSort(double[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotLocation = Partition(arr, low, high);
                QuickSort(arr, low, pivotLocation);
                QuickSort(arr, pivotLocation + 1, high);
            }
        }

        private static int Partition(double[] arr, int low, int high)
        {
            double pivot = arr[low];
            int leftWall = low;

            for (var i = low + 1; i < high; i++)
            {
                if (arr[i] < pivot)
                {
                    leftWall += 1;
                    Swap(arr, i , leftWall);
                }
            }

            Swap(arr, low, leftWall);

            return leftWall;
        }

        private static void QuickSort(string[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotLocation = Partition(arr, low, high);
                QuickSort(arr, low, pivotLocation);
                QuickSort(arr, pivotLocation + 1, high);
            }
        }

        private static int Partition(string[] arr, int low, int high)
        {
            string pivot = arr[low];
            int leftWall = low;

            for (var i = low + 1; i < high; i++)
            {
                if (string.Compare(arr[i], pivot) == -1)
                {
                    leftWall += 1;
                    Swap(arr, i, leftWall);
                }
            }

            Swap(arr, low, leftWall);

            return leftWall;
        }

        private static void Swap(int[] arr, int i1, int i2)
        {
            int oldP1 = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = oldP1;
        }

        private static void Swap(double[] arr, int i1, int i2)
        {
            double oldP1 = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = oldP1;
        }

        private static void Swap(string[] arr, int i1, int i2)
        {
            string oldP1 = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = oldP1;
        }
    }
}
