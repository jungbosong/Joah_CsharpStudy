using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        string state;
        int length;
        int eatCount = 0;
        Point headPoint;
        Direction direction;
        public List<Point> points = new List<Point>();

        public Snake(Point point, int length, Direction direction)
        {
            this.headPoint = point;
            this.length = length;
            this.direction = direction;
            points.Add(headPoint);
        }

        public void Draw()
        {
            for(int i = length-1; i >= 0; i--)
            {
                if(i == length-1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else 
                {
                    Console.ResetColor();
                }
                points[i].Draw();
            }
        }
        
        public void AddBody()
        {
            length++;
        }

        public void LoseLength()
        {
            --length;
            if(length > 1)
            {
                points.RemoveAt(0);
            }
            if(length <= 0)
            {
                length = 1;
            }
        }

        public void SetHeadPoint(int x, int y)
        {
            headPoint.x = x;
            headPoint.y = y;
        }

        public void SetDirection(Direction direction)
        {
            this.direction=direction;
        }

        public int GetLength()
        {
            return length;
        }

        public int GetEatCount()
        {
            return eatCount;
        }

        public void MoveHeadPoint()
        {
            switch(direction)
            {
                case Direction.LEFT:
                {
                    --headPoint.x;
                    if (headPoint.x <= 0)
                    {
                        headPoint.x = 1;
                        LoseLength();
                    }
                    break;
                }
                case Direction.RIGHT:
                {
                    ++headPoint.x;
                    if (headPoint.x > 10)
                    {
                        headPoint.x = 10;
                        LoseLength();
                    }
                    break;
                }
                case Direction.UP:
                {
                    --headPoint.y;
                    if (headPoint.y <= 0)
                    {
                        headPoint.y = 1;
                        LoseLength();
                    }
                    break;
                }
                case Direction.DOWN:
                {
                    ++headPoint.y;
                    if (headPoint.y > 10)
                    {
                        headPoint.y = 10;
                        LoseLength();
                    }
                    break;
                }
            }
            Point newPoint = new Point(headPoint.x, headPoint.y, headPoint.sym);
            points.Add(newPoint);
            if(points.Count() > length+1)
            {
                points.RemoveAt(0);
            }
        }

        public bool EatFood(Point food)
        {
            if(headPoint.IsHit(food))
            {
                AddBody();
                eatCount++;
                return true;
            }
            return false;
        }
    }
}
