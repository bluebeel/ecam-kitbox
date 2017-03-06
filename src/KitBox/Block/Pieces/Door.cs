using System;
using System.Drawing;

namespace KitBox
{
    public abstract class Door : Product, IFrontElement
    {
        public Door(decimal price, int width, int height, int depth, Color color) : base(price, width, height, depth, color)
        {
        }
    }
}
