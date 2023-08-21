using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHyeongyo_RPG
{
    public virtual class Item
    {
        public string Name;
        public int Atk;
        public int Def;
        public abstract string Explanation;
    }

    public class Weapon : Item
    {

    }

    public class Armor : Item
    {
        
    }
}
