using System;
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
            
            //ToolBox.PencilButton
            var pencilButton = new Button();
            pencilButton.Width = _toolBoxWidth - 4;
            pencilButton.Height = toolBox.Height / 20;
            pencilButton.Location = new Point(toolBox.Location.X + 2, toolBox.Location.Y + 2);
            pencilButton.Click += new EventHandler(PencilButton_Click);
            toolBox.Controls.Add(pencilButton);
            
            //ToolBox.LineButton
            var lineButton = new Button();
            lineButton.Width = _toolBoxWidth - 4;
            lineButton.Height = toolBox.Height / 20;
            lineButton.Location = new Point(toolBox.Location.X + 2, toolBox.Location.Y + pencilButton.Height + 2);
            lineButton.Click += new EventHandler(LineButton_Click);
            toolBox.Controls.Add(lineButton);
            
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
            drawingPanel.BackColor = Color.White;
            _graphics = drawingPanel.CreateGraphics();
            drawingPanel.MouseDown += new MouseEventHandler(DrawingPanel_MouseDown);
            drawingPanel.MouseUp += new MouseEventHandler(DrawingPanel_MouseUp);
            drawingPanel.MouseMove += new MouseEventHandler(DrawingPanel_MouseMove);
            this.Controls.Add(drawingPanel);

            //UndoRedo Toolbox
            var undoRedoBox = new GroupBox();
            undoRedoBox.Location = new Point(0, 0);
            undoRedoBox.Width = toolBox.Width + 5;
            undoRedoBox.Height = 20;
            undoRedoBox.BackColor = Color.LightGray;
            drawingPanel.Controls.Add(undoRedoBox);
            
            //Undo Button
            var undoButton = new Button();
            undoButton.Location = new Point(0, 0);
            undoButton.Height = undoRedoBox.Height;
            undoButton.Width = undoRedoBox.Width / 2;
            undoButton.Click += new EventHandler(UndoButton_Click);
            undoRedoBox.Controls.Add(undoButton);
            
            //Redo Button
            var redoButton = new Button();
            redoButton.Location = new Point(undoRedoBox.Width / 2, 0);
            redoButton.Height = undoRedoBox.Height;
            redoButton.Width = undoRedoBox.Width / 2;
            redoButton.Click += new EventHandler(RedoButton_Click);
            undoRedoBox.Controls.Add(redoButton);
        }
    }
}