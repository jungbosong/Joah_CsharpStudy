using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public class Player : Character
	{
		public int Level { get; set; }
		public string Name { get; }
		public string chad { get; }
		public float AttackPower { get; set; }
		public float DefensivePower { get; set; }
		public float Health { get; set; }
		public int Gold { get; set; }

		public Player(string Name, string chad)
		{

			Level = 1;
			this.Name = Name;
			this.chad = chad;
			AttackPower = 10.0f;
			DefensivePower = 5.0f;
			Health = 100.0f;
			Gold = 1500;
		}

		public void PlayerDead()
		{
			Console.Clear();
			Console.WriteLine($"{Name} 이 죽었습니다..");
		}
	}
}
