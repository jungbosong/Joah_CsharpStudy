using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHyeongyo_RPG
{
    internal class Items
    {
        public enum Placed { Inventory, Store }

        public class Item
        {
            public string Name { get; set; }
            public string Explanation { get; set; }
            public Placed Placed { get; set; } = Placed.Inventory;
            public bool IsEquip { get; set; } = false;
            public int Atk { get; set; } = 0;
            public int Def { get; set; } = 0;
        }

        public class Weapon : Item
        {
            public Weapon(string name, string explanation, int atk)
            {
                Name = name;
                Explanation = explanation;
                Atk = atk;
            }

            public Weapon(string name, string explanation, int atk, Placed placed)
            {
                Name = name;
                Explanation = explanation;
                Atk = atk;
                Placed = placed;
            }
        }

        public class Armor : Item
        {
            public Armor(string name, string explanation, int def)
            {
                Name = name;
                Explanation = explanation;
                Def = def;
            }

            public Armor(string name, string explanation, int def, Placed placed)
            {
                Name = name;
                Explanation = explanation;
                Def = def;
                Placed = placed;
            }
        }
    }
}
