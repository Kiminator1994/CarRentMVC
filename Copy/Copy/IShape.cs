using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy
{
    internal interface IShape : IGraphicItem
    {
        Color AreaColor { get; set; }
    }
}
