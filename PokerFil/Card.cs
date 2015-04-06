using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerFil
{
    #region enums
    public enum CardSuit
    {
        Cross,
        Diamonds,
        Hearts,
        Spades
    }

    public enum CardRang
    {
        None = 0,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
    #endregion

    public class Card : Object, ICloneable
    {
        public Card()
        {
        }

        public Card(Card card)
        {
            Rang = card.Rang;
            Suit = card.Suit;
        }

        public CardRang Rang { get; set; }

        public CardSuit Suit { get; set; }

        public override string ToString()
        {
            return Rang + " " + Suit;
        }

        public object Clone()
        {
            return new Card(this);
        }

        public string ShortString
        {
            get { return ToShortString(); }
        }

        public string ToShortString()
        {
            var sb = new StringBuilder();
            switch (Rang)
            {
                case CardRang.None:
                    sb.Append("none");
                    break;
                case CardRang.Two:
                    sb.Append("2");
                    break;
                case CardRang.Three:
                    sb.Append("3");
                    break;
                case CardRang.Four:
                    sb.Append("4");
                    break;
                case CardRang.Five:
                    sb.Append("5");
                    break;
                case CardRang.Six:
                    sb.Append("6");
                    break;
                case CardRang.Seven:
                    sb.Append("7");
                    break;
                case CardRang.Eight:
                    sb.Append("8");
                    break;
                case CardRang.Nine:
                    sb.Append("9");
                    break;
                case CardRang.Ten:
                    sb.Append("10");
                    break;
                case CardRang.Jack:
                    sb.Append("J");
                    break;
                case CardRang.Queen:
                    sb.Append("Q");
                    break;
                case CardRang.King:
                    sb.Append("K");
                    break;
                case CardRang.Ace:
                    sb.Append("A");
                    break;
                default:
                    sb.Append("none");
                    break;
            }

            switch (Suit)
            {
                case CardSuit.Cross:
                    sb.Append("c");
                    break;
                case CardSuit.Diamonds:
                    sb.Append("d");
                    break;
                case CardSuit.Hearts:
                    sb.Append("h");
                    break;
                case CardSuit.Spades:
                    sb.Append("s");
                    break;
                default:
                    sb.Append("none");
                    break;
                    
            }

            return sb.ToString();
        }

        public static bool operator ==(Card a, Card b)
        {
            return a.Rang == b.Rang && a.Suit == b.Suit;
        }

        public static bool operator !=(Card a, Card b)
        {
            return  !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Card)
            {
                return this == (Card) obj;
            }
            return false;
        }
    }
}
