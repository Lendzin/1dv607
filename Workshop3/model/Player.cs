﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Player
    {
        protected bool _isDealer = false;
        private ICardDealtObserver m_subscriber;
        private List<Card> m_hand = new List<Card>();

        public void AddSubscriber(ICardDealtObserver a_subscriber) {
            m_subscriber = a_subscriber;
        }

        public void DealCard(Card a_card)
        {
            m_hand.Add(a_card);
            m_subscriber.CardDealt(this, a_card);
            System.Threading.Thread.Sleep(2500);
        }

        public IEnumerable<Card> GetHand()
        {
            return m_hand.Cast<Card>();
        }

        public void ClearHand()
        {
            m_hand.Clear();
        }

        public bool isDealer() {
            return _isDealer;
        }

        public void ShowHand()
        {
            foreach (Card c in GetHand())
            {
                c.Show(true);
            }
        }

        public int CalcScore()
        {
            int score = CalculateActualScore();

            if (score > 21)
            {
                foreach (Card c in GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && score > 21)
                    {
                        score -= 10;
                    }
                }
            }

            return score;
        }

        private int CalculateActualScore() {
            int[] cardScores = new int[(int)model.Card.Value.Count]
                {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
            int score = 0;

            foreach(Card c in GetHand()) {
                if (c.GetValue() != Card.Value.Hidden)
                {
                    score += cardScores[(int)c.GetValue()];
                }
            }
            return score;
        }
        public int CalcLowestScore()
        {
            int score = CalculateActualScore();
            foreach (Card c in GetHand())
            {
                if ( c.GetValue() == Card.Value.Ace)
                {
                    score -=10;
                }
            }
            return score;
        }
    }
}
