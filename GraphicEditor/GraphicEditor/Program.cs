using System;
using System.Windows.Forms;

namespace GraphicEditor
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new GraphicEditorForm());
        }
    }
}