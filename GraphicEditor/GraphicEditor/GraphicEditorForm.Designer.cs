using System.Drawing;
using System.Windows.Forms;

namespace GraphicEditor
{
    public partial class GraphicEditorForm
    {
        private const int _toolBoxWidth = 27;
        private Graphics _graphics;
        public void InitializeComponents()
        {
            this.ClientSize = new Size(960, 540);
            this.Text = "Pepeint";
            
            //Tool Box
            var toolBox = new GroupBox();
            toolBox.Location = new Point(0, 0);
            toolBox.Width = _toolBoxWidth;
            toolBox.Height = this.Height;
            toolBox.BackColor = Color.LightGray;
            this.Controls.Add(toolBox);

            //Brush Settings Box
            var brushSettingsBox = new GroupBox();
            brushSettingsBox.Width = _toolBoxWidth;
            brushSettingsBox.Height = this.Height;
            brushSettingsBox.Location = new Point(this.Width - brushSettingsBox.Width, 0);
            brushSettingsBox.BackColor = Color.LightGray;
            this.Controls.Add(brushSettingsBox);
            
            //Drawing Panel
            var drawingPanel = new Panel();
            drawingPanel.Location = new Point( toolBox.Width, 0);
            drawingPanel.Width = this.Width - brushSettingsBox.Width - toolBox.Width;
            drawingPanel.Height = this.Height;
            _graphics = drawingPanel.CreateGraphics();
            drawingPanel.MouseDown += new MouseEventHandler(DrawingPanel_MouseDown);
            drawingPanel.MouseUp += new MouseEventHandler(DrawingPanel_MouseUp);
            drawingPanel.MouseMove += new MouseEventHandler(DrawingPanel_MouseMove);
            this.Controls.Add(drawingPanel);
        }
    }
}