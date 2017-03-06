using System;
using System.Drawing;

namespace KitBox
{
    public class ClassicDoor : Door
    {
        private Slot slot;

        public ClassicDoor(decimal price, int width, int height, int depth, Color color, Slot slot) : base(price, width, height, depth, color)
        {
            this.slot = slot;
        }
    }
}