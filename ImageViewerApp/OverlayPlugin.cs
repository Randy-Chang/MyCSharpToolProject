using System;
using System.Drawing;
using System.Windows.Forms;


namespace ImageViewerApp
{
    /// <summary>
    /// 插件介面
    /// </summary>
    public interface IOverlayPlugin
    {
        string Name { get; }
        bool IsEnabled { get; set; }

        void Draw(Graphics g, System.Drawing.Image image, PointF imagePosition, float zoomLevel);
        void HandleInput(KeyEventArgs e);

        void OnMouseDown(MouseEventArgs e, PointF imagePosition, float zoomLevel);
        void OnMouseMove(MouseEventArgs e, PointF imagePosition, float zoomLevel);
        void OnMouseUp(MouseEventArgs e, PointF imagePosition, float zoomLevel);
    }

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

        public void OnMouseDown(MouseEventArgs e, PointF imagePosition, float zoomLevel)
        {
        }

        public void OnMouseMove(MouseEventArgs e, PointF imagePosition, float zoomLevel)
        {

        }

        public void OnMouseUp(MouseEventArgs e, PointF imagePosition, float zoomLevel)
        {
        }
    }

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

        public void OnMouseDown(MouseEventArgs e, PointF imagePosition, float zoomLevel)
        {
        }

        public void OnMouseMove(MouseEventArgs e, PointF imagePosition, float zoomLevel)
        {
        }

        public void OnMouseUp(MouseEventArgs e, PointF imagePosition, float zoomLevel)
        {
        }
    }

    /// <summary>
    /// 繪製ROI
    /// </summary>
    public class RoiPlugin : IOverlayPlugin
    {
        public string Name => "ROI";
        public bool IsEnabled { get; set; } = false;

        private RectangleF _roi = new RectangleF(100, 100, 200, 200);
        private bool _isDragging = false;
        private Point _lastMousePos;
        private ResizeDirection _resizeDirection = ResizeDirection.None;
        private Image _image;

        private enum ResizeDirection
        {
            None,
            Move,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            Left,
            Right,
            Top,
            Bottom
        }

        public void Draw(Graphics g, Image image, PointF imagePosition, float zoomLevel)
        {
            if (!IsEnabled || image == null || _roi == RectangleF.Empty) return;

            _image = image;

            float scaledX = (_roi.X * zoomLevel) + imagePosition.X;
            float scaledY = (_roi.Y * zoomLevel) + imagePosition.Y;
            float scaledWidth = _roi.Width * zoomLevel;
            float scaledHeight = _roi.Height * zoomLevel;

            using (var pen = new Pen(Color.Red, 2))
            {
                g.DrawRectangle(pen, scaledX, scaledY, scaledWidth, scaledHeight);
            }

            float handleSize = 6f;
            using (Brush handleBrush = new SolidBrush(Color.Red))
            {
                g.FillRectangle(handleBrush, scaledX - handleSize, scaledY - handleSize, handleSize * 2, handleSize * 2); // TopLeft
                g.FillRectangle(handleBrush, scaledX + scaledWidth - handleSize, scaledY - handleSize, handleSize * 2, handleSize * 2); // TopRight
                g.FillRectangle(handleBrush, scaledX - handleSize, scaledY + scaledHeight - handleSize, handleSize * 2, handleSize * 2); // BottomLeft
                g.FillRectangle(handleBrush, scaledX + scaledWidth - handleSize, scaledY + scaledHeight - handleSize, handleSize * 2, handleSize * 2); // BottomRight
            }
        }

        public void HandleInput(KeyEventArgs e) { }

        public void OnMouseDown(MouseEventArgs e, PointF imagePosition, float zoomLevel)
        {
            if (!IsEnabled || _roi == RectangleF.Empty) return;

            _resizeDirection = GetResizeDirection(e.Location, imagePosition, zoomLevel);

            if (_resizeDirection != ResizeDirection.None)
            {
                _isDragging = true;
                _lastMousePos = e.Location;
            }
        }

        public void OnMouseMove(MouseEventArgs e, PointF imagePosition, float zoomLevel)
        {
            if (_isDragging && _resizeDirection != ResizeDirection.None)
            {
                float deltaXScaled = (e.X - _lastMousePos.X) / zoomLevel;
                float deltaYScaled = (e.Y - _lastMousePos.Y) / zoomLevel;

                RectangleF newRoi = _roi;

                switch (_resizeDirection)
                {
                    case ResizeDirection.Move:
                        newRoi.X += deltaXScaled;
                        newRoi.Y += deltaYScaled;
                        break;
                    case ResizeDirection.TopLeft:
                        newRoi.X += deltaXScaled;
                        newRoi.Y += deltaYScaled;
                        newRoi.Width -= deltaXScaled;
                        newRoi.Height -= deltaYScaled;
                        break;
                    case ResizeDirection.TopRight:
                        newRoi.Y += deltaYScaled;
                        newRoi.Width += deltaXScaled;
                        newRoi.Height -= deltaYScaled;
                        break;
                    case ResizeDirection.BottomLeft:
                        newRoi.X += deltaXScaled;
                        newRoi.Width -= deltaXScaled;
                        newRoi.Height += deltaYScaled;
                        break;
                    case ResizeDirection.BottomRight:
                        newRoi.Width += deltaXScaled;
                        newRoi.Height += deltaYScaled;
                        break;
                    case ResizeDirection.Left:
                        newRoi.X += deltaXScaled;
                        newRoi.Width -= deltaXScaled;
                        break;
                    case ResizeDirection.Right:
                        newRoi.Width += deltaXScaled;
                        break;
                    case ResizeDirection.Top:
                        newRoi.Y += deltaYScaled;
                        newRoi.Height -= deltaYScaled;
                        break;
                    case ResizeDirection.Bottom:
                        newRoi.Height += deltaYScaled;
                        break;
                }

                _roi = ConstrainToImageBounds(newRoi, zoomLevel);
                _lastMousePos = e.Location;
            }
            else
            {
                // 滑鼠沒在拖動，變更游標
                var direction = GetResizeDirection(e.Location, imagePosition, zoomLevel);
                Cursor.Current = GetCursorForResizeDirection(direction);
            }
        }


        public void OnMouseUp(MouseEventArgs e, PointF imagePosition, float zoomLevel)
        {
            _isDragging = false;
            _resizeDirection = ResizeDirection.None;
        }

        private RectangleF ConstrainToImageBounds(RectangleF roi, float zoomLevel)
        {
            float minSize = 5f / zoomLevel;

            // 防止負值寬高
            roi.Width = Math.Max(minSize, roi.Width);
            roi.Height = Math.Max(minSize, roi.Height);

            // 限制在圖片內
            float maxWidth = _image.Width;
            float maxHeight = _image.Height;

            roi.X = Math.Max(0, Math.Min(roi.X, maxWidth - roi.Width));
            roi.Y = Math.Max(0, Math.Min(roi.Y, maxHeight - roi.Height));

            return roi;
        }

        private Cursor GetCursorForResizeDirection(ResizeDirection direction)
        {
            switch (direction)
            {
                case ResizeDirection.TopLeft:
                    return Cursors.SizeNWSE;
                case ResizeDirection.TopRight:
                    return Cursors.SizeNESW;
                case ResizeDirection.BottomLeft:
                    return Cursors.SizeNESW;
                case ResizeDirection.BottomRight:
                    return Cursors.SizeNWSE;
                case ResizeDirection.Left:
                    return Cursors.SizeWE;
                case ResizeDirection.Right:
                    return Cursors.SizeWE;
                case ResizeDirection.Top:
                    return Cursors.SizeNS;
                case ResizeDirection.Bottom:
                    return Cursors.SizeNS;
                case ResizeDirection.Move:
                    return Cursors.SizeAll;
                default:
                    return Cursors.Default;
            }
        }

        private ResizeDirection GetResizeDirection(Point mousePos, PointF imagePosition, float zoomLevel)
        {
            float scaledX = (_roi.X * zoomLevel) + imagePosition.X;
            float scaledY = (_roi.Y * zoomLevel) + imagePosition.Y;
            float scaledWidth = _roi.Width * zoomLevel;
            float scaledHeight = _roi.Height * zoomLevel;

            RectangleF screenRect = new RectangleF(scaledX, scaledY, scaledWidth, scaledHeight);
            float handleSize = 6f;

            RectangleF topLeft = new RectangleF(screenRect.Left - handleSize, screenRect.Top - handleSize, handleSize * 2, handleSize * 2);
            RectangleF topRight = new RectangleF(screenRect.Right - handleSize, screenRect.Top - handleSize, handleSize * 2, handleSize * 2);
            RectangleF bottomLeft = new RectangleF(screenRect.Left - handleSize, screenRect.Bottom - handleSize, handleSize * 2, handleSize * 2);
            RectangleF bottomRight = new RectangleF(screenRect.Right - handleSize, screenRect.Bottom - handleSize, handleSize * 2, handleSize * 2);

            if (topLeft.Contains(mousePos)) return ResizeDirection.TopLeft;
            if (topRight.Contains(mousePos)) return ResizeDirection.TopRight;
            if (bottomLeft.Contains(mousePos)) return ResizeDirection.BottomLeft;
            if (bottomRight.Contains(mousePos)) return ResizeDirection.BottomRight;

            RectangleF left = new RectangleF(screenRect.Left - handleSize, screenRect.Top + handleSize, handleSize * 2, screenRect.Height - handleSize * 2);
            RectangleF right = new RectangleF(screenRect.Right - handleSize, screenRect.Top + handleSize, handleSize * 2, screenRect.Height - handleSize * 2);
            RectangleF top = new RectangleF(screenRect.Left + handleSize, screenRect.Top - handleSize, screenRect.Width - handleSize * 2, handleSize * 2);
            RectangleF bottom = new RectangleF(screenRect.Left + handleSize, screenRect.Bottom - handleSize, screenRect.Width - handleSize * 2, handleSize * 2);

            if (left.Contains(mousePos)) return ResizeDirection.Left;
            if (right.Contains(mousePos)) return ResizeDirection.Right;
            if (top.Contains(mousePos)) return ResizeDirection.Top;
            if (bottom.Contains(mousePos)) return ResizeDirection.Bottom;

            if (screenRect.Contains(mousePos)) return ResizeDirection.Move;

            return ResizeDirection.None;
        }

        public void SetROI(RectangleF roi)
        {
            _roi = roi;
        }

        public void ClearROI()
        {
            _roi = RectangleF.Empty;
        }
    }


}
