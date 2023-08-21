using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHyeongyo_RPG
{
    public class Notice
    {
        // 입력받는 리스트
        List<string> optionList = new List<string>();

        // 입력받는 전체 메서드
        public void option(string option)
        {
            Console.Clear();
            optionList.Clear();
            switch (option)
            {
                case "start":
                    start();
                    optionList.Add("상태 보기");
                    optionList.Add("인벤토리");
                    break;
                case "status":
                    status();
                    optionList.Add("나가기");
                    break;
                case "inventory":
                    inventory();
                    optionList.Add("장착 관리");
                    optionList.Add("나가기");
                    break;
            }

            for (int i = 0; i < optionList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {optionList[i]}");
            }
            next(1, optionList.Count);
        }

        public void next(int min, int max)
        {
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            int a = CheckValidInput(min, max);
            switch (optionList[a - 1])
            {
                case "상태 보기":
                    option("status");
                    break;
                case "인벤토리":
                    option("inventory");
                    break;
                case "나가기":
                    option("start");
                    break;
                case "장착 관리":
                    option("start");
                    break;
            }
        }
        // 숫자 체크
        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }


        // 단순 출력 메서드
        public void start()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
        }
        public void status()
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine("Lv. " + Program.player.Level);
            Console.WriteLine($"{Program.player.Name} ( {Program.player.Job} )");
            Console.WriteLine("공격력 : " + Program.player.Atk);
            Console.WriteLine("방어력 : " + Program.player.Def);
            Console.WriteLine("체 력 : " + Program.player.Hp);
            Console.WriteLine("Gole : " + Program.player.Gold);
            Console.WriteLine();
        }
        public void inventory()
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine();
        }
    }
}
