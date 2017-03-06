using System;
using System.Drawing;

namespace KitBox
{
    public abstract class Product : IProduct
    {
        private decimal price;
        private Dimensions dimensions;
        private Color color;

        public Product()
        {
        }
    }
}
