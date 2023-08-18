namespace Snake
{
    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    internal class Program
    {
        const int HEIGHT = 10;
        const int WIDTH = 10;
        static void Main(string[] args)
        {
            int gameSpeed = 100;

            DrawWalls();

            Point snakePosition = new Point(4, 5, '*');
            Snake snake = new Snake(snakePosition, 2, Direction.RIGHT);
            snake.Draw();

            Random random = new Random();
            FoodCreator foodCreator = new FoodCreator(random.Next(2, WIDTH), random.Next(2, HEIGHT), '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            ConsoleKeyInfo input;

            while (true)
            {
                Console.SetCursorPosition(0, HEIGHT + 3);
                Console.WriteLine("\n방향키를 눌러 뱀을 이동시키고 음식을 먹어 뱀의 몸을 늘리세요.\n뱀: *\t음식: $\n");
                if(Console.KeyAvailable)
                {
                    input = Console.ReadKey(true);
                    switch (input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            snake.SetDirection(Direction.LEFT);
                            break;
                        case ConsoleKey.RightArrow:
                            snake.SetDirection(Direction.RIGHT);
                            break;
                        case ConsoleKey.UpArrow:
                            snake.SetDirection(Direction.UP);
                            break;
                        case ConsoleKey.DownArrow:
                            snake.SetDirection(Direction.DOWN);
                            break;
                        default:
                            break;
                    }
                    if (snake.Eat(food))
                    {
                        snake.eatCount++;
                        food.Draw();
                        food = foodCreator.CreateFood();
                        food.Draw();
                        if (gameSpeed > 10)
                        {
                            gameSpeed -= 10;
                        }
                    }
                    snake.Move();

                    if (snake.IsHitTail() || snake.IsHitWall())
                    {
                        break;
                    }
                }
                Thread.Sleep(gameSpeed);
                Console.SetCursorPosition(0, HEIGHT + 7);
                Console.WriteLine($"\n현재 길이: {snake.GetLength()}\n먹은 음식의 수: {snake.eatCount}");
            }
            WriteGameOver();
        }

        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 22;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("         GAME OVER", xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

        static void DrawWalls()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, WIDTH);
                Console.Write("#");
            }

            // 좌우 벽 그리기
            for (int i = 0; i < WIDTH; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");
                Console.SetCursorPosition(HEIGHT, i);
                Console.Write("#");
            }
        }
    }   
}