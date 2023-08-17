namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point snakePosition = new Point(4, 5, '*');
            Snake snake = new Snake(snakePosition, 1, Direction.RIGHT);
            
            Random random = new Random();
            FoodCreator foodCreator = new FoodCreator(random.Next(1,11), random.Next(1, 11), '$');
            Point food = foodCreator.CreateFood();

            ConsoleKeyInfo input;

            while (true)
            {
                Console.Clear();
                snake.Draw();
                food.Draw();

                Console.SetCursorPosition(0, 10);
                Console.ResetColor();
                Console.WriteLine("\n방향키를 눌러 뱀을 이동시키고 음식을 먹어 뱀의 몸을 늘리세요.\n뱀: *\t음식: $\n");
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

                snake.MoveHeadPoint();
                if(snake.EatFood(food))
                {
                    foodCreator = new FoodCreator(random.Next(1, 11), random.Next(1, 11), '$');
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                snake.Draw();

                Thread.Sleep(100);
                Console.SetCursorPosition(0,15);
                Console.WriteLine($"\n현재 길이: {snake.GetLength()}\n먹은 음식의 수: {snake.GetEatCount()}");
                Thread.Sleep(300);
            }
        }
    }

    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
}