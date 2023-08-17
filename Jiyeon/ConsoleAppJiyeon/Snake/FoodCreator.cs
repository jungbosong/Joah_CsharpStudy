using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class FoodCreator
    {
        private int x, y;
        private char foodName;

        public FoodCreator(int x, int y, char foodName)
        {
            this.x = x;
            this.y = y;
            this.foodName = foodName;
        }

        public Point CreateFood()
        {
            return new Point(x, y, foodName);
        }
    }
}
