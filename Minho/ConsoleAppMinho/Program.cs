using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SpartaDungeon
{
    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
    public interface Equipment
    {
        string Name { get; set; }
        string Information { get; }
        int AdditionalAtk { get; }
        int AdditionalDef { get; }
        int BuyPrice { get; }
        int SellPrice { get; }
        bool IsEquiped { get; set; }
        
        
    }

    public class Weapon : Equipment
    {
        public string Name { get; set; }
        public string Information { get; }
        public int AdditionalAtk { get; }
        public int AdditionalDef { get; }
        public int BuyPrice { get; }
        public int SellPrice { get; }
        public bool IsEquiped { get; set; }
        

        public Weapon(string name, string information, int additionalAtk, int additionalDef, int buyPrice, int sellPrice, bool isEquiped)
        { 
            Name = name;
            Information = information;
            AdditionalAtk = additionalAtk;
            AdditionalDef = additionalDef;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            IsEquiped = isEquiped;
        }
        public void EquipCheck()
        {
            if (IsEquiped == true)
            {
                IsEquiped = false;
                Name = Name.Replace("[E] ", "");
            }
            else
            {
                IsEquiped = true;
                Name = "[E] " + Name;
            }
        }


    }
    public class Armor : Equipment
    {
        public string Name { get; set; }
        public string Information { get; }
        public int AdditionalAtk { get; }
        public int AdditionalDef { get; }
        public int BuyPrice { get; }
        public int SellPrice { get; }
        public bool IsEquiped { get; set; }
        public Armor(string name, string information, int additionalAtk, int additionalDef, int buyPrice, int sellPrice, bool isEquiped)
        {
            Name = name;
            Information = information;
            AdditionalAtk = additionalAtk;
            AdditionalDef = additionalDef;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            IsEquiped = isEquiped;
        }
        public void EquipCheck()
        {
            if (IsEquiped == false)
            {
                IsEquiped = true;
                Name = "[E] " + Name;
            }
            else
            {
                IsEquiped = false;
                Name = Name.Replace("[E] ", "");
            }
        }
    }
    class Programmountable
    {
        private static Character player;
        private static Armor oldArmor;
        private static Weapon oldSword;
        private static List<Armor> armorList;
        private static List<Weapon> weaponList;


        static void GameSetting()
        {
            player = new Character("Chad", "전사", 01, 10, 5, 100, 1500);
            oldArmor = new Armor("낡은 갑옷", "기본적인 갑옷", 0, 5, 100, 50, false);
            oldSword = new Weapon("낡은 검", "기본적인 검", 5, 0, 100, 50, false);     
            armorList = new List<Armor>();
            armorList.Add(oldArmor);
            weaponList = new List<Weapon>();
            weaponList.Add(oldSword);
        }
        static void StartScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1.상태 보기");
            Console.WriteLine("2.인벤토리");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요\n>>");
            while (true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": Status(); break;
                    case "2": Inventory(); break;
                    default: Console.Write("잘못된 입력입니다\n>>"); break;
                }
            }

        }

        static void Status()
        {
            Console.Clear();
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name} ({player.Job})");
            EquipStatus();
            Console.WriteLine($"체 력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요\n>>");
            while (true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0": StartScene(); break;
                    default: Console.Write("잘못된 입력입니다\n>>"); break;
                }
            }
        }
        static void EquipStatus()
        {
            int equipAtk = 0;
            int equipDef = 0;
            for (int i = 0; i < weaponList.Count; i++) 
            {
                if (weaponList[i].IsEquiped == true)
                {
                    equipAtk += weaponList[i].AdditionalAtk;
                }
            }
            for (int i = 0; i < armorList.Count; i++)
            {
                if (armorList[i].IsEquiped == true)
                {
                    equipDef += armorList[i].AdditionalDef;
                }
            }
            if (equipAtk == 0)
            {
                Console.WriteLine($"공격력 : {player.Atk}");
            }
            else 
            {
                Console.WriteLine($"공격력 : {player.Atk} (+{equipAtk})");
            }
            if (equipDef == 0)
            {
                Console.WriteLine($"방어력 : {player.Def}");
            }
            else
            {
                Console.WriteLine($"방어력 : {player.Def} (+{equipDef})");
            }
            
        }
        static void ShowWeapon()
        {
            int count=0;
            foreach ( var i in  weaponList)
            {
                Console.WriteLine($"-{weaponList[count].Name}   | 공력력 + {weaponList[count].AdditionalAtk} | {weaponList[count].Information}");
                count++;
            }          
        }
        static void ShowArmor()
        {
            int count = 0;
            foreach (var i in armorList)
            {
                Console.WriteLine($"-{armorList[count].Name}   | 방어력 + {armorList[count].AdditionalDef} | {armorList[count].Information}");
                count++;
            }
        }
        
        

        static void Inventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            ShowWeapon();
            ShowArmor();
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.Write("원하시는 행동을 입력해주세요\n>>");
            while (true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": InventoryManager(); break;
                    case "0": StartScene(); break;
                    default: Console.Write("잘못된 입력입니다\n>>"); break;
                }
            }
        }
        static void InventoryManager()
        {
            Console.Clear();
            Console.WriteLine("인벤토리-장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            EquipManager();           
        }
        static void EquipManager()
        {
            int count = 0;
            int weaponCount = 0;
            int allCount = 0;
            foreach (var i in weaponList)
            {
                Console.WriteLine($"-{allCount + 1} {weaponList[count].Name}   | 공력력 + {weaponList[count].AdditionalAtk} | {weaponList[count].Information}");
                count++;
                allCount++;
                weaponCount++;
            }

            count = 0;

            foreach (var i in armorList)
            {
                Console.WriteLine($"-{allCount + 1} {armorList[count].Name}   | 방어력 + {armorList[count].AdditionalDef} | {armorList[count].Information}");
                count++;
                allCount++;
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if (input > 0 && input <= weaponCount)
                {
                    weaponList[input - 1].EquipCheck();
                    InventoryManager();
                }
                else if (input > weaponCount && input <= allCount)
                {
                    armorList[input - 1 - weaponCount].EquipCheck();
                    InventoryManager();
                }
                else
                {
                    switch (input)
                    {
                        case 0: Inventory(); break;
                        default: Console.Write("잘못된 입력입니다\n>>"); break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            GameSetting();
            StartScene();
        }
    }
}

