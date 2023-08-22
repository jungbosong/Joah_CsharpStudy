using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public class SpartaGame
    {
        private static SpartaGame _instance = null;
        public static SpartaGame Instance()
        {
            if (_instance == null)
            {
                _instance = new SpartaGame();
            }
            return _instance;
        }

        Player player = Player.Instance();
        List<string> itemList = new List<string>();
        List<string> myInfo = new List<string>();

        public void DisplayStartGame()
        {
            SetTitle(MsgDefine.MAIN);
            Console.Write(MsgDefine.OPENING_PHARASE);

            SetAction("1. " + MsgDefine.SHOW_STATE + "2. " + MsgDefine.INVENTORY);
            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;
                case 2:
                    DisplayInventory();
                    break;
            }
        }

        public void DisplayMyInfo()
        {
            SetTitle(MsgDefine.SHOW_STATE);
            Console.Write(MsgDefine.EXPLAN_STATE);

            SetMyInfo();
            foreach (string info in myInfo)
            {
                Console.Write(info);
            }

            Console.WriteLine();

            SetAction("0. " + MsgDefine.OUT);
            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayStartGame();
                    break;
            }
        }

        public void DisplayInventory()
        {
            SetTitle($"{MsgDefine.INVENTORY}\n");
            Console.Write(MsgDefine.EXPLAN_INVENTORY);
            Console.WriteLine();

            SetItemList();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(itemList[0]);
            for (int i = 1; i < itemList.Count; i++)
            {
                Console.Write($"- {itemList[i]}");
            }
            Console.WriteLine();
            Console.ResetColor();

            SetAction("1. " + MsgDefine.MANAGE_EQUIP + "0. " + MsgDefine.OUT);           
            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayStartGame();
                    break;
                case 1:
                    DisplayManageEquipment();
                    break;
            }
        }

        public void DisplayManageEquipment()
        {
            SetTitle($"{MsgDefine.INVENTORY}-{MsgDefine.MANAGE_EQUIP}");
            Console.Write(MsgDefine.EXPLAN_EQUIP);

            SetItemList();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(itemList[0]);
            for (int i = 1; i < itemList.Count; i++)
            {
                Console.Write($"- {i} {itemList[i]}");
            }
            Console.WriteLine();
            Console.ResetColor();

            SetAction("0. " + MsgDefine.OUT);
            int input = CheckValidInput(0, player.inventory.itemCount);
            if(input == 0)
            {
                DisplayInventory();
            }
            else
            {
                player.EquipItem(input);
                DisplayManageEquipment();
            }
        }

        public void DisplayStore()
        {

        }

        public void SetTitle(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(title);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SetAction(string actions)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(actions);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(MsgDefine.INPUT_ACTION);
        }

        public void SetItemList()
        {
            itemList.Clear();
            itemList.Add($"{MsgDefine.LIST_ITEM}\n");

            foreach(DefensiveItem item in player.inventory.defensiveItems)
            {
                string tmp = "";
                if (item.equipped)
                {
                    tmp += MsgDefine.EQUIP;
                }
                tmp += $"{item.name}  | {MsgDefine.DEFENSIVE_POWER} +{item.def} | {item.explanation}\n";
                
                itemList.Add(tmp);
            }

            foreach (AttackItem item in player.inventory.attackItems)
            {
                string tmp = "";
                if (item.equipped)
                {
                    tmp += MsgDefine.EQUIP;
                }
                tmp += $"{item.name}  | {MsgDefine.OFFENSIVE_POWER} +{item.atk} | {item.explanation}\n";

                itemList.Add(tmp);
            }
        }

        public void SetMyInfo()
        {
            myInfo.Clear();
            player.UpdateInfo();
            string tmp = "";
            if(player.level < 10)
            {
                tmp = $"{MsgDefine.LEVEL}0{player.level}\n";
            }
            else
            {
                tmp = $"{MsgDefine.LEVEL}{player.level}\n";
            }
            myInfo.Add(tmp);

            tmp = $"{MsgDefine.JOB} ( {player.JobToString()} )\n";
            myInfo.Add(tmp);

            if(player.increasedAtk == 0)
            {
                tmp = $"{MsgDefine.OFFENSIVE_POWER} : {player.atk}\n";
                myInfo.Add(tmp);
            }
            else
            {
                tmp = $"{MsgDefine.OFFENSIVE_POWER} : {player.atk} (+{player.increasedAtk})\n";
                myInfo.Add(tmp);
            }
            
            if(player.increasedDef == 0)
            {
                tmp = $"{MsgDefine.DEFENSIVE_POWER} : {player.def}\n";
                myInfo.Add(tmp);
            }
            else
            {
                tmp = $"{MsgDefine.DEFENSIVE_POWER} : {player.def} (+{player.increasedDef})\n";
                myInfo.Add(tmp);
            }

            tmp = $"{MsgDefine.HP} : {player.hp}\n";
            myInfo.Add(tmp);

            tmp = $"{MsgDefine.GOLD} : {player.gold} G\n";
            myInfo.Add(tmp);
        }

        public void WriteWrongInput()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(MsgDefine.WRONG_INPUT);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write(MsgDefine.INPUT_ACTION);
        }

        int CheckValidInput(int min, int max)
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

                WriteWrongInput();
            }
        }
    }
}
