using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public class StateStage
	{

		Start s6 = Start.Instance();
		public void StateOn()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("상태 보기");
			Console.ResetColor();
			Console.WriteLine("캐릭터의 정보가 표시됩니다");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"이름 : {s6.player.Name}");
			Console.WriteLine($"Lv {s6.player.Level}");
			Console.WriteLine($"Chad ( {s6.player.chad} )");
			if (s6.AttackUP > 0 )
			{
				Console.WriteLine($"공격력 : {s6.player.AttackPower} (+{s6.AttackUP})");
			}
			else
			{
				Console.WriteLine($"공격력 : {s6.player.AttackPower}");
			}
			if (s6.DefensiveUP > 0 )
			{
				Console.WriteLine($"방어력 : {s6.player.DefensivePower} (+{s6.DefensiveUP})");
			}
			else
			{
				Console.WriteLine($"방어력 : {s6.player.DefensivePower}");
			}
			Console.WriteLine($"체 력 : {s6.player.Health}");
			Console.WriteLine($"Gold : {s6.player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요");
			Console.WriteLine(">>");

			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "0": s6.GameStart(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}
	}
}

