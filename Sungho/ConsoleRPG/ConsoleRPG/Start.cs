using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public class Start
	{
		public static Start _instance = null;
		public static Start Instance()
		{
			if (_instance == null)
			{
				_instance = new Start();
			}

			return _instance;
		}

		public bool atk = false;
		public bool def = false;
		public Item? AtkItem = null;
		public Item? DefItem = null;
		public int AttackUP = 0;
		public int DefensiveUP = 0;
		public Player player = new State("Sungho", "전사");
		public List<Item> store_Items = new List<Item>
			{ new GoldSword("황금검", "금으로 만들어진 검입니다."),
			  new IronArmor("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다."),
			  new OldSword("낡은 검", "쉽게 볼 수 있는 낡은 검입니다."),
			  new Sword("검", "튼튼한 검입니다."),
			  new IronRing("철반지", "은으로 만들어진 반지입니다.")
			};
		public List<Item> items = new List<Item> { };
		public Start()
		{
			items.Add(store_Items[1]);
			items.Add(store_Items[2]);
		}

		public void GameStart()
		{
			EnhanceStage eh = new EnhanceStage();
			Rest rs = new Rest();
			DungeonStage ds = new DungeonStage();
			StoreStage st = new StoreStage();
			Inventory it = new Inventory();
			StateStage ss = new StateStage();
			Console.Clear();
			Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
			Console.WriteLine("이곳에서 던전을 들어가기 전 활동을 할 수 있습니다.");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("1. 상태 보기");
			Console.WriteLine();
			Console.WriteLine("2. 인벤토리");
			Console.WriteLine();
			Console.WriteLine("3. 상점");
			Console.WriteLine();
			Console.WriteLine("4. 던전입장");
			Console.WriteLine();
			Console.WriteLine("5. 휴식하기");
			Console.WriteLine();
			Console.WriteLine("6. 강화하기");
			Console.WriteLine();
			Console.ResetColor();
			Console.WriteLine();

			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "1": ss.StateOn(); break;
					case "2": it.InventoryOn(); break;
					case "3": st.Store(); break;
					case "4": ds.Dungeon(); break;
					case "5": rs.RestOn(); break;
					case "6": eh.EnhanceOn(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}
	}
}
