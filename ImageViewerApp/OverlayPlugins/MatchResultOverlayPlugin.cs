using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewerApp.OverlayPlugins
{
    public class MatchResultOverlayPlugin : IOverlayPlugin
    {
        public string Name => "Match Result Overlay";
        public bool IsEnabled { get; set; } = true;

        // 你可以把辨識結果的資料結構放進來，例如一個 List<RectangleF> 或你自己定義的 MatchResult
        public List<RectangleF> ResultRectangles { get; set; } = new List<RectangleF>();

        public void Draw(Graphics g, Image image, PointF imagePosition, float zoomLevel)
        {
            if (!IsEnabled || image == null || ResultRectangles == null) return;

            using (var pen = new Pen(Color.Magenta, 2))
            {
                foreach (var rect in ResultRectangles)
                {
                    // 把 ROI 從 image 座標轉成 viewer 的座標
                    RectangleF viewRect = new RectangleF(
                        imagePosition.X + rect.X * zoomLevel,
                        imagePosition.Y + rect.Y * zoomLevel,
                        rect.Width * zoomLevel,
                        rect.Height * zoomLevel
                    );

                    g.DrawRectangle(pen, viewRect.X, viewRect.Y, viewRect.Width, viewRect.Height);
                }
            }
        }

        public void HandleInput(KeyEventArgs e) { }
        public void OnMouseDown(MouseEventArgs e, PointF imagePosition, float zoomLevel) { }
        public void OnMouseMove(MouseEventArgs e, PointF imagePosition, float zoomLevel) { }
        public void OnMouseUp(MouseEventArgs e, PointF imagePosition, float zoomLevel) { }
    }

}
