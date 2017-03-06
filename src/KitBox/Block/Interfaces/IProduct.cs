using System;
using System.Drawing;

namespace KitBox
{
    public interface IProduct
    {
        int get_width();
        int get_height();
        int get_depth();

        decimal get_price();

        Color get_color();
    }
}
