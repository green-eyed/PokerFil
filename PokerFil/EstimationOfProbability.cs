using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PokerFil.Calculator;

namespace PokerFil
{
    public class EstimationOfProbability
    {
        private DAL.DAL dal = new DAL.DAL();

        private class HandCardProbability
        {
            public CardRang Rang1 { get; set; }

            public CardRang Rang2 { get; set; }

            public bool EqualsSuit { get; set; }

            public ProbabilityResult probability { get; set; }
        }

        private List<HandCardProbability>  probabilityList = new List<HandCardProbability>();

        public void calcPreflopProbability()
        {
            var deck = Utils.getDeckOfCards();
            //for (int i = 1; i <= 9; i++)
            //{
            //    allCombinationPreflop(deck, 2, i);
            //}
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            allCombinationPreflop(deck, 2, 4);

            var ts = new TimeSpan(stopWatch.Elapsed.Ticks);
            string elapsedTime = String.Format("!!!! calcPreflopProbability   {0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime);
        }

        public void allCombinationPreflop(Card[] src, int size, int playersCount)
        {
            var hand = new Card[size];
            allCombinationPreflop(src, size, playersCount, 0, 0, hand);
        }

        private void allCombinationPreflop(Card[] src, int size, int playersCount, int cardNumber, int startIndex, Card[] hand)
        {
            var calculator = new MonteCarloWinCalculator();
            for (int i = startIndex; i < src.Length; i++)
            {
                hand[cardNumber] = src[i];
                if (cardNumber == size - 1)
                {
                    var equalsSuit = hand[0].Suit == hand[1].Suit;
                    var history = probabilityList.FirstOrDefault(l => l.Rang1 == hand[0].Rang
                                                                      && l.Rang2 == hand[1].Rang
                                                                      && l.EqualsSuit == equalsSuit);
                    ProbabilityResult p = null;
                    if (history == null)
                    {
                        p = calculator.CalcWinProbability(hand, new Card[] {}, playersCount, 0);
                        probabilityList.Add(new HandCardProbability
                                                {
                                                    Rang1 = hand[0].Rang,
                                                    Rang2 = hand[1].Rang,
                                                    EqualsSuit = equalsSuit,
                                                    probability = p
                                                });
                    }
                    else
                    {
                        p = history.probability;
                    }
                    dal.addPreflopProbability(hand, p, playersCount);
                }
                else
                {
                    allCombinationPreflop(src, size, playersCount, cardNumber + 1, i + 1, hand);
                }
            }
        }
    }
}
