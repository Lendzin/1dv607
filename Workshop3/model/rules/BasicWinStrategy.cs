using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class BasicWinStrategy : IWinStrategy
    {
        private const int g_hitLimit = 17;

        public bool CheckDealerWon(model.Player a_dealer, model.Player a_player, int g_maxScore)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            if (a_dealer.CalcScore() > g_maxScore)
            {
                return false;
            }
            if (a_dealer.CalcScore() < a_player.CalcScore()) {
                return false;
            }
            return true;
            
        }
    }
}