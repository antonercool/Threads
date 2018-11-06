using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadsExercise
{
    public class HelloWriter
    {
        public string Name { get; set; }
        public int NumberOfTimesToLoop{ get; set; }


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
        }

        public void SayHello2(object numberOfTimes)
        {
            for (int i = 0; i < (int)numberOfTimes; i++)
            {
                Console.WriteLine($"Hello from {Name} : {i}");
            }
        }

    }
    
}
