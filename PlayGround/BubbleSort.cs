using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGround
{
    public class BubbleSort
    {
        static Random random = new Random(Environment.TickCount);

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Size of the Array that will be sorted: ");
            var size = Console.ReadLine();
            long[] array = new long[0];
            if (long.TryParse(size, out long sizeEntered))
            {
                array = new long[sizeEntered];
            }
            else
            {
                Console.Write("Error! Your entry is invalid.");
            }
            createTestData(array);
            long start = Environment.TickCount;
            doBubbleSort(array);
            long end = Environment.TickCount;
            Console.WriteLine("Time taken to sort: " + (end - start));
        }

        private static void createTestData(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, int.MaxValue);
            }
        }

        private static void doBubbleSort(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        long tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                }
            }
        }
    }
}
