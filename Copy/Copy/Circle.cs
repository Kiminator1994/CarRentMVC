using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy
{
    internal class Circle : IShape
    {
        public int Radius { get; }
        public Color AreaColor { get; set; }
        public Circle(Point2D center, int radius, Color color)
        {
            Location = center;
            Radius = radius;
            AreaColor = color;

        }

        public Point2D Location { get; }
        public IGraphicItem CopyShallow()
        {
            return (IGraphicItem)this.MemberwiseClone(); 
        }

        public IGraphicItem CopyDeep()
        {
            Circle deepCopyCircle = new Circle(new Point2D(this.Location.X, this.Location.Y), this.Radius, this.AreaColor);
            return deepCopyCircle;
        }

        
    }
}
