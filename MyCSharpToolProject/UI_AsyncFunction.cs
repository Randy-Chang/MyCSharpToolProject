using System;
using System.Collections.Generic;
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
    }
}
