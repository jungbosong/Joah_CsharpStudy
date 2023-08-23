using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public class GoldSword : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }
		public int Price { get; set; }
		public bool I_Exist { get; set; }
		public bool equipped { get; set; }
		public string Sign { get; set; }
		public int EnhanceNum { get; set; }

		public GoldSword(string Name, int AttackPower, string Information)
		{
			this.Name = Name;
			this.AttackPower = AttackPower;
			this.Information = Information;
			DefensivePower = 0;
			Price = 1300;
			I_Exist = false;
			equipped = false;
			Sign = "";
			EnhanceNum = 0;
		}
	}
}
