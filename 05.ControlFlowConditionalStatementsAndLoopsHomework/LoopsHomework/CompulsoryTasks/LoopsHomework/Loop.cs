namespace LoopsHomework
{
    using System;

    public class Loop
    {
        public static void Find()
        {
            int[] array = new int[20];
            var expectedValue = 7;

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                    if (array[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                        break;
                    }

                    i++;
                }
                else
                {
                    Console.WriteLine(array[i]);
                    i++;
                }
            }
        }
    }
}
