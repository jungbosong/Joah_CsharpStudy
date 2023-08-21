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
		int Price { get; set; }
		bool I_Exist { get; set; }
		bool equipped { get; set; }
		string Sign { get; set; }
	}

	public class IronArmor : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }
		public int Price { get; set; }
		public bool I_Exist { get; set; }
		public bool equipped { get; set; }
		public string Sign { get; set; }
		public IronArmor(string Name, int DefensivePower, string Information) 
		{ 
			this.Name = Name;
			this.DefensivePower = DefensivePower;
			this.Information = Information;
			AttackPower = 0;
			Price = 600;
			I_Exist = true;
			equipped = false;
			Sign = "";
		}
	}

	public class IronRing : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }
		public int Price { get; set; }
		public bool I_Exist { get; set; }
		public bool equipped { get; set; }
		public string Sign { get; set; }




		public IronRing(string Name, int DefensivePower, string Information)
		{
			this.Name = Name;
			this.DefensivePower = DefensivePower;
			this.Information = Information;
			AttackPower = 0;
			Price = 400;
			I_Exist = false;
			equipped = false;
			Sign = "";
		}
	}

	public class OldSword : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }
		public int Price { get; set; }
		public bool I_Exist { get; set; }
		public bool equipped { get; set; }
		public string Sign { get; set; }

		public OldSword(string Name, int AttackPower, string Information)
		{
			this.Name = Name;
			this.AttackPower = AttackPower;
			this.Information = Information;
			DefensivePower = 0;
			Price = 200;
			I_Exist = true;
			equipped = false;
			Sign = "";
		}
	}
	public class Sword : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }
		public int Price { get; set; }
		public bool I_Exist { get; set; }
		public bool equipped { get; set; }
		public string Sign { get; set; }

		public Sword(string Name, int AttackPower, string Information)
		{
			this.Name = Name;
			this.AttackPower = AttackPower;
			this.Information = Information;
			DefensivePower = 0;
			Price = 800;
			I_Exist = false;
			equipped = false;
			Sign = "";
		}
	}

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

		public GoldSword(string Name, int AttackPower, string Information)
		{
			this.Name = Name;
			this.AttackPower = AttackPower;
			this.Information = Information;
			DefensivePower = 0;
			Price = 1300;
			I_Exist = false;
			equipped = false;
			Sign = "";
		}
	}

	public class Start
	{
		bool atk = false;
		bool def = false;
		Item AtkItem = null;
		Item DefItem = null;
		int AttackUP = 0;
		int DefensiveUP = 0;
		private Character player;
		private List<Item> items;
		private List<Item> store_Items;
		public Start(Player player, List<Item>items, List<Item>store_Items)
		{
			this.player = player;
			this.items = items;
			this.store_Items = store_Items;
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
			Console.WriteLine("3. 상점");
			Console.WriteLine();

			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");
		
			while (true) {
				string ?input = Console.ReadLine();
				switch (input)
				{
					case "1": StateOn(); break;
					case "2": InventoryOn(); break;
					case "3": Store(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}

		public void Store()
		{
			Console.Clear();
			Console.WriteLine("상점");
			Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
			Console.WriteLine();
			Console.WriteLine("[보유 골드]");
			Console.WriteLine($"{player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");

			for(int i = 0; i < store_Items.Count; i++)
			{
				if (store_Items[i].DefensivePower == 0)
				{
					if (!store_Items[i].I_Exist)
					{
						Console.WriteLine($"- {store_Items[i].Name,-6}  | 공격력 +{store_Items[i].AttackPower} | {store_Items[i].Information,-10} | {store_Items[i].Price} G");
					}
					else
					{
						Console.WriteLine($"- {store_Items[i].Name,-6}  | 공격력 +{store_Items[i].AttackPower} | {store_Items[i].Information,-10} | 소지 중");
					}

				}
				else if (store_Items[i].AttackPower == 0)
				{
					if (!store_Items[i].I_Exist)
					{
						Console.WriteLine($"- {store_Items[i].Name,-6}  | 방어력 +{store_Items[i].DefensivePower} | {store_Items[i].Information,-10} | {store_Items[i].Price} G");
					}
					else
					{
						Console.WriteLine($"- {store_Items[i].Name,-6}  | 방어력 +{store_Items[i].DefensivePower} | {store_Items[i].Information,-10} | 소지 중");
					}
				}
			}
			Console.WriteLine();
			Console.WriteLine("1. 아이템 구매");
			Console.WriteLine("2. 아이템 판매");
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "1": StorePurchase(); break;
					case "2": StoreSell(); break;
					case "0": GameStart(); break;
					default: Console.WriteLine("잘못된 입력입니다."); break;
				}
			}
		}
		public void StoreSell()
		{
			bool[] storeItem_chk = new bool[5];
			Console.Clear();
			Console.WriteLine("상점 - 아이템 판매");
			Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
			Console.WriteLine();
			Console.WriteLine("[보유 골드]");
			Console.WriteLine($"{player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");

			for (int i = 0; i < items.Count; i++)
			{
				storeItem_chk[i] = true;
				if (items[i].DefensivePower == 0)
				{
					Console.WriteLine($"- {i + 1} {items[i].Name,-6}  | 공격력 +{items[i].AttackPower} | {items[i].Information,-10} | {(items[i].Price / 100) * 85} G");
				}
				else if (items[i].AttackPower == 0)
				{
					Console.WriteLine($"- {i + 1} {items[i].Name,-6}  | 방어력 +{items[i].DefensivePower} | {items[i].Information,-10} | {(items[i].Price / 100) * 85} G");
				}
			}
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
					case "1":
						if (storeItem_chk[0])
						{
							if (items[0].I_Exist)
							{
								if (items[0].equipped)
								{
									player.AttackPower -= items[0].AttackPower;
									player.DefensivePower -= items[0].DefensivePower;
									AttackUP -= items[0].AttackPower;
									DefensiveUP -= items[0].DefensivePower;
									items[0].equipped = false;
									items[0].Sign = "";
								}
								items[0].I_Exist = false;
								player.Gold += (items[0].Price / 100) * 85;
								items.Remove(items[0]);
								StoreSell();
							}
							else
							{
								Console.WriteLine("존재하지않는 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "2":
						if (storeItem_chk[1])
						{
							if (items[1].I_Exist)
							{
								if (items[1].equipped)
								{
									player.AttackPower -= items[1].AttackPower;
									player.DefensivePower -= items[1].DefensivePower;
									AttackUP -= items[1].AttackPower;
									DefensiveUP -= items[1].DefensivePower;
									items[1].equipped = false;
									items[1].Sign = "";
								}
								items[1].I_Exist = false;
								player.Gold += (items[1].Price / 100) * 85;
								items.Remove(items[1]);
								StoreSell();
							}
							else
							{
								Console.WriteLine("존재하지않는 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "3":
						if (storeItem_chk[2])
						{
							if (items[2].I_Exist)
							{
								if (items[2].equipped)
								{
									player.AttackPower -= items[2].AttackPower;
									player.DefensivePower -= items[2].DefensivePower;
									AttackUP -= items[2].AttackPower;
									DefensiveUP -= items[2].DefensivePower;
									items[2].equipped = false;
									items[2].Sign = "";
								}
								items[2].I_Exist = false;
								player.Gold += (items[2].Price / 100) * 85;
								items.Remove(items[2]);
								StoreSell();
							}
							else
							{
								Console.WriteLine("존재하지않는 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "4":
						if (storeItem_chk[3])
						{
							if (items[3].I_Exist)
							{
								if (items[3].equipped)
								{
									player.AttackPower -= items[3].AttackPower;
									player.DefensivePower -= items[3].DefensivePower;
									AttackUP -= items[3].AttackPower;
									DefensiveUP -= items[3].DefensivePower;
									items[3].equipped = false;
									items[3].Sign = "";
								}
								items[3].I_Exist = false;
								player.Gold += (items[3].Price / 100) * 85;
								items.Remove(items[3]);
								StoreSell();
							}
							else
							{
								Console.WriteLine("존재하지않는 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "5":
						if (storeItem_chk[4])
						{
							if (items[4].I_Exist)
							{
								if (items[4].equipped)
								{
									player.AttackPower -= items[4].AttackPower;
									player.DefensivePower -= items[4].DefensivePower;
									AttackUP -= items[4].AttackPower;
									DefensiveUP -= items[4].DefensivePower;
									items[4].equipped = false;
									items[4].Sign = "";
								}
								items[4].I_Exist = false;
								player.Gold += (items[4].Price / 100) * 85;
								items.Remove(items[4]);
								StoreSell();
							}
							else
							{
								Console.WriteLine("존재하지않는 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;

					case "0": Store(); break;
					default: Console.WriteLine("잘못된 입력입니다."); break;
				}
			}
		}
		public void StorePurchase()
		{
			bool[] storeItem_chk = new bool[5];
			Console.Clear();
			Console.WriteLine("상점 - 아이템 구매");
			Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
			Console.WriteLine();
			Console.WriteLine("[보유 골드]");
			Console.WriteLine($"{player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			for (int i = 0; i < store_Items.Count; i++)
			{
				storeItem_chk[i] = true;
				if (store_Items[i].DefensivePower == 0)
				{
					if (!store_Items[i].I_Exist)
					{
						Console.WriteLine($"- {i + 1} {store_Items[i].Name,-6}  | 공격력 +{store_Items[i].AttackPower} | {store_Items[i].Information,-10} | {store_Items[i].Price} G");
					}
					else
					{
						Console.WriteLine($"- {i + 1} {store_Items[i].Name,-6}  | 공격력 +{store_Items[i].AttackPower} | {store_Items[i].Information,-10} | 소지 중");
					}

				}
				else if (store_Items[i].AttackPower == 0)
				{
					if (!store_Items[i].I_Exist)
					{
						Console.WriteLine($"- {i + 1} {store_Items[i].Name,-6}  | 방어력 +{store_Items[i].DefensivePower} | {store_Items[i].Information,-10} | {store_Items[i].Price} G");
					}
					else
					{
						Console.WriteLine($"- {i + 1} {store_Items[i].Name,-6}  | 방어력 +{store_Items[i].DefensivePower} | {store_Items[i].Information,-10} | 소지 중");
					}
				}
			}
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
					case "1":
						if (storeItem_chk[0])
						{
							if (!store_Items[0].I_Exist && player.Gold >= store_Items[0].Price)
							{
								store_Items[0].I_Exist = true;
								player.Gold -= store_Items[0].Price;
								items.Add(store_Items[0]);
								StorePurchase();							
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "2":
						if (storeItem_chk[1])
						{
							if (!store_Items[1].I_Exist && player.Gold >= store_Items[1].Price)
							{
								store_Items[1].I_Exist = true;
								player.Gold -= store_Items[1].Price;
								items.Add(store_Items[1]);
								StorePurchase();
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "3":
						if (storeItem_chk[2])
						{
							if (!store_Items[2].I_Exist && player.Gold >= store_Items[2].Price)
							{
								store_Items[2].I_Exist = true;
								player.Gold -= store_Items[2].Price;
								items.Add(store_Items[2]);
								StorePurchase();
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "4":
						if (storeItem_chk[3])
						{
							if (!store_Items[3].I_Exist && player.Gold >= store_Items[3].Price)
							{
								store_Items[3].I_Exist = true;
								player.Gold -= store_Items[3].Price;
								items.Add(store_Items[3]);
								StorePurchase();
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "5":
						if (storeItem_chk[4])
						{
							if (!store_Items[4].I_Exist && player.Gold >= store_Items[4].Price)
							{
								store_Items[4].I_Exist = true;
								player.Gold -= store_Items[4].Price;
								items.Add(store_Items[4]);
								StorePurchase();
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;

					case "0": Store(); break;
					default: Console.WriteLine("잘못된 입력입니다."); break;
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
			for(int i = 0; i < items.Count; i++)
			{
	
				if (items[i].DefensivePower == 0)
				{
					Console.WriteLine($"- {items[i].Sign}{items[i].Name, -6}  | 공격력 +{items[i].AttackPower} | {items[i].Information, -10}");
				}
				else
				{
					Console.WriteLine($"- {items[i].Sign}{items[i].Name, -6}  | 방어력 +{items[i].DefensivePower} | {items[i].Information, -10}");
				}
			}
			Console.WriteLine();
			Console.WriteLine("1. 장착 관리");
			Console.WriteLine("2. 정렬(공격력)");
			Console.WriteLine("3. 정렬(방어력)");
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
					case "2": AttackPowerInventorySort(); InventoryOn(); break;
					case "3": DefensivePowerInventorySort(); InventoryOn(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}

		public void InventoryManager()
		{
			bool[] Display = new bool[5];
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("인벤토리 - 장착 관리");
			Console.ResetColor();
			Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			for (int i = 0; i < items.Count; i++)
			{
				Display[i] = true;
				if (items[i].DefensivePower == 0)
				{
					Console.WriteLine($"- {i + 1} {items[i].Sign}{items[i].Name, -6}  | 공격력 +{items[i].AttackPower} | {items[i].Information, -10}");
				}
				else
				{
					Console.WriteLine($"- {i + 1} {items[i].Sign}{items[i].Name, -6}  | 방어력 +{items[i].DefensivePower} | {items[i].Information, -10}");
				}
			}
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
							if (Display[0])
							{
								if (!items[0].equipped && items[0].AttackPower > 0 && !atk && AtkItem != null)
								{
									atk = true;
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									items[0].Sign = "[E]";
									items[0].equipped = true;
									AttackUP += items[0].AttackPower;
									player.AttackPower += items[0].AttackPower;
									AtkItem = items[0];
									InventoryManager();
								}
								else if (!items[0].equipped && items[0].AttackPower > 0 && !atk && AtkItem == null)
								{
									atk = true;
									items[0].Sign = "[E]";
									items[0].equipped = true;
									AttackUP += items[0].AttackPower;
									player.AttackPower += items[0].AttackPower;
									AtkItem = items[0];
									InventoryManager();
								}
								else if (!items[0].equipped && items[0].DefensivePower > 0 && !def && DefItem != null)
								{
									def = true;
									DefItem.Sign = "";
									DefItem.equipped = false;
									items[0].Sign = "[E]";
									items[0].equipped = true;
									DefensiveUP += items[0].DefensivePower;
									player.DefensivePower += items[0].DefensivePower;
									DefItem = items[0];
									InventoryManager();
								}

								else if (!items[0].equipped && items[0].DefensivePower > 0 && !def && DefItem == null)
								{
									def = true;
									items[0].Sign = "[E]";
									items[0].equipped = true;
									DefensiveUP += items[0].DefensivePower;
									player.DefensivePower += items[0].DefensivePower;
									DefItem = items[0];
									InventoryManager();
								}
								else if (atk && AtkItem != null && AtkItem != items[0] && items[0].AttackPower > 0)
								{									
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									items[0].Sign = "[E]";
									items[0].equipped = true;
									player.AttackPower -= AtkItem.AttackPower;
									AttackUP -= AtkItem.AttackPower;
									player.AttackPower += items[0].AttackPower;
									AttackUP += items[0].AttackPower;
									AtkItem = items[0];
									InventoryManager();
								}
								else if (def && DefItem != null && DefItem != items[0] && items[0].DefensivePower > 0)
								{								
									DefItem.Sign = "";
									DefItem.equipped = false;
									items[0].Sign = "[E]";
									items[0].equipped = true;
									player.DefensivePower -= DefItem.DefensivePower;
									DefensiveUP -= DefItem.DefensivePower;
									player.DefensivePower += items[0].DefensivePower;
									DefensiveUP += items[0].DefensivePower;
									DefItem = items[0];
									InventoryManager();
								}
								else
								{
									DefItem = null;
									def = false;
									AtkItem = null;
									atk = false;
									items[0].Sign = "";
									items[0].equipped = false;
									DefensiveUP -= items[0].DefensivePower;
									AttackUP += items[0].AttackPower;
									player.DefensivePower -= items[0].DefensivePower;
									player.AttackPower -= items[0].AttackPower;
									InventoryManager();
								}
							}
							else
							{
								Console.WriteLine("잘못된 입력입니다");
							}
							break;
						}
					case "2":
						{
							if (Display[1])
							{
								if (!items[1].equipped && items[1].AttackPower > 0 && !atk && AtkItem != null)
								{
									atk = true;
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									items[1].Sign = "[E]";
									items[1].equipped = true;
									AttackUP += items[1].AttackPower;
									player.AttackPower += items[1].AttackPower;
									AtkItem = items[1];
									InventoryManager();
								}
								else if (!items[1].equipped && items[1].AttackPower > 0 && !atk && AtkItem == null)
								{
									atk = true;
									items[1].Sign = "[E]";
									items[1].equipped = true;
									AttackUP += items[1].AttackPower;
									player.AttackPower += items[1].AttackPower;
									AtkItem = items[1];
									InventoryManager();
								}
								else if (!items[1].equipped && items[1].DefensivePower > 0 && !def && DefItem != null)
								{
									def = true;
									DefItem.Sign = "";
									DefItem.equipped = false;
									items[1].Sign = "[E]";
									items[1].equipped = true;
									DefensiveUP += items[1].DefensivePower;
									player.DefensivePower += items[1].DefensivePower;
									DefItem = items[1];
									InventoryManager();
								}

								else if (!items[1].equipped && items[1].DefensivePower > 0 && !def && DefItem == null)
								{
									def = true;
									items[1].Sign = "[E]";
									items[1].equipped = true;
									DefensiveUP += items[1].DefensivePower;
									player.DefensivePower += items[1].DefensivePower;
									DefItem = items[1];
									InventoryManager();
								}
								else if (atk && AtkItem != null && AtkItem != items[1] && items[1].AttackPower > 0)
								{
									
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									items[1].Sign = "[E]";
									items[1].equipped = true;
									player.AttackPower -= AtkItem.AttackPower;
									AttackUP -= AtkItem.AttackPower;
									player.AttackPower += items[1].AttackPower;
									AttackUP += items[1].AttackPower;
									AtkItem = items[1];
									InventoryManager();
								}
								else if (def && DefItem != null && DefItem != items[1] && items[1].DefensivePower > 0)
								{
									
									DefItem.Sign = "";
									DefItem.equipped = false;
									items[1].Sign = "[E]";
									items[1].equipped = true;
									player.DefensivePower -= DefItem.DefensivePower;
									DefensiveUP -= DefItem.DefensivePower;
									player.DefensivePower += items[1].DefensivePower;
									DefensiveUP += items[1].DefensivePower;
									DefItem = items[1];
									InventoryManager();
								}
								else
								{
									DefItem = null;
									def = false;
									AtkItem = null;
									atk = false;
									items[1].Sign = "";
									items[1].equipped = false;
									DefensiveUP -= items[1].DefensivePower;
									AttackUP -= items[1].AttackPower;
									player.DefensivePower -= items[1].DefensivePower;
									player.AttackPower -= items[1].AttackPower;
									InventoryManager();
								}
							}
							else
							{
								Console.WriteLine("잘못된 입력입니다.");
							}
							break;
						}
					case "3":
						{
							if (Display[2])
							{
								if (!items[2].equipped && items[2].AttackPower > 0 && !atk && AtkItem != null)
								{
									atk = true;
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									items[2].Sign = "[E]";
									items[2].equipped = true;
									AttackUP += items[2].AttackPower;
									player.AttackPower += items[2].AttackPower;
									AtkItem = items[2];
									InventoryManager();
								}
								else if (!items[2].equipped && items[2].AttackPower > 0 && !atk && AtkItem == null)
								{
									atk = true;
									items[2].Sign = "[E]";
									items[2].equipped = true;
									AttackUP += items[2].AttackPower;
									player.AttackPower += items[2].AttackPower;
									AtkItem = items[2];
									InventoryManager();
								}
								else if (!items[2].equipped && items[2].DefensivePower > 0 && !def && DefItem != null)
								{
									def = true;
									DefItem.Sign = "";
									DefItem.equipped = false;
									items[2].Sign = "[E]";
									items[2].equipped = true;
									DefensiveUP += items[2].DefensivePower;
									player.DefensivePower += items[2].DefensivePower;
									DefItem = items[2];
									InventoryManager();
								}

								else if (!items[2].equipped && items[2].DefensivePower > 0 && !def && DefItem == null)
								{
									def = true;
									items[2].Sign = "[E]";
									items[2].equipped = true;
									DefensiveUP += items[2].DefensivePower;
									player.DefensivePower += items[2].DefensivePower;
									DefItem = items[2];
									InventoryManager();
								}
								else if (atk && AtkItem != null && AtkItem != items[2] && items[2].AttackPower > 0)
								{
									
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									items[2].Sign = "[E]";
									items[2].equipped = true;
									player.AttackPower -= AtkItem.AttackPower;
									AttackUP -= AtkItem.AttackPower;
									player.AttackPower += items[2].AttackPower;
									AttackUP += items[2].AttackPower;
									AtkItem = items[2];
									InventoryManager();
								}
								else if (def && DefItem != null && DefItem != items[2] && items[2].DefensivePower > 0)
								{
							
									DefItem.Sign = "";
									DefItem.equipped = false;
									items[2].Sign = "[E]";
									items[2].equipped = true;
									player.DefensivePower -= DefItem.DefensivePower;
									DefensiveUP -= DefItem.DefensivePower;
									player.DefensivePower += items[2].DefensivePower;
									DefensiveUP += items[2].DefensivePower;
									DefItem = items[2];
									InventoryManager();
								}
								else
								{
									DefItem = null;
									def = false;
									AtkItem = null;
									atk = false;
									items[2].Sign = "";
									items[2].equipped = false;
									DefensiveUP -= items[2].DefensivePower;
									AttackUP -= items[2].AttackPower;
									player.DefensivePower -= items[2].DefensivePower;
									player.AttackPower -= items[2].AttackPower;
									InventoryManager();
								}
							}
							else
							{
								Console.WriteLine("잘못된 입력입니다.");
							}
							break;
						}
					case "4":
						{
							if (Display[3])
							{
								if (!items[3].equipped && items[3].AttackPower > 0 && !atk && AtkItem != null)
								{
									atk = true;
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									items[3].Sign = "[E]";
									items[3].equipped = true;
									AttackUP += items[3].AttackPower;
									player.AttackPower += items[3].AttackPower;
									AtkItem = items[3];
									InventoryManager();
								}
								else if (!items[3].equipped && items[3].AttackPower > 0 && !atk && AtkItem == null)
								{
									atk = true;
									items[3].Sign = "[E]";
									items[3].equipped = true;
									AttackUP += items[3].AttackPower;
									player.AttackPower += items[3].AttackPower;
									AtkItem = items[3];
									InventoryManager();
								}
								else if (!items[3].equipped && items[3].DefensivePower > 0 && !def && DefItem != null)
								{
									def = true;
									DefItem.Sign = "";
									DefItem.equipped = false;
									items[3].Sign = "[E]";
									items[3].equipped = true;
									DefensiveUP += items[3].DefensivePower;
									player.DefensivePower += items[3].DefensivePower;
									DefItem = items[3];
									InventoryManager();
								}

								else if (!items[3].equipped && items[3].DefensivePower > 0 && !def && DefItem == null)
								{
									def = true;
									items[3].Sign = "[E]";
									items[3].equipped = true;
									DefensiveUP += items[3].DefensivePower;
									player.DefensivePower += items[3].DefensivePower;
									DefItem = items[3];
									InventoryManager();
								}
								else if (atk && AtkItem != null && AtkItem != items[3] && items[3].AttackPower > 0)
								{

									AtkItem.Sign = "";
									AtkItem.equipped = false;
									items[3].Sign = "[E]";
									items[3].equipped = true;
									player.AttackPower -= AtkItem.AttackPower;
									AttackUP -= AtkItem.AttackPower;
									player.AttackPower += items[3].AttackPower;
									AttackUP += items[3].AttackPower;
									AtkItem = items[3];
									InventoryManager();
								}
								else if (def && DefItem != null && DefItem != items[3] && items[3].DefensivePower > 0)
								{

									DefItem.Sign = "";
									DefItem.equipped = false;
									items[3].Sign = "[E]";
									items[3].equipped = true;
									player.DefensivePower -= DefItem.DefensivePower;
									DefensiveUP -= DefItem.DefensivePower;
									player.DefensivePower += items[3].DefensivePower;
									DefensiveUP += items[3].DefensivePower;
									DefItem = items[3];
									InventoryManager();
								}
								else
								{
									DefItem = null;
									def = false;
									AtkItem = null;
									atk = false;
									items[3].Sign = "";
									items[3].equipped = false;
									DefensiveUP -= items[3].DefensivePower;
									AttackUP -= items[3].AttackPower;
									player.DefensivePower -= items[3].DefensivePower;
									player.AttackPower -= items[3].AttackPower;
									InventoryManager();
								}
							}
							else
							{
								Console.WriteLine("잘못된 입력입니다.");
							}
							break;
						}
					case "5":
						{
							if (Display[4])
							{
								if (!items[4].equipped && items[4].AttackPower > 0 && !atk && AtkItem != null)
								{
									atk = true;
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									items[4].Sign = "[E]";
									items[4].equipped = true;
									AttackUP += items[4].AttackPower;
									player.AttackPower += items[4].AttackPower;
									AtkItem = items[4];
									InventoryManager();
								}
								else if (!items[4].equipped && items[4].AttackPower > 0 && !atk && AtkItem == null)
								{
									atk = true;
									items[4].Sign = "[E]";
									items[4].equipped = true;
									AttackUP += items[4].AttackPower;
									player.AttackPower += items[4].AttackPower;
									AtkItem = items[4];
									InventoryManager();
								}
								else if (!items[4].equipped && items[4].DefensivePower > 0 && !def && DefItem != null)
								{
									def = true;
									DefItem.Sign = "";
									DefItem.equipped = false;
									items[4].Sign = "[E]";
									items[4].equipped = true;
									DefensiveUP += items[4].DefensivePower;
									player.DefensivePower += items[4].DefensivePower;
									DefItem = items[4];
									InventoryManager();
								}

								else if (!items[4].equipped && items[4].DefensivePower > 0 && !def && DefItem == null)
								{
									def = true;
									items[4].Sign = "[E]";
									items[4].equipped = true;
									DefensiveUP += items[4].DefensivePower;
									player.DefensivePower += items[4].DefensivePower;
									DefItem = items[4];
									InventoryManager();
								}
								else if (atk && AtkItem != null && AtkItem != items[4] && items[4].AttackPower > 0)
								{

									AtkItem.Sign = "";
									AtkItem.equipped = false;
									items[4].Sign = "[E]";
									items[4].equipped = true;
									player.AttackPower -= AtkItem.AttackPower;
									AttackUP -= AtkItem.AttackPower;
									player.AttackPower += items[4].AttackPower;
									AttackUP += items[4].AttackPower;
									AtkItem = items[4];
									InventoryManager();
								}
								else if (def && DefItem != null && DefItem != items[4] && items[4].DefensivePower > 0)
								{

									DefItem.Sign = "";
									DefItem.equipped = false;
									items[4].Sign = "[E]";
									items[4].equipped = true;
									player.DefensivePower -= DefItem.DefensivePower;
									DefensiveUP -= DefItem.DefensivePower;
									player.DefensivePower += items[4].DefensivePower;
									DefensiveUP += items[4].DefensivePower;
									DefItem = items[4];
									InventoryManager();
								}
								else
								{
									DefItem = null;
									def = false;
									AtkItem = null;
									atk = false;
									items[4].Sign = "";
									items[4].equipped = false;
									DefensiveUP -= items[4].DefensivePower;
									AttackUP -= items[4].AttackPower;
									player.DefensivePower -= items[4].DefensivePower;
									player.AttackPower -= items[4].AttackPower;
									InventoryManager();
								}
							}
							else
							{
								Console.WriteLine("잘못된 입력입니다.");
							}
							break;
						}
					case "0": InventoryOn(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}

		public void AttackPowerInventorySort()
		{
			items.Sort((x, y) =>
			{
				return y.AttackPower.CompareTo(x.AttackPower);
			});
		}

		public void DefensivePowerInventorySort()
		{
			items.Sort((x, y) =>
			{
				return y.DefensivePower.CompareTo(x.DefensivePower);
			});
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
			if (AttackUP > 0)
			{
				Console.WriteLine($"공격력 : {player.AttackPower} (+{AttackUP})");
			}
			else
			{
				Console.WriteLine($"공격력 : {player.AttackPower}");
			}
			if (DefensiveUP > 0)
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
			List<Item> store_Items = new List<Item> 
			{ new GoldSword("황금검", 8, "금으로 만들어진 검입니다."),
			  new IronArmor("무쇠갑옷", 5, "무쇠로 만들어져 튼튼한 갑옷입니다."),
			  new OldSword("낡은 검", 2, "쉽게 볼 수 있는 낡은 검입니다."),
			  new Sword("검", 4, "튼튼한 검입니다."),
			  new IronRing("철반지", 3, "은으로 만들어진 반지입니다.")
			};

			List<Item> items = new List<Item>()
			{ }; 
			
			items.Add(store_Items[1]);
			items.Add(store_Items[2]);

			Player player = new State("Sungho" , "전사");
			Start start = new Start(player, items, store_Items);

			start.GameStart();			
		}
	}
}