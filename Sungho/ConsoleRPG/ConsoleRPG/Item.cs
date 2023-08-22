using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public interface Item
	{
		string Name { get; set; }
		int DefensivePower { get; set; }
		int AttackPower { get; set; }
		string Information { get; set; }
		int Price { get; set; }
		bool I_Exist { get; set; }
		bool equipped { get; set; }
		string Sign { get; set; }
		int EnhanceNum { get; set; }
	}
}
