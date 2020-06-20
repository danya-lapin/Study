using System.Collections.Generic;
using System.Drawing;

namespace GraphicEditor
{
    public interface IShape
    {
        Pen ShapePen { get; set; }
        List<Point> BearingPoints { get; set; }
        void Draw(Graphics graphics);
    }
}