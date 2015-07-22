//-----------------------------------------------------------------------
// <copyright file="CatConcert.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CSharpPart2Exam
{
    using System;
    using System.Collections;

    /// <summary>
    /// Class for the solution of the task Cat Concert in the CSharp Part 2 Exam in TA 2015
    /// </summary>
    public class CatConcert
    {
        /// <summary>
        /// Entry point for the solution
        /// </summary>
        public static void Main()
        {
            var catSongs = ReadInput();
            var answer = SolveUsingBitMasks(catSongs);
            if (answer == int.MaxValue)
            {
                Console.WriteLine("No concert!");
            }
            else
            {
                Console.WriteLine(answer);
            }
        }

        /// <summary>
        /// Solving problem using brute force (simulating all scenarios for the cats concert)
        /// Using binary representation of the numbers from 1 to 2^n - 1 (for n=5 => 00001 -> 11111)
        /// </summary>
        /// <param name="catSongs">Boolean 2-dimensional array representing the cats' songs awareness</param>
        /// <returns>Returns 32-bit-integer max value when there is a cat that will not sing</returns>
        private static int SolveUsingBitMasks(bool[,] catSongs)
        {
            var catsCount = catSongs.GetLength(0);
            var songsCount = catSongs.GetLength(1);
            int min = int.MaxValue;
            var maxCombination = (int)Math.Pow(2, songsCount) - 1;
            for (int combination = 1; combination <= maxCombination; combination++)
            {
                var songsToBeSing = new BitArray(new[] { combination });
                bool allCatsWillSing = true;
                for (int i = 0; i < catsCount; i++)
                {
                    bool catIWillSing = false;
                    for (int j = 0; j < songsCount; j++)
                    {
                        if (songsToBeSing[j] && catSongs[i, j])
                        {
                            // Song j will be sing and the cat can sing it
                            catIWillSing = true;
                            break;
                        }
                    }

                    if (!catIWillSing)
                    {
                        allCatsWillSing = false;
                        break;
                    }
                }

                if (allCatsWillSing)
                {
                    int songs = 0;
                    for (int i = 0; i < songsCount; i++)
                    {
                        if (songsToBeSing[i])
                        {
                            songs++;
                        }
                    }

                    min = Math.Min(min, songs);
                }
            }

            return min;
        }

        /// <summary>
        /// Reads the input for the assignment
        /// </summary>
        /// <returns>2-dimensional array of boolean values</returns>
        private static bool[,] ReadInput()
        {
            var firstLine = Console.ReadLine();
            var secondLine = Console.ReadLine();

            var catsCount = int.Parse(firstLine.Split(' ')[0]);
            var songsCount = int.Parse(secondLine.Split(' ')[0]);

            var catSongs = new bool[catsCount, songsCount];
            while (true)
            {
                // Cat X knows song Y
                var line = Console.ReadLine();
                if (line == "Mew!")
                {
                    break;
                }

                var lineParts = line.Split(' ');

                var cat = int.Parse(lineParts[1]);
                var song = int.Parse(lineParts[4]);

                // Cats are numbered from 1 to C
                // Songs are numbered from 1 to S
                catSongs[cat - 1, song - 1] = true;
            }

            return catSongs;
        }
    }
}