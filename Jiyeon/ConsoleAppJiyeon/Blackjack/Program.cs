namespace Blackjack
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    class Program
    {
        static void Main(string[] args)
        {
            Blackjack blackjack = Blackjack.Instance();

            Console.WriteLine(blackjack.PlayBlackjack());
        }
    }
}