using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IWinStrategy
    {
        bool CheckDealerWon(model.Player a_dealer, model.Player a_player, int g_maxScore);
    }
}