using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJack.model
{
    interface ICardDealtObserver
    {
        void CardDealt(Player a_player, Card a_card);

    }
}
