using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class FoodCreator
    {
        private int width, height;
        private char foodName;

        Random random = new Random();

        public FoodCreator(int width, int height, char foodName)
        {
            this.width = width;
            this.height = height;
            this.foodName = foodName;
        }

        public Point CreateFood()
        {
            int x = random.Next(2, width);
            int y = random.Next(2, height);
            return new Point(x, y, foodName);
        }
    }
}
