using System.Drawing;

namespace CopySolution {
    public interface IShape : IGraphicItem {
        Color AreaColor { get; set;  }
    }
}