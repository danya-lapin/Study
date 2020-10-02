using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicEditor
{
    class Pencil: IShape
    {
        public Pencil()
        {
            BearingPoints = new List<Point>();
        }
        public Pen ShapePen { get; set; }
        public List<Point> BearingPoints { get; set; }
        public void Draw(Graphics graphics)
        {
            graphics.DrawLines(ShapePen, BearingPoints.ToArray());
        }
    }
}