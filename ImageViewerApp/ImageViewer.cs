using ImageViewerApp.OverlayPlugins;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace ImageViewerApp
{
    public partial class ImageViewer : ImageViewerBase
    {

        private List<Button> _buttons = new List<Button>();

        public ImageViewer() : base()
        {
            this.Dock = DockStyle.Fill;

            // 預設載入內建插件
            _plugins.Add(new CrosshairPlugin());
            _plugins.Add(new GridPlugin());
            _plugins.Add(new RoiPlugin());
            _plugins.Add(new MatchResultOverlayPlugin());

            // 初始化按鍵
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            // 假設在這裡添加按鍵到控制項
            #region 建立按鍵
            Button fitButton = new Button
            {
                Text = "Fit",
                Size = new Size(30, 30),
                Location = new Point(10, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button zoomInButton = new Button 
            { 
                Text = "+",
                Size = new Size(30, 30),
                Location = new Point(10,10),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button zoomOutButton = new Button
            {
                Text = "-",
                Size = new Size(30, 30),
                Location = new Point(10, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button draggingButton = new Button
            {
                Text = "",
                Size = new Size(30, 30),
                Location = new Point(10, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Image = new Bitmap(Properties.Resources.drag_1, new Size(25,25)),  // 縮放圖片到按鈕大小
                ImageAlign = ContentAlignment.MiddleCenter  // 讓圖片居中顯示

            };

            Button crosshairButton = new Button
            {
                Text = "十",
                Size = new Size(30, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button gridButton = new Button
            {
                Text = "井",
                Size = new Size(30, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button roiButton = new Button
            {
                Text = "ROI",
                Size = new Size(30, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            #endregion

            fitButton.Click += (s, e) => 
            { 
                _zoomLevel = _zoomLevelForControl;
                _position = _positionForFit;
                Invalidate(); 
            };
            zoomInButton.Click += (s, e) => { _zoomLevel *= 1.1f; Invalidate(); };
            zoomOutButton.Click += (s, e) => { _zoomLevel /= 1.1f; Invalidate(); };
            draggingButton.Click += (s, e) => { EnableDragging = !EnableDragging; };
            crosshairButton.Click += (s, e) => TogglePlugin("Crosshair");
            gridButton.Click += (s, e) => TogglePlugin("Grid");
            roiButton.Click += (s, e) => TogglePlugin("ROI");

            _buttons.Add(fitButton);
            _buttons.Add(draggingButton);
            _buttons.Add(zoomInButton);
            _buttons.Add(zoomOutButton);
            _buttons.Add(crosshairButton);
            _buttons.Add(gridButton);
            _buttons.Add(roiButton);


            int yIntervel = 5;
            int yStartPos = 5; 
            int cnt = 0;

            foreach (Button button in _buttons)
            {
                int ySize = button.Size.Height;
                int yPos = yStartPos + (yIntervel + ySize) * cnt;
                
                button.Location = new Point(5, yPos);
                cnt++;
            }

            // 將按鍵加入到控制項中
            foreach (var button in _buttons)
            {
                Controls.Add(button);
            }
        }

        // 覆寫 OnResize 來通知 ImageViewerBase 調整大小
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // 呼叫 ImageViewerBase 來調整圖片顯示區域大小
            this.UpdateImageSize();
        }

        // 在這裡可以新增一個方法來更新圖片大小
        private void UpdateImageSize()
        {
            // 在這裡加入調整圖片大小的邏輯
            // 例如，將 ImageViewerBase 顯示的圖片尺寸設為目前 ImageViewer 的大小
            this.UpdateZoomToFit();
        }
    }

    // 插件擴充相關
    public partial class ImageViewer
    {
        private List<IOverlayPlugin> _plugins = new List<IOverlayPlugin>();

        // 公開插件控制方法
        public void TogglePlugin(string pluginName)
        {
            var plugin = _plugins.Find(p => p.Name == pluginName);
            if (plugin != null)
            {
                plugin.IsEnabled = !plugin.IsEnabled;
                Invalidate();
            }
        }

        public void AddPlugin(IOverlayPlugin plugin) => _plugins.Add(plugin);

        // 覆蓋 OnPaint 方法以繪製插件效果
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // 先執行基礎類別的繪製邏輯

            foreach (var plugin in _plugins.Where(p => p.IsEnabled))
            {
                plugin.Draw(e.Graphics, _image, _position, _zoomLevel);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            foreach (var plugin in _plugins.Where(p => p.IsEnabled))
                plugin.OnMouseDown(e, _position, _zoomLevel);

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            foreach (var plugin in _plugins.Where(p => p.IsEnabled))
                plugin.OnMouseMove(e, _position, _zoomLevel);

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            foreach (var plugin in _plugins.Where(p => p.IsEnabled))
                plugin.OnMouseUp(e, _position, _zoomLevel);

            base.OnMouseUp(e);
        }
    }

    // ROI 
    public partial class ImageViewer
    {
        public Rectangle GetRoiRectangle()
        {
            var roiPlugin = _plugins.OfType<IRoiProvider>().FirstOrDefault();
            return roiPlugin?.GetROIInt ?? Rectangle.Empty;
        }

        public Bitmap GetRoiImage()
        {
            var roiPlugin = _plugins.OfType<IRoiProvider>().FirstOrDefault();
            if (roiPlugin != null && _image != null)
            {
                Rectangle roi = roiPlugin.GetROIInt;
                if (_image.PixelFormat != PixelFormat.Undefined && roi.Width > 0 && roi.Height > 0)
                {
                    // 使用 Graphics.FromImage 和 DrawImage 來複製 ROI 區域影像  
                    Bitmap roiImage = new Bitmap(roi.Width, roi.Height);
                    using (Graphics g = Graphics.FromImage(roiImage))
                    {
                        g.DrawImage(_image, new Rectangle(0, 0, roi.Width, roi.Height), roi, GraphicsUnit.Pixel);
                    }
                    return roiImage;
                }
            }
            return null;
        }
    }


    public partial class ImageViewer 
    {
        public void AddMatchResult(List<RectangleF> rectangleFs)
        {
            var matchPlugin = _plugins.OfType<MatchResultOverlayPlugin>().FirstOrDefault();
            matchPlugin.ResultRectangles.Clear();
            matchPlugin.ResultRectangles = new List<RectangleF>(rectangleFs);
        }
    }
}
