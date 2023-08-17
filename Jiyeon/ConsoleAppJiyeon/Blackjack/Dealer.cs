using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    // 딜러 클래스를 작성하고, 딜러의 행동 로직을 구현하세요.
    public class Dealer : Player
    {
        private static Dealer _instance;

        public static Dealer Instance()
        {
            if(_instance == null)
            {
                _instance = new Dealer();
            }
            return _instance;
        }

        public override bool CheckAcceptable()
        {
            if(Hand.GetTotalValue() < 17)
            {
                return true;
            }
            return false;
        }        
    }
}
