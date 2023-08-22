using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public class AttackItem: Item, IAttackable
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
    }
}
