using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHyeongyo_RPG
{
    public class Option
    {
        public enum Action { Start, Status, Inventory, EquipManage}

        Notice notice = new Notice();
        // 입력받는 리스트
        List<string> optionList = new List<string>();

        // 입력받는 전체 메서드
        public void option(Action action)
        {
            Console.Clear();
            optionList.Clear();
            switch (action)
            {
                case Action.Start:
                    notice.start();
                    optionList.Add("상태 보기");
                    optionList.Add("인벤토리");
                    break;
                case Action.Status:
                    notice.status();
                    optionList.Add("시작화면으로");
                    break;
                case Action.Inventory:
                    notice.inventory();
                    optionList.Add("장착 관리");
                    optionList.Add("시작화면으로");
                    break;
                case Action.EquipManage:
                    notice.equipManage();
                    for (int i = 0; i < Program.items.Count; i++)
                    {
                        if (Program.items[i].IsEquip)
                        {
                            if (Program.items[i] is Items.Weapon)
                            {
                                optionList.Add($"- [E]{Program.items[i].Name}\t│ 공격력 +{Program.items[i].Atk} │ {Program.items[i].Explanation}");
                            }
                            else if (Program.items[i] is Items.Armor)
                            {
                                optionList.Add($"- [E]{Program.items[i].Name}\t│ 방어력 +{Program.items[i].Def} │ {Program.items[i].Explanation}");
                            }
                        }
                        else
                        {
                            if (Program.items[i] is Items.Weapon)
                            {
                                optionList.Add($"- {Program.items[i].Name}\t│ 공격력 +{Program.items[i].Atk} │ {Program.items[i].Explanation}");
                            }
                            else if (Program.items[i] is Items.Armor)
                            {
                                optionList.Add($"- {Program.items[i].Name}\t│ 방어력 +{Program.items[i].Def} │ {Program.items[i].Explanation}");
                            }
                        }
                    }
                    optionList.Add("인벤토리");
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
            if (optionList[a - 1].Contains("-"))
            {
                if (optionList[a - 1].Contains("[E]"))
                {
                    if (Program.items[a - 1] is Items.Weapon)
                    {
                        notice.equipAtk -= Program.items[a - 1].Atk;
                    }
                    else if (Program.items[a - 1] is Items.Armor)
                    {
                        notice.equipDef -= Program.items[a - 1].Def;
                    }
                    Program.items[a - 1].IsEquip = false;
                    option(Action.EquipManage);
                }
                else
                {
                    if (Program.items[a - 1] is Items.Weapon)
                    {
                        notice.equipAtk += Program.items[a - 1].Atk;
                    }
                    else if (Program.items[a - 1] is Items.Armor)
                    {
                        notice.equipDef += Program.items[a - 1].Def;
                    }
                    Program.items[a - 1].IsEquip = true;
                    option(Action.EquipManage);
                }
            }
            else
            {
                switch (optionList[a - 1])
                {
                    case "상태 보기":
                        option(Action.Status);
                        break;
                    case "인벤토리":
                        option(Action.Inventory);
                        break;
                    case "시작화면으로":
                        option(Action.Start);
                        break;
                    case "장착 관리":
                        option(Action.EquipManage);
                        break;
                }
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
    }
}
