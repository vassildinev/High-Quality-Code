using System;

public class PersianRugs
{
    public static void Main()
    {
        // INPUT
        int n = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());

        // SOLUTION
        int height = (2 * n) + 1;
        int width = (2 * n) + 1;
        int[,] matrix = new int[height, width];
        int currentRow = height / 2;
        int currentCol = width / 2;
        while (currentCol >= 0 && currentRow >= 0)
        {
            matrix[currentRow, currentCol] = 1;
            matrix[height - 1 - currentRow, currentCol] = 2;
            matrix[currentRow, width - 1 - currentCol] = 2;
            matrix[height - 1 - currentRow, width - 1 - currentCol] = 1;
            for (int col = currentCol; col <= width / 2; col++)
            {
                if (col > currentCol)
                {
                    for (int col1 = currentCol + 1; col1 <= currentCol + d + 1; col1++)
                    {
                        if (col1 <= width / 2)
                        {
                            matrix[currentRow, col1] = 8;
                            matrix[height - 1 - currentRow, col1] = 8;
                            matrix[currentRow, width - 1 - col1] = 8;
                            matrix[height - 1 - currentRow, width - 1 - col1] = 8;
                        }
                    }
                }

                for (int col1 = currentCol + 1 + d; col1 < width / 2; col1++)
                {
                    if (col1 <= currentCol + 1 + d)
                    {
                        matrix[currentRow, col1] = 1;
                        matrix[currentRow, width - 1 - col1] = 2;
                        matrix[height - 1 - currentRow, width - 1 - col1] = 1;
                        matrix[height - 1 - currentRow, col1] = 2;
                    }
                }

                for (int col1 = currentCol + 1 + d + 1; col1 <= width / 2; col1++)
                {
                    if (col1 <= width / 2)
                    {
                        matrix[currentRow, col1] = 3;
                        matrix[currentRow, width - 1 - col1] = 3;
                        matrix[height - 1 - currentRow, width - 1 - col1] = 3;
                        matrix[height - 1 - currentRow, col1] = 3;
                    }
                }
            }

            currentCol--;
            currentRow--;
        }

        matrix[height / 2, width / 2] = 9;

        // OUTPUT
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (matrix[row, col] == 0)
                {
                    Console.Write("#");
                }

                if (matrix[row, col] == 1)
                {
                    Console.Write("\\");
                }

                if (matrix[row, col] == 2)
                {
                    Console.Write("/");
                }

                if (matrix[row, col] == 3)
                {
                    Console.Write(".");
                }

                if (matrix[row, col] == 9)
                {
                    Console.Write("X");
                }

                if (matrix[row, col] == 8)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }
}
