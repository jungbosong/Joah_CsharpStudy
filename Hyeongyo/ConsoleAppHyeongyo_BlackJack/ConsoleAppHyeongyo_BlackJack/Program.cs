using System.ComponentModel.DataAnnotations;

namespace ConsoleAppHyeongyo_BlackJack
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
    public enum WINTYPE { PlayerWin, DealerWin, NoWin }

    // 카드 한 장을 표현하는 클래스
    public class Card
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }

        public Card(Suit s, Rank r)
        {
            Suit = s;
            Rank = r;
        }

        public int GetValue()
        {
            if ((int)Rank <= 10)
            {
                return (int)Rank;
            }
            else if ((int)Rank <= 13)
            {
                return 10;
            }
            else
            {
                return 11;
            }
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }

    // 덱을 표현하는 클래스
    public class Deck
    {
        private static Deck _instance = null;
        public static Deck Instance()
        {
            if (_instance == null)
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
            if (cards.Count == 0)
            {
                return false;
            }
            return true;
        }
    }

    // 패를 표현하는 클래스
    public class Hand
    {
        private List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int GetTotalValue()
        {
            int total = 0;
            int aceCount = 0;

            foreach (Card card in cards)
            {
                if (card.Rank == Rank.Ace)
                {
                    aceCount++;
                }
                total += card.GetValue();
            }

            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }

            return total;
        }

        public Rank GetRANK(int idx)
        {
            return cards[idx].Rank;
        }

        public string GetFirstCard()
        {
            return cards[0].ToString();
        }

        public string GetAllCard()
        {
            string result = "";
            foreach (Card card in cards)
            {
                result += card.ToString() + "\n";
            }
            return result;
        }
    }

    // 플레이어를 표현하는 클래스
    public class Player
    {
        public Hand Hand { get; private set; }

        public Player()
        {
            Hand = new Hand();
        }

        public Card DrawCardFromDeck(Deck deck)
        {
            Card drawnCard = deck.DrawCard();
            Hand.AddCard(drawnCard);
            return drawnCard;
        }

        public virtual bool CheckAcceptable()
        {
            if (Hand.GetTotalValue() < 21)
            {
                return true;
            }
            return false;
        }
    }

    // 딜러 클래스를 작성하고, 딜러의 행동 로직을 구현하세요.
    public class Dealer : Player
    {
        private static Dealer _instance;

        public static Dealer Instance()
        {
            if (_instance == null)
            {
                _instance = new Dealer();
            }
            return _instance;
        }

        public override bool CheckAcceptable()
        {
            if (Hand.GetTotalValue() < 17)
            {
                return true;
            }
            return false;
        }
    }

    // 블랙잭 게임을 구현하세요. 
    public class Blackjack
    {
        private static Blackjack _instance;

        public static Blackjack Instance()
        {
            if (_instance == null)
            {
                _instance = new Blackjack();
            }
            return _instance;
        }

        Deck deck = Deck.Instance();
        Dealer dealer = Dealer.Instance();
        Player player = new Player();
        bool doneGame = false;
        WINTYPE winner = WINTYPE.NoWin;
        string result = "";

        public string PlayBlackjack()
        {
            for (int i = 0; i < 2; i++)
            {
                player.DrawCardFromDeck(deck);
                dealer.DrawCardFromDeck(deck);
            }
            char input = 'y';

            while (Deck.Instance().ExistCard())
            {
                Console.Clear();

                Console.WriteLine("현재 당신이 가진 카드들 입니다.");
                Console.WriteLine($"{player.Hand.GetAllCard()}");
                ShowScore(false);

                Console.WriteLine("카드를 더 받으시려면 y를, 더 받지 않고 결과를 보시려면 n을 입력하세요.");
                input = Console.ReadLine().ElementAt(0);

                if (input == 'y')
                {
                    player.DrawCardFromDeck(deck);
                }
                else if (input == 'n')
                {
                    Console.WriteLine("딜러가 가진 카드가 17점이 될 때까지 딜러가 카드를 더 뽑는 중 입니다.");
                    Thread.Sleep(1000);
                }
                if (CheckBlackjack(player.Hand) || CheckBlackjack(dealer.Hand) || player.Hand.GetTotalValue() >= 21 || dealer.Hand.GetTotalValue() >= 17)
                {
                    doneGame = true;
                }
                if (doneGame)
                {
                    break;
                }
                dealer.DrawCardFromDeck(deck);
            }
            Console.WriteLine("승패가 가려져 게임이 종료되었습니다.\n아래 결과를 확인해주세요.");
            SetResult();
            return result;
        }

        public bool CheckBlackjack(Hand hand)
        {
            if (hand.GetRANK(0) == Rank.Ace)
            {
                if (hand.GetRANK(1) == Rank.Jack || hand.GetRANK(1) == Rank.Queen || hand.GetRANK(1) == Rank.King)
                    return true;
            }
            return false;
        }

        void SetResult()
        {
            int playerTotal = player.Hand.GetTotalValue();
            int dealerTotal = dealer.Hand.GetTotalValue();

            if (CheckBlackjack(player.Hand))
            {
                if (CheckBlackjack(dealer.Hand))
                {
                    result = "~~딜러와 플레이어 모두 블랙잭~~\n";
                }
                else
                {
                    result = "!!블랙잭!\n";
                    winner = WINTYPE.PlayerWin;
                }
            }
            else if (CheckBlackjack(dealer.Hand))
            {
                result = "!!블랙잭!!\n";
                winner = WINTYPE.DealerWin;
            }
            else if (playerTotal > 21)
            {
                if (dealerTotal > 21)
                {
                    result = "~~딜러와 플레이어 모두 21점 초과~~\n";
                }
                else
                {
                    result = "플레이어 21점 초과\n";
                    winner = WINTYPE.DealerWin;
                }
            }
            else if (dealerTotal > 21)
            {
                result = "딜러 21점 초과\n";
                winner = WINTYPE.PlayerWin;
            }
            else if (playerTotal < dealerTotal)
            {
                winner = WINTYPE.DealerWin;
            }
            else
            {
                winner = WINTYPE.PlayerWin;
            }

            switch (winner)
            {
                case WINTYPE.PlayerWin:
                    result = "결과: 플레이어 승리\n" + result;
                    break;
                case WINTYPE.DealerWin:
                    result = "결과: 딜러 승리\n" + result;
                    break;
                case WINTYPE.NoWin:
                    result = "결과: 무승부\n" + result;
                    break;
            }

            ShowScore(true);
        }

        void ShowScore(bool showDealerScore)
        {
            if (showDealerScore)
            {
                Console.WriteLine($"플레이어 점수: {player.Hand.GetTotalValue()}\t딜러 점수: {dealer.Hand.GetTotalValue()}\n");
            }
            else
            {
                Console.WriteLine($"현재 당신의 점수는 {player.Hand.GetTotalValue()}입니다.");
                Console.WriteLine($"현재 딜러가 가진 카드 한 장은 {dealer.Hand.GetFirstCard()}입니다.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Blackjack blackjack = Blackjack.Instance();

            Console.WriteLine(blackjack.PlayBlackjack());
        }
    }
}