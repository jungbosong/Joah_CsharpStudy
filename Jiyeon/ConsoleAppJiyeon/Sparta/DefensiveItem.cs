using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public class DefensiveItem: Item, IDefensible
    {
        public override void Init(string name, string explanation, int effect)
        {
            this.name = name;
            this.explanation = explanation;
            this.effect = effect;
            type = (int)ItemType.DefensiveItem;
        }
        public int Defense()
        {
            return effect;
        }
    }
}
