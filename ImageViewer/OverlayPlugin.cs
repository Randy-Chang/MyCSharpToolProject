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
        void Draw(Graphics g, Rectangle bounds);
        void HandleInput(KeyEventArgs e); // 保留，但這裡不會用
    }

    public class CrosshairPlugin : IOverlayPlugin
    {
        public string Name => "Crosshair";
        public bool IsEnabled { get; set; } = false;

        public void Draw(Graphics g, Rectangle bounds)
        {
            if (!IsEnabled) return;
            using (var pen = new Pen(Color.Red, 1))
            {
                g.DrawLine(pen, bounds.Width / 2, 0, bounds.Width / 2, bounds.Height);
                g.DrawLine(pen, 0, bounds.Height / 2, bounds.Width, bounds.Height / 2);
            }
        }

        public void HandleInput(KeyEventArgs e) { } // 空實現，按鈕控制
    }

    /// <summary>
    /// 九宮格
    /// </summary>
    public class GridPlugin : IOverlayPlugin
    {
        public string Name => "Grid";
        public bool IsEnabled { get; set; } = false;

        public void Draw(Graphics g, Rectangle bounds)
        {
            if (!IsEnabled) return;
            using (var pen = new Pen(Color.Gray, 1))
            {
                for (int i = 1; i < 3; i++)
                {
                    g.DrawLine(pen, bounds.Width / 3 * i, 0, bounds.Width / 3 * i, bounds.Height);
                    g.DrawLine(pen, 0, bounds.Height / 3 * i, bounds.Width, bounds.Height / 3 * i);
                }
            }
        }

        public void HandleInput(KeyEventArgs e) { } // 空實現，按鈕控制
    }
}
