using ImageViewerApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageViewerApp
{
    public class ImageViewerBase : Control
    {
        protected Image _image;
        protected float _zoomLevel = 1.0f;
        protected float _zoomLevelForControl = 1.0f;
        protected PointF _positionForFit = new PointF(0, 0);
        protected PointF _position = new PointF(0, 0);

        protected Point _lastMousePos;
        private bool _isDragging = false;

        public ImageViewerBase()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public void LoadImage(string filePath)
        {
            try
            {
                using (var tempImage = Image.FromFile(filePath))
                {
                    _image?.Dispose();
                    _image = (Image)tempImage.Clone();
                }

                UpdateZoomToFit();
                Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入圖片失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void UpdateZoomToFit()
        {
            if (_image == null || Width == 0 || Height == 0) return;

            float widthRatio = (float)Width / _image.Width;
            float heightRatio = (float)Height / _image.Height;
            _zoomLevel = Math.Min(widthRatio, heightRatio);
            _zoomLevelForControl = _zoomLevel;

            // 圖片置中
            float displayWidth = _image.Width * _zoomLevel;
            float displayHeight = _image.Height * _zoomLevel;
            _position = new PointF(
                (Width - displayWidth) / 2f,
                (Height - displayHeight) / 2f
            );

            _positionForFit = _position;
        }

        

        // 滑鼠滾輪控制縮放
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            float oldZoom = _zoomLevel;

            // 更新縮放比例
            if (e.Delta > 0) _zoomLevel *= 1.1f;
            else _zoomLevel /= 1.1f;

            // 限制縮放比例範圍
            _zoomLevel = Math.Max(0.1f, Math.Min(_zoomLevel, 10f));

            // 計算新的偏移，讓滑鼠點保持在同一個圖像位置
            float scaleChange = _zoomLevel / oldZoom;

            // 滑鼠座標 (控制範圍內的座標)
            float mouseX = e.X;
            float mouseY = e.Y;

            // 更新圖片偏移位置
            _position.X = mouseX - scaleChange * (mouseX - _position.X);
            _position.Y = mouseY - scaleChange * (mouseY - _position.Y);

            Invalidate(); // 重新繪製
            base.OnMouseWheel(e);
        }

        public bool EnableDragging { get; set; } = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (EnableDragging && e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _lastMousePos = e.Location;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_isDragging && _image != null)
            {
                float deltaX = e.X - _lastMousePos.X;
                float deltaY = e.Y - _lastMousePos.Y;

                _position.X += deltaX;
                _position.Y += deltaY;

                // 計算圖片顯示尺寸
                float displayWidth = _image.Width * _zoomLevel;
                float displayHeight = _image.Height * _zoomLevel;

                // 限制圖片位置不要超出控制項邊界
                float minX = Math.Min(0, Width - displayWidth);
                float minY = Math.Min(0, Height - displayHeight);
                float maxX = Math.Max(0, Width - displayWidth);  // 如果圖片比容器小，允許置中
                float maxY = Math.Max(0, Height - displayHeight);

                _position.X = Math.Min(maxX, Math.Max(minX, _position.X));
                _position.Y = Math.Min(maxY, Math.Max(minY, _position.Y));

                _lastMousePos = e.Location;
                Invalidate();
            }

            Invalidate();
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isDragging = false;
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);

            if (_image != null)
            {
                e.Graphics.DrawImage(_image,
                    _position.X, _position.Y,
                    _image.Width * _zoomLevel,
                    _image.Height * _zoomLevel);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _image?.Dispose();
            base.Dispose(disposing);
        }
    }
}
