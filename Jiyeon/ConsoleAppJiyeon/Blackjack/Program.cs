namespace Blackjack
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    class Program
    {
        static void Main(string[] args)
        {
            // 블랙잭 게임을 실행하세요
            Blackjack blackjack = Blackjack.Instance();
            Deck deck = Deck.Instance();
            Dealer dealer = Dealer.Instance();
            Player player = new Player();

            Console.WriteLine(blackjack.PlayBlackjack(player));
        }
    }
}