using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerFil
{
    public class CardCombination : IComparer
    {
        private const int WeightOfFirstCard  = 0x1;
        private const int WeightOfSecondCard = 0x10;
        private const int WeightOfThirdCard  = 0x100;
        private const int WeightOfFourthCard = 0x1000;
        private const int WeightOfFifthCard  = 0x10000;

        private const int WeightOfHighCard  = 0x100000;
        private const int WeightOfOnePair   = 0x200000;
        private const int WeightOfTwoPair   = 0x300000;
        private const int WeightOfThreeCards = 0x400000;
        private const int WeightOfStraight = 0x500000;
        private const int WeightOfFlush = 0x600000;
        private const int WeightOfFullHouse = 0x700000;
        private const int WeightOfFourCards = 0x800000;
        private const int WeightOfStraightFlush = 0x900000;

        public enum HandType
        {
            None,
            HightCard,
            OnePair,
            TwoPair,
            ThreeCards,
            Straight,
            Flush,
            FullHouse,
            FourCards,
            StraightFlush
        }

        private Card[] _cards;

        private HandType _handType;
        public HandType HandTypeValue
        {
            get
            {
                return _handType;
            }
        }

        private int _power = 0;
        public int Power
        {
            get
            {
                if(_power == 0) calcPower();
                return _power;
            }
        }

        //public Hand()
        //{
        //    _cards = new Card[5];
        //}

        public CardCombination(Card[] cards)
        {
            _cards = (Card[] )cards.Clone();
            calcHash();
        }

        public CardCombination(Card card1, Card card2, Card card3, Card card4, Card card5 )
        {
            _cards = new Card[]
                         {
                             (Card)card1.Clone(),
                             (Card)card2.Clone(),
                             (Card)card3.Clone(),
                             (Card)card4.Clone(),
                             (Card)card5.Clone()
                         };
            calcHash();
        }

        public void Sort()
        {
            Array.Sort(_cards, Compare);
        }

        public int Compare(object x, object y)
        {
            var card1 = (Card) x;
            var card2 = (Card) y;
            if (card1.Rang != card2.Rang)
            {
                return card1.Rang - card2.Rang;
            }

            return card1.Suit - card2.Suit;
        }

        public Card this[int i]
        {
            get
            {
                return _cards[i];
            }
            //set
            //{
            //    _cards[i] = value;
            //    _power = 0;
            //    _handType = HandType.None;
            //}
        }

        private ulong _hash;
        public ulong Hash { get { return _hash; } }

        private void calcHash()
        {
            ulong h1 = (ulong)1 << (int)_cards[0].Rang + ((int)_cards[0].Suit * (int)CardRang.Ace);
            ulong h2 = (ulong)1 << (int)_cards[1].Rang + ((int)_cards[1].Suit * (int)CardRang.Ace);
            ulong h3 = (ulong)1 << (int)_cards[2].Rang + ((int)_cards[2].Suit * (int)CardRang.Ace);
            ulong h4 = (ulong)1 << (int)_cards[3].Rang + ((int)_cards[3].Suit * (int)CardRang.Ace);
            ulong h5 = (ulong)1 << (int)_cards[4].Rang + ((int)_cards[4].Suit * (int)CardRang.Ace);
            _hash = h1 | h2 | h3 | h4 | h5 & 0xFFFFFFFFFFFFFFFE;
        }

        public static ulong calcHash(Card[] cards)
        {
            ulong h = 0;
            foreach (var card in cards)
            {
                h |= (ulong)1 << (int)card.Rang + ((int)card.Suit * (int)CardRang.Ace);
            }
            return h & 0xFFFFFFFFFFFFFFFE;
        }

        public bool checkByMask(Card[] cards)
        {
            var  mask= calcHash(cards);
            var coincidence = Hash & mask;
            return coincidence == mask;
        }

        #region Calc Power
        public void calcPower()
        {
            getPowerFromTable();
            if (_power > 0) return;

            Sort();
            isStraightFlush();
            if (_power > 0)
            {
                addPowerToTable();
                return;
            }
            isFour();
            if (_power > 0)
            {
                addPowerToTable();
                return;
            }
            isFullHouse();
            if (_power > 0)
            {
                addPowerToTable();
                return;
            }
            isFlush();
            if (_power > 0)
            {
                addPowerToTable();
                return;
            }
            isStraight();
            if (_power > 0)
            {
                addPowerToTable();
                return;
            }
            isThree();
            if (_power > 0)
            {
                addPowerToTable();
                return;
            }
            isTwoPair();
            if (_power > 0)
            {
                addPowerToTable();
                return;
            }
            isOnePair();
            if (_power > 0)
            {
                addPowerToTable();
                return;
            }
            isHighCard();
            addPowerToTable();
        }

        private void isStraightFlush()
        {
            if(_cards[0].Suit == _cards[1].Suit &&
                _cards[0].Suit == _cards[2].Suit &&
                _cards[0].Suit == _cards[3].Suit &&
                _cards[0].Suit == _cards[4].Suit &&
                _cards[0].Rang == _cards[1].Rang - 1 &&
                _cards[0].Rang == _cards[2].Rang - 2 &&
                _cards[0].Rang == _cards[3].Rang - 3 
              )
            {
                if ((_cards[0].Rang == _cards[4].Rang - 4))
                {
                    _power = WeightOfStraightFlush + (int)_cards[0].Rang;
                    _handType = HandType.StraightFlush;
                }
                else if (_cards[0].Rang == CardRang.Two && _cards[4].Rang == CardRang.Ace)
                {
                    _power = WeightOfStraightFlush + 1;
                    _handType = HandType.StraightFlush;
                }
            }
        }

        private void isFour()
        {          
            if(_cards[1].Rang == _cards[2].Rang &&
                _cards[1].Rang == _cards[3].Rang
                )
            {
                if(_cards[0].Rang == _cards[1].Rang)
                {
                    _power = WeightOfFourCards + (int)_cards[4].Rang + (int)_cards[1].Rang * WeightOfSecondCard;
                    _handType = HandType.FourCards;
                }
                else if (_cards[1].Rang == _cards[4].Rang)
                {
                    _power = WeightOfFourCards + (int)_cards[0].Rang + (int)_cards[1].Rang * WeightOfSecondCard;
                    _handType = HandType.FourCards;
                }
            }
        }

        private void isFullHouse()
        {          
            if (_cards[0].Rang == _cards[1].Rang &&
                _cards[0].Rang == _cards[2].Rang &&
                _cards[3].Rang == _cards[4].Rang)
            {
                _power = WeightOfFullHouse + (int)_cards[4].Rang + (int)_cards[0].Rang * WeightOfSecondCard;
            }
            else if (_cards[0].Rang == _cards[1].Rang &&
                _cards[2].Rang == _cards[3].Rang &&
                _cards[2].Rang == _cards[4].Rang)
            {
                _power = WeightOfFullHouse + (int)_cards[0].Rang + (int)_cards[2].Rang * WeightOfSecondCard;
                _handType = HandType.FullHouse;
            }
        }

        private void isFlush()
        {           
            if (_cards[0].Suit == _cards[1].Suit &&
                _cards[0].Suit == _cards[2].Suit &&
                _cards[0].Suit == _cards[3].Suit &&
                _cards[0].Suit == _cards[4].Suit )
            {
                _power = WeightOfFlush +
                           (int)_cards[0].Rang
                         + WeightOfSecondCard * (int)_cards[1].Rang
                         + WeightOfThirdCard * (int)_cards[2].Rang
                         + WeightOfFourthCard * (int)_cards[3].Rang
                         + WeightOfFifthCard * (int)_cards[4].Rang;
                _handType = HandType.Flush;
            }
        }

        private void isStraight()
        {           
            if (_cards[0].Rang == _cards[1].Rang - 1 &&
                _cards[0].Rang == _cards[2].Rang - 2 &&
                _cards[0].Rang == _cards[3].Rang - 3
              )
            {
                if ((_cards[0].Rang == _cards[4].Rang - 4))
                {
                    _power = WeightOfStraight + (int)_cards[0].Rang;
                    _handType = HandType.Straight;
                } else if(_cards[0].Rang == CardRang.Two && _cards[4].Rang == CardRang.Ace)
                {
                    _power = WeightOfStraight + 1;
                    _handType = HandType.Straight;
                }
            }
        }

        private void isThree()
        {
            CardRang threeTang = CardRang.None;
            CardRang lowKicker = CardRang.None;
            CardRang highKicker = CardRang.None;

            var rangs = _cards.GroupBy(c => c.Rang);
            if(rangs.Count() == 3)
            {
                if(rangs.ElementAt(0).Count() == 3)
                {
                    threeTang = rangs.ElementAt(0).Key;
                    lowKicker = rangs.ElementAt(1).Key;
                    highKicker = rangs.ElementAt(2).Key;
                }
                else if (rangs.ElementAt(1).Count() == 3)
                {
                    threeTang = rangs.ElementAt(1).Key;
                    lowKicker = rangs.ElementAt(0).Key;
                    highKicker = rangs.ElementAt(2).Key;
                }
                else if (rangs.ElementAt(2).Count() == 3)
                {
                    threeTang = rangs.ElementAt(2).Key;
                    lowKicker = rangs.ElementAt(0).Key;
                    highKicker = rangs.ElementAt(1).Key;
                }
            }
            if (lowKicker != CardRang.None && highKicker != CardRang.None && threeTang != CardRang.None)
            {
                _power = WeightOfThreeCards + (int) lowKicker
                         + (int) highKicker*WeightOfSecondCard + (int) threeTang*WeightOfThirdCard;
                _handType = HandType.ThreeCards;
            }
        }

        private void isTwoPair()
        {
            CardRang kicker = CardRang.None;
            CardRang lowPair = CardRang.None;
            CardRang highPair = CardRang.None;

            var rangs = _cards.GroupBy(c => c.Rang);
            if (rangs.Count() == 3)
            {
                if (rangs.ElementAt(0).Count() == 2 && rangs.ElementAt(1).Count() == 2)
                {
                    kicker = rangs.ElementAt(2).Key;
                    lowPair = rangs.ElementAt(0).Key;
                    highPair = rangs.ElementAt(1).Key;
                }
                else if (rangs.ElementAt(0).Count() == 2 && rangs.ElementAt(2).Count() == 2)
                {
                    kicker = rangs.ElementAt(1).Key;
                    lowPair = rangs.ElementAt(0).Key;
                    highPair = rangs.ElementAt(2).Key;
                }
                else if (rangs.ElementAt(1).Count() == 2 && rangs.ElementAt(2).Count() == 2)
                {
                    kicker = rangs.ElementAt(0).Key;
                    lowPair = rangs.ElementAt(1).Key;
                    highPair = rangs.ElementAt(2).Key;
                }
            }

            if (lowPair != CardRang.None && highPair != CardRang.None && kicker != CardRang.None)
            {
                _power = WeightOfTwoPair + (int)kicker + (int)lowPair * WeightOfSecondCard
                         + (int) highPair*WeightOfThirdCard;
                _handType = HandType.TwoPair;
            }
        }

        private void isOnePair()
        {
            CardRang pair = CardRang.None;
            CardRang lowKicker = CardRang.None;
            CardRang middleKicker = CardRang.None;
            CardRang highKicker = CardRang.None;

            var rangs = _cards.GroupBy(c => c.Rang);
            if (rangs.Count() == 4)
            {
                if (rangs.ElementAt(0).Count() == 2)
                {
                    pair         = rangs.ElementAt(0).Key;
                    lowKicker    = rangs.ElementAt(1).Key;
                    middleKicker = rangs.ElementAt(2).Key;
                    highKicker   = rangs.ElementAt(3).Key;
                }
                else if (rangs.ElementAt(1).Count() == 2)
                {
                    lowKicker = rangs.ElementAt(0).Key;
                    pair = rangs.ElementAt(1).Key;
                    middleKicker = rangs.ElementAt(2).Key;
                    highKicker = rangs.ElementAt(3).Key;
                }
                else if (rangs.ElementAt(2).Count() == 2)
                {
                    lowKicker = rangs.ElementAt(0).Key;
                    middleKicker = rangs.ElementAt(1).Key;
                    pair = rangs.ElementAt(2).Key;
                    highKicker = rangs.ElementAt(3).Key;
                }
                else if (rangs.ElementAt(3).Count() == 2)
                {
                    lowKicker = rangs.ElementAt(0).Key;
                    middleKicker = rangs.ElementAt(1).Key;
                    highKicker = rangs.ElementAt(2).Key;
                    pair = rangs.ElementAt(3).Key;
                }
                
            }
            if (pair != CardRang.None && lowKicker != CardRang.None 
                && middleKicker != CardRang.None && highKicker != CardRang.None)
            {
                _power = WeightOfOnePair + (int)lowKicker + (int)middleKicker * WeightOfSecondCard
                         + (int)highKicker * WeightOfThirdCard + (int)pair * WeightOfFourthCard;
                _handType = HandType.OnePair;
            }
        }

        private void isHighCard()
        {
            _power = WeightOfHighCard 
                        + (int)_cards[0].Rang
                        + (int)_cards[1].Rang * WeightOfSecondCard
                        + (int)_cards[2].Rang * WeightOfThirdCard
                        + (int)_cards[3].Rang * WeightOfFourthCard
                        + (int)_cards[4].Rang * WeightOfFifthCard;
            _handType = HandType.HightCard;
        }

        public struct HandPower
        {
            public int Power { get; set; }
            public HandType Type { get; set; }
        }

        private static Dictionary<ulong, HandPower> _handPowersTable = new Dictionary<ulong, HandPower>();

        private void getPowerFromTable()
        {
            if (_handPowersTable.ContainsKey(_hash))
            {
                var item = _handPowersTable[_hash];
                _power = item.Power;
                _handType = item.Type;
            }
        }

        private void addPowerToTable()
        {
            try
            {
                _handPowersTable.Add(_hash, new HandPower { Power = _power, Type = _handType });
            }
            catch (Exception)
            {
                System.Console.WriteLine(_cards[0] + " " + 
                                        _cards[1] + " " +
                                        _cards[2] + " " +
                                        _cards[3] + " " +
                                        _cards[4]);
            }
                
        }

        #endregion


        public static CardCombination[] allCombinationForSevenCards(Card[] src)
        {
            return new CardCombination[]
                       {
                           new CardCombination(src[0], src[1], src[2], src[3], src[4]),
                           new CardCombination(src[0], src[1], src[2], src[3], src[5]),
                           new CardCombination(src[0], src[1], src[2], src[3], src[6]),
                           new CardCombination(src[0], src[1], src[2], src[4], src[6]),
                           new CardCombination(src[0], src[1], src[2], src[4], src[5]),
                           new CardCombination(src[0], src[1], src[2], src[5], src[6]),
                           new CardCombination(src[0], src[1], src[3], src[4], src[5]),
                           new CardCombination(src[0], src[1], src[3], src[4], src[6]),
                           new CardCombination(src[0], src[1], src[3], src[5], src[6]),
                           new CardCombination(src[0], src[1], src[4], src[5], src[6]),
                           new CardCombination(src[0], src[2], src[3], src[4], src[5]),
                           new CardCombination(src[0], src[2], src[3], src[4], src[6]),
                           new CardCombination(src[0], src[2], src[3], src[5], src[6]),
                           new CardCombination(src[0], src[2], src[4], src[5], src[6]),
                           new CardCombination(src[0], src[3], src[4], src[5], src[6]),
                           new CardCombination(src[1], src[2], src[3], src[4], src[5]),
                           new CardCombination(src[1], src[2], src[3], src[4], src[6]),
                           new CardCombination(src[1], src[2], src[3], src[5], src[6]),
                           new CardCombination(src[1], src[2], src[4], src[5], src[6]),
                           new CardCombination(src[1], src[3], src[4], src[5], src[6]),
                           new CardCombination(src[2], src[3], src[4], src[5], src[6]),
                       };
        }
    }
}
