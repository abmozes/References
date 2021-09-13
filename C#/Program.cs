/* 
 * Mózes Árpád Benedek
 * Project Euler 345
 * 2020. 05. 03.
 */

using System;
using System.IO;

namespace PE345_Mozes_Arpad
{
    class Program
    {
        static int size;

        static int findMtxSum(int[,] matrix, int[] maxRemaining, bool[] isUsed, int row = 0, int sum = 0, int atLeast = 0)
        {
            // if no more left
            if (row == size)
            {
                return sum;
            }
            // if cannot be increased
            if (sum + maxRemaining[row] <= atLeast)
            {
                return 0;
            }
            // finding a greater sum
            for (int column = 0; column < size; column++)
            {
                // if column already in use, try next
                if (isUsed[column])
                {
                    continue;
                }
                // if column not used, use it: try to find a greater sum
                isUsed[column] = true;
                int current = findMtxSum(matrix, maxRemaining, isUsed, row + 1, sum + matrix[row, column], atLeast);
                if (atLeast < current)
                {
                    atLeast = current;
                }
                isUsed[column] = false;
                // coulmn not is use anymore, if greater, we found a new atLeast
            }

            return atLeast;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Input txt index: ");
                string input = "input" + Console.ReadLine().ToString() + ".txt";
                #region Input Reading

                StreamReader sr = new StreamReader(@input);
                size = int.Parse(sr.ReadLine());
                int[,] matrix = new int[size, size];

                for (int i = 0; i < size; i++)
                {
                    string[] line = sr.ReadLine().Split();
                    for (int j = 0; j < size; j++)
                    {
                        matrix[i, j] = int.Parse(line[j]);
                    }
                }

                sr.Close();
                #endregion

                #region Calculation
                // max values in rows, to calculate remaining
                int[] maxValuePerRow = new int[size];
                for (int row = 0; row < size; row++)
                {
                    maxValuePerRow[row] = matrix[0, row];
                    for (int column = 1; column < size; column++)
                    {
                        if (maxValuePerRow[row] < matrix[column, row]) maxValuePerRow[row] = matrix[column, row];
                    }
                }

                // cumulative
                int[] maxRemaining = new int[size];
                maxRemaining[size - 1] = maxValuePerRow[size - 1];
                for (int row = size - 1; row > 0; row--)
                {
                    maxRemaining[row - 1] = maxRemaining[row] + maxValuePerRow[row - 1];
                }
                bool[] isUsed = new bool[size];

                // output
                Console.WriteLine("Matrix Sum = " + findMtxSum(matrix, maxRemaining, isUsed).ToString());
                Console.ReadLine();
                #endregion
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}
