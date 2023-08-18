using System.Reflection.Emit;
using System;

namespace ConsoleRPG
{
	// 혹시 몰라서 interface로 구현, 바로 클래스로 구현 가능
	public interface Character
	{
		int Level { get; set; }
		string Name { get; }
		string chad { get; }
		int AttackPower { get; set; }
		int DefensivePower { get; set; }
		int Health { get; set; }
		int Gold { get; set; }
	}

	public class Player : Character
	{
		public int Level { get; set; }
		public string Name { get; }
		public string chad { get; }
		public int AttackPower { get; set; }
		public int DefensivePower { get; set; }
		public int Health { get; set; }
		public int Gold { get; set; }

		public Player(string Name, string chad)
		{
			Level = 01;
			this.Name = Name;
			this.chad = chad;
			AttackPower = 10;
			DefensivePower = 5;
			Health = 100;
			Gold = 1500;
		}

	}
	public class State : Player
	{
		public State(string Name, string chad) : base(Name, chad) { }

	}

	public interface Item
	{
		string Name { get; set; }
		int DefensivePower { get; set; }

		int AttackPower { get; set; }
		string Information { get; set; }
	}

	public class IronArmor : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }

		public IronArmor(string Name, int DefensivePower, string Information) 
		{ 
			this.Name = Name;
			this.DefensivePower = DefensivePower;
			this.Information = Information;
		}
	}

	public class OldSword : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }

		public OldSword(string Name, int AttackPower, string Information)
		{
			this.Name = Name;
			this.AttackPower = AttackPower;
			this.Information = Information;
		}
	}
	public class Start
	{
		int AttackUP = 0;
		int DefensiveUP = 0;
		string IronArmorDisplay = "";
		bool IronArmorChk = false;
		string OldSwordDisplay = "";
		bool OldSwordChk = false;
		
		private Character player;
		private List<Item> items;
		public Start(Player player, List<Item>items)
		{
			this.player = player;
			this.items = items;
		}

		public void GameStart()
		{
			Console.Clear();
			Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
			Console.WriteLine("이곳에서 던전을 들어가기 전 활동을 할 수 있습니다.");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("1. 상태 보기");
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("2. 인벤토리");
			Console.ResetColor();
			Console.WriteLine();

			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");
		
			while (true) {
				string ?input = Console.ReadLine();
				switch (input)
				{
					case "1": StateOn(); break;
					case "2": InventoryOn(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}
		
		public void InventoryOn()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("인벤토리");
			Console.ResetColor();
			Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			Console.WriteLine($"- {IronArmorDisplay}{items[0].Name}    | 방어력 +{items[0].DefensivePower} | {items[0].Information}");
			Console.WriteLine($"- {OldSwordDisplay}{items[1].Name}    | 공격력 +{items[1].AttackPower} | {items[1].Information}");
			Console.WriteLine();
			Console.WriteLine("1. 장착 관리");
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요");
			Console.Write(">>");
			

			while (true)
			{
				string ?input = Console.ReadLine();
				switch (input)
				{
					case "1": InventoryManager(); break;
					case "0": GameStart(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}

		public void InventoryManager()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("인벤토리 - 장착 관리");
			Console.ResetColor();
			Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			Console.WriteLine($"- 1 {IronArmorDisplay}{items[0].Name}    | 방어력 +{items[0].DefensivePower} | {items[0].Information}");
			Console.WriteLine($"- 2 {OldSwordDisplay}{items[1].Name}    | 공격력 +{items[1].AttackPower} | {items[1].Information}");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요");
			Console.Write(">>");
			while (true) { 
			string ?input = Console.ReadLine();
				switch (input)
				{
					case "1":
						{
							if (!IronArmorChk)
							{
								IronArmorDisplay = "[E]";
								IronArmorChk = true;
								DefensiveUP += items[0].DefensivePower;
								player.DefensivePower += items[0].DefensivePower;
								InventoryManager();
							}
							else
							{
								IronArmorDisplay = "";
								IronArmorChk = false;
								DefensiveUP -= items[0].DefensivePower;
								player.DefensivePower -= items[0].DefensivePower;
								InventoryManager();
							}
							break;
						}
					case "2":
						{
							if (!OldSwordChk)
							{
								OldSwordDisplay = "[E]";
								OldSwordChk = true;
								AttackUP += items[1].AttackPower;
								player.AttackPower += items[1].AttackPower;
								InventoryManager();
							}
							else
							{
								OldSwordDisplay = "";
								OldSwordChk = false;
								AttackUP -= items[1].AttackPower;
								player.AttackPower -= items[1].AttackPower;
								InventoryManager();
							}
							break;
						}
					case "0": GameStart(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}

		public void StateOn()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("상태 보기");
			Console.ResetColor();
			Console.WriteLine("캐릭터의 정보가 표시됩니다");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"이름 : {player.Name}");
			Console.WriteLine($"Lv {player.Level}");
			Console.WriteLine($"Chad ( {player.chad} )");
			if (OldSwordChk)
			{
				Console.WriteLine($"공격력 : {player.AttackPower} (+{AttackUP})");
			}
			else
			{
				Console.WriteLine($"공격력 : {player.AttackPower}");
			}
			if (IronArmorChk)
			{
				Console.WriteLine($"방어력 : {player.DefensivePower} (+{DefensiveUP})");
			}
			else
			{
				Console.WriteLine($"방어력 : {player.DefensivePower}");
			}
			Console.WriteLine($"체 력 : {player.Health}");
			Console.WriteLine($"Gold : {player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요");
			Console.WriteLine(">>");

			while (true)
			{
				string ?input = Console.ReadLine();
				switch (input)
				{
					case "0": GameStart(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Item>items = new List<Item> 
			{ new IronArmor("무쇠갑옷", 5, "무쇠로 만들어져 튼튼한 갑옷입니다."), 
			  new OldSword("낡은 검", 2, "쉽게 볼 수 있는 낡은 검입니다.") };

			Player player = new State("Sungho" , "전사");
			Start start = new Start(player, items);

			start.GameStart();			
		}
	}
}