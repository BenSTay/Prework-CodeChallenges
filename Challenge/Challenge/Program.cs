﻿using System;
using System.Linq;

namespace Challenge
{
    class Program
    {
        /// <summary>
        /// Runs the Array Max Result program.
        /// </summary>
        static void Challenge1()
        {
            int[] array = GenerateArray(5, 1, 10);
            int result = ArrayMaxResult(array, GetInt("Pick a number: ", 1, 10));
            Console.WriteLine($"Score: {result}");
        }

        /// <summary>
        /// Runs the Leap Year Calculator program.
        /// </summary>
        static void Challenge2()
        {
            int year = GetInt("Enter a year: ");
            Console.WriteLine($"{year} is{(LeapYearCalculator(year) ? "" : " not")} a leap year.");
        }

        /// <summary>
        /// Runs the Perfect Sequence program.
        /// </summary>
        static void Challenge3()
        {
            int[] sequence = GenerateArray(0,0);
            PrintArray(sequence);
            if (PerfectSequence(sequence)) Console.WriteLine(" Is a perfect sequence!");
            else Console.WriteLine(" Is not a perfect sequence.");
        }

        /// <summary>
        /// Runs the Sum of Rows program.
        /// </summary>
        static void Challenge4()
        {
            int[,] testArray = Generate2dArray();

            Console.WriteLine("\nInput:");
            Print2dArray(testArray);

            int[] sumArray = SumOfRows(testArray);

            Console.WriteLine("\nOutput:");
            PrintArray(sumArray);
            Console.WriteLine();
        }
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
        static int[] GenerateArray(int length = 0, int min = Int32.MinValue, int max = Int32.MaxValue)
        {
            if (length == 0) length = GetInt("Enter array length: ", 1);
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = GetInt($"Enter a number ({i + 1} of {length}): ", min, max);
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
        static int GetInt(string prompt, int min = Int32.MinValue, int max = Int32.MaxValue)
        {
            int num;
            bool success;
            do
            {
                Console.Write(prompt);
                success = Int32.TryParse(Console.ReadLine(), out num);
                if (!success) Console.WriteLine("Invalid input. Please enter a whole number.");
                else
                {
                    if (num < min)
                    {
                        Console.WriteLine($"Number must be greater than or equal to {min}");
                        success = false;
                    }
                    if (num > max)
                    {
                        Console.WriteLine($"Number must be less than or equal to {max}");
                        success = false;
                    }
                    
                }
            } while (!success);
            return num;
        }

        /// <summary>
        /// Randomly generates a 2-dimensional array with a length and width specified by the user.
        /// </summary>
        /// <returns>A 2-dimensional array.</returns>
        static int[,] Generate2dArray()
        {
            int rows = GetInt("Enter number of rows: ", 1);
            int columns = GetInt("Enter number of columns: ", 1);
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

        /// <summary>
        /// Displays the main menu.
        /// </summary>
        static void ListPrograms()
        {
            Console.Clear();
            Console.WriteLine("Choose a program: ");
            Console.WriteLine("1) Array Max Result");
            Console.WriteLine("2) Leap Year Calculator");
            Console.WriteLine("3) Perfect Sequence");
            Console.WriteLine("4) Sum of Rows");
            Console.WriteLine("Enter any other number to quit.");
        }

        /// <summary>
        /// Requires that the user press a key before the program continues.
        /// </summary>
        static void PressKeyToContinue()
        {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            bool go = true;
            do
            {
                ListPrograms();
                switch (GetInt("\n> "))
                {
                    case 1:
                        Console.Clear();
                        Challenge1();
                        PressKeyToContinue();
                        break;
                    case 2:
                        Console.Clear();
                        Challenge2();
                        PressKeyToContinue();
                        break;
                    case 3:
                        Console.Clear();
                        Challenge3();
                        PressKeyToContinue();
                        break;
                    case 4:
                        Console.Clear();
                        Challenge4();
                        PressKeyToContinue();
                        break;
                    default:
                        go = false;
                        break;
                }
            } while (go);
        }
    }
}
