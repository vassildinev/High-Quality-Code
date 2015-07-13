using System;
using System.Numerics;

public class ConsoleApplication1
{
    public static void Main()
    {
        // INPUT
        int count = 0;
        BigInteger product = 1;
        BigInteger newProduct = 1;
        string input = Console.ReadLine();
        long number;
        while (input != "END")
        {
            count++;
            if (count % 2 == 0)
            {
                number = long.Parse(input);
                if (count <= 10)
                {
                    if (number != 0)
                    {
                        while (number != 0)
                        {
                            if (number % 10 != 0)
                            {
                                product *= number % 10;
                            }

                            number /= 10;
                        }
                    }
                }
                else
                {
                    number = long.Parse(input);
                    if (number != 0)
                    {
                        while (number != 0)
                        {
                            if (number % 10 != 0)
                            {
                                newProduct *= number % 10;
                            }

                            number /= 10;
                        }
                    }
                }
            }

            input = Console.ReadLine();
        }

        // OUTPUT
        Console.WriteLine(product.ToString());
        if (count > 10)
        {
            Console.WriteLine(newProduct.ToString());
        }
    }
}