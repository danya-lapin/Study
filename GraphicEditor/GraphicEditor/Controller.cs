using System.Drawing;

namespace GraphicEditor
{
    public class Controller
    {
        private readonly Graphics _controllerGraphics;
        private IShape CurrentTool { get; set; }
        public ShapeFactory CurrentShape { get; set; }

        private readonly UndoRedoStack _undoRedoStack;
        
        private readonly Model _model;

        public Controller(Graphics controllerGraphics)
        {
            _controllerGraphics = controllerGraphics;
            _model = new Model(_controllerGraphics);
            CurrentTool = _model.SwitchTool(ShapeFactory.Pencil);
            _undoRedoStack = new UndoRedoStack();
        }

        public void StartDrawing(Pen pen, Point startPoint)
        {
            CurrentTool = _model.SwitchTool(CurrentShape);
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
            _undoRedoStack.Add(new DrawShapeCommand(_controllerGraphics, CurrentTool));
            _model.ShapeList.Add(CurrentTool);
        }

        public void Undo()
        {
            _undoRedoStack.Undo();
        }

        public void Redo()
        {
            _undoRedoStack.Redo();
        }
    }
}