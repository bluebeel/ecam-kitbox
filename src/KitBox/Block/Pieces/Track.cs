using System;
using System.Drawing;

namespace KitBox
{
    public abstract class Track : Product
    {
        public Track(decimal price, int width, int height, int depth, Color color) : base(price, width, height, depth, color)
        {
        }
    }
}
