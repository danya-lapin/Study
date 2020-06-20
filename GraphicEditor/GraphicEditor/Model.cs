using System.Collections.Generic;
using System.Drawing;

namespace GraphicEditor
{
    class Model
    {
        public List<IShape> ShapeList { get; }
        private readonly Graphics _modelGraphics;

        public Model(Graphics modelGraphics)
        {
            _modelGraphics = modelGraphics;
            ShapeList = new List<IShape>();
        }

        public void DrawAll()
        {
            foreach (var shape in ShapeList)
            {
                shape.Draw(_modelGraphics);
            }
        }

        public IShape SwitchTool(ShapeFactory shape)
        {
            switch (shape)
            {
                default:
                    return new Pencil();
                case ShapeFactory.Line:
                    return new Line();
                case ShapeFactory.Pencil:
                    return new Pencil();
            }
        }
    }
}