using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerFil.Calculator
{
    interface IOutCalculator
    {
        OutProbabilityResult CalcOutProbability(Card[] playerCards, Card[] commonCards);
    }
}
