using System.Drawing;

namespace CopySolution {
    public class Circle : IShape {
        public Circle(Point2D center, int radius, Color color) {
            this.Location = center;
            this.AreaColor = color;
            this.Radius = radius;
        }

        public int Radius { get; }
        public Point2D Location { get; private set; }

        public IGraphicItem CopyShallow() {
            return (IGraphicItem)this.MemberwiseClone();
        }

        public IGraphicItem CopyDeep() {
            return (IGraphicItem)this.MemberwiseClone();
        }

        public Color AreaColor { get; set; }
    }
}
