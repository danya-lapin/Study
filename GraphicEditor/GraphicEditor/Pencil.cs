using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicEditor
{
    class Pencil: IShape
    {
        public Pen ShapePen { get; set; }
        public List<Point> BearingPoints { get; set; }
        public void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}