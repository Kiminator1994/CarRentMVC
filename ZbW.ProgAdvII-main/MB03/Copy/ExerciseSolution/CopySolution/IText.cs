using System.Drawing;

namespace CopySolution {
    public interface IText : IGraphicItem {
        string Text { get; }
        Color TextColor { get; }
    }
}
