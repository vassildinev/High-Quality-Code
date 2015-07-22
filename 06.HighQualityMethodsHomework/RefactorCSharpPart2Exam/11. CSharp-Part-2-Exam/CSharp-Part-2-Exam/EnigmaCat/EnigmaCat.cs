//-----------------------------------------------------------------------
// <copyright file="EnigmaCat.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CSharpPart2Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class for the solution of the task Enigma Cat in the CSharp Part 2 Exam in TA 2015
    /// </summary>
    public class EnigmaCat
    {
        /// <summary>
        /// Entry point for the solution
        /// </summary>
        public static void Main()
        {
            // Convert the received string input to an array of number strings
            string[] catNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var results = new List<string>();

            foreach (string number in catNumbers)
            {
                ulong decimalNum = ConvertToDecimal(number, 17);
                string result = ConvertToBase26(decimalNum);
                results.Add(result);
            }

            // Join the converted numbers as the assignment requires
            Console.WriteLine(string.Join(" ", results));
        }

        /// <summary>
        /// Raises an unsigned 64-bit-integer to a power
        /// </summary>
        /// <param name="number">Unsigned 64-bit-integer to raise</param>
        /// <param name="power">Unsigned 32-bit-integer to raise to</param>
        /// <returns>Unsigned 64-bit-number</returns>
        private static ulong NumberToPower(ulong number, uint power)
        {
            ulong result = 1;

            // Multiply number "power" times
            for (uint i = 0; i < power; i++)
            {
                result *= number;
            }

            return result;
        }

        /// <summary>
        /// Converts an unsigned 64-bit-integer to base 26 numeric system
        /// </summary>
        /// <param name="decimalNumber">Number to convert as an unsigned 64-bit-integer</param>
        /// <returns>Number in base 26 numeric system as string</returns>
        private static string ConvertToBase26(ulong decimalNumber)
        {
            StringBuilder converedNumberToBase26AsStringBuilder = new StringBuilder();
            ulong decimalNumberCopy = decimalNumber;

            // Check if number is first digit in base 26
            if (decimalNumberCopy == 0)
            {
                return "a";
            }

            // Convert to a numeric system using the standard formula for conversion
            while (decimalNumberCopy != 0)
            {
                converedNumberToBase26AsStringBuilder.Append((char)((decimalNumberCopy % 26) + 'a'));
                decimalNumberCopy /= 26;
            }

            string result = string.Join(string.Empty, converedNumberToBase26AsStringBuilder.ToString().Reverse()).Trim();

            return result;
        }

        /// <summary>
        /// Convert a number in a specified base to decimal number
        /// </summary>
        /// <param name="number">Number to convert as string</param>
        /// <param name="baseNum">Base to convert from as an unsigned 64-bit-integer</param>
        /// <returns>Converted number in decimal system as an unsigned 64-bit-integer</returns>
        private static ulong ConvertToDecimal(string number, ulong baseNum)
        {
            ulong result = 0;

            // Convert to decimal using the standard formula for conversion
            for (int i = number.Length - 1; i >= 0; i--)
            {
                ulong digit = (ulong)((ulong)(number[i] - 'a') % baseNum);
                result += digit * NumberToPower(baseNum, (uint)(number.Length - 1 - i));
            }

            return result;
        }
    }
}