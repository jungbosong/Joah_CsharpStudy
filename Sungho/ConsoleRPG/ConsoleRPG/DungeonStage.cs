using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public class DungeonStage
	{
		Start s3 = Start.Instance();
		public void Dungeon()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("던전입장");
			Console.ResetColor();
			Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("1. 쉬운 던전     | 방어력 5 이상 권장");
			Console.ResetColor();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("2. 일반 던전     | 방어력 11 이상 권장");
			Console.ResetColor();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("3. 어려운 던전    | 방어력 17 이상 권장");
			Console.ResetColor();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");
			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "1": EasyStage(); break;
					case "2": NormalStage(); break;
					case "3": HardStage(); break;
					case "0": s3.GameStart(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}
		public void EasyStage()
		{
			Random ClearRan = new Random();
			Random DownHpRan = new Random();
			Random GoldRan = new Random();
			int GoldAtk = GoldRan.Next((int)s3.player.AttackPower, (int)(s3.player.AttackPower * 2) + 1);
			int clearChk = ClearRan.Next(1, 11);
			int DownHp = DownHpRan.Next(20, 36);
			int PreviousHP = (int)s3.player.Health;
			int PreviousGold = s3.player.Gold;

			if (s3.player.DefensivePower < 5)
			{
				if (clearChk <= 4)
				{
					s3.player.Health -= 50;
					if (s3.player.Health < 0)
					{
						s3.player.PlayerDead();
					}
					else
					{
						StageFail(PreviousHP, "쉬움");
					}
				}
				else
				{
					int extraGold = 10 * GoldAtk; // 1000/100 = 10
					s3.player.Gold += 1000 + extraGold;
					s3.player.Health -= DownHp + (5 - s3.player.DefensivePower);
					if (s3.player.Health > 0)
					{
						s3.player.PlayerDead();
					}
					else
					{
						StageClear(PreviousHP, PreviousGold, "쉬움");
					}
				}
			}
			else
			{
				int extraGold = 10 * GoldAtk;
				s3.player.Gold += 1000 + extraGold;
				s3.player.Health -= DownHp - (s3.player.DefensivePower - 5);
				if (s3.player.Health < 0)
				{
					s3.player.PlayerDead();
				}
				else
				{
					StageClear(PreviousHP, PreviousGold, "쉬움");
				}
			}
		}

		public void NormalStage()
		{
			Random ClearRan = new Random();
			Random DownHpRan = new Random();
			Random GoldRan = new Random();
			int GoldAtk = GoldRan.Next((int)s3.player.AttackPower, (int)(s3.player.AttackPower * 2) + 1);
			int clearChk = ClearRan.Next(1, 11);
			int DownHp = DownHpRan.Next(20, 36);
			int PreviousHP = (int)s3.player.Health;
			int PreviousGold = s3.player.Gold;

			if (s3.player.DefensivePower < 11)
			{
				if (clearChk <= 4)
				{
					s3.player.Health -= 50;
					if (s3.player.Health < 0)
					{
						s3.player.PlayerDead();
					}
					else
					{
						StageFail(PreviousHP, "일반");
					}
				}
				else
				{
					int extraGold = 17 * GoldAtk; // 1700/100 = 10
					s3.player.Gold += 1700 + extraGold;
					s3.player.Health -= DownHp + (11 - s3.player.DefensivePower);
					if (s3.player.Health < 0)
					{
						s3.player.PlayerDead();
					}
					else
					{
						StageClear(PreviousHP, PreviousGold, "일반");
					}
				}
			}
			else
			{
				int extraGold = 17 * GoldAtk;
				s3.player.Gold += 1700 + extraGold;
				s3.player.Health -= DownHp - (s3.player.DefensivePower - 11);
				if (s3.player.Health < 0)
				{
					s3.player.PlayerDead();
				}
				else
				{
					StageClear(PreviousHP, PreviousGold, "일반");
				}
			}
		}

		public void HardStage()
		{
			Random ClearRan = new Random();
			Random DownHpRan = new Random();
			Random GoldRan = new Random();
			int GoldAtk = GoldRan.Next((int)s3.player.AttackPower, (int)(s3.player.AttackPower * 2) + 1);
			int clearChk = ClearRan.Next(1, 11);
			int DownHp = DownHpRan.Next(20, 36);
			int PreviousHP = (int)s3.player.Health;
			int PreviousGold = s3.player.Gold;

			if (s3.player.DefensivePower < 17)
			{
				if (clearChk <= 4)
				{

					s3.player.Health -= 50;
					if (s3.player.Health < 0)
					{
						s3.player.PlayerDead();
					}
					else
					{
						StageFail(PreviousHP, "어려움");
					}
				}
				else
				{
					int extraGold = 25 * GoldAtk; // 2500/100 = 10
					s3.player.Gold += 2500 + extraGold;
					s3.player.Health -= DownHp + (17 - s3.player.DefensivePower);
					if (s3.player.Health < 0)
					{
						s3.player.PlayerDead();
					}
					else
					{
						StageClear(PreviousHP, PreviousGold, "어려움");
					}
				}
			}
			else
			{
				int extraGold = 25 * GoldAtk;
				s3.player.Gold += 2500 + extraGold;
				s3.player.Health -= DownHp - (s3.player.DefensivePower - 17);
				if (s3.player.Health < 0)
				{
					s3.player.PlayerDead();
				}
				else
				{
					StageClear(PreviousHP, PreviousGold, "어려움");
				}
			}
		}

		public void StageClear(int PrevHP, int PrevGold, string StageLevel)
		{
			s3.player.Level += 1;
			s3.player.AttackPower += 0.5f;
			s3.player.DefensivePower += 1.0f;
			Console.Clear();
			Console.WriteLine("던전 클리어");
			Console.WriteLine("축하합니다!!");
			Console.WriteLine($"{StageLevel} 던전을 클리어 하였습니다.");
			Console.WriteLine();
			Console.WriteLine("[탐험 결과]");
			Console.WriteLine($"체력 {PrevHP} -> {s3.player.Health}");
			Console.WriteLine($"Gold {PrevGold} G -> {s3.player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");
			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "0": Dungeon(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}

		public void StageFail(int PrevHP, string StageLevel)
		{
			Console.Clear();
			Console.WriteLine("던전 실패");
			Console.WriteLine($"{s3.player.Name} 가 쓰러졌습니다..");
			Console.WriteLine($"{StageLevel} 던전을 실패 하였습니다.");
			Console.WriteLine();
			Console.WriteLine("[탐험 결과]");
			Console.WriteLine($"체력 {PrevHP} -> {s3.player.Health}");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "0": Dungeon(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}
	}
}
