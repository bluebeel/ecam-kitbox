using System;
using System.Drawing;

namespace KitBox
{
    public class Panel : Product, IBackElement, ISideElement, IHorizontalElement
    {
        public Panel(decimal price, int width, int height, int depth, Color color) : base(price, width, height, depth, color)
        {
        }
    }
}
