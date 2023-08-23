using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public class Rest
	{
		bool rest; // 휴식 판별
		Start s2 = Start.Instance();
		public void RestOn()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine("휴식하기");
			Console.ResetColor();
			Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다.    보유골드 : {s2.player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("1. 휴식하기");
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			if (rest) Console.WriteLine("휴식을 완료했습니다."); Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			rest = false;

			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "1":
						if (s2.player.Gold >= 500)
						{
							s2.player.Gold -= 500;
							s2.player.Health = 100;
							rest = true;
							RestOn();
						}
						else
						{
							Console.WriteLine("Gold 가 부족합니다.");
						}
						break;

					case "0": s2.GameStart(); break;

					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}
	}
}
