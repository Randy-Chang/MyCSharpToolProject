using ImageViewerApp;
using ImageViewerApp.OverlayPlugins;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project_ImageViewer
{
    public partial class Form1 : Form
    {
        ImageViewer viewer;
        ImageViewer viewerRoi;
        Bitmap roiImage;
        Bitmap sourceImage;
        
        TemplateMatching templateMatching;
        Point point;


        public Form1()
        {
            InitializeComponent();

            templateMatching = new TemplateMatching();

            viewer = new ImageViewer();
            viewerRoi = new ImageViewer();
            plImageViewer.Controls.Add(viewer);
            plRoiImage.Controls.Add(viewerRoi);

            sourceImage = new Bitmap(@"C:\Users\gdba5\Pictures\桌布\Zelda_2560_1440.jpg");
            viewer.LoadImage(sourceImage);

            btnSaveRoiImage.Click += btnSaveRoiImage_Click;
            btnMatch.Click += btnMatch_Click;
            btnShowMatchResult.Click += btnShowMatchResult_Click;
        }

        private void btnSaveRoiImage_Click(object sender, EventArgs e)
        {
            roiImage = viewer.GetRoiImage();

            viewerRoi.LoadImage(roiImage);
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            double maxVal;

            point = templateMatching.MatchTemplateFast(sourceImage, roiImage, out maxVal);
        }

        private void btnShowMatchResult_Click(object sender, EventArgs e)
        {
            Size templateSize = roiImage.Size;

            RectangleF matchRect = new RectangleF(point, templateSize);
            List<RectangleF> matches = new List<RectangleF>();
            matches.Add(matchRect);

            viewer.AddMatchResult(matches);
        }
    }
}
