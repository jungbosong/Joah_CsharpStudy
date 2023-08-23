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
        public List<Item> items = new List<Item>();
        public List<AttackItem> attackItems = new List<AttackItem>();
        public List<DefensiveItem> defensiveItems = new List<DefensiveItem>();
        public int itemCount;

        public void Init()
        {
            defensiveItems.Clear();
            AddDefensiveItem("무쇠값옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 9);
            AddDefensiveItem("수련자 값옷", "수련에 도움을 주는 갑옷입니다.", 5);
            AddDefensiveItem("스파르타의 값옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 15);

            attackItems.Clear();
            AddAttackItem("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 2);
            AddAttackItem("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5);
            AddAttackItem("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7);

            itemCount = attackItems.Count + defensiveItems.Count;
        }

        public void AddAttackItem(string name, string explanation, int effect)
        {
            AttackItem item = new AttackItem();
            item.Init(name, explanation, effect);
            attackItems.Add(item);
            items.Add(item);
        }

        public void AddDefensiveItem(string name, string explanation, int effect)
        {
            DefensiveItem item = new DefensiveItem();
            item.Init(name, explanation, effect);
            defensiveItems.Add(item);
            items.Add(item);
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