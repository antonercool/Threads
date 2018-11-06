using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadExercise2
{
    public class Counter
    {

        private TotalCount _TotalCount;

        //private object myLock = new object();

        

        public Counter(TotalCount TotalCount)
        {
            _TotalCount = TotalCount;
        }

        public void StartCounting(object numberOfTimesToCount)
        {

            for (int i = 0; i < (int)numberOfTimesToCount; i++)
            {
                lock (_TotalCount.myLock)
                {
                    _TotalCount.Count++;
                }
               

            }
        }
    }
}
