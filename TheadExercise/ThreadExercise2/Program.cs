using System;
using System.Threading;

namespace ThreadExercise2
{
    class Program
    {
        static void Main(string[] args)
        {

            TotalCount totalCount = new TotalCount();


            Thread thread1 = new Thread(new Counter(totalCount).StartCounting);
            Thread thread2 = new Thread(new Counter(totalCount).StartCounting);


            thread1.Start(200000);
            thread2.Start(500000);

            thread1.Join();
            thread2.Join();



            //This whould fuck up without lock
            Console.WriteLine("Expected TotalCount : 700000, Actual : {0}", totalCount.Count);


            Console.ReadKey();
            //Console.WriteLine("Hello World!");
        }
    }
}
