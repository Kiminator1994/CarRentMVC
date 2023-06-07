using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy
{
    internal interface IGraphicItem
    {
        Point2D Location { get; }
        IGraphicItem CopyShallow();
        IGraphicItem CopyDeep();
    }
}
