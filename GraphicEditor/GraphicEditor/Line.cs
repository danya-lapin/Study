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
            ClearBearingPoints();
            graphics.DrawLine(ShapePen, BearingPoints[0], BearingPoints[BearingPoints.Count - 1]);
        }

        private void ClearBearingPoints()
        {
            for (var i = 0; i < BearingPoints.Count; i++)
            {
                if (i == 0 || i == BearingPoints.Count - 1)
                {
                    continue;
                }
                
                BearingPoints.RemoveAt(i);
            }
        }
    }
}