using System.Drawing;

namespace CopySolution {
    public class Rectangle : IShape {
        public Rectangle(Point2D location, int width, int height, Color color) {
            this.Location = location;
            this.AreaColor = color;
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; }
        public int Height { get; }
        public Point2D Location { get; }


        public IGraphicItem CopyShallow() {
            return (IGraphicItem) this.MemberwiseClone();
        }

        public IGraphicItem CopyDeep() {
            return new Rectangle(new Point2D(this.Location.X, this.Location.Y), this.Width, this.Height, this.AreaColor);
        }

        public Color AreaColor { get; set;  }
    }
}
