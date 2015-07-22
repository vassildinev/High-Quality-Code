//-----------------------------------------------------------------------
// <copyright file="DecreasingAbsoluteDifference.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CSharpPart2Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class for the solution of the task Decreasing Absolute Difference in the CSharp Part 2 Exam in TA 2015
    /// </summary>
    public class DecreasingAbsoluteDifference
    {
        /// <summary>
        /// Entry point for the solution
        /// </summary>
        public static void Main()
        {
            int numberOfSequences = int.Parse(Console.ReadLine());

            // Read and process each sequence directly when received
            for (int i = 0; i < numberOfSequences; i++)
            {
                int[] numbersOfCurrentSequence = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var differences = new List<int>();
                int currentNumber = 0;
                int nextNumber = 0;

                for (int j = 0; j < numbersOfCurrentSequence.Length - 1; j++)
                {
                    currentNumber = numbersOfCurrentSequence[j];
                    nextNumber = numbersOfCurrentSequence[j + 1];
                    differences.Add(Math.Max(currentNumber, nextNumber) - Math.Min(currentNumber, nextNumber));
                }

                Console.WriteLine(CheckSequence(differences));

                // Clear the list of differences for the next iteration, i.e. for the next sequence of numbers
                differences.Clear();
            }
        }

        /// <summary>
        /// Check if a list of 32-bit-integers is a decreasing sequence
        /// and the absolute difference between neighbor elements is between 0 and 1
        /// </summary>
        /// <param name="numbers">List of 32-bit integers</param>
        /// <returns>True or false</returns>
        private static bool CheckSequence(List<int> numbers)
        {
            if(numbers.Count == 0)
            {
                throw new ArgumentException("List of numbers must contain at least one element");
            }

            int previousNumber, currentNumber;

            for (int i = 1; i < numbers.Count; i++)
            {
                previousNumber = numbers[i - 1];
                currentNumber = numbers[i];
                if (previousNumber >= currentNumber && Math.Abs(previousNumber - currentNumber) <= 1)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}