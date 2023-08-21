using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public class Inventory
    {
        private static Inventory _instance = null;
        public static Inventory Instance()
        {
            if (_instance == null)
            {
                _instance = new Inventory();
            }
            return _instance;
        }

        public List<AttackItem> attackItems = new List<AttackItem>();
        public List<DefensiveItem> defensiveItems = new List<DefensiveItem>();
        public int itemCount;

        public void Init()
        {
            attackItems.Clear();
            AttackItem attackItem = new AttackItem();
            attackItem.Init("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 2);
            AddAttackItem(attackItem);

            defensiveItems.Clear();
            DefensiveItem defensiveItem = new DefensiveItem();
            defensiveItem.Init("무쇠값옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 5);
            AddDefensiveItem(defensiveItem);

            itemCount = attackItems.Count + defensiveItems.Count;
        }

        public void AddAttackItem(AttackItem item)
        {
            attackItems.Add(item);
        }

        public void AddDefensiveItem(DefensiveItem item)
        {
            defensiveItems.Add(item);
        }

        public void DeleteIAttackItem(int idx)
        {
            attackItems.RemoveAt(idx);
        }
        public void DeleteIDefensiveItem(int idx)
        {
            defensiveItems.RemoveAt(idx);
        }
    }
}