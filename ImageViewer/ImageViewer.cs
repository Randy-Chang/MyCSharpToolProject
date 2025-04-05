using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ImageViewerApp
{
    public class ImageViewer : ImageViewerBase
    {
        private List<IOverlayPlugin> _plugins = new List<IOverlayPlugin>();
        private List<Button> _buttons = new List<Button>();

        public ImageViewer(int controlWidth = 0, int controlHeight = 0) : base(controlWidth, controlHeight)
        {
            this.Dock = DockStyle.Fill;
            // 預設載入內建插件
            _plugins.Add(new CrosshairPlugin());
            _plugins.Add(new GridPlugin());

            // 初始化按鍵
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            // 假設在這裡添加按鍵到控制項
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
                Location = new Point(10,45),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button zoomOutButton = new Button
            {
                Text = "-",
                Size = new Size(30, 30),
                Location = new Point(10, 80),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            fitButton.Click += (s, e) => 
            { 
                _zoomLevel = _zoomLevelForControl;
                _position = _positionForFit;
                Invalidate(); 
            };
            zoomInButton.Click += (s, e) => { _zoomLevel *= 1.1f; Invalidate(); };
            zoomOutButton.Click += (s, e) => { _zoomLevel /= 1.1f; Invalidate(); };

            _buttons.Add(fitButton);
            _buttons.Add(zoomInButton);
            _buttons.Add(zoomOutButton);

            // 將按鍵加入到控制項中
            foreach (var button in _buttons)
            {
                Controls.Add(button);
            }
        }

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
                plugin.Draw(e.Graphics, ClientRectangle);
            }
        }
    }
}
