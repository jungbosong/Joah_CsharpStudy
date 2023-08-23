namespace ConsoleAppHyeongyo_RPG
{
    internal class Program
    {
        // 플레이어 객체 생성
        public static Player player;

        // 아이템 객체 생성
        public static Items.Weapon weapon01;
        public static Items.Armor armor01;

        // 아이템 리스트 생성
        public static List<Items.Item> items= new List<Items.Item>();
        
        // 캐릭터, 아이템 정보 세팅
        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Player("Player", "전사", 1, 10, 5, 20, 150);

            // 아이템 정보 세팅
            weapon01 = new Items.Weapon("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2);
            items.Add(weapon01);
            armor01 = new Items.Armor("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 5);
            items.Add(armor01);
        }

        // 선택지 객체 생성
        public static Option option  = new Option();

        static void Main(string[] args)
        {
            // 세팅 시작
            GameDataSetting();
            // 시작 선택지 실행
            option.option(Option.Action.Start);
        }
    }
}