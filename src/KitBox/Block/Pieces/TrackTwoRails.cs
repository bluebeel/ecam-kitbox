using System;
using System.Drawing;

namespace KitBox
{
    public class TrackTwoRails : Track, IFrontElement
    {
        public TrackTwoRails(decimal price, int width, int height, int depth, Color color) : base(price, width, height, depth, color)
        {
        }
    }
}