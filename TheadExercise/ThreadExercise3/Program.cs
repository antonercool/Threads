using System;
using System.IO;
using System.Threading;

namespace ThreadExercise3
{
    class Program
    {
        static void Main(string[] args)
        {
           
            // Load files into String arrays
            string[] suitsFromFile1 = File.ReadAllText(@"C:\Users\Anton\Source\Repos\antonercool\Threads\TheadExercise\ThreadExercise3\cards.txt").Split((char)0x0A);
            string[] suitsFromFile2 = File.ReadAllText(@"C:\Users\Anton\Source\Repos\antonercool\Threads\TheadExercise\ThreadExercise3\cards2.txt").Split((char)0x0A);
            string[] suitsFromFile3 = File.ReadAllText(@"C:\Users\Anton\Source\Repos\antonercool\Threads\TheadExercise\ThreadExercise3\cards3.txt").Split((char)0x0A);


            #region CalcCardDataWith1Thread(MainThread)
            int numberOfSpades = 0;
            int numberOfCards = 0;
            int numberOfAces = 0;

            var watch = System.Diagnostics.Stopwatch.StartNew(); 
            foreach (var s in suitsFromFile1)
            {
                if (s == "")
                {
                    continue;
                }

                numberOfCards++;
                if (s.Contains("SPADE"))
                {
                    numberOfSpades++;
                }

                string[] card = s.Split(',');
                int cardValue = int.Parse(card[1]);

                if (cardValue == 1)
                {
                    numberOfAces++;
                }
            }

            foreach (var s in suitsFromFile2)
            {

                if (string.IsNullOrEmpty(s))
                {
                    continue;
                }

                numberOfCards++;
                if (s.Contains("SPADE"))
                {
                    numberOfSpades++;
                }
                
                string[] card = s.Split(',');
                int cardValue = int.Parse(card[1]);

                if (cardValue == 1)
                {
                    numberOfAces++;
                }
            }

            foreach (var s in suitsFromFile3)
            {
                if (string.IsNullOrEmpty(s))
                {
                    continue;
                }

                numberOfCards++;

                if (s.Contains("SPADE"))
                {
                    numberOfSpades++;
                }

                string[] card = s.Split(',');
                int cardValue = int.Parse(card[1]);

                if (cardValue == 1)
                {
                    numberOfAces++;
                }
            }


            watch.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("With on thread (MAIN THREAD)");
            Console.WriteLine($"Time to execute Syncrone {watch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Number of cards : {numberOfCards}, Number of ACE : {numberOfAces}, Number of SPADES {numberOfSpades} \n \n");

            #endregion

            #region CalcCardDataInParralelWith3Threads

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            CardCounter counter1 = new CardCounter();
            CardCounter counter2 = new CardCounter();
            CardCounter counter3 = new CardCounter();

            Thread thread1 = new Thread(counter1.CountCards);
            Thread thread2 = new Thread(counter2.CountCards);
            Thread thread3 = new Thread(counter3.CountCards);

            thread1.Start(suitsFromFile1);
            thread2.Start(suitsFromFile2);
            thread3.Start(suitsFromFile3);

            thread1.Join();
            thread2.Join();
            thread3.Join();

            int sumOfCards, sumOfSpades, sumOfAces = 0;

            sumOfCards = counter1.NumberOfCards + counter2.NumberOfCards + counter3.NumberOfCards;
            sumOfSpades = counter1.NumberOfSpades + counter2.NumberOfSpades + counter3.NumberOfSpades;
            sumOfAces = counter1.NumberOfAces + counter2.NumberOfAces + counter3.NumberOfAces;

            watch2.Stop();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Parralel with 3 threads");
            Console.WriteLine($"Time to execute Syncrone {watch2.ElapsedMilliseconds} ms");
            Console.WriteLine($"Number of cards : {sumOfCards}, Number of ACE : {sumOfAces}, Number of SPADES {sumOfSpades} \n \n");

            #endregion

            #region CalcCardDataInParraelWith3ThreadsInThreadPool
            var watch3 = System.Diagnostics.Stopwatch.StartNew();

            CountdownEvent countdownEvent = new CountdownEvent(3);

            CardCounter counter4 = new CardCounter();
            CardCounter counter5 = new CardCounter();
            CardCounter counter6 = new CardCounter();

            object[] objects1 = new object[2] { countdownEvent, suitsFromFile1 };
            object[] objects2 = new object[2] { countdownEvent, suitsFromFile2 };
            object[] objects3 = new object[2] { countdownEvent, suitsFromFile3 };
            

            ThreadPool.QueueUserWorkItem(counter4.CountCardsForPool, objects1);
            ThreadPool.QueueUserWorkItem(counter5.CountCardsForPool, objects2);
            ThreadPool.QueueUserWorkItem(counter6.CountCardsForPool, objects3);


            // Wait for the 3 threads to finish calculating
            countdownEvent.Wait();

            
            int sumOfCards2, sumOfSpades2, sumOfAces2 = 0;

            sumOfCards2 = counter4.NumberOfCards + counter4.NumberOfCards + counter4.NumberOfCards;
            sumOfSpades2 = counter5.NumberOfSpades + counter5.NumberOfSpades + counter5.NumberOfSpades;
            sumOfAces2 = counter6.NumberOfAces + counter6.NumberOfAces + counter6.NumberOfAces;

            watch3.Stop();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Parralel with 3 threads From ThreadPool");
            Console.WriteLine($"Time to execute Syncrone {watch3.ElapsedMilliseconds} ms");
            Console.WriteLine($"Number of cards : {sumOfCards2}, Number of ACE : {sumOfAces2}, Number of SPADES {sumOfSpades2} \n \n");


            #endregion


            Console.ReadKey();

        }




    }
}
