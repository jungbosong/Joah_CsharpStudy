using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public interface IItem
    {
        public void Init(string name, string explanation, int effect);
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

    public enum ItemType
    {
        NONE,
        AttackItem,
        DefensiveItem,
    }

    public class Item: IItem, IEquipable
    {
        public string name;
        public string explanation;
        public bool equipped = false;
        public int effect;
        public int type = (int)ItemType.NONE; // 공격 아이템

        public virtual void Init(string name, string explanation, int effect)
        {
            this.name = name;
            this.explanation = explanation;
            this.effect = effect;
        }

        public void Equip()
        {
            equipped = !equipped;
        }
    }
}
