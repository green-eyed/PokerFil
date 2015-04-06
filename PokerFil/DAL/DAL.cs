using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerFil.DAL
{
    public class DAL
    {
        private DataClassesDataContext db;

        public DAL()
        {
            db = new DataClassesDataContext();
        }

        public void addPreflopProbability(Card[] cards, Calculator.ProbabilityResult p, int otherPlayersCount)
        {
            var hash = CardCombination.calcHash(cards);
            var sb = new StringBuilder();
            foreach (var card in cards)
            {
                sb.Append(card.ToShortString()).Append(" ");
            }
            var newProbability = new PreflopProbility
                                     {
                                         Hash = BitConverter.GetBytes(hash),
                                         Id = Guid.NewGuid(),
                                         OtherPlayersCount = otherPlayersCount,
                                         SplitProbility = p.SplitProbability,
                                         WinProbility = p.WinProbability,
                                         Cards = sb.ToString()
                                     };
            db.PreflopProbility.InsertOnSubmit(newProbability);
            db.SubmitChanges();
        }
    }
}
