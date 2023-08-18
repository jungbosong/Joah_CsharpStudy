namespace MyApp
{
    internal class Program
    {
        //플레이어 객체, 초기화값 설정
        class player
        {
            public int Length { get; set; } = 0;
            public bool IsEnd { get; set; } = true;
            public int X { get; set; } = 10;
            public int Y { get; set; } = 10;
            public string Dir { get; set; } = "Right";
        }

        // 먹이 개체, 랜덤 위치 메서드
        class food
        {
            Random random = new Random();
            public bool IsExist { get; set; } = false;
            public int[] RandomLoc() {
                int X = random.Next(1, 18);
                int Y = random.Next(1, 18);
                int[] foodLoc = new int[2] { X, Y };
                return foodLoc;
            }
        }


        static void Main(string[] args)
        {
            // 맵 배열 생성
            int[,] Map = new int[20, 20];
            
            // 키 입력 변수 생성
            ConsoleKeyInfo keyInfo;

            // 플레이어 객체 생성
            player player = new player();

            // 먹이 클래스
            food food = new food();

            // 먹이 객체 생성
            int[] foodLoc = new int[2];

            // 플레이어 컬렉션 생성
            List<int[]> locList = new List<int[]>();
            locList.Add([player.X, player.Y]);

            // 게임오버 전까지 반복
            while (player.IsEnd)
            {
                // 콘솔 클리어
                Console.Clear();

                // 키보드 입력 확인 후 플레이어 방향 변경 / 180도 방향 전환 막음
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            if (player.Dir == "Left")
                            {
                                break;
                            }
                            player.Dir = "Right";
                            break;
                        case ConsoleKey.LeftArrow:
                            if (player.Dir == "Right")
                            {
                                break;
                            }
                            player.Dir = "Left";
                            break;
                        case ConsoleKey.UpArrow:
                            if (player.Dir == "Down")
                            {
                                break;
                            }
                            player.Dir = "Up";
                            break;
                        case ConsoleKey.DownArrow:
                            if (player.Dir == "Up")
                            {
                                break;
                            }
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

                // 먹이가 없다면 먹이 좌표 생성
                if (!food.IsExist)
                {
                    food.IsExist = true;
                    foodLoc = food.RandomLoc();
                }

                // 플레이어가 먹이를 먹었을때 플레이어 길이, 컬렉션 추가 및 정리, 먹이 소멸
                if (player.X == foodLoc[0] && player.Y == foodLoc[1])
                {
                    player.Length++;
                    locList.Add(foodLoc);
                    for (int i = player.Length; i > 0; i--)
                    {
                        locList[i] = locList[i - 1];
                    }
                    food.IsExist = false;
                }

                // 플레이어 위치 따른 플레이어 컬렉션 조정
                locList.RemoveAt(0);
                locList.Add([player.X, player.Y]);

                // 게임오버
                // 벽에 부딪히는경우
                if (player.X < 1 || player.Y < 1 || player.X > 18 || player.Y > 18)
                {
                    player.IsEnd = false;
                }

                // 자기 몸체에 부딪히는 경우
                for (int i = (locList.Count - 2); i >= 0; i--)
                {
                    if (player.X == locList[i][0] && player.Y == locList[i][1])
                    {
                        player.IsEnd = false;
                        break;
                    }
                }

                //맵과 캐릭터 출력
                Console.WriteLine($"스네이크 게임\t\t\t길이 : {player.Length + 1}");

                for (int i = 0; i < Map.GetLength(0); i++)
                {
                    for (int j = 0; j < Map.GetLength(1); j++)
                    {
                        // 테두리 출력
                        if (i == 0 || j == 0 || i == (Map.GetLength(0) - 1) || j == (Map.GetLength(1) - 1))
                        {
                            Console.Write("■ ");
                        }
                        // 먹이 출력
                        else if (i == foodLoc[1] && j == foodLoc[0])
                        {
                            Console.Write("□ ");
                        }
                        // 아무 조건이 없으면 공백 출력
                        else
                        {
                            Console.Write("  ");
                        }

                        // 플레이어 컬렉션 출력
                        for (int k = 0; k < locList.Count; k++)
                        {
                            if (j == locList[k][0] && i == locList[k][1])
                            {
                                Console.Write("\b\b■ ");
                            }
                        }
                    }
                    Console.WriteLine();
                }

                // 게임오버 텍스트 출력
                if (!player.IsEnd)
                {
                    Console.WriteLine("게임오버 입니다.");
                }

                // 지연시간(ms) / 게임 진행 속도
                Thread.Sleep(100);
            }
        }
    }
}