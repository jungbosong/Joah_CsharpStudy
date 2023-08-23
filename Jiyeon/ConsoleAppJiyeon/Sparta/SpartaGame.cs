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
        List<string> storeItemList = new List<string>();
        public List<string> myInfo = new List<string>();
        private const int MAX_NAME_LENGTH = 10;
        private const int MAX_EFFECT_LENGTH = 10;
        private const int MAX_DESCRIPTION_LENGTH = 30;

        public void DisplayStartGame()
        {
            SetTitle(MsgDefine.MAIN);
            Console.Write(MsgDefine.OPENING_PHARASE);

            SetAction($"1. {MsgDefine.SHOW_STATE}2. {MsgDefine.INVENTORY}\n3. {MsgDefine.STORE}");
            int input = CheckValidInput(1, 3);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;
                case 2:
                    DisplayInventory();
                    break;
                case 3:
                    DisplayStore();
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

            SetAction($"0. {MsgDefine.OUT}");
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

            SetAction($"1. {MsgDefine.MANAGE_EQUIP}2. {MsgDefine.SORT_ITEM}0. {MsgDefine.OUT}");           
            int input = CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    DisplayStartGame();
                    break;
                case 1:
                    DisplayManageEquipment();
                    break;
                case 2:
                    DisplaySortItem();
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

            SetAction($"0. {MsgDefine.OUT}");
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

        public void DisplaySortItem()
        {
            SetTitle($"{MsgDefine.INVENTORY} - {MsgDefine.SORT_ITEM}");
            Console.Write(MsgDefine.EXPLAN_INVENTORY);
            Console.WriteLine();

            SetItemList();
            WriteItemList();

            SetAction($"1. {MsgDefine.NAME}2. {MsgDefine.EQUIPPED}3. {MsgDefine.OFFENSIVE_POWER}\n4.{MsgDefine.DEFENSIVE_POWER}\n0. {MsgDefine.OUT}");
            int input = CheckValidInput(0, 4);
            switch (input)
            {
                case 0:
                    DisplayStartGame();
                    break;
                case 1:
                    SortItemList(MsgDefine.NAME);
                    DisplaySortItem();
                    break;
                case 2:
                    SortItemList(MsgDefine.EQUIPPED);
                    DisplaySortItem();
                    break;
                case 3:
                    SortItemList(MsgDefine.OFFENSIVE_POWER);
                    DisplaySortItem();
                    break;
                case 4:
                    SortItemList(MsgDefine.DEFENSIVE_POWER);
                    DisplaySortItem();
                    break;
            }
        }

        public void DisplayStore()
        {
            SetTitle($"{MsgDefine.STORE}\n");
            Console.Write(MsgDefine.EXPLAN_STORE);
            Console.WriteLine();

            Console.Write(MsgDefine.GOLD_POSSESSION);
            Console.WriteLine($"{player.gold} {MsgDefine.GOLD}\n");

            SetStoreItemList();
            Console.Write(storeItemList[0]);
            for (int i = 1; i < storeItemList.Count; i++)
            {
                Console.Write($"- {storeItemList[i]}");
            }
            Console.WriteLine();

            SetAction($"1. {MsgDefine.PURCHASE_ITEM}2. {MsgDefine.SELL_ITEM}0. {MsgDefine.OUT}");
            int input = CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    DisplayStartGame();
                    break;
                case 1:
                    // TODO 아이템 구매 화면으로 이동
                    break;
                case 2:
                    // TODO 아이템 판매 화면으로 이동
                    break;
            }
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

            foreach (Item item in player.inventory.items)
            {
                string tmp = "";
                if (item.equipped)
                {
                    tmp += MsgDefine.EQUIP;
                }
                if(item.type == (int)ItemType.DefensiveItem)
                {
                    tmp += string.Format("{0,-15}|{1,-10} +{2}|{3,-30}\n", item.name, MsgDefine.DEFENSIVE_POWER, item.effect, item.explanation);
                }
                else
                {
                    tmp += string.Format("{0,-15}|{1,-10} +{2}|{3,-30}\n", item.name, MsgDefine.OFFENSIVE_POWER, item.effect, item.explanation);
                }
                
                
                itemList.Add(tmp);
            }
        }
        
        public void SetStoreItemList()
        {
            storeItemList.Clear();
            storeItemList.Add($"{MsgDefine.LIST_ITEM}\n");

            // TODO 상점 아이템 품목으로 변경해야 함
            foreach (DefensiveItem item in player.inventory.defensiveItems)
            {
                string tmp = "";
                if (item.equipped)
                {
                    tmp += MsgDefine.EQUIP;
                }
                tmp += $"{item.name}  | {MsgDefine.DEFENSIVE_POWER} +{item.effect} | {item.explanation}\n";

                storeItemList.Add(tmp);
            }

            foreach (AttackItem item in player.inventory.attackItems)
            {
                string tmp = "";
                if (item.equipped)
                {
                    tmp += MsgDefine.EQUIP;
                }
                tmp += $"{item.name}  | {MsgDefine.OFFENSIVE_POWER} +{item.effect} | {item.explanation}\n";

                storeItemList.Add(tmp);
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

        public void WriteItemList()
        {
            Console.Write(itemList[0]);
            for (int i = 1; i < itemList.Count; i++)
            {
                Console.Write($"- {itemList[i]}");
            }
            Console.WriteLine();
        }

        // 0, 1, 2
        public int CheckValidInput(int min, int max)
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

        public void SortItemList(string sortBy)
        {
            switch(sortBy)
            {
                case MsgDefine.NAME:
                    Inventory.Instance().items = Inventory.Instance().items.OrderByDescending(item => item.name.Replace(" ", string.Empty).Length).ToList();
                    break;
                case MsgDefine.EQUIPPED:
                    Inventory.Instance().items = Inventory.Instance().items.OrderBy(item => item.equipped).ToList();
                    break;
                case MsgDefine.OFFENSIVE_POWER:
                    Inventory.Instance().items = Inventory.Instance().items.OrderBy(item => item.type).ToList();
                    break;
                case MsgDefine.DEFENSIVE_POWER:
                    Inventory.Instance().items = Inventory.Instance().items.OrderByDescending(item => item.type).ToList();
                    break;
            }
        }
    }
}
