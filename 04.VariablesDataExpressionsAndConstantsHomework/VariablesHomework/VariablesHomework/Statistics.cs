namespace VariablesHomework
{
    using System;

    public class Statistics
    {
        public void PrintStatistics(double[] array, int count)
        {
            double maximum = int.MinValue;
            for (int i = 0; i < count; i++)
            {
                if (array[i] > maximum)
                {
                    maximum = array[i];
                }
            }

            PrintMaximum(maximum);

            double minimum = int.MaxValue;
            for (int i = 0; i < count; i++)
            {
                if (array[i] < minimum)
                {
                    minimum = array[i];
                }
            }

            PrintMinimum(minimum);

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += array[i];
            }

            PrintAverage(sum / count);
        }
    }
}
