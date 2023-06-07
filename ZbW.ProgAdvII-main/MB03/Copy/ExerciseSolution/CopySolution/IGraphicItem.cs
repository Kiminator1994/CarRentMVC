namespace CopySolution {
    public interface IGraphicItem {
        Point2D Location { get; }
        IGraphicItem CopyShallow();
        IGraphicItem CopyDeep();
    }
}
