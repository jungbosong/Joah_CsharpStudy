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
		public int OriginAttackPower { get; }
		public int OriginDefensivePower { get; }


		public GoldSword(string Name, string Information)
		{
			this.Name = Name;
			AttackPower = 8;
			this.Information = Information;
			DefensivePower = 0;
			Price = 1300;
			I_Exist = false;
			equipped = false;
			Sign = "";
			EnhanceNum = 0;
			OriginAttackPower = 8;
			OriginDefensivePower = 0;
		}
	}
}
