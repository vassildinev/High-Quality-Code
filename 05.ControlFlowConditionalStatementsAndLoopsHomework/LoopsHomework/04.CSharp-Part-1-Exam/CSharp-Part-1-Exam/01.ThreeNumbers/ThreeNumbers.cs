using System;

public class Three_Numbers
{
    public static void Main()
    {
        // INPUT
        long firstNumber = long.Parse(Console.ReadLine());
        long secondNumber = long.Parse(Console.ReadLine());
        long thirdNumber = long.Parse(Console.ReadLine());

        // SOLUTION
        long biggest = Math.Max(Math.Max(firstNumber, secondNumber), thirdNumber);
        long smallest = Math.Min(Math.Min(firstNumber, secondNumber), thirdNumber);
        decimal arithmeticMean = (decimal)(firstNumber + secondNumber + thirdNumber) / 3;

        // OUTPUT
        Console.WriteLine(biggest);
        Console.WriteLine(smallest);
        Console.WriteLine("{0:F2}", arithmeticMean);
    }
}