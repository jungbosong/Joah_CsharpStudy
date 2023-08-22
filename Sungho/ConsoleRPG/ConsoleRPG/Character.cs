using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public interface Character
	{
		int Level { get; set; }
		string Name { get; }
		string chad { get; }
		float AttackPower { get; set; }
		float DefensivePower { get; set; }
		float Health { get; set; }
		int Gold { get; set; }
		void PlayerDead();
	}
}
