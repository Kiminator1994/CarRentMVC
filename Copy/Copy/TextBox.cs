using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy
{
    internal class TextBox : Rectangle, IText
    {
        public string Text { get; set; }

        public Color TextColor { get; set; }

        public TextBox(Point2D location, int width, int height, Color areaColor, string text, Color textColor): base(location,width,height, areaColor)
        {
            Text = text;
            TextColor = textColor;
        }
    }
}
