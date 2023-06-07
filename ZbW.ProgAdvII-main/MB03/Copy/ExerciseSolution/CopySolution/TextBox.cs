using System.Drawing;

namespace CopySolution {
    public class TextBox : Rectangle, IText {
        public TextBox(Point2D location, int width, int height, Color areaColor, string text, Color textColor) : base(location, width, height, areaColor) {
            this.Text = text;
            this.TextColor = textColor;
        }

        public string Text { get; }
        public Color TextColor { get; }
    }
}
