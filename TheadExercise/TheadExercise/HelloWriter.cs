using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadsExercise
{
    public class HelloWriter
    {
        public string Name { get; set; }
        public int NumberOfTimesToLoop{ get; set; }

        public bool _ShallStop = false;


        public HelloWriter(string name, int numberOfTimesToLoop)
        {
            NumberOfTimesToLoop = numberOfTimesToLoop;
            Name = name;
        }
        public void SayHello()
         {
             for (int i = 0; i < NumberOfTimesToLoop; i++)
             {
                 Console.WriteLine($"Hello from {Name} : {i}");
             }
             //_ShallStop = true;
        }

        public void SayHello2(object objectData)
        {
            Array argArray = new object[2];
            argArray = (Array) objectData;
            for (int i = 0; i < (int)argArray.GetValue(0); i++)
            {
                Console.WriteLine($"Hello from {Name} : {i}");
                Thread.Sleep((int)argArray.GetValue(1));

            }

            Console.WriteLine("Thread Terminated");

         }

        public void NeverEndingThread()
        {
            while (!_ShallStop)
            {
                Console.WriteLine("Never Ending story");
                Thread.Sleep(5000);
            }

        }
        

    }
    
}
