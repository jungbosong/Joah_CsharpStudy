namespace ConsoleAppHyeongyo_RPG
{
    internal class Program
    {
        // 플레이어 객체 생성
        public static Player player;
        
        // 캐릭터, 아이템 정보 세팅
        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Player("Player", "전사", 1, 10, 5, 20, 150);

            // 아이템 정보 세팅
        }

        // 안내 객체
        private static Notice notice = new Notice();
        static void Main(string[] args)
        {
            GameDataSetting();

            notice.option("start");
        }
    }
}