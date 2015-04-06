using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokerFil.Calculator
{
    public class MonteCarloWinCalculator : IWinCalculator
    {
        public MonteCarloWinCalculator()
        {
            RoundCount = 350000;
        }

        private static Mutex mutexAddWinCount = new Mutex();
        private int _winCount;
        private void addWinCount()
        {
            mutexAddWinCount.WaitOne();
            _winCount++;
            mutexAddWinCount.ReleaseMutex();
        }

        private static Mutex mutexAddSplitCount = new Mutex();
        private int _splitCount;
        private void addSplitCount()
        {
            mutexAddSplitCount.WaitOne();
            _splitCount++;
            mutexAddSplitCount.ReleaseMutex();
        }

        public int RoundCount { get; set; }

        public ProbabilityResult CalcWinProbability(Card[] playerCards, Card[] commonCards, int playersCount, int foldPlayersCount)
        {
            _winCount = 0;
            _splitCount = 0;

            Parallel.For(0, RoundCount, i => CalcWinProbabilityParallel2(playerCards,commonCards, playersCount, foldPlayersCount));

            var p = new ProbabilityResult
            {
                WinProbability = (double)_winCount / RoundCount,
                SplitProbability = (double)_splitCount / RoundCount
            };

            //p.handCards[0] = (Card)playerCards[0].Clone();
            //p.handCards[1] = (Card)playerCards[1].Clone();
            return p;
        }

        private void CalcWinProbabilityParallel(Card[] playerCards, Card[] commonCards, int playersCount, int foldPlayersCount)
        {
            var deck = Utils.getDeckOfCardsList();
            deck.RemoveAll(d => playerCards.Any(c => c.Rang == d.Rang && c.Suit == d.Suit));
            deck.RemoveAll(d => commonCards.Any(c => c.Rang == d.Rang && c.Suit == d.Suit));

            var otherPlayersMaxHands = new CardCombination[playersCount - foldPlayersCount];

            var cardsForCalc = new Card[7];
            Array.Copy(commonCards, cardsForCalc, commonCards.Length);

            var otherPlayersCards = new Card[playersCount][];
            var otherPlayersCardsRandom = getRandomCards(2 * playersCount, ref deck);
            for (int j = 0; j < playersCount; j++)
            {
                otherPlayersCards[j] = new Card[] { otherPlayersCardsRandom[j], otherPlayersCardsRandom[j+1] };
            }
            if (commonCards.Length < 5)
            {
                var additionalCards = getRandomCards(5 - commonCards.Length, ref deck);
                Array.Copy(additionalCards, 0, cardsForCalc, commonCards.Length, additionalCards.Length);
            }

            cardsForCalc[5] = playerCards[0];
            cardsForCalc[6] = playerCards[1];
            var playerMaxHand = CardCombination.allCombinationForSevenCards(cardsForCalc).OrderBy(c => c.Power).Last();
            for (int k = 0; k < otherPlayersMaxHands.Length; k++)
            {
                cardsForCalc[5] = otherPlayersCards[k][0];
                cardsForCalc[6] = otherPlayersCards[k][1];
                otherPlayersMaxHands[k] = CardCombination.allCombinationForSevenCards(cardsForCalc).OrderBy(c => c.Power).Last();
            }

            var max = otherPlayersMaxHands.Max(p => p.Power);
            if (playerMaxHand.Power > max)
            {
                //addWinCount();
                mutexAddWinCount.WaitOne();
                _winCount++;
                mutexAddWinCount.ReleaseMutex();
            }
            else if (playerMaxHand.Power == max)
            {
                //addSplitCount();
                mutexAddSplitCount.WaitOne();
                _splitCount++;
                mutexAddSplitCount.ReleaseMutex();
            }
        }

        private void CalcWinProbabilityParallel2(Card[] playerCards, Card[] commonCards, int playersCount, int foldPlayersCount)
        {
            var deck = Utils.getDeckOfCards();
            var index1 = Array.IndexOf(deck, playerCards[0]);
            var index2 = Array.IndexOf(deck, playerCards[1]);
            var deckSize = deck.Length - 2;

            deck[index1] = deck[deck.Length - 1];
            deck[index2] = deck[deck.Length - 2];


            var otherPlayersHands = new CardCombination[(playersCount - foldPlayersCount) * 21];

            var cardsForCalc = new Card[7];
            Array.Copy(commonCards, cardsForCalc, commonCards.Length);

            var otherPlayersCards = getRandomCards(2 * playersCount, ref deck, ref deckSize);
            if (commonCards.Length < 5)
            {
                var additionalCards = getRandomCards(5 - commonCards.Length, ref deck, ref deckSize);
                Array.Copy(additionalCards, 0, cardsForCalc, commonCards.Length, additionalCards.Length);
            }

            cardsForCalc[5] = playerCards[0];
            cardsForCalc[6] = playerCards[1];
            var playerMaxHand = CardCombination.allCombinationForSevenCards(cardsForCalc).Max(c => c.Power);
            for (int k = 0; k < otherPlayersCards.Length; k+=2)
            {
                cardsForCalc[5] = otherPlayersCards[k];
                cardsForCalc[6] = otherPlayersCards[k + 1];
                var comb = CardCombination.allCombinationForSevenCards(cardsForCalc);
                Array.Copy(comb, 0, otherPlayersHands, k / 2 * 21, comb.Length);
            }

            var max = otherPlayersHands.Max(p => p.Power);
            if (playerMaxHand > max)
            {
                mutexAddWinCount.WaitOne();
                _winCount++;
                mutexAddWinCount.ReleaseMutex();
            }
            else if (playerMaxHand == max)
            {
                mutexAddSplitCount.WaitOne();
                _splitCount++;
                mutexAddSplitCount.ReleaseMutex();
            }
        }


        private Card[] getRandomCards(int count, ref List<Card> deck )
        {
            var random = new Random();
            var cards = new Card[count];
            for(int i = 0; i < count; i++)
            {
                var index = random.Next(deck.Count);
                cards[i] = deck[index];
                deck.RemoveAt(index);
            }
            return cards;
        }

        private Card[] getRandomCards(int count, ref Card[] deck, ref int deckSize)
        {
            //var random = new Random();
            var rngCsp = new RNGCryptoServiceProvider();
            var randomNumber = new byte[count];
            rngCsp.GetBytes(randomNumber);
            var cards = new Card[count];
            for (int i = 0; i < count; i++)
            {
                //var index = random.Next(deckSize);
                
                var index = randomNumber[i] % deckSize;
                cards[i] = (Card) deck[index].Clone();
                deck[index] = deck[deckSize - 1];
                deckSize--;
            }
            return cards;
        }

        private void returnCardToDeck(Card[] cards, ref List<Card> deck, int startIndex = 0, int length = 0 )
        {
            var finishIndex = 0;
            if (length == 0)
            {
                finishIndex = cards.Length;
            }
            else
            {
                finishIndex = startIndex + length;
            }
            for (int i = startIndex; i < finishIndex; i++)
            {
                deck.Add(cards[i]);
            }
        }
    }
}
