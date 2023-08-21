using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta
{
    public class SpartaGame
    {
        private static SpartaGame _instance = null;
        public static SpartaGame Instance()
        {
            if (_instance == null)
            {
                _instance = new SpartaGame();
            }
            return _instance;
        }

        string input;

        public void DisplayStartGame()
        {
            SetTitle(MsgDefine.MAIN);
            Console.Write(MsgDefine.OPENING_PHARASE);

            SetAction("1. " + MsgDefine.SHOW_STATE + "2. " + MsgDefine.INVENTORY);
            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;
                case 2:
                    DisplayInventory();
                    break;
            }
        }

        public void DisplayMyInfo()
        {
            SetTitle(MsgDefine.SHOW_STATE);
            Console.Write(MsgDefine.EXPLAN_STATE);
            Console.WriteLine(MsgDefine.LEVEL);
            Console.WriteLine(MsgDefine.JOB + MsgDefine.COLON);
            Console.WriteLine(MsgDefine.OFFENSIVE_POWER + MsgDefine.COLON);
            Console.WriteLine(MsgDefine.DEFENSIVE_POWER + MsgDefine.COLON);
            Console.WriteLine(MsgDefine.HP + MsgDefine.COLON);
            Console.WriteLine(MsgDefine.GOLD + MsgDefine.COLON + "G");
            Console.WriteLine();

            SetAction("0. " + MsgDefine.OUT);
            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayStartGame();
                    break;
            }
        }

        public void DisplayInventory()
        {
            SetTitle($"{MsgDefine.INVENTORY}\n");
            Console.Write(MsgDefine.EXPLAN_INVENTORY);
            Console.WriteLine();

            SetAction("1. " + MsgDefine.MANAGE_EQUIP + "0. " + MsgDefine.OUT);           
            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayStartGame();
                    break;
                case 1:
                    DisplayManageEquipment();
                    break;
            }
        }

        public void DisplayManageEquipment()
        {
            SetTitle($"{MsgDefine.INVENTORY}-{MsgDefine.MANAGE_EQUIP}");
            Console.Write(MsgDefine.EXPLAN_EQUIP);

            SetAction("0. " + MsgDefine.OUT);
            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayInventory();
                    break;
            }
        }

        public void SetTitle(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(title);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SetAction(string actions)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(actions);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(MsgDefine.INPUT_ACTION);
        }

        public void WriteWrongInput()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(MsgDefine.WRONG_INPUT);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write(MsgDefine.INPUT_ACTION);
        }

        int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                WriteWrongInput();
            }
        }
    }
}
