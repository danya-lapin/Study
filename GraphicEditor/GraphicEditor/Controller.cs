using System.Drawing;

namespace GraphicEditor
{
    public class Controller
    {
        private readonly Graphics _controllerGraphics;
        public IShape CurrentTool { get; set; }
        private readonly Model _model;

        public Controller(Graphics controllerGraphics)
        {
            _controllerGraphics = controllerGraphics;
            _model = new Model(_controllerGraphics);
            CurrentTool = new Line();
        }

        public void StartDrawing(Pen pen, Point startPoint)
        {
            CurrentTool = _model.SwitchTool(ShapeFactory.Line);
            CurrentTool.BearingPoints.Add(startPoint);
            CurrentTool.ShapePen = pen;
        }

        public void ContinueDrawing(Point endPoint)
        {
            _controllerGraphics.Clear(Color.White);
            _model.DrawAll();
            CurrentTool.BearingPoints.Add(endPoint);
            CurrentTool.Draw(_controllerGraphics);
        }

        public void EndDrawing()
        {
            _model.ShapeList.Add(CurrentTool);
        }
    }
}