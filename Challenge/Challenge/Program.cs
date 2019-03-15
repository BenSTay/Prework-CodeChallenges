using System;
using System.Linq;

namespace Challenge
{
    class Program
    {
        /// <summary>
        /// Computes a score based on the frequency of a given number in an array.
        /// </summary>
        /// <param name="array">The array being checked.</param>
        /// <param name="num">The number being looked for.</param>
        /// <returns>The number being looked for multiplied by how many times it appears in the array.</returns>
        static int ArrayMaxResult(int[] array, int num)
        {
            int score = 0;
            foreach (int i in array)
            {
                if (i == num) score += num;
            }
            return score;
        }

        /// <summary>
        /// Determines if a year is a leap year or not.
        /// </summary>
        /// <param name="year">The year being checked.</param>
        /// <returns>True if the year is a leap year, else false.</returns>
        static bool LeapYearCalculator(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 400 == 0) return true;
                else if (year % 100 == 0) return false;
                else return true;
            }
            else return false;
        }

        /// <summary>
        /// Determines if the sum and product of a sequence of numbers are equal.
        /// </summary>
        /// <param name="array">The sequence of numbers being checked.</param>
        /// <returns>true if the sequence is perfect, else false.</returns>
        static bool PerfectSequence(int[] array)
        {
            return ArraySum(array) == ArrayProduct(array);
        }

        /// <summary>
        /// Generates a single-dimensional array from user input.
        /// </summary>
        /// <returns>The generated array.</returns>
        static int[] GenerateArray(int length = 0)
        {
            if (length == 0) length = GetIntGreaterThanZero("Enter array length: ");
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = GetInt($"Enter a number ({i + 1} of {length}): ");
            }
            return array;
        }

        /// <summary>
        /// Finds the product of a single-dimensional array of integers.
        /// </summary>
        /// <param name="array">A single-dimensional array of integers.</param>
        /// <returns>The product of the array.</returns>
        static int ArrayProduct(int[] array)
        {
            int product = 1;
            foreach (int i in array)
            {
                product *= i;
            }
            return product;
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
                if (!success) Console.WriteLine("Invalid input. Please enter a whole number.");
            } while (!success);
            return num;
        }

        /// <summary>
        /// Gets an integer greater than 0 from user input.
        /// </summary>
        /// <param name="prompt">Text prompting the user for input.</param>
        /// <returns>An integer from user input.</returns>
        static int GetIntGreaterThanZero(string prompt)
        {
            int num;
            do
            {
                num = GetInt(prompt);
                if (num <= 0) Console.WriteLine("Number must be greater than 0.");
            } while (num <= 0);
            return num;
        }

        /// <summary>
        /// Randomly generates a 2-dimensional array with a length and width specified by the user.
        /// </summary>
        /// <returns>A 2-dimensional array.</returns>
        static int[,] Generate2dArray()
        {
            int rows = GetIntGreaterThanZero("Enter number of rows: ");
            int columns = GetIntGreaterThanZero("Enter number of columns: ");
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
            // Challenge 1
            int[] array = GenerateArray(5);
            int result = ArrayMaxResult(array, GetInt("Pick a number: "));
            Console.WriteLine($"Score: {result}");

            // Challenge 2
            //int year = GetInt("Enter a year: ");
            //Console.WriteLine($"{year} is{(LeapYearCalculator(year) ? "" : " not")} a leap year.");

            // Challenge 3

            //int[] sequence = GenerateArray();
            //PrintArray(sequence);
            //if (PerfectSequence(sequence)) Console.WriteLine(" Is a perfect sequence!");
            //else Console.WriteLine(" Is not a perfect sequence.");

            // Challenge 4
            //int[,] testArray = Generate2dArray();

            //Console.WriteLine("\nInput:");
            //Print2dArray(testArray);

            //int[] sumArray = SumOfRows(testArray);

            //Console.WriteLine("\nOutput:");
            //PrintArray(sumArray);

            Console.ReadKey();
        }
    }
}
