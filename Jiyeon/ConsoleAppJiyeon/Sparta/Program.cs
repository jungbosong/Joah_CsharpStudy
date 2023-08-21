namespace Sparta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpartaGame spartaGame = SpartaGame.Instance();

            spartaGame.DisplayStartGame();
        }
    }
}