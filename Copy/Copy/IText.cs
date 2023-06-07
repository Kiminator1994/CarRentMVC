using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy
{
    internal interface IText: IGraphicItem
    {
        string Text { get; }
        Color TextColor { get; }
    }
}
