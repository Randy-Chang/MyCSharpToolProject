using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace MyCSharpToolProject
{
    public static partial class ToolFunctions
    {
        public static void InitGraph(ref Panel pl, ref ZedGraphControl graph)
        {
            pl.Controls.Clear();
            graph = new ZedGraphControl();
            graph.Parent = pl;
            graph.Dock = DockStyle.Fill;
            GraphPane pane = graph.GraphPane;

            graph.Invalidate();
        }

        public static void PlotChart(ZedGraphControl graph, List<double> xDatas, List<double> yDatas,
                                            ZGraphParameters_Axis xParam, ZGraphParameters_Axis yParam)
        {
            try
            {
                GraphPane Pane = graph.GraphPane;
                Pane.Title.IsVisible = false;

                #region 載入資料畫出曲線
                Color CurveColor = yParam.CurveColor;
                SymbolType CurveSymbol = yParam.CurveSymbol;
                PointPairList PPList = new PointPairList();
                double X = 0;
                double Y = 0;

                for (int i = 0; i < xDatas.Count; i++)
                {
                    X = xDatas[i];
                    Y = yDatas[i];
                    PPList.Add(X, Y);
                }

                LineItem myCurve = Pane.AddCurve($"", PPList, CurveColor, CurveSymbol);
                myCurve.IsY2Axis = false;
                myCurve.Line.Width = 1.80F;
                #endregion


                #region X軸參數
                double X_ScaleMin = yParam.ScaleMin;
                double X_ScaleMax = yParam.ScaleMax;
                bool X_ScaleIsDefault = xParam.ScaleIsCustom;

                Pane.XAxis.Title.Text = xParam.Title;

                if (X_ScaleIsDefault)
                {
                    Pane.XAxis.Scale.Min = X_ScaleMin;
                    Pane.XAxis.Scale.Max = X_ScaleMax;
                }
                #endregion

                #region Y軸參數
                double Y_ScaleMin = yParam.ScaleMin;
                double Y_ScaleMax = yParam.ScaleMax;
                bool Y_ScaleIsDefault = yParam.ScaleIsCustom;

                Pane.YAxis.Title.Text = yParam.Title;

                if (Y_ScaleIsDefault)
                {
                    Pane.YAxis.Scale.Min = Y_ScaleMin;
                    Pane.YAxis.Scale.Max = Y_ScaleMax;
                }
                #endregion

                graph.AxisChange();
                graph.Invalidate();
            }
            catch (Exception exp)
            {

            }
        }


        public static void PlotChart(ZedGraphControl graph, List<double> xDatas, List<List<double>> yDatas,
                                            ZGraphParameters_Axis xParam, ZGraphParameters_Axis yParam)
        {
            try
            {
                GraphPane Pane = graph.GraphPane;
                Pane.Title.IsVisible = false;

                #region 載入資料畫出曲線
                SymbolType CurveSymbol = yParam.CurveSymbol;

                double X = 0;
                double Y = 0;
                List<Color> colors = GenerateDistinctColors(yDatas.Count);

                for (int j = 0; j < yDatas.Count; j++)
                {
                    PointPairList PPList = new PointPairList();
                    Random rnd = new Random();

                    for (int i = 0; i < xDatas.Count; i++)
                    {
                        X = xDatas[i];
                        Y = yDatas[j][i];
                        PPList.Add(X, Y);
                    }

                    Color CurveColor = colors[j];
                    LineItem myCurve = Pane.AddCurve($"{j}", PPList, CurveColor, CurveSymbol);
                    myCurve.IsY2Axis = false;
                    myCurve.Line.Width = 2.0F;
                }
                #endregion

                #region X軸參數
                double X_ScaleMin = yParam.ScaleMin;
                double X_ScaleMax = yParam.ScaleMax;
                bool X_ScaleIsDefault = xParam.ScaleIsCustom;

                Pane.XAxis.Title.Text = xParam.Title;

                if (X_ScaleIsDefault)
                {
                    Pane.XAxis.Scale.Min = X_ScaleMin;
                    Pane.XAxis.Scale.Max = X_ScaleMax;
                }
                #endregion

                #region Y軸參數
                double Y_ScaleMin = yParam.ScaleMin;
                double Y_ScaleMax = yParam.ScaleMax;
                bool Y_ScaleIsDefault = yParam.ScaleIsCustom;

                Pane.YAxis.Title.Text = yParam.Title;

                if (Y_ScaleIsDefault)
                {
                    Pane.YAxis.Scale.Min = Y_ScaleMin;
                    Pane.YAxis.Scale.Max = Y_ScaleMax;
                }
                #endregion

                graph.AxisChange();
                graph.Invalidate();
            }
            catch (Exception exp)
            {

            }
        }


        #region 顏色取得
        static List<Color> GenerateDistinctColors(int count)
        {
            if (count < 1)
                throw new ArgumentException("Count must be at least 1.");

            List<Color> colors = new List<Color>();
            double goldenRatioConjugate = 0.618033988749895; // 用黃金比例分隔色相
            double hue = 0; // 初始色相

            for (int i = 0; i < count; i++)
            {
                // 確保顏色不接近白色 (避免高亮)
                double saturation = 0.6 + (i % 2) * 0.3; // 交替使用高飽和度和中等飽和度
                double brightness = 0.7;

                // HSV 轉 RGB
                Color color = ColorFromHSV(hue * 360, saturation, brightness);
                colors.Add(color);

                // 更新色相 (用黃金比例分隔，避免色彩過於相近)
                hue += goldenRatioConjugate;
                hue %= 1; // 保證在 [0, 1] 之間
            }

            return colors;
        }

        static Color ColorFromHSV(double hue, double saturation, double brightness)
        {
            double chroma = brightness * saturation;
            double x = chroma * (1 - Math.Abs((hue / 60) % 2 - 1));
            double m = brightness - chroma;

            double r = 0, g = 0, b = 0;

            if (hue < 60)
            {
                r = chroma; g = x; b = 0;
            }
            else if (hue < 120)
            {
                r = x; g = chroma; b = 0;
            }
            else if (hue < 180)
            {
                r = 0; g = chroma; b = x;
            }
            else if (hue < 240)
            {
                r = 0; g = x; b = chroma;
            }
            else if (hue < 300)
            {
                r = x; g = 0; b = chroma;
            }
            else
            {
                r = chroma; g = 0; b = x;
            }

            return Color.FromArgb(
                (int)((r + m) * 255),
                (int)((g + m) * 255),
                (int)((b + m) * 255)
            );
        }
        #endregion


        /// <summary>
        /// 圖參數
        /// </summary>
        public class ZGraphParameters_Axis
        {
            public string Title { get; set; }
            public Color TitleFontColor { get; set; }

            public double ScaleMin { get; set; }
            public double ScaleMax { get; set; }

            public bool ScaleIsCustom { get; set; }
            public double FontSpecSize { get; set; }
            public Color ScaleFontColor { get; set; }



            public SymbolType CurveSymbol { get; set; } = SymbolType.None;
            public Color CurveColor { get; set; }
            public float LineWidth { get; set; }

        }
    }
}
