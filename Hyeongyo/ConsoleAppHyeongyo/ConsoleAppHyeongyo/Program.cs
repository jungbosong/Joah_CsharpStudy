namespace MyApp
{
    internal class Program
    {
        //플레이어 객체
        class player
        {
            public int Length { get; set; }
            public bool IsEnd { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public string Dir { get; set; }
        }


        static void Main(string[] args)
        {
            // 맵 배열 생성
            int[,] Map = new int[20, 20];
            
            // 키 입력 변수 생성
            ConsoleKeyInfo keyInfo;

            // 플레이어 객체 생성, 초기화
            player player = new player();
            player.Length = 1;
            player.IsEnd = true;
            player.X = 10;
            player.Y = 10;
            player.Dir = "Right";

            // 플레이어 컬렉션 생성
            List<int[,]> list = new List<int[,]>();
            list.Add([]);
            

            // 게임오버 전까지 반복
            while (player.IsEnd)
            {
                // 콘솔 클리어
                Console.Clear();

                //맵과 캐릭터 출력
                Console.WriteLine($"스네이크 게임\t\t\t길이 : {player.Length} 플레이어 좌표{player.X}/{player.Y}/{player.Dir}");
                
                for (int i = 0; i < Map.GetLength(0); i++)
                {
                    for (int j = 0; j < Map.GetLength(1); j++)
                    {
                        // 테두리 출력
                        if (i == 0 || j == 0 || i == (Map.GetLength(0) - 1) || j == (Map.GetLength(1) - 1))
                        {
                            Console.Write("■ ");
                        }
                        // 플레이어 출력
                        else if (i == player.Y && j == player.X)
                        {
                            for (int k = 0; k < player.Length; k++)
                            {
                                Console.Write("■ ");
                            }
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                    Console.WriteLine();
                }

                // 키보드 입력 확인 후 플레이어 방향 변경
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            player.Dir = "Right";
                            break;
                        case ConsoleKey.LeftArrow:
                            player.Dir = "Left";
                            break;
                        case ConsoleKey.UpArrow:
                            player.Dir = "Up";
                            break;
                        case ConsoleKey.DownArrow:
                            player.Dir = "Down";
                            break;
                    }
                }

                // 플레이어 방향 확인 후 위치 변경
                switch (player.Dir)
                {
                    case "Right":
                        player.X++;
                        break;
                    case "Left":
                        player.X--;
                        break;
                    case "Up":
                        player.Y--;
                        break;
                    case "Down":
                        player.Y++;
                        break;
                }

                // 지연시간(ms) / 게임 진행 속도
                Thread.Sleep(300);
            }
        }
    }
}