using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public abstract class Item
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
