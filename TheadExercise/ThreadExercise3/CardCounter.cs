using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadExercise3
{
    public class CardCounter
    {

        public int NumberOfCards { get; set; }

        public int NumberOfSpades { get; set; }

        public int NumberOfAces { get; set; }


        public void CountCards(object cardStringsObject)
        {
            string[] cardStrings = (string[]) cardStringsObject;

            foreach (var s in cardStrings)
            {
                if (s == "")
                {
                    continue;
                }

                NumberOfCards++;
                if (s.Contains("SPADE"))
                {
                    NumberOfSpades++;
                }

                string[] card = s.Split(',');
                int cardValue = int.Parse(card[1]);

                if (cardValue == 1)
                {
                    NumberOfAces++;
                }
            }
        }

        public void CountCardsForPool(object args)
        {
            object[] cardStringsObject = (object[]) args;

            string[] cardStrings = (string[])cardStringsObject[1];

            CountdownEvent countdownEvent = (CountdownEvent) cardStringsObject[0];

            foreach (var s in cardStrings)
            {
                if (s == "")
                {
                    continue;
                }

                NumberOfCards++;
                if (s.Contains("SPADE"))
                {
                    NumberOfSpades++;
                }

                string[] card = s.Split(',');
                int cardValue = int.Parse(card[1]);

                if (cardValue == 1)
                {
                    NumberOfAces++;
                }
            }

            countdownEvent.Signal();
        }



    }
}
