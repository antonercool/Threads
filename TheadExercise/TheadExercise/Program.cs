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
            HelloWriter helloWriter3 = new HelloWriter("EndLessWriter", 0);


            Thread thread1 = new Thread(helloWriter1.SayHello2);
            Thread thread2 = new Thread(helloWriter2.SayHello2);
            Thread thread3 = new Thread(helloWriter2.NeverEndingThread);


            //thread1.IsBackground = true;
            //thread2.IsBackground = true;
            thread3.IsBackground = false;

            thread1.Start(new object[] { 100, 100 });
            thread2.Start(new object[]{50,  200});
            thread3.Start();
           
            Console.WriteLine("The Main Thread as Spawned 2 threads");
            
            //thread2.Start(2000);
            

            Console.WriteLine("Main is done");
        }
    }
}
