using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpToolProject
{
    /*
     * 參考文獻
     * COMPARISON OF ALGORITHMS FOR FITTING A GAUSSIAN FUNCTION USED IN TESTING SMART SENSORS
     * 網址 https://intapi.sciendo.com/pdf/10.2478/jee-2015-0029
     */

    public enum EMethod { TwoPoint, CaruanasAlgorithm, GuosAlgorithm }

    public static class GaussianFittingFactory
    {
        public static IGaussianFitting GetFittingAlgorithm(EMethod method)
        {
            switch (method)
            {
                case EMethod.TwoPoint:
                    return new TwoPointFitting();
                case EMethod.CaruanasAlgorithm:
                    return new CaruanasAlgorithmFitting();
                case EMethod.GuosAlgorithm:
                    return new GuosAlgorithmFitting();
                default:
                    throw new ArgumentException("未知的高斯擬合方法");
            }
        }
    }

    #region Gaussian Fitting Algorithm

    /// <summary>
    /// 使用兩點法擬合高斯分佈
    /// </summary>
    public class TwoPointFitting : IGaussianFitting
    {
        double ampRatio = 0.5; // 這裡可以讓使用者輸入，單位[%]

        #region 實作IGaussianFitting
        /// <summary>
        /// 設定振幅比例條件
        /// </summary>
        /// <param name="ampRatio">振幅比例</param>
        public void InputAmpRatioConditionByTwoPoint(double ampRatio)
        {
            this.ampRatio = ampRatio;
        }

        /// <summary>
        /// 執行高斯擬合
        /// </summary>
        /// <param name="xData">X 軸數據</param>
        /// <param name="yData">Y 軸數據</param>
        /// <param name="gaussianParameter">輸出的高斯參數</param>
        public void Fit(List<double> xData, List<double> yData, out GaussianParameter gaussianParameter)
        {
            TwoPointMethod(xData, yData, ampRatio, out gaussianParameter);
        }
        #endregion

        #region Calculate Function
        /// <summary>
        /// 使用兩點法計算高斯參數
        /// </summary>
        /// <param name="xData">X 軸數據</param>
        /// <param name="yData">Y 軸數據</param>
        /// <param name="ampRatio">振幅比例</param>
        /// <param name="gaussianParameter">輸出的高斯參數</param>
        private void TwoPointMethod(List<double> xData, List<double> yData, double ampRatio,
                                                    out GaussianParameter gaussianParameter)
        {
            double Max = yData.Max();
            double Target = Max * ampRatio;
            int indexMax = yData.IndexOf(Max);

            double xLeft = FindLeftPoint(Target, indexMax, xData, yData);
            double xRight = FindRightPoint(Target, indexMax, xData, yData);

            double amp = Max;
            double mu = xData[indexMax];
            double sigma = Math.Sqrt((Math.Pow(xRight - mu, 2) + Math.Pow(xLeft - mu, 2)) / (2 * Math.Log(2)));

            gaussianParameter = new GaussianParameter { amp = amp, mu = mu, sigma = sigma };
        }

        /// <summary>
        /// 找到左側點
        /// </summary>
        /// <param name="Target">目標振幅值</param>
        /// <param name="indexMax">最大值索引</param>
        /// <param name="xData">X 軸數據</param>
        /// <param name="yData">Y 軸數據</param>
        /// <returns>左側對應的 X 軸數值</returns>
        private double FindLeftPoint(double Target, int indexMax, List<double> xData, List<double> yData)
        {
            for (int i = indexMax; i >= 0; i--)
            {
                if (yData[i] <= Target) return xData[i];
            }
            return xData[0];
        }

        /// <summary>
        /// 找到右側點
        /// </summary>
        /// <param name="Target">目標振幅值</param>
        /// <param name="indexMax">最大值索引</param>
        /// <param name="xData">X 軸數據</param>
        /// <param name="yData">Y 軸數據</param>
        /// <returns>右側對應的 X 軸數值</returns>
        private double FindRightPoint(double Target, int indexMax, List<double> xData, List<double> yData)
        {
            for (int i = indexMax; i < yData.Count; i++)
            {
                if (yData[i] <= Target) return xData[i];
            }
            return xData[xData.Count - 1];
        }
        #endregion

    }

    /// <summary>
    /// 使用 Caruana's Algorithm 擬合高斯分佈
    /// </summary>
    public class CaruanasAlgorithmFitting : IGaussianFitting
    {
        #region 實作IGaussianFitting
        /// <summary>
        /// 執行高斯擬合
        /// </summary>
        /// <param name="xData">X 軸數據</param>
        /// <param name="yData">Y 軸數據</param>
        /// <param name="gaussianParameter">輸出的高斯參數</param>
        public void Fit(List<double> xData, List<double> yData, out GaussianParameter gaussianParameter)
        {
            CARUANAS_ALGORITHM(xData, yData, out gaussianParameter);
        }

        /// <summary>
        /// 設定振幅比例條件（目前未實作）
        /// </summary>
        /// <param name="ampRatio">振幅比例</param>
        public void InputAmpRatioConditionByTwoPoint(double ampRatio)
        {

        }
        #endregion

        #region Calculate Function
        /// <summary>
        /// 使用 Caruana's Algorithm 計算高斯參數
        /// </summary>
        /// <param name="xData">X 軸數據</param>
        /// <param name="yData">Y 軸數據</param>
        /// <param name="gaussianParameter">輸出的高斯參數</param>
        private void CARUANAS_ALGORITHM(List<double> xData, List<double> yData, out GaussianParameter gaussianParameter)
        {
            gaussianParameter = new GaussianParameter();

            double term11 = 0;
            double term12 = 0;
            double term13 = 0;
            double term21 = 0;
            double term22 = 0;
            double term23 = 0;
            double term31 = 0;
            double term32 = 0;
            double term33 = 0;
            double termY1 = 0;
            double termY2 = 0;
            double termY3 = 0;

            int count = yData.Count;

            for (int i = 0; i < count; i++)
            {
                term11 += Math.Pow(yData[i], 2);
                term12 += xData[i] * Math.Pow(yData[i], 2);
                term13 += Math.Pow(xData[i], 2) * Math.Pow(yData[i], 2);
                term21 += xData[i] * Math.Pow(yData[i], 2);
                term22 += Math.Pow(xData[i], 2) * Math.Pow(yData[i], 2);
                term23 += Math.Pow(xData[i], 3) * Math.Pow(yData[i], 2);
                term31 += Math.Pow(xData[i], 2) * Math.Pow(yData[i], 2);
                term32 += Math.Pow(xData[i], 3) * Math.Pow(yData[i], 2);
                term33 += Math.Pow(xData[i], 4) * Math.Pow(yData[i], 2);
                termY1 += Math.Log(Math.Abs(yData[i])) * Math.Pow(yData[i], 2);
                termY2 += Math.Log(Math.Abs(yData[i])) * xData[i] * Math.Pow(yData[i], 2);
                termY3 += Math.Log(Math.Abs(yData[i])) * xData[i] * xData[i] * Math.Pow(yData[i], 2);
            }

            double delta = term11 * term22 * term33 + term21 * term32 * term13 + term12 * term23 * term31
                            - term13 * term22 * term31 - term12 * term21 * term33 - term11 * term23 * term32;

            double delta_x1 = termY1 * term22 * term33 + termY2 * term32 * term13 + term12 * term23 * termY3
                            - term13 * term22 * termY3 - term12 * termY2 * term33 - termY1 * term23 * term32;

            double delta_x2 = term11 * termY2 * term33 + term21 * termY3 * term13 + termY1 * term23 * term31
                            - term13 * termY2 * term31 - termY1 * term21 * term33 - term11 * term23 * termY3;

            double delta_x3 = term11 * term22 * termY3 + term21 * term32 * termY1 + term12 * termY2 * term31
                            - termY1 * term22 * term31 - term12 * term21 * termY3 - term11 * termY2 * term32;

            double a = delta_x1 / delta;
            double b = delta_x2 / delta;
            double c = delta_x3 / delta;

            double mu = -1 * b / (2 * c);
            double sigma = Math.Sqrt(-1 / (2 * c));
            double A = Math.Exp(a - b * b / (4 * c));

            gaussianParameter = new GaussianParameter { amp = A, mu = mu, sigma = sigma };
        }
        #endregion
    }


    /// <summary>
    /// 使用 Guo's Algorithm 擬合高斯分佈
    /// </summary>
    public class GuosAlgorithmFitting : IGaussianFitting
    {
        #region 實作IGaussianFitting
        /// <summary>
        /// 執行高斯擬合
        /// </summary>
        /// <param name="xData">X 軸數據</param>
        /// <param name="yData">Y 軸數據</param>
        /// <param name="gaussianParameter">輸出的高斯參數</param>
        public void Fit(List<double> xData, List<double> yData, out GaussianParameter gaussianParameter)
        {
            GUOS_ALGORITHM(xData, yData, out gaussianParameter);
        }

        /// <summary>
        /// 設定振幅比例條件（目前未實作）
        /// </summary>
        /// <param name="ampRatio">振幅比例</param>
        public void InputAmpRatioConditionByTwoPoint(double ampRatio)
        {

        }
        #endregion

        #region Calculate Function
        /// <summary>
        /// 使用 Guo's Algorithm 計算高斯參數
        /// </summary>
        /// <param name="xData">X 軸數據</param>
        /// <param name="yData">Y 軸數據</param>
        /// <param name="gaussianParameter">輸出的高斯參數</param>
        private void GUOS_ALGORITHM(List<double> xData, List<double> yData, out GaussianParameter gaussianParameter)
        {
            gaussianParameter = new GaussianParameter();

            double term11 = 0;
            double term12 = 0;
            double term13 = 0;
            double term21 = 0;
            double term22 = 0;
            double term23 = 0;
            double term31 = 0;
            double term32 = 0;
            double term33 = 0;
            double termY1 = 0;
            double termY2 = 0;
            double termY3 = 0;

            int count = yData.Count;

            for (int i = 0; i < count; i++)
            {
                term11 += Math.Pow(yData[i], 2);
                term12 += xData[i] * Math.Pow(yData[i], 2);
                term13 += Math.Pow(xData[i], 2) * Math.Pow(yData[i], 2);
                term21 += xData[i] * Math.Pow(yData[i], 2);
                term22 += Math.Pow(xData[i], 2) * Math.Pow(yData[i], 2);
                term23 += Math.Pow(xData[i], 3) * Math.Pow(yData[i], 2);
                term31 += Math.Pow(xData[i], 2) * Math.Pow(yData[i], 2);
                term32 += Math.Pow(xData[i], 3) * Math.Pow(yData[i], 2);
                term33 += Math.Pow(xData[i], 4) * Math.Pow(yData[i], 2);
                termY1 += Math.Log(Math.Abs(yData[i])) * Math.Pow(yData[i], 2);
                termY2 += Math.Log(Math.Abs(yData[i])) * xData[i] * Math.Pow(yData[i], 2);
                termY3 += Math.Log(Math.Abs(yData[i])) * xData[i] * xData[i] * Math.Pow(yData[i], 2);
            }

            double delta = term11 * term22 * term33 + term21 * term32 * term13 + term12 * term23 * term31
                            - term13 * term22 * term31 - term12 * term21 * term33 - term11 * term23 * term32;

            double delta_x1 = termY1 * term22 * term33 + termY2 * term32 * term13 + term12 * term23 * termY3
                            - term13 * term22 * termY3 - term12 * termY2 * term33 - termY1 * term23 * term32;

            double delta_x2 = term11 * termY2 * term33 + term21 * termY3 * term13 + termY1 * term23 * term31
                            - term13 * termY2 * term31 - termY1 * term21 * term33 - term11 * term23 * termY3;

            double delta_x3 = term11 * term22 * termY3 + term21 * term32 * termY1 + term12 * termY2 * term31
                            - termY1 * term22 * term31 - term12 * term21 * termY3 - term11 * termY2 * term32;

            double a = delta_x1 / delta;
            double b = delta_x2 / delta;
            double c = delta_x3 / delta;

            double mu = -1 * b / (2 * c);
            double sigma = Math.Sqrt(-1 / (2 * c));
            double A = Math.Exp(a - b * b / (4 * c));

            gaussianParameter = new GaussianParameter { amp = A, mu = mu, sigma = sigma };
        }
        #endregion
    }

    #endregion

    public interface IGaussianFitting
    {
        void InputAmpRatioConditionByTwoPoint(double ampRatio);

        void Fit(List<double> xData, List<double> yData, out GaussianParameter gaussianParameter);
    }

    public class GaussianParameter
    {
        public double amp = 0;
        public double mu = 0;
        public double sigma = 0;
    }
}
