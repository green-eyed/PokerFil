using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerFil
{
    public class Utils
    {
        public static Card[] getDeckOfCards()
        {
            var deck = new Card[]
            {
                new Card { Rang = CardRang.Ace, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Two, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Three, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Four, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Five, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Six, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Seven, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Eight, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Nine, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Ten, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Jack, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Queen, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.King, Suit = CardSuit.Cross },
                
                new Card { Rang = CardRang.Ace, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Two, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Three, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Four, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Five, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Six, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Seven, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Eight, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Nine, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Ten, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Jack, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Queen, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.King, Suit = CardSuit.Diamonds },
                
                new Card { Rang = CardRang.Ace, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Two, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Three, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Four, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Five, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Six, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Seven, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Eight, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Nine, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Ten, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Jack, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Queen, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.King, Suit = CardSuit.Hearts },
                
                new Card { Rang = CardRang.Ace, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Two, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Three, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Four, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Five, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Six, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Seven, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Eight, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Nine, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Ten, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Jack, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Queen, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.King, Suit = CardSuit.Spades },
            };
            return deck;
        }

        public static List<Card> getDeckOfCardsList()
        {
            var deck = new List<Card>
            {
                new Card { Rang = CardRang.Ace, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Two, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Three, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Four, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Five, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Six, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Seven, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Eight, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Nine, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Ten, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Jack, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.Queen, Suit = CardSuit.Cross },
                new Card { Rang = CardRang.King, Suit = CardSuit.Cross },
                
                new Card { Rang = CardRang.Ace, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Two, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Three, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Four, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Five, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Six, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Seven, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Eight, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Nine, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Ten, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Jack, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.Queen, Suit = CardSuit.Diamonds },
                new Card { Rang = CardRang.King, Suit = CardSuit.Diamonds },
                
                new Card { Rang = CardRang.Ace, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Two, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Three, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Four, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Five, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Six, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Seven, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Eight, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Nine, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Ten, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Jack, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.Queen, Suit = CardSuit.Hearts },
                new Card { Rang = CardRang.King, Suit = CardSuit.Hearts },
                
                new Card { Rang = CardRang.Ace, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Two, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Three, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Four, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Five, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Six, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Seven, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Eight, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Nine, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Ten, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Jack, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.Queen, Suit = CardSuit.Spades },
                new Card { Rang = CardRang.King, Suit = CardSuit.Spades },
            };
            return deck;
        }

        public static void calcPowerAllPosibliCombination()
        {
            Utils.allCombination(Utils.getDeckOfCards());
        }

        public static List<CardCombination> allCombination(Card[] src)
        {
            var result = new List<CardCombination>();
            var hand = new Card[5];
            allCombination(src, 0, 0, ref hand, ref result);
            //Console.WriteLine("countCombination " + result.Count);
            return result;
        }

        private static void allCombination(Card[] src, int cardNumber, int startIndex, ref Card[] hand, ref List<CardCombination> result)
        {
            
            for (int i = startIndex; i < src.Length; i++)
            {
                hand[cardNumber] = src[i];
                if (cardNumber == 4)
                {
                    var combination = new CardCombination(hand);
                    combination.calcPower();
                    result.Add(combination);
                }
                else
                {
                    allCombination(src, cardNumber + 1, i + 1, ref hand, ref result);
                }
            }
        }
    }
}
