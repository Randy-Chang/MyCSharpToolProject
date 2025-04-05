using ImageViewerApp;
using System.Drawing;
using System.Windows.Forms;

namespace Project_ImageViewer
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            ImageViewer viewer = new ImageViewer(plImageViewer.Width, plImageViewer.Height);

            plImageViewer.Controls.Add(viewer);

            viewer.LoadImage(@"C:\Users\gdba5\Pictures\桌布\Zelda_2560_1440.jpg");

        }



    }
}
