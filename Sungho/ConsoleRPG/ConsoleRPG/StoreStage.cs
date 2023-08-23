using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public class StoreStage
	{
		bool purchase; // 구매 판별
		Start s4 = Start.Instance();
		public void Store()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("상점");
			Console.ResetColor();
			Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
			Console.WriteLine();
			Console.WriteLine("[보유 골드]");
			Console.WriteLine($"{s4.player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");

			for (int i = 0; i < s4.store_Items.Count; i++)
			{
				if (s4.store_Items[i].DefensivePower == 0)
				{
					if (!s4.store_Items[i].I_Exist)
					{
						Console.WriteLine($"- {s4.store_Items[i].Name,-6}  | 공격력 +{s4.store_Items[i].OriginAttackPower} | {s4.store_Items[i].Information,-10} | {s4.store_Items[i].Price} G");
					}
					else
					{
						Console.WriteLine($"- {s4.store_Items[i].Name,-6}  | 공격력 +{s4.store_Items[i].OriginAttackPower} | {s4.store_Items[i].Information,-10} | 소지 중");
					}

				}
				else if (s4.store_Items[i].AttackPower == 0)
				{
					if (!s4.store_Items[i].I_Exist)
					{
						Console.WriteLine($"- {s4.store_Items[i].Name,-6}  | 방어력 +{s4.store_Items[i].OriginDefensivePower} | {s4.store_Items[i].Information,-10} | {s4.store_Items[i].Price} G");
					}
					else
					{
						Console.WriteLine($"- {s4.store_Items[i].Name,-6}  | 방어력 +{s4.store_Items[i].OriginDefensivePower} | {s4.store_Items[i].Information,-10} | 소지 중");
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
					case "0": s4.GameStart(); break;
					default: Console.WriteLine("잘못된 입력입니다."); break;
				}
			}
		}
		public void StoreSell()
		{
			bool[] storeItem_chk = new bool[5];
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("상점 - 아이템 판매");
			Console.ResetColor();
			Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
			Console.WriteLine();
			Console.WriteLine("[보유 골드]");
			Console.WriteLine($"{s4.player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");

			for (int i = 0; i < s4.items.Count; i++)
			{
				storeItem_chk[i] = true;
				if (s4.items[i].DefensivePower == 0)
				{
					Console.WriteLine($"- {i + 1} {s4.items[i].Name,-6}  | 공격력 +{s4.items[i].AttackPower} | {s4.items[i].Information,-10} | {(s4.items[i].Price / 100) * 85} G");
				}
				else if (s4.items[i].AttackPower == 0)
				{
					Console.WriteLine($"- {i + 1} {s4.items[i].Name,-6}  | 방어력 +{s4.items[i].DefensivePower} | {s4.items[i].Information,-10} | {(s4.items[i].Price / 100) * 85} G");
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
							if (s4.items[0].I_Exist)
							{
								if (s4.items[0].equipped)
								{
									s4.player.AttackPower -= s4.items[0].AttackPower;
									s4.player.DefensivePower -= s4.items[0].DefensivePower;
									s4.AttackUP -= s4.items[0].AttackPower;
									s4.DefensiveUP -= s4.items[0].DefensivePower;
									s4.items[0].equipped = false;
									s4.items[0].Sign = "";
								}
								s4.items[0].I_Exist = false;
								s4.player.Gold += (s4.items[0].Price / 100) * 85;
								s4.items.Remove(s4.items[0]);
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
							if (s4.items[1].I_Exist)
							{
								if (s4.items[1].equipped)
								{
									s4.player.AttackPower -= s4.items[1].AttackPower;
									s4.player.DefensivePower -= s4.items[1].DefensivePower;
									s4.AttackUP -= s4.items[1].AttackPower;
									s4.DefensiveUP -= s4.items[1].DefensivePower;
									s4.items[1].equipped = false;
									s4.items[1].Sign = "";
								}
								s4.items[1].I_Exist = false;
								s4.player.Gold += (s4.items[1].Price / 100) * 85;
								s4.items.Remove(s4.items[1]);
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
							if (s4.items[2].I_Exist)
							{
								if (s4.items[2].equipped)
								{
									s4.player.AttackPower -= s4.items[2].AttackPower;
									s4.player.DefensivePower -= s4.items[2].DefensivePower;
									s4.AttackUP -= s4.items[2].AttackPower;
									s4.DefensiveUP -= s4.items[2].DefensivePower;
									s4.items[2].equipped = false;
									s4.items[2].Sign = "";
								}
								s4.items[2].I_Exist = false;
								s4.player.Gold += (s4.items[2].Price / 100) * 85;
								s4.items.Remove(s4.items[2]);
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
							if (s4.items[3].I_Exist)
							{
								if (s4.items[3].equipped)
								{
									s4.player.AttackPower -= s4.items[3].AttackPower;
									s4.player.DefensivePower -= s4.items[3].DefensivePower;
									s4.AttackUP -= s4.items[3].AttackPower;
									s4.DefensiveUP -= s4.items[3].DefensivePower;
									s4.items[3].equipped = false;
									s4.items[3].Sign = "";
								}
								s4.items[3].I_Exist = false;
								s4.player.Gold += (s4.items[3].Price / 100) * 85;
								s4.items.Remove(s4.items[3]);
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
							if (s4.items[4].I_Exist)
							{
								if (s4.items[4].equipped)
								{
									s4.player.AttackPower -= s4.items[4].AttackPower;
									s4.player.DefensivePower -= s4.items[4].DefensivePower;
									s4.AttackUP -= s4.items[4].AttackPower;
									s4.DefensiveUP -= s4.items[4].DefensivePower;
									s4.items[4].equipped = false;
									s4.items[4].Sign = "";
								}
								s4.items[4].I_Exist = false;
								s4.player.Gold += (s4.items[4].Price / 100) * 85;
								s4.items.Remove(s4.items[4]);
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
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("상점 - 아이템 구매");
			Console.ResetColor();
			Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
			Console.WriteLine();
			Console.WriteLine("[보유 골드]");
			Console.WriteLine($"{s4.player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			for (int i = 0; i < s4.store_Items.Count; i++)
			{
				storeItem_chk[i] = true;
				if (s4.store_Items[i].DefensivePower == 0)
				{
					if (!s4.store_Items[i].I_Exist)
					{
						Console.WriteLine($"- {i + 1} {s4.store_Items[i].Name,-6}  | 공격력 +{s4.store_Items[i].OriginAttackPower} | {s4.store_Items[i].Information,-10} | {s4.store_Items[i].Price} G");
					}
					else
					{
						Console.WriteLine($"- {i + 1} {s4.store_Items[i].Name,-6}  | 공격력 +{s4.store_Items[i].OriginAttackPower} | {s4.store_Items[i].Information,-10} | 소지 중");
					}

				}
				else if (s4.store_Items[i].AttackPower == 0)
				{
					if (!s4.store_Items[i].I_Exist)
					{
						Console.WriteLine($"- {i + 1} {s4.store_Items[i].Name,-6}  | 방어력 +{s4.store_Items[i].OriginDefensivePower} | {s4.store_Items[i].Information,-10} | {s4.store_Items[i].Price} G");
					}
					else
					{
						Console.WriteLine($"- {i + 1} {s4.store_Items[i].Name,-6}  | 방어력 +{s4.store_Items[i].OriginDefensivePower} | {s4.store_Items[i].Information,-10} | 소지 중");
					}
				}
			}
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			if (purchase) Console.WriteLine("구매를 완료했습니다."); Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");
			purchase = false;
			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "1":
						if (storeItem_chk[0])
						{
							if (!s4.store_Items[0].I_Exist && s4.player.Gold >= s4.store_Items[0].Price)
							{
								s4.store_Items[0].I_Exist = true;
								s4.player.Gold -= s4.store_Items[0].Price;
								s4.items.Add(s4.store_Items[0]);
								purchase = true;
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
							if (!s4.store_Items[1].I_Exist && s4.player.Gold >= s4.store_Items[1].Price)
							{
								s4.store_Items[1].I_Exist = true;
								s4.player.Gold -= s4.store_Items[1].Price;
								s4.items.Add(s4.store_Items[1]);
								purchase = true;
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
							if (!s4.store_Items[2].I_Exist && s4.player.Gold >= s4.store_Items[2].Price)
							{
								s4.store_Items[2].I_Exist = true;
								s4.player.Gold -= s4.store_Items[2].Price;
								s4.items.Add(s4.store_Items[2]);
								purchase = true;
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
							if (!s4.store_Items[3].I_Exist && s4.player.Gold >= s4.store_Items[3].Price)
							{
								s4.store_Items[3].I_Exist = true;
								s4.player.Gold -= s4.store_Items[3].Price;
								s4.items.Add(s4.store_Items[3]);
								purchase = true;
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
							if (!s4.store_Items[4].I_Exist && s4.player.Gold >= s4.store_Items[4].Price)
							{
								s4.store_Items[4].I_Exist = true;
								s4.player.Gold -= s4.store_Items[4].Price;
								s4.items.Add(s4.store_Items[4]);
								purchase = true;
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
	}
}
