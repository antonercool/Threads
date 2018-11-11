using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuickSort
{
    public class QuickSort
    {

        public static void QuickSortTaskParralel(long[] elements)
        {
            
            Task t1 = Task.Factory.StartNew((argsToFunction) =>
            {
                ObectToPass argsPassed = (ObectToPass)argsToFunction;
                SerialQuicksort(argsPassed.Array, argsPassed.Left, argsPassed.Right);

            }, new ObectToPass(elements, 0, (elements.Length/4)));


            Task t2 = Task.Factory.StartNew((argsToFunction) =>
            {
                ObectToPass argsPassed = (ObectToPass)argsToFunction;
                SerialQuicksort(argsPassed.Array, argsPassed.Left, argsPassed.Right);

            }, new ObectToPass(elements, (elements.Length / 4)+1, ((elements.Length / 4)*2)));


            Task t3 = Task.Factory.StartNew((argsToFunction) =>
            {
                ObectToPass argsPassed = (ObectToPass)argsToFunction;
                SerialQuicksort(argsPassed.Array, argsPassed.Left, argsPassed.Right);

            }, new ObectToPass(elements, ((elements.Length / 4) * 2)+1, ((elements.Length / 4) * 3)));


            Task t4 = Task.Factory.StartNew((argsToFunction) =>
            {
                ObectToPass argsPassed = (ObectToPass)argsToFunction;
                SerialQuicksort(argsPassed.Array, argsPassed.Left, argsPassed.Right);

            }, new ObectToPass(elements, ((elements.Length / 4) * 3)+1, elements.Length - 1));

            Task[] listOfTasks = new Task[] {t1, t2, t3, t4};


            Task.WaitAll(listOfTasks);

            
        }


        public static void SerialQuicksort(long[] elements, long left, long right)
        {
            long i = left, j = right;
            var pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0) i++;
                while (elements[j].CompareTo(pivot) > 0) j--;

                if (i <= j)
                {
                    // Swap
                    var tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j) SerialQuicksort(elements, left, j);
            if (i < right) SerialQuicksort(elements, i, right);
        }

       
        //Bad Idea!!! Starts SOOOO MANY TASKS
        public static void TaskQuickSort(long[] elements, List<Task> listOfTasks)
        {
            // Start Parrent task
            
            listOfTasks.Add( Task.Factory.StartNew((argsToFunction) =>
            {
                ObectToPass argsPassed = (ObectToPass)argsToFunction;
                TaskQuickSortFunc(argsPassed.Array, argsPassed.Left, argsPassed.Right, listOfTasks);

            }, new ObectToPass(elements, 0, elements.Length - 1)));


        }

        // 2 Many tasks!!
        public static void TaskQuickSortFunc(long[] elements, long left, long right, List<Task> listOfTasks)
        {
            long i = left, j = right;
            var pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0) i++;
                while (elements[j].CompareTo(pivot) > 0) j--;

                if (i <= j)
                {
                    // Swap
                    var tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)

                listOfTasks.Add(Task.Factory.StartNew((args) =>
                {
                    ObectToPass argsPassed = (ObectToPass) args;
                    TaskQuickSortFunc(argsPassed.Array, argsPassed.Left, argsPassed.Right, listOfTasks);
                }, new ObectToPass(elements, left, j)));

                

            if (i < right)
            {
                
                listOfTasks.Add(Task.Factory.StartNew((args) =>
                {
                    ObectToPass argsPassed = (ObectToPass) args;
                    TaskQuickSortFunc(argsPassed.Array, argsPassed.Left, argsPassed.Right, listOfTasks);
                }, new ObectToPass(elements, i, right)));
                
            }
        }



        public static int IsSorted(long[] arr)
        {
            int error = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    error++;
                    
                }
            }
            return error;
        }

    }


    public class ObectToPass
    {
        public ObectToPass(long[] array, long left, long right)
        {
            Array = array;
            Left = left;
            Right = right;
        }

        public long[] Array { get; set; }

        public long Left { get; set; }

        public long Right { get; set; }
    }


   
}