using System;
using System.Linq;

namespace Challenge
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        static void ArrayMaxResult()
        {

        }

        static void LeapYearCalculator()
        {

        }

        static void PerfectSequence()
        {

        }

        /// <summary>
        /// Finds the sum of a single-dimensional array of integers.
        /// </summary>
        /// <param name="array">A single-dimensional array of integers.</param>
        /// <returns>The sum of the array.</returns>
        static int ArraySum(int[] array)
        {
            int sum = 0;
            foreach(int i in array)
            {
                sum += i;
            }
            return sum;
        }

        /// <summary>
        /// Finds the sum of each row in a 2-dimensional array of integers.
        /// </summary>
        /// <param name="array2d">The 2-dimensional array being added together.</param>
        /// <returns>A single-dimensional array containing all of the row's sums.</returns>
        static int[] SumOfRows(int[,] array2d)
        {
            int[] sumArray = new int[array2d.GetLength(0)];
            for (int i = 0; i < sumArray.Length; i++)
            {
                int[] sub = Enumerable.Range(0, array2d.GetLength(1)).Select(j => array2d[i, j]).ToArray();
                sumArray[i] = ArraySum(sub);
            }
            return sumArray;
        }

        /// <summary>
        /// Prints an array of integers to the console.
        /// </summary>
        /// <param name="array">The array being printed.</param>
        static void PrintArray(int[] array)
        {
            Console.Write("{ ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}{(i < array.Length - 1 ? "," : "")} ");
            }
            Console.Write("}");

        }

        /// <summary>
        /// Prints a 2-dimensional array of integers to the console.
        /// </summary>
        /// <param name="array">The 2-dimensional array being printed.</param>
        static void Print2dArray(int[,] array)
        {
            Console.WriteLine("{");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("  ");
                int[] sub = Enumerable.Range(0, array.GetLength(1)).Select(j => array[i, j]).ToArray();
                PrintArray(sub);
                if (i < array.GetLength(0) - 1)
                {
                    Console.Write(",\n");
                }
            }
            Console.WriteLine("\n}");
        }

        /// <summary>
        /// Gets an integer from user input.
        /// </summary>
        /// <param name="prompt">Text prompting the user for input.</param>
        /// <returns>An integer from user input.</returns>
        static int GetInt(string prompt)
        {
            int num;
            bool success;
            do
            {
                Console.Write(prompt);
                success = Int32.TryParse(Console.ReadLine(), out num);
                if (!success) Console.WriteLine("Invalid input. Please enter a whole number");
            } while (!success);
            return num;
        }

        /// <summary>
        /// Randomly generates a 2-dimensional array with a length and width specified by the user.
        /// </summary>
        /// <returns>A 2-dimensional array.</returns>
        static int[,] Generate2dArray()
        {
            int rows = GetInt("Enter number of rows: ");
            int columns = GetInt("Enter number of columns: ");
            int[,] array = new int[rows, columns];
            Random rng = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = rng.Next(-10, 11);
                }
            }
            return array;
        }

        static void Main(string[] args)
        {
            // Challenge 4
            int[,] testArray = Generate2dArray();

            Console.WriteLine("\nInput:");
            Print2dArray(testArray);

            int[] sumArray = SumOfRows(testArray);

            Console.WriteLine("\nOutput:");
            PrintArray(sumArray);

            Console.ReadKey();
        }
    }
}
