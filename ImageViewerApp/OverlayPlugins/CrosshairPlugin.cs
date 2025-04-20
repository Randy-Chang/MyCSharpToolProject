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
    /// 繪製十字線
    /// </summary>
    public class CrosshairPlugin : IOverlayPlugin
    {
        public string Name => "Crosshair";
        public bool IsEnabled { get; set; } = false;

        public void Draw(Graphics g, System.Drawing.Image image, PointF imagePosition, float zoomLevel)
        {
            if (!IsEnabled || image == null) return;

            using (var pen = new Pen(Color.Blue, 1))
            {
                float centerX = imagePosition.X + image.Width * zoomLevel / 2f;
                float centerY = imagePosition.Y + image.Height * zoomLevel / 2f;

                g.DrawLine(pen, centerX, imagePosition.Y, centerX, imagePosition.Y + image.Height * zoomLevel);
                g.DrawLine(pen, imagePosition.X, centerY, imagePosition.X + image.Width * zoomLevel, centerY);
            }
        }

        public void HandleInput(KeyEventArgs e) { } // 空實現，按鈕控制
        public void OnMouseDown(MouseEventArgs e, PointF imagePosition, float zoomLevel) { }
        public void OnMouseMove(MouseEventArgs e, PointF imagePosition, float zoomLevel) { }
        public void OnMouseUp(MouseEventArgs e, PointF imagePosition, float zoomLevel) { }

    }
}
