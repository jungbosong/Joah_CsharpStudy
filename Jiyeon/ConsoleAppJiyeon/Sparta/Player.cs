using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
        public Job job;
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
                increasedAtk += item.atk;
            }
        }

        public void SetIncreasedDef()
        {
            foreach (DefensiveItem item in inventory.defensiveItems)
            {
                increasedDef += item.def;
            }
        }

        public void EquipItem(int idx)
        {
            if(inventory.defensiveItems.Count < idx)
            {
                inventory.attackItems[idx - inventory.defensiveItems.Count - 1].Equip();
            }
            else
            {
                inventory.defensiveItems[idx].Equip();
            }
        }
    }
}
