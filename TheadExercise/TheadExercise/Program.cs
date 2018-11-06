using System;
using System.Threading;
using ThreadsExercise;

namespace TheadExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWriter helloWriter1 = new HelloWriter("HelloWriter1", 1000);
            HelloWriter helloWriter2 = new HelloWriter("HelloWriter2", 2000);


            Thread thread1 = new Thread(helloWriter1.SayHello2);
            thread1.Start(1000);
            //thread1.IsBackground = true;

            Thread thread2 = new Thread(helloWriter2.SayHello2);
            thread2.Start(2000);
            //thread2.IsBackground = true;





            Console.ReadKey();
            Console.WriteLine("Main is done");
        }
    }
}
