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

        static int[] SumOfRows(int[,] array2d)
        {
            int[] sumArray = new int[array2d.GetLength(0)];
            for (int i = 0; i < sumArray.Length; i++)
            {
                for (int j = 0; j < array2d.GetLength(1); j++)
                {
                    sumArray[i] += array2d[i, j];
                }
            }
            return sumArray;
        }

        static void PrintArray(int[] array)
        {
            Console.Write("{ ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}{(i < array.Length - 1 ? "," : "")} ");
            }
            Console.Write("}");

        }

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

        static void Main(string[] args)
        {
            // Challenge 4
            int[,] testArray = new int[4, 4] {
                { 1, 2, 3, 4 },
                { 2, 4, 6, 8 },
                { 3, 6, 9, 12 },
                { 4, 8, 12, 16 },
            };

            Console.WriteLine("Input:");
            Print2dArray(testArray);

            int[] sumArray = SumOfRows(testArray);

            Console.WriteLine("\nOutput:");
            PrintArray(sumArray);

            Console.ReadKey();
        }
    }
}
