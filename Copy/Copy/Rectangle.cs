using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy
{
    internal class Rectangle : IShape
    {
        int Width { get; }
        int Height { get; }
        public Point2D Location { get; }
        public Color AreaColor { get; set; }
        public Rectangle(Point2D location, int width, int height,  Color areaColor)
        {
            Width = width;
            Height = height;
            Location = location;
            AreaColor = areaColor;
        }


        public IGraphicItem CopyShallow()
        {
            return this.MemberwiseClone() as IGraphicItem;
        }

        public IGraphicItem CopyDeep()
        {
            Rectangle deepCopyRectangle = new Rectangle(new Point2D(this.Location.X, this.Location.Y), this.Width, this.Height, AreaColor);
            return deepCopyRectangle;
        }

        
    }
}
