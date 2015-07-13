using System;

public class SearchInBits
{
    public static void Main()
    {
        // INPUT
        string sequence = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(4, '0');
        int numberOfInputs = int.Parse(Console.ReadLine());
        string[] inputs = new string[numberOfInputs];
        for (int i = 0; i < numberOfInputs; i++)
        {
            inputs[i] = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(30, '0');
        }

        // SOLUTION
        int numberOfOccurrences = 0;
        for (int i = 0; i < numberOfInputs; i++)
        {
            for (int index = 0; index < inputs[i].Length - 3; index++)
            {
                if (inputs[i][index] == sequence[0]
                   && inputs[i][index + 1] == sequence[1]
                   && inputs[i][index + 2] == sequence[2]
                   && inputs[i][index + 3] == sequence[3])
                {
                    numberOfOccurrences++;
                }
            }
        }

        // OUTPUT
        Console.WriteLine(numberOfOccurrences);
    }
}
