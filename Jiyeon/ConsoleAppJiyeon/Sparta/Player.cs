using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sparta
{
    public enum Job
    {
        WARRIOR,
        WIZARD,
        HEALER,
        TANKER,
    }

    public class Player
    {
        private static Player _instance = null;
        public static Player Instance()
        {
            if (_instance == null)
            {
                _instance = new Player();
            }
            
            return _instance;
        }

        public int level = 1;
        public Job job = Job.WARRIOR;
        public int hp = 100;
        public int atk = 10;
        public int increasedAtk = 0;
        public int def = 5;
        public int increasedDef = 0;
        public int gold = 1500;
        public string name;
        public Inventory inventory = Inventory.Instance();

        public void Init()
        {
            inventory.Init();
        }

        public void UpdateInfo()
        {
            SetIncreasedAtk();
            SetIncreasedDef();   
        }

        public void SetIncreasedAtk()
        {
            foreach(AttackItem item in inventory.attackItems)
            {
                if (item.equipped)
                {
                    increasedAtk += item.effect;
                    atk += increasedAtk;
                }
                else if(increasedAtk >= item.effect)
                {
                    atk -= increasedAtk;
                    increasedAtk -= item.effect;
                }
            }            
        }

        public void SetIncreasedDef()
        {
            foreach (DefensiveItem item in inventory.defensiveItems)
            {
                if (item.equipped)
                {
                    increasedDef += item.effect;
                    def += increasedDef;
                }
                else if(increasedDef >= item.effect)
                {
                    def -= increasedDef;
                    increasedDef -= item.effect;
                }
            }
        }

        public void EquipItem(int idx)
        {
            inventory.items[idx-1].Equip();
        }

        public string JobToString()
        {
            string result = "";
            switch(job)
            {
                case Job.WARRIOR:
                    result = "전사";
                    break;
                case Job.WIZARD:
                    result = "마법사";
                    break;
                case Job.HEALER:
                    result = "힐러";
                    break;
                case Job.TANKER:
                    result = "탱커";
                    break;
            }
            return result;
        }
    }
}