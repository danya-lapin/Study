using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GraphicEditor
{
    public partial class GraphicEditorForm: Form
    {
        private readonly Controller _controller;
        private readonly Model _model;

        private Pen CurrentPen { get; set; }
        private bool IsDrawing { get; set; }
        
        public GraphicEditorForm()
        {
            InitializeComponents();
            _controller = new Controller(_graphics);
            _model = new Model(_graphics);
            CurrentPen = new Pen(Color.Black, 1);
            _graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            IsDrawing = true;
            _controller.StartDrawing(CurrentPen, e.Location);
        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsDrawing)
            {
                _controller.EndDrawing();
            }
            
            IsDrawing = false;
        }

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrawing)
            {
                _controller.ContinueDrawing(e.Location);
            }
        }

        private void PencilButton_Click(object sender, EventArgs e)
        {
             _model.SwitchTool(ShapeFactory.Pencil);
             _controller.CurrentShape = ShapeFactory.Pencil;
        }
        
        private void LineButton_Click(object sender, EventArgs e)
        {
            _model.SwitchTool(ShapeFactory.Line);
            _controller.CurrentShape = ShapeFactory.Line;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            _controller.Undo();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            _controller.Redo();
        }
    }
}