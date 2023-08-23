using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System;
using System.Text;
using System.Threading;
using System.ComponentModel.Design;

namespace SpartaDungeon
{
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
        // 상점 장비들
        private static Weapon[] weapons;
        private static Armor[] armors;
        // 플레이어 장비들
        private static List<Armor> armorList;
        private static List<Weapon> weaponList;
        private static StringBuilder sb = new StringBuilder();
        private static Random randomObj = new Random();
        private static Dungeon easyDungeon;
        private static Dungeon normalDungeon;
        private static Dungeon hardDungeon;
        // 캐릭터와 아이템 세팅
        static void GameSetting()
        {
            player = new Character("Chad", "전사", 00, 01, 5, 5, 100, 500);
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
            // 던전
            easyDungeon = new Dungeon("쉬운 던전", 1000, 10);
            normalDungeon = new Dungeon("일반 던전", 1700, 15);
            hardDungeon = new Dungeon("어려운 던전", 2500, 20);
        }
        // 시작 화면
        static void StartScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전입장");
            Console.WriteLine("5. 휴식");
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
                    case "4": DungeonEnter(); break;
                    case "5": Resting(); break;
                    default: Console.Write("잘못된 입력입니다\n>>"); break;
                }
            }

        }
        // 상태창
        static void Status()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;            
            Console.WriteLine("상태보기");
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리");
            Console.ResetColor();
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
                    if (weaponList[input - 1].IsEquiped == true)
                    {
                        weaponList[input - 1].EquipCheck();
                        InventoryManager();
                    }
                    else
                    {
                        for (int i = 0; i < weaponCount; i++)
                        {
                            if (weaponList[i].IsEquiped == true)
                            {
                                weaponList[i].EquipCheck();
                            }
                        }
                        weaponList[input - 1].EquipCheck();
                        InventoryManager();
                    }
                }
                else if (input > weaponCount && input <= allCount)
                {
                    if (armorList[input - 1 - weaponCount].IsEquiped == true)
                    {
                        armorList[input - 1 - weaponCount].EquipCheck();
                        InventoryManager();
                    }
                    else
                    {
                        for (int i = 0; i < armorList.Count; i++)
                        {
                            if (armorList[i].IsEquiped == true)
                            {
                                armorList[i].EquipCheck();
                            }
                        }
                        armorList[input - 1 - weaponCount].EquipCheck();
                        InventoryManager();
                    }
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점");
            Console.ResetColor();
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
            Console.WriteLine("3. 무기 판매");
            Console.WriteLine("4. 방어구 판매");
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
                    case "3": WeaponSell(); break;
                    case "4": ArmorSell(); break;
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
                if (weapons[i].IsSold == true)
                {
                    Console.WriteLine(sb.Append($"{weaponName,-15:C}{weaponStatus,-15:C}{weaponInformation,-35:C}| 구매완료"));
                    sb.Clear();
                }
                else
                {
                    Console.WriteLine(sb.Append($"{weaponName,-15:C}{weaponStatus,-15:C}{weaponInformation,-35:C}{weaponPrice}"));
                    sb.Clear();
                }

            }
            for (int i = 0; i < armors.Length; i++)
            {
                string armorName = $"-{armors[i].Name}";
                string armorStatus = $"| {armors[i].AdditionalAtk}";
                string armorInformation = $"| {armors[i].Information}";
                string armorPrice = $"| {armors[i].BuyPrice} G";
                if (armors[i].IsSold == true)
                {
                    Console.WriteLine(sb.Append($"{armorName,-15:C}{armorStatus,-15:C}{armorInformation,-35:C}| 구매완료"));
                    sb.Clear();
                }
                else
                {
                    Console.WriteLine(sb.Append($"{armorName,-15:C}{armorStatus,-15:C}{armorInformation,-35:C}{armorPrice}"));
                    sb.Clear();
                }
            }
        }
        //상점 구매 페이지
        static void WeaponBuy()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("상점 - 무기 구매");
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("상점 - 방어구 구매");
            Console.ResetColor();
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
        //상점 판매 페이지
        static void WeaponSell()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("상점-무기 판매");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < weaponList.Count; i++)
            {
                string weaponName = $"- {i + 1} {weaponList[i].Name}";
                string weaponStatus = $"| {weaponList[i].AdditionalAtk}";
                string weaponInformation = $"| {weaponList[i].Information}";
                string weaponPrice = $"| {weaponList[i].SellPrice}";
                Console.WriteLine(sb.Append($"{weaponName,-15:C}{weaponStatus,-15:C}{weaponInformation,-35:C}{weaponPrice}"));
                sb.Clear();
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요\n>>");
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if (input > 0 && input <= weaponList.Count + 1)
                {
                    if (weaponList[input - 1].IsEquiped == true)
                    {
                        Console.WriteLine("장착중인 장비입니다.");
                        Thread.Sleep(1000);
                        WeaponSell();
                    }
                    else
                    {
                        weaponList[input - 1].IsSold = false;
                        player.Gold += weaponList[input - 1].SellPrice;
                        weaponList.RemoveAt(input - 1);
                        WeaponSell();
                    }
                }
                switch (input)
                {
                    case 0: Store(); break;
                    default: Console.Write("잘못된 입력입니다\n>>"); break;
                }
            }
        }
        static void ArmorSell()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("상점-방어구 판매");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < armorList.Count; i++)
            {
                string armorName = $"- {i + 1} {armorList[i].Name}";
                string armorStatus = $"| {armorList[i].AdditionalAtk}";
                string armorInformation = $"| {armorList[i].Information}";
                string armorPrice = $"| {armorList[i].SellPrice}";
                Console.WriteLine(sb.Append($"{armorName,-15:C}{armorStatus,-15:C}{armorInformation,-35:C}{armorPrice}"));
                sb.Clear();
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요\n>>");
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if (input > 0 && input <= armorList.Count + 1)
                {
                    if (armorList[input - 1].IsEquiped == true)
                    {
                        Console.WriteLine("장착중인 장비입니다.");
                        Thread.Sleep(1000);
                        ArmorSell();
                    }
                    else
                    {
                        armorList[input - 1].IsSold = false;
                        player.Gold += armorList[input - 1].SellPrice;
                        armorList.RemoveAt(input - 1);
                        ArmorSell();
                    }
                }
                switch (input)
                {
                    case 0: Store(); break;
                    default: Console.Write("잘못된 입력입니다\n>>"); break;
                }
            }
        }
        //던전 입장
        static void DungeonEnter()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("던전입장");
            Console.ResetColor();
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 쉬운 던전     | 방어력 10 이상 권장");
            Console.WriteLine("2. 일반 던전     | 방어력 15 이상 권장");
            Console.WriteLine("3. 어려운 던전   | 방어력 20 이상 권장");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요\n>>");
            while (true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": EasyDungeon(); break;
                    case "2": NormalDungeon(); break;
                    case "3": HardDungeon(); break;
                    case "0": StartScene(); break;
                    default: Console.Write("잘못된 입력입니다\n>>"); break;
                }
            }
        }
        //던전 구성
        static void Dungeon(string dungeonName, int rewards, int defCut)
        {
            Console.Clear();
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
            if (player.Def + equipDef < defCut)
            {

                Console.WriteLine($"{dungeonName}에 입장합니다.");
                Console.WriteLine("권장 방어력보다 낮습니다. 40프로 확률로 모험에 실패합니다.");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("던전을 탐험하는 중입니다.");
                Thread.Sleep(2000);
                int defeatPosibility = randomObj.Next(1, 10);
                if (defeatPosibility < 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("던전을 실패했습니다.");
                    Console.WriteLine("체력 절반 감소");
                    Console.ResetColor();
                    player.Hp /= 2;
                    Console.WriteLine();
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.Write("원하시는 행동을 입력해주세요\n>>");
                    while (true)
                    {
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "0": DungeonEnter(); break;
                            default: Console.Write("잘못된 입력입니다\n>>"); break;
                        }
                    }
                }
                else
                {
                    int hpDown = randomObj.Next(20, 35);
                    hpDown -= player.Def + equipDef - defCut;
                    int bonusGold = randomObj.Next(player.Atk + equipAtk, 2 * (player.Atk + equipAtk));
                    int clearGold = rewards + rewards * bonusGold / 100;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("던전 클리어!");
                    Console.WriteLine("축하합니다.");
                    Console.ResetColor();
                    Console.WriteLine($"{dungeonName}을 클리어 하였습니다.");
                    Console.WriteLine();
                    Console.WriteLine("[탐험 결과]");
                    Console.WriteLine($"체력 {player.Hp} -> {player.Hp - hpDown}");
                    player.Hp -= hpDown;
                    Console.WriteLine($"Gold {player.Gold} -> {player.Gold + clearGold}");
                    player.Gold += clearGold;
                    LevelUp();
                    Console.WriteLine();
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.Write("원하시는 행동을 입력해주세요\n>>");
                    while (true)
                    {
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "0": DungeonEnter(); break;
                            default: Console.Write("잘못된 입력입니다\n>>"); break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"{dungeonName}에 입장합니다.");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("던전을 탐험하는 중입니다.");
                Thread.Sleep(2000);
                int hpDown = randomObj.Next(20, 35);
                hpDown -= player.Def + equipDef - defCut;
                int bonusGold = randomObj.Next(player.Atk + equipAtk, 2 * (player.Atk + equipAtk));
                int clearGold = rewards + rewards * bonusGold / 100;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("던전 클리어!");
                Console.WriteLine("축하합니다.");
                Console.ResetColor();
                Console.WriteLine($"{dungeonName}을 클리어 하였습니다.");
                Console.WriteLine();
                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 {player.Hp} -> {player.Hp - hpDown}");
                player.Hp -= hpDown;
                Console.WriteLine($"Gold {player.Gold} -> {player.Gold + clearGold}");
                player.Gold += clearGold;
                LevelUp();
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.Write("원하시는 행동을 입력해주세요\n>>");
                while (true)
                {
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "0": DungeonEnter(); break;
                        default: Console.Write("잘못된 입력입니다\n>>"); break;
                    }
                }
            }
        }
        //난이도별 던전
        static void EasyDungeon()
        {
            Dungeon(easyDungeon.Name,easyDungeon.Rewards,easyDungeon.DefCut);
        }
        static void NormalDungeon()
        {
            Dungeon(normalDungeon.Name, normalDungeon.Rewards, normalDungeon.DefCut);
        }
        static void HardDungeon()
        {
            Dungeon(hardDungeon.Name, hardDungeon.Rewards, hardDungeon.DefCut);
        }
        //휴식
        static void Resting()
        {
            Console.Clear();
            Console.WriteLine("휴식하기");
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {player.Gold} G)");
            Console.WriteLine();
            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "1")
                {
                    if (player.Gold >= 500)
                    {
                        Console.WriteLine("휴식을 완료했습니다.");
                        player.Hp = 100;
                        player.Gold -= 500;
                        Thread.Sleep(1500);
                        StartScene();
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                        Thread.Sleep(1500);
                        StartScene();
                    }
                }
                switch (input)
                {
                    case "0": StartScene(); break;
                    default: Console.Write("잘못된 입력입니다\n>>"); break;
                }
            }
        }
        //경험치를 얻어 레벨업
        static void LevelUp()
        {
            player.Exp++;
            if (player.Exp == player.Level)
            {
                player.Exp = 0;
                player.Level++;
                player.Atk++;
                player.Def++;
                Console.WriteLine("축하합니다! 레벨이 올랐습니다!");
                Console.WriteLine($"{player.Level - 1} -> {player.Level}");
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
