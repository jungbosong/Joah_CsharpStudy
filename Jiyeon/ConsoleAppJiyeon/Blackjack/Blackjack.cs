using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public enum WINTYPE
    {
        PlayerWin,
        DealerWin,
        NoWin,
    }
    // 블랙잭 게임을 구현하세요. 
    public class Blackjack
    {
        private static Blackjack _instance;

        public static Blackjack Instance()
        {
            if(_instance == null)
            {
                _instance = new Blackjack();
            }
            return _instance;
        }
        Deck deck = Deck.Instance();
        Dealer dealer = Dealer.Instance();
        bool doneGame = false;
        WINTYPE winner = WINTYPE.NoWin;
        string result = "";

        public string PlayBlackjack(Player player)
        {
            dealer.DrawCardFromDeck(deck);
            player.DrawCardFromDeck(deck);
            dealer.DrawCardFromDeck(deck);
            player.DrawCardFromDeck(deck);
            char input = 'y';

            while (Deck.Instance().ExistCard())
            {
                Console.Clear();

                Console.WriteLine("현재 당신이 가진 카드들 입니다.");
                Console.WriteLine($"{player.Hand.GetAllCard()}");
                ShowScore(player, false);

                Console.WriteLine("카드를 더 받으시려면 y를, 더 받지 않고 결과를 보시려면 n을 입력하세요.");
                input = Console.ReadLine().ElementAt(0);

                if (input == 'y')
                {
                    player.DrawCardFromDeck(deck);
                }
                else if(input == 'n')
                {
                    Console.WriteLine("딜러가 가진 카드가 17점이 될 때까지 딜러가 카드를 더 뽑는 중 입니다.");
                    Thread.Sleep(1000);
                }
                if (CheckBlackjack(player.Hand) || CheckBlackjack(dealer.Hand) || player.Hand.GetTotalValue() >= 21 || dealer.Hand.GetTotalValue() >= 17)
                {
                    doneGame = true;
                }
                if(doneGame)
                {
                    break;
                }
                dealer.DrawCardFromDeck(deck);
            }
            Console.WriteLine("승패가 가려져 게임이 종료되었습니다.\n아래 결과를 확인해주세요.");
            SetResult(player);
            return result;
        }

        public bool CheckBlackjack(Hand hand)
        {
            if (hand.GetRANK(0) == Rank.Ace)
            {
                if(hand.GetRANK(1) == Rank.Jack || hand.GetRANK(1) == Rank.Queen || hand.GetRANK(1) == Rank.King)
                    return true;
            }
            return false;
        }

        void SetResult(Player player)
        {
            int playerTotal = player.Hand.GetTotalValue();
            int dealerTotal = dealer.Hand.GetTotalValue();

            if(CheckBlackjack(player.Hand))
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
            else if(CheckBlackjack(dealer.Hand))
            {
                result = "!!블랙잭!!\n";
                winner = WINTYPE.DealerWin;
            }
            else if(playerTotal > 21)
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
            else if(dealerTotal > 21)
            {
                result = "딜러 21점 초과\n";
                winner = WINTYPE.PlayerWin;
            }
            else if(playerTotal < dealerTotal)
            {
                winner = WINTYPE.DealerWin;
            }
            else
            {
                winner = WINTYPE.PlayerWin;
            }

            switch(winner)
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

            ShowScore(player, true);
        }

        void ShowScore(Player player, bool showDealerScore)
        {
            if(showDealerScore)
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
}
