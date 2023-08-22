using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public class DefensiveItem: Item, IDefensible
    {
        public int def;

        public override void Init(string name, string explanation, int def)
        {
            this.name = name;
            this.explanation = explanation;
            this.def = def;
        }

        public int Defense()
        {
            return def;
        }
    }
}
