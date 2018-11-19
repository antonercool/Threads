using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();
            GameOfLife gol = new GameOfLife(1000);
            gol.RunParrel(100);
            watch.Stop();

            Console.WriteLine($"Time to exe in milli : {watch.ElapsedMilliseconds}");
            Console.ReadKey();
        }
    }
}
