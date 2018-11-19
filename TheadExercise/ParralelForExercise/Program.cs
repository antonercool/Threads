using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ParralelForExercise
{
    class Program
    {
        static void Main(string[] args)
        {


            


            #region Sequencial

            Stopwatch stopwatch1 = new Stopwatch();
            const long N1 = 40000000;
            double[] A1, B1, C1;
            A1 = new double[N1];
            B1 = new double[N1];
            C1 = new double[N1];
            Random rand1 = new Random();
            for (int i = 0; i < N1; i++)
            {
                A1[i] = rand1.Next();
                B1[i] = rand1.Next();
                C1[i] = rand1.Next();
            }
            Console.WriteLine("Starts sequential for now.");
            stopwatch1.Start();
            for (int i = 0; i < N1; i++)
            {
                C1[i] = A1[i] * B1[i];
            }
            stopwatch1.Stop();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sequential loop time in milliseconds: {0}", stopwatch1.ElapsedMilliseconds);
            Console.ForegroundColor = ConsoleColor.Black;
            stopwatch1.Reset();
            Console.WriteLine("Finished");

            #endregion


            #region MyParallelForLoop

            Stopwatch stopwatch2 = new Stopwatch();
            const long N2 = 40000000;
            double[] A2, B2, C2;
            A2 = new double[N2];
            B2 = new double[N2];
            C2 = new double[N2];
            Random rand2 = new Random();

            Console.WriteLine("Generating randomNumbers in parallel  Starts Now");
            MyParallelFor.MyParallelForMethod(0, (int)N2, (numberFromBody) =>
            {
                A2[numberFromBody] = rand2.Next();
                B2[numberFromBody] = rand2.Next();
                C2[numberFromBody] = rand2.Next();
            });


            // public void lambaExp(int);


            stopwatch2.Start();
            MyParallelFor.MyParallelForMethod(0, (int)N2,  (i)=>
            {
                C2[i] = A2[i] * B2[i];
            });

            stopwatch2.Stop();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MyParallelFor loop time in milliseconds: {0}", stopwatch2.ElapsedMilliseconds);
            Console.ForegroundColor = ConsoleColor.Black;
            stopwatch2.Reset();
            Console.WriteLine("Finished");
            #endregion


            #region Normal Build ParallelFor
            Stopwatch stopwatch3 = new Stopwatch();
            const long N3 = 40000000;
            double[] A3, B3, C3;
            A3 = new double[N3];
            B3 = new double[N3];
            C3 = new double[N3];
            Random rand3 = new Random();

            Console.WriteLine("Generating randomNumbers in parallel  Starts Now");
            Parallel.For(0, (int)N3, (numberFromBody) =>
            {
                A3[numberFromBody] = rand3.Next();
                B3[numberFromBody] = rand3.Next();
                C3[numberFromBody] = rand3.Next();
            });


           
            stopwatch3.Start();
            Parallel.For(0, (int)N3, (i) =>
            {
                C3[i] = A3[i] * B3[i];
            });

            stopwatch3.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(".Net ParallelFor loop time in milliseconds: {0}", stopwatch3.ElapsedMilliseconds);
            Console.ForegroundColor = ConsoleColor.Black;
            stopwatch3.Reset();
            Console.WriteLine("Finished");


            #endregion


            #region NormalBuild ParallelForEach

            Stopwatch stopwatch4 = new Stopwatch();
            const long N4 = 40000000;
            List<MultiArgs> multiArgs = new List<MultiArgs>((int)N4);

            Random rand4 = new Random();

            Console.WriteLine("Generating randomNumbers in parallel  Starts Now");
            Parallel.ForEach(multiArgs, (current) =>
            {
                current.A = rand4.Next();
                current.B = rand4.Next();
                current.C = rand4.Next();
            });



            stopwatch4.Start();
            Parallel.ForEach(multiArgs, (current) =>
            {
                current.C = current.B * current.A;
            });

            stopwatch4.Stop();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(".Net ParallelForEach loop time in milliseconds: {0}", stopwatch4.ElapsedMilliseconds);
            Console.ForegroundColor = ConsoleColor.Black;
            stopwatch4.Reset();
            Console.WriteLine("Finished");


            #endregion



            Console.ReadKey();



        }



       


    }
}
