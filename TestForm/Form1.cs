using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PokerFil;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           Utils.calcPowerAllPosibliCombination();

           var noneCard = new Card[]
                                 {
                                     new Card{ Rang = CardRang.None, Suit = CardSuit.Cross}, 
                                     new Card{ Rang = CardRang.None, Suit = CardSuit.Cross}, 
                                     new Card{ Rang = CardRang.None, Suit = CardSuit.Cross}, 
                                     new Card{ Rang = CardRang.None, Suit = CardSuit.Cross}, 
                                     new Card{ Rang = CardRang.None, Suit = CardSuit.Cross}, 
                                 };

            var hash = CardCombination.calcHash(noneCard);
            Console.WriteLine("hash = " + hash);

           var calculator = new PokerFil.Calculator.MonteCarloWinCalculator();
           var playerCard = new Card[]
                                 {
                                     new Card{ Rang = CardRang.King, Suit = CardSuit.Spades}, 
                                     new Card{ Rang = CardRang.Queen, Suit = CardSuit.Diamonds}, 
                                 };
           var commonCard = new Card[] 
                                {
                                     new Card{ Rang = CardRang.King, Suit = CardSuit.Spades}, 
                                     new Card{ Rang = CardRang.Queen, Suit = CardSuit.Diamonds}, 
                                     new Card{ Rang = CardRang.Three, Suit = CardSuit.Diamonds}, 
                                     new Card{ Rang = CardRang.Ten, Suit = CardSuit.Diamonds}, 
                                     new Card{ Rang = CardRang.Seven, Suit = CardSuit.Diamonds}, 
                                 };
            var comb = new CardCombination(commonCard);
            Console.WriteLine(comb.checkByMask(playerCard));
            Console.WriteLine(comb.checkByMask(noneCard));

            //var playerCard1 = new Card[]
            //                      {
            //                          new Card{ Rang = CardRang.King, Suit = CardSuit.Cross}, 
            //                          new Card{ Rang = CardRang.Queen, Suit = CardSuit.Hearts}, 
            //                      };

            // var p = calculator.CalcWinProbability(playerCard, commonCard, 1, 0);
            // Console.WriteLine("iteration = " + calculator.RoundCount +
            //                     " P win " + p.WinProbability + " P split " + p.SplitProbability);

            // p = calculator.CalcWinProbability(playerCard1, commonCard, 1, 0);
            // Console.WriteLine("iteration = " + calculator.RoundCount +
            //                     " P win " + p.WinProbability + " P split " + p.SplitProbability);

            //Console.WriteLine("P avg " + pList.Average());

            //var ep = new EstimationOfProbability();
            //ep.calcPreflopProbability();
            //testSpeed();
        }

        private void testSpeed()
        {
            var calculator = new PokerFil.Calculator.MonteCarloWinCalculator();
            var playerCard = new Card[]
                                 {
                                     new Card{ Rang = CardRang.King, Suit = CardSuit.Spades}, 
                                     new Card{ Rang = CardRang.Queen, Suit = CardSuit.Diamonds}, 
                                 };
            var commonCard = new Card[]
                                 {
                                 };

            const int rounds = 10;
            var ticks = new long[rounds];
            try
            {
                for (int i = 0; i < rounds; i++)
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    var p = calculator.CalcWinProbability(playerCard, commonCard, 1, 0);
                    Console.WriteLine("P win " + p.WinProbability + " P split " + p.SplitProbability + "player = " + i);
                    ticks[i] = stopWatch.Elapsed.Ticks;
                    Console.WriteLine(i);
                }

                var avgTicks = (long)ticks.Average();
                var ts = new TimeSpan(avgTicks);
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine(elapsedTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        
        private void btnCalc_Click(object sender, EventArgs e)
        {
           
                lblPwin.Text = "";
                lblPsplit.Text = "";
                var calculator = new PokerFil.Calculator.MonteCarloWinCalculator();

            var playerCards = getCardsFromTextBox(tbxPlayersCard);
            var commonCards = getCardsFromTextBox(tbxCommonCards);

            if (playerCards.Any())
            {
                var p = calculator.CalcWinProbability(playerCards, commonCards.ToArray(), 1, 0);
                lblPwin.Text = p.WinProbability.ToString("0.00");
                lblPsplit.Text = p.SplitProbability.ToString("0.00");
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            lblPwin.Text = "";
            lblPsplit.Text = "";
            tbxPlayersCard.Text = "";
            tbxCommonCards.Text = "";
        }

        private  Card[] getCardsFromTextBox(TextBox tbx)
        {
            var cards = new List<Card>();
            var cardsStr = tbx.Text.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            if(cardsStr.Any())
            {
                var deck = PokerFil.Utils.getDeckOfCards();
                foreach (var str in cardsStr)
                {
                    var card = deck.First(d => d.ShortString == str);
                    cards.Add(card);
                }
            }

            return cards.ToArray();
        }

        private void tbxPlayersCard_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
            {
                btnCalc_Click(null, null);
            }
        }

        private void tbxCommonCards_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnCalc_Click(null, null);
            }
        }
    }
}
