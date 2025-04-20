using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewerApp.OverlayPlugins
{
    /// <summary>
    /// 繪製九宮格
    /// </summary>
    public class GridPlugin : IOverlayPlugin
    {
        public string Name => "Grid";
        public bool IsEnabled { get; set; } = false;

        public void Draw(Graphics g, System.Drawing.Image image, PointF imagePosition, float zoomLevel)
        {
            if (!IsEnabled || image == null) return;

            using (var pen = new Pen(Color.Blue, 1))
            {
                float cellWidth = image.Width * zoomLevel / 3f;
                float cellHeight = image.Height * zoomLevel / 3f;

                for (int i = 1; i < 3; i++)
                {
                    float x = imagePosition.X + i * cellWidth;
                    float y = imagePosition.Y + i * cellHeight;

                    g.DrawLine(pen, x, imagePosition.Y, x, imagePosition.Y + image.Height * zoomLevel);
                    g.DrawLine(pen, imagePosition.X, y, imagePosition.X + image.Width * zoomLevel, y);
                }
            }
        }

        public void HandleInput(KeyEventArgs e) { } // 空實現，按鈕控制
        public void OnMouseDown(MouseEventArgs e, PointF imagePosition, float zoomLevel) { }
        public void OnMouseMove(MouseEventArgs e, PointF imagePosition, float zoomLevel) { }
        public void OnMouseUp(MouseEventArgs e, PointF imagePosition, float zoomLevel) { }
    }
}
