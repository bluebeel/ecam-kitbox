using System;
using System.Drawing;

namespace KitBox
{
    public abstract class Product : IProduct
    {
        private decimal price;
        private Dimensions dimensions;
        private Color color;

        public Product(decimal price, int width, int height, int depth, Color color)
        {
            this.price = price;
            this.dimensions = new Dimensions(width, height, depth);
            this.color = color;
        }

        // Implement IProduct interface
        public int get_width()
        {
            return dimensions.Width;
        }

        public int get_height()
        {
            return dimensions.Height;
        }

        public int get_depth()
        {
            return dimensions.Depth;
        }

        public decimal get_price()
        {
            return price;
        }

        public Color get_color()
        {
            return color;
        }
    }
}
