using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{

    // 플레이어 캐릭터 클래스
    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Exp { get; set; }
        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }

        public Character(string name, string job, int exp, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Exp = exp;
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
    }
    public class Dungeon
    {
        public string Name { get; set; }
        public int Rewards { get; set; }
        public int DefCut { get; }

        public Dungeon(string name, int rewards, int defCut)
        {
            Name = name;
            Rewards = rewards;
            DefCut = defCut;
        }

    }
}

