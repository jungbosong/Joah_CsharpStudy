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
			Start pd = Start.Instance();

			Console.Clear();
			Console.WriteLine($"{Name} 이 죽었습니다..");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("1. 다시 시작");
			Console.WriteLine("2. 게임 종료");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요");
			Console.WriteLine(">>");

			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "1":
						pd.player.Level = 1;
						pd.player.AttackPower = 10.0f;
						pd.player.DefensivePower = 5.0f;
						pd.player.Health = 100.0f;
						pd.player.Gold = 1500;
						pd.GameStart();
						break;
					case "2": return;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
			
		}
	}
}
