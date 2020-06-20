using System.Collections.Generic;
using System.Drawing;

namespace GraphicEditor
{
    class Line : IShape
    {
        public Pen ShapePen { get; set; }
        public List<Point> BearingPoints { get; set; }

        public Line()
        {
            BearingPoints = new List<Point>();
        }
        
        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(ShapePen, BearingPoints[0], BearingPoints[BearingPoints.Count - 1]);
        }
    }
}