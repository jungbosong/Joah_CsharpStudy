using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public class AttackItem: Item, IAttackable
    {
        public override void Init(string name, string explanation, int effect)
        {
            this.name = name;
            this.explanation = explanation;
            this.effect = effect;
            type = (int)ItemType.AttackItem;
        }
        public int Attack()
        {
            return effect;
        }
    }
}
