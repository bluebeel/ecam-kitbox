﻿using System;
using System.Drawing;

namespace KitBox
{
    public class TrackOneRail : Track, ISideElement
    {
        public TrackOneRail(decimal price, int width, int height, int depth, Color color) : base(price, width, height, depth, color)
        {
        }
    }
}