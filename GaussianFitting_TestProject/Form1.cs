using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCSharpToolProject;
using ZedGraph;

namespace GaussianFitting_TestProject
{
    public partial class Form1 : Form
    {
        ZedGraphControl graphControl;
        IGaussianFitting gaussianFitting;
        private GaussianParameter gaussianParameter;
        List<double> xValues;
        List<double> yValues;
        List<double> yValues_Fitting;
        ToolFunctions.ZGraphParameters_Axis xAxisParameter, yAxisParameter;

        public Form1()
        {
            InitializeComponent();

            ToolFunctions.InitGraph(ref plChart, ref graphControl);
            xAxisParameter = new ToolFunctions.ZGraphParameters_Axis();
            yAxisParameter = new ToolFunctions.ZGraphParameters_Axis();

            // 產生帶有雜訊的高斯波形數據
            GaussianFittingFactory.GenerateNoisyGaussian(out xValues, out yValues);

            yAxisParameter.CurveColor = Color.Black;
            ToolFunctions.PlotChart(graphControl, xValues, yValues, xAxisParameter, yAxisParameter);

            Run();
        }

        void Run()
        {
            Dictionary<EMethod, Color> colors = new Dictionary<EMethod, Color>()
            {
                { EMethod.CaruanasAlgorithm, Color.Blue },
                { EMethod.GuosAlgorithm, Color.Red },
                { EMethod.TwoPoint, Color.Green },
            };

            foreach (EMethod  method in Enum.GetValues(typeof(EMethod)))
            {
                gaussianFitting = GaussianFittingFactory.GetFittingAlgorithm(method);
                gaussianFitting.Fit(xValues, yValues, out gaussianParameter);
                GaussianFittingFactory.GenerateGaussianCurve(xValues, gaussianParameter, out yValues_Fitting);

                yAxisParameter.CurveColor = colors[method];
                ToolFunctions.PlotChart(graphControl, xValues, yValues_Fitting, xAxisParameter, yAxisParameter);
            }
        }
    }
}
