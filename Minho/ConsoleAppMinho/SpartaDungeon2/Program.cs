using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System;
using System.Text;
using System.Threading;

namespace SpartaDungeon
{
    // 플레이어 캐릭터 클래스
    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; set; }

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
    // 장비 아이템 인터페이스
    public interface Equipment
    {
        string Name { get; set; }
        string Information { get; }
        int AdditionalAtk { get; }
        int AdditionalDef { get; }
        int BuyPrice { get; }
        int SellPrice { get; }
        bool IsEquiped { get; set; }
        bool IsSold { get; set; }
    }
    // 장비 중 무기 클래스
    public class Weapon : Equipment
    {
        public string Name { get; set; }
        public string Information { get; }
        public int AdditionalAtk { get; }
        public int AdditionalDef { get; }
        public int BuyPrice { get; }
        public int SellPrice { get; }
        public bool IsEquiped { get; set; }
        public bool IsSold { get; set; }

        public Weapon(string name, string information, int additionalAtk, int additionalDef, int buyPrice, int sellPrice, bool isEquiped, bool IsSold)
        {
            Name = name;
            Information = information;
            AdditionalAtk = additionalAtk;
            AdditionalDef = additionalDef;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            IsEquiped = isEquiped;
            IsSold = IsSold;
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
    //장비 중 방어구 클래스
    public class Armor : Equipment
    {
        public string Name { get; set; }
        public string Information { get; }
        public int AdditionalAtk { get; }
        public int AdditionalDef { get; }
        public int BuyPrice { get; }
        public int SellPrice { get; }
        public bool IsEquiped { get; set; }
        public bool IsSold { get; set; }
        public Armor(string name, string information, int additionalAtk, int additionalDef, int buyPrice, int sellPrice, bool isEquiped, bool isSold)
        {
            Name = name;
            Information = information;
            AdditionalAtk = additionalAtk;
            AdditionalDef = additionalDef;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            IsEquiped = isEquiped;
            IsSold = isSold;
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



        class Programmountable
        {
            // 사용할 객체들
            private static Character player;
            private static Weapon oldSword;
            private static Weapon ironSword;
            private static Weapon ironSpear;
            private static Weapon spartaSpear;
            private static Weapon leonidasSpear;
            private static Armor oldArmor;
            private static Armor ironArmor;
            private static Armor spartaArmor;
            private static Armor leonidasArmor;
            private static Weapon[] weapons;
            private static Armor[] armors;
            private static List<Armor> armorList;
            private static List<Weapon> weaponList;
            private static StringBuilder sb = new StringBuilder();
            // 캐릭터와 아이템 세팅
            static void GameSetting()
            {
                player = new Character("Chad", "전사", 01, 10, 5, 100, 500);
                oldSword = new Weapon("낡은 검", "가장 기본적인 초심자용 검", 5, 0, 100, 50, false, false);
                ironSword = new Weapon("강철 검", "숙련된 모험가의 검", 10, 0, 500, 100, false, false);
                ironSpear = new Weapon("강철 창", "숙련된 모험가의 창", 8, 0, 500, 100, false, false);
                spartaSpear = new Weapon("스파르타 창", "스파르타의 용사들이 사용하는 창", 16, 0, 1500, 300, false, false);
                leonidasSpear = new Weapon("레오니다스의 창", "레오니다스가 사용한 전설적인 창", 32, 0, 5000, 1000, false, false);
                oldArmor = new Armor("낡은 갑옷", "가장 기본적인 초심자용 갑옷", 0, 5, 100, 50, false, false);
                ironArmor = new Armor("강철 갑옷", "숙련된 모험가의 갑옷", 0, 10, 500, 100, false, false);
                spartaArmor = new Armor("스파르타 갑옷", "스파르타의 용사들이 착용하는 갑옷", 0, 15, 1500, 300, false, false);
                leonidasArmor = new Armor("레오니다스의 갑옷", "레오니다스가 사용한 전설적인 갑옷", 0, 25, 3000, 600, false, false);
                weapons = new Weapon[] { ironSword, ironSpear, spartaSpear, leonidasSpear };
                armors = new Armor[] { ironArmor, spartaArmor, leonidasArmor };
                // 인벤토리  
                armorList = new List<Armor>();
                armorList.Add(oldArmor);

                weaponList = new List<Weapon>();
                weaponList.Add(oldSword);

            }
            // 시작 화면
            static void StartScene()
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1.상태 보기");
                Console.WriteLine("2.인벤토리");
                Console.WriteLine("3.상점");
                Console.WriteLine();
                Console.Write("원하시는 행동을 입력해주세요\n>>");
                while (true)
                {
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1": Status(); break;
                        case "2": Inventory(); break;
                        case "3": Store(); break;
                        default: Console.Write("잘못된 입력입니다\n>>"); break;
                    }
                }

            }
            // 상태창
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
            // 상태창에 장착 장비 적용
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
            // 인벤토리에 표시될 장비 아이템
            static void ShowWeapon()
            {
                int count = 0;
                foreach (var i in weaponList)
                {
                    string weaponName = $"-{weaponList[count].Name}";
                    string weaponStatus = $"| 공력력 + {weaponList[count].AdditionalAtk}";
                    string weaponInformation = $"| {weaponList[count].Information}";
                    Console.WriteLine(sb.AppendLine($"{weaponName,-15:C}{weaponStatus,-15:C}{weaponInformation}"));
                    sb.Clear();
                    count++;
                }

            }
            static void ShowArmor()
            {
                int count = 0;
                foreach (var i in armorList)
                {
                    string armorName = $"-{armorList[count].Name}";
                    string armorStatus = $"| 방어력 + {armorList[count].AdditionalDef}";
                    string armorInformation = $"| {armorList[count].Information}";
                    Console.WriteLine(sb.AppendLine($"{armorName,-14:C}{armorStatus,-15:C}{armorInformation}"));
                    sb.Clear();
                    count++;
                }
            }


            // 인벤토리 페이지
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
            // 인벤토리에서 장비 장착을 관리할 페이지
            static void InventoryManager()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("인벤토리-장착관리");
                Console.ResetColor();
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                EquipManager();
            }
            // 인벤토리 매니저의 확장
            static void EquipManager()
            {
                int count = 0;
                int weaponCount = 0;
                int allCount = 0;
                Console.ForegroundColor = ConsoleColor.Yellow;
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
                Console.ResetColor();
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
            //상점 페이지
            static void Store()
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.Gold} G");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                ShowEquipments();
                Console.WriteLine();
                Console.WriteLine("1. 무기 구매");
                Console.WriteLine("2. 방어구 구매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.Write("원하시는 행동을 입력해주세요\n>>");
                while (true)
                {
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1": WeaponBuy(); break;
                        case "2": ArmorBuy(); break;
                        case "0": StartScene(); break;
                        default: Console.Write("잘못된 입력입니다\n>>"); break;
                    }
                }
            }
            static void ShowEquipments()
            {
                for (int i = 0; i < weapons.Length; i++)
                {
                    string weaponName = $"-{weapons[i].Name}";
                    string weaponStatus = $"| {weapons[i].AdditionalAtk}";
                    string weaponInformation = $"| {weapons[i].Information}";
                    string weaponPrice = $"| {weapons[i].BuyPrice}";
                    Console.WriteLine(sb.Append($"{weaponName,-15:C}{weaponStatus,-15:C}{weaponInformation,-35:C}{weaponPrice}"));
                    sb.Clear();
                }
                for (int i = 0; i < armors.Length; i++)
                {
                    string armorName = $"-{armors[i].Name}";
                    string armorStatus = $"| {armors[i].AdditionalAtk}";
                    string armorInformation = $"| {armors[i].Information}";
                    string armorPrice = $"| {armors[i].BuyPrice} G";
                    Console.WriteLine(sb.Append($"{armorName,-15:C}{armorStatus,-15:C}{armorInformation,-35:C}{armorPrice}"));
                    sb.Clear();
                }
            }
            static void WeaponBuy()
            {
                Console.Clear();
                Console.WriteLine("상점 - 무기 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.Gold} G");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                StoreWeapons();
            }
            static void StoreWeapons()
            {
                for (int i = 0; i < weapons.Length; i++)
                {
                    string weaponName = $"- {i + 1} {weapons[i].Name}";
                    string weaponStatus = $"| {weapons[i].AdditionalAtk}";
                    string weaponInformation = $"| {weapons[i].Information}";
                    string weaponPrice = $"| {weapons[i].BuyPrice}";
                    if (weapons[i].IsSold == false)
                    {
                        Console.WriteLine(sb.Append($"{weaponName,-15:C}{weaponStatus,-15:C}{weaponInformation,-35:C}{weaponPrice}"));
                        sb.Clear();
                    }
                    else
                    {
                        Console.WriteLine(sb.Append($"{weaponName,-15:C}{weaponStatus,-15:C}{weaponInformation,-35:C}| 구매완료"));
                        sb.Clear();
                    }
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.Write("원하시는 행동을 입력해주세요\n>>");
                while (true)
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input > 0 && input <= weapons.Length + 1)
                    {
                        if (weapons[input - 1].IsSold == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                            Thread.Sleep(1000);
                            WeaponBuy();
                        }
                        else if (player.Gold >= weapons[input - 1].BuyPrice)
                        {
                            weapons[input - 1].IsSold = true;
                            player.Gold -= weapons[input - 1].BuyPrice;
                            weaponList.Add(weapons[input - 1]);
                            WeaponBuy();
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다.");
                            Thread.Sleep(1000);
                            WeaponBuy();
                        }
                    }
                    switch (input)
                    {
                        case 0: Store(); break;
                        default: Console.Write("잘못된 입력입니다\n>>"); break;
                    }
                }
            }
            static void ArmorBuy()
            {
                Console.Clear();
                Console.WriteLine("상점 - 방어구 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.Gold} G");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                StoreArmors();
            }
            static void StoreArmors()
            {
                for (int i = 0; i < armors.Length; i++)
                {
                    string armorName = $"- {i + 1} {armors[i].Name}";
                    string armorStatus = $"| {armors[i].AdditionalAtk}";
                    string armorInformation = $"| {armors[i].Information}";
                    string armorPrice = $"| {armors[i].BuyPrice}";
                    if (armors[i].IsSold == false)
                    {
                        Console.WriteLine(sb.Append($"{armorName,-15:C}{armorStatus,-15:C}{armorInformation,-35:C}{armorPrice}"));
                        sb.Clear();
                    }
                    else
                    {
                        Console.WriteLine(sb.Append($"{armorName,-15:C}{armorStatus,-15:C}{armorInformation,-35:C}| 구매완료"));
                        sb.Clear();
                    }
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.Write("원하시는 행동을 입력해주세요\n>>");
                while (true)
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input > 0 && input <= armors.Length + 1)
                    {
                        if (armors[input - 1].IsSold == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                            Thread.Sleep(1000);
                            ArmorBuy();
                        }
                        else if (player.Gold >= weapons[input - 1].BuyPrice)
                        {
                            armors[input - 1].IsSold = true;
                            player.Gold -= weapons[input - 1].BuyPrice;
                            armorList.Add(armors[input - 1]);
                            ArmorBuy();
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다.");
                            Thread.Sleep(1000);
                            ArmorBuy();
                        }
                    }
                    switch (input)
                    {
                        case 0: Store(); break;
                        default: Console.Write("잘못된 입력입니다\n>>"); break;
                    }
                }
            }

            //메인 함수 구동
            static void Main(string[] args)
            {
                GameSetting();
                StartScene();
            }
        }
    }
}


