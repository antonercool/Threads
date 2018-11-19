using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfElements = 20000000;
            DataGenerator dataGenerator = new DataGenerator();
            dataGenerator.Generate(numberOfElements);

            for (int i = 0; i < 3; i++)
            {
                long[] numbers = dataGenerator.GetNumbers();
                var stopwatch = new Stopwatch();

                Console.WriteLine("QuickSort By Recursive Method - run # {0}", i);
                stopwatch.Reset();
                stopwatch.Start();
                
               
                // 3 Errors ??
                QuickSort.QuickSortTaskParralel(numbers);

               //  QuickSort.SerialQuicksort(numbers, 0, numberOfElements - 1);
                stopwatch.Stop();

                var singleThreadRuntime = stopwatch.ElapsedMilliseconds;

                //System.Console.WriteLine("Single thread calculation runtime: {0} ms", singleThreadRuntime);

                System.Console.WriteLine("Task calculation runtime: {0} ms", singleThreadRuntime);
                System.Console.WriteLine("IsSorted ? {0}", QuickSort.IsSorted(numbers));
                


            }

            Console.ReadKey();
        }
    }
}
