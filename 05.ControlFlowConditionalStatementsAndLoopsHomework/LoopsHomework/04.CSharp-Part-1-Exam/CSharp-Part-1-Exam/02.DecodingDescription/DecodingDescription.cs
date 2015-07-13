using System;

public class DecodingDescription
{
    public static void Main()
    {
        // INPUT
        int salt = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();

        // OUTPUT
        for (int i = 0; i < text.Length; i++)
        {
            char symbol = text[i];
            if (symbol == '@')
            {
                break;
            }

            if (char.IsLetter(symbol))
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0:F2}", (((decimal)symbol * salt) + 1000) / 100);
                }
                else
                {
                    Console.WriteLine("{0}", (((int)symbol * salt) + 1000) * 100);
                }
            }
            else if (char.IsDigit(symbol))
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0:F2}", ((decimal)symbol + salt + 500) / 100);
                }
                else
                {
                    Console.WriteLine("{0}", ((long)symbol + salt + 500) * 100);
                }
            }
            else if (!char.IsDigit(symbol) && !char.IsLetter(symbol))
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0:F2}", ((decimal)symbol - salt) / 100);
                }
                else
                {
                    Console.WriteLine("{0}", ((long)symbol - salt) * 100);
                }
            }
        }
    }
}