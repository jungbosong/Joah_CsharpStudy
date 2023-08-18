using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        public int eatCount { get; set; }
        Direction direction;
        public List<Point> body = new List<Point>();

        public Snake(Point point, int length, Direction direction)
        {
            this.direction = direction;
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(point.x, point.y, '*');
                body.Add(p);
                point.x += 1;
            }
            eatCount = 0;
        }

        public void Draw()
        {
            foreach (Point p in body)
            {
                p.Draw();
            }
        }

        public void SetDirection(Direction direction)
        {
            this.direction = direction;
        }

        public int GetLength()
        {
            return body.Count;
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                body.Add(food);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Move()
        {
            Point tail = body[0];
            body.Remove(tail);
            Point head = GetNextPoint();
            body.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            int lastIdx = body.Count - 1;
            if(lastIdx  < 0)
            {
                lastIdx = 0;
            }
            Point head = body[lastIdx];
            
            Point nextPoint = new Point(head.x, head.y, head.sym);
            switch (direction)
            {
                case Direction.LEFT:
                    nextPoint.x -= 1;
                    break;
                case Direction.RIGHT:
                    nextPoint.x += 1;
                    break;
                case Direction.UP:
                    nextPoint.y -= 1;
                    break;
                case Direction.DOWN:
                    nextPoint.y += 1;
                    break;
            }
            return nextPoint;
        }

        public bool IsHitTail()
        {
            var head = body.Last();
            for (int i = 0; i < body.Count - 2; i++)
            {
                if (head.IsHit(body[i]))
                    return true;
            }
            return false;
        }

        public bool IsHitWall()
        {
            var head = body.Last();
            if (head.x <= 0 || head.x >= 10 || head.y <= 0 || head.y >= 10)
            {
                return true;
            }
            return false;
        }
    }
}
