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

    public interface IEquipable: IItem
    {
        public void Equip();
    }

    public interface  IAttackable
    {
        public int Attack();
    }

    public interface IDefensible
    {
        public int Defense();
    }

    public class AttackItem: Item, IAttackable, IEquipable
    {
        public int atk;

        public override void Init(string name, string explanation, int atk)
        {
            this.name = name;
            this.explanation = explanation;
            this.atk = atk;
        }

        public int Attack()
        {
            return atk;
        }

        public void Equip()
        {
            this.equipped = !this.equipped;
        }
    }
}
