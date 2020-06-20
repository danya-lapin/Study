using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GraphicEditor
{
    public partial class GraphicEditorForm: Form
    {
        private readonly Controller _controller;
        private Pen CurrentPen { get; set; }
        private bool IsDrawing { get; set; }
        
        public GraphicEditorForm()
        {
            _controller = new Controller(_graphics);
            CurrentPen = new Pen(Color.Black, 1);
            InitializeComponents();
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
    }
}