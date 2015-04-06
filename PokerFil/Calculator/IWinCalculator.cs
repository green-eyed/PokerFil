using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerFil.Calculator
{
    interface IWinCalculator
    {
        ProbabilityResult CalcWinProbability(Card[] playerCards, Card[] commonCards, int playerscount, int foldPlayersCount);
    }
}
