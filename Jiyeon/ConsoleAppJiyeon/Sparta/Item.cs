using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public interface IItem
    {
        //public Item MakeItem(string name, string explanation, int atk, int def);
    }

    public interface IEquipable : IItem
    {
        public void Equip();
    }

    public interface IAttackable
    {
        public int Attack();
    }

    public interface IDefensible
    {
        public int Defense();
    }
    public abstract class Item: IEquipable
    {
        public string name;
        public string explanation;
        public bool equipped = false;

        public abstract void Init(string name, string explanation, int effect);

        public void Equip()
        {
            equipped = !equipped;
        }
    }
}
