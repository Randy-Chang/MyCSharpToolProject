using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCSharpToolProject
{
    public static partial class ToolFunctions
    {
        public delegate void SetEnabledCallback(Control cntr, bool b);
        public delegate void SetTextCallback(Control cntr, string text);
        public delegate void SetValueCallback(ProgressBar pgb, int value);

        /// <summary>
        /// Asynchronously sets the Enabled property of a control.
        /// 異步設置控件的Enabled屬性。
        /// </summary>
        /// <param name="cntr">The control to set the Enabled property on. 要設置Enabled屬性的控件。</param>
        /// <param name="b">The value to set the Enabled property to. 要設置的Enabled屬性值。</param>
        public static void AsyncSetEnabled(Control cntr, bool b)
        {
            try
            {
                if (cntr.InvokeRequired)
                {
                    SetEnabledCallback d = new SetEnabledCallback(AsyncSetEnabled);
                    cntr.BeginInvoke(d, new object[] { cntr, b });
                }
                else
                    cntr.Enabled = b;
            }
            catch (Exception e)
            {
                //WriteLog(DateTime.Now.ToLongTimeString() + " : " + cntr.Name + " , AsyncSetColor " + e.Message);
            }
        }

        /// <summary>
        /// Asynchronously sets the Text property of a control.
        /// 異步設置控件的Text屬性。
        /// </summary>
        /// <param name="cntr">The control to set the Text property on. 要設置Text屬性的控件。</param>
        /// <param name="text">The value to set the Text property to. 要設置的Text屬性值。</param>
        public static void AsyncSetText(Control cntr, string text)
        {
            try
            {
                // 檢查是否需要透過 Invoke 回到 UI 執行緒
                if (cntr.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(AsyncSetText);
                    cntr.BeginInvoke(d, new object[] { cntr, text });
                }
                else
                    cntr.Text = text;
            }
            catch (Exception e)
            {
                //WriteLog(DateTime.Now.ToLongTimeString() + " : " + cntr.Name + " , AsyncSetColor " + e.Message);
            }
        }

        /// <summary>
        /// Asynchronously sets the Value property of a ProgressBar.
        /// 異步設置ProgressBar的Value屬性。
        /// </summary>
        /// <param name="pgb">The ProgressBar to set the Value property on. 要設置Value屬性的ProgressBar。</param>
        /// <param name="value">The value to set the Value property to. 要設置的Value屬性值。</param>
        public static void AsyncProgressBarSetValue(ProgressBar pgb, int value)
        {
            try
            {
                // 檢查是否需要透過 Invoke 回到 UI 執行緒
                if (pgb.InvokeRequired)
                {
                    SetValueCallback d = new SetValueCallback(AsyncProgressBarSetValue);
                    pgb.BeginInvoke(d, new object[] { pgb, value });
                }
                else
                    pgb.Value = value;
            }
            catch (Exception e)
            {
                //WriteLog(DateTime.Now.ToLongTimeString() + " : " + cntr.Name + " , AsyncSetColor " + e.Message);
            }
        }

        /// <summary>
        /// Asynchronously sets the Maximum property of a ProgressBar.
        /// 異步設置ProgressBar的Maximum屬性。
        /// </summary>
        /// <param name="pgb">The ProgressBar to set the Maximum property on. 要設置Maximum屬性的ProgressBar。</param>
        /// <param name="value">The value to set the Maximum property to. 要設置的Maximum屬性值。</param>
        public static void AsyncProgressBarSetMaximum(ProgressBar pgb, int value)
        {
            try
            {
                // 檢查是否需要透過 Invoke 回到 UI 執行緒
                if (pgb.InvokeRequired)
                {
                    SetValueCallback d = new SetValueCallback(AsyncProgressBarSetMaximum);
                    pgb.BeginInvoke(d, new object[] { pgb, value });
                }
                else
                    pgb.Maximum = value;
            }
            catch (Exception e)
            {
                //WriteLog(DateTime.Now.ToLongTimeString() + " : " + cntr.Name + " , AsyncSetColor " + e.Message);
            }
        }

        /// <summary>
        /// Asynchronously sets the Text and ForeColor properties of a control.
        /// 異步設置控件的Text與ForeColor屬性。
        /// </summary>
        /// <param name="cntr">The control to set the properties on. 要設置屬性的控件。</param>
        /// <param name="text">The value to set the Text property to. 要設置的Text屬性值。</param>
        /// <param name="color">The value to set the ForeColor property to. 要設置的ForeColor屬性值。</param>
        public static void AsyncSetTextAndForeColor(Control cntr, string text, Color color)
        {
            try
            {
                if (cntr.InvokeRequired)
                {
                    cntr.BeginInvoke(new Action(() => AsyncSetTextAndForeColor(cntr, text, color)));
                }
                else
                {
                    cntr.Text = text;
                    cntr.ForeColor = color;
                }
            }
            catch (Exception e)
            {
                //WriteLog(DateTime.Now.ToLongTimeString() + " : " + cntr.Name + " , AsyncSetTextAndForeColor " + e.Message);
            }
        }

        /// <summary>
        /// Asynchronously sets the Location property of a control.
        /// 異步設置控件的Location屬性。
        /// </summary>
        /// <param name="cntr">The control to set the Location property on. 要設置Location屬性的控件。</param>
        /// <param name="location">The value to set the Location property to. 要設置的Location屬性值。</param>
        public static void AsyncSetLocation(Control cntr, Point location)
        {
            try
            {
                if (cntr.InvokeRequired)
                {
                    cntr.BeginInvoke(new Action(() => AsyncSetLocation(cntr, location)));
                }
                else
                {
                    cntr.Location = location;
                }
            }
            catch (Exception e)
            {
                //WriteLog(DateTime.Now.ToLongTimeString() + " : " + cntr.Name + " , AsyncSetLocation " + e.Message);
            }
        }

    }
}
