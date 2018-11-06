using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadExercise2
{
    public class TotalCount
    {
        public object myLock = new object();

        private int _count = 0;

        public int Count
        {
            get{return _count;}

            set{_count = value;} 
        }
        
    }
}
