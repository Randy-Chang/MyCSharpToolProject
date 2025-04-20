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
    /// 定義疊加插件的介面，提供繪製、輸入處理及滑鼠事件的功能。  
    /// </summary>  
    public interface IOverlayPlugin
    {
        /// <summary>  
        /// 插件名稱。  
        /// </summary>  
        string Name { get; }

        /// <summary>  
        /// 指示插件是否啟用。  
        /// </summary>  
        bool IsEnabled { get; set; }

        /// <summary>  
        /// 繪製插件內容到指定的圖形對象上。  
        /// </summary>  
        /// <param name="g">繪圖的 Graphics 對象。</param>  
        /// <param name="image">當前顯示的影像。</param>  
        /// <param name="imagePosition">影像在視窗中的位置。</param>  
        /// <param name="zoomLevel">影像的縮放比例。</param>  
        void Draw(Graphics g, System.Drawing.Image image, PointF imagePosition, float zoomLevel);

        /// <summary>  
        /// 處理鍵盤輸入事件。  
        /// </summary>  
        /// <param name="e">鍵盤事件參數。</param>  
        void HandleInput(KeyEventArgs e);

        /// <summary>  
        /// 處理滑鼠按下事件。  
        /// </summary>  
        /// <param name="e">滑鼠事件參數。</param>  
        /// <param name="imagePosition">影像在視窗中的位置。</param>  
        /// <param name="zoomLevel">影像的縮放比例。</param>  
        void OnMouseDown(MouseEventArgs e, PointF imagePosition, float zoomLevel);

        /// <summary>  
        /// 處理滑鼠移動事件。  
        /// </summary>  
        /// <param name="e">滑鼠事件參數。</param>  
        /// <param name="imagePosition">影像在視窗中的位置。</param>  
        /// <param name="zoomLevel">影像的縮放比例。</param>  
        void OnMouseMove(MouseEventArgs e, PointF imagePosition, float zoomLevel);

        /// <summary>  
        /// 處理滑鼠釋放事件。  
        /// </summary>  
        /// <param name="e">滑鼠事件參數。</param>  
        /// <param name="imagePosition">影像在視窗中的位置。</param>  
        /// <param name="zoomLevel">影像的縮放比例。</param>  
        void OnMouseUp(MouseEventArgs e, PointF imagePosition, float zoomLevel);
    }
}
