using System.Drawing;

namespace GraphicEditor
{
    class DrawShapeCommand: ICommand
    {
        private readonly IShape _shape;
        private readonly Graphics _graphics;
        
        public DrawShapeCommand(Graphics graphics, IShape currentShape)
        {
            _graphics = graphics;
            _shape = currentShape;
        }

        public void Execute()
        {
            _shape.Draw(_graphics);
        }
    }
}