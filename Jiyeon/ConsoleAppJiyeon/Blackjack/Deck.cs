using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    // 덱을 표현하는 클래스
    public class Deck
    {
        private static Deck _instance = null;
        public static Deck Instance()
        {
            if(_instance == null)
            {
                _instance = new Deck();
            }
            return _instance;
        }

        private readonly List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();

            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(s, r));
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            Random rand = new Random();

            for (int i = 0; i < cards.Count; i++)
            {
                int j = rand.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card DrawCard()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public bool ExistCard()
        {
            if(cards.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
