using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ParralelForExercise
{
    public class MyParallelFor
    {


        public static void MyParallelForMethod(int inclusiveLowerBound, int exclusiveUpperBound, Action<int> body)
        {
            // Determine size of each partition of work (size/nCores) – static partitioning
            int size = exclusiveUpperBound - inclusiveLowerBound;
            int numProcs = Environment.ProcessorCount;
            int range = size / numProcs;

            // Initialize threads to do work
            var threads = new List<Thread>(numProcs);
            for (int p = 0; p < numProcs; p++)
            {
                int start = p * range + inclusiveLowerBound;
                int end = (p == numProcs - 1) ? exclusiveUpperBound : start + range;
                threads.Add(new Thread(() => {
                    for (int i = start; i < end; i++) body(i);
                }));
            }
            // Start and await threads
            foreach (var thread in threads) thread.Start(); // Start them all
            foreach (var thread in threads) thread.Join(); // wait on all
        }


        

    }



    public class MultiArgs
    {
        public double C { get; set; }
        public double A { get; set; }
        public double B { get; set; }

    }
}
