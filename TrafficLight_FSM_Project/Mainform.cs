using MyCSharpToolProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficLight_FSM;
using TrafficLight_FSM.StatePattern;

namespace TrafficLight_FSM_Project
{
    public partial class Mainform : Form, ITrafficLightUIController
    {
        // readonly修飾，確保不可重新賦值
        private readonly ITrafficLight pack;

        public Mainform(ITrafficLight pack)
        {
            InitializeComponent();

            this.pack = pack ?? throw new ArgumentNullException(nameof(pack));

            #region// 綁定按鈕點擊事件，用 Lambda 表達式
            btnStart.Click += (s, e) => pack.Start();
            btnPause.Click += (s, e) => pack.Pause();
            btnStop.Click += (s, e) => pack.Stop();

            btnSettingDuration.Click += (s, e) =>
            {
                if (int.TryParse(tbRedLightDuration.Text, out int red) &&
                    int.TryParse(tbGreenLightDuration.Text, out int green) &&
                    int.TryParse(tbYellowLightDuration.Text, out int yellow))
                {
                    pack.SetDurations(red, green, yellow);
                }
                else
                {
                    MessageBox.Show("請輸入有效的數字！", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            #endregion
        }

        #region 實作 ITrafficLightUIController 介面
        private void UpdateTrafficLight(Color red, Color yellow, Color green)
        {
            pbRed.BackColor = red;
            pbYellow.BackColor = yellow;
            pbGreen.BackColor = green;
        }

        public void ShowRedLight() => UpdateTrafficLight(Color.Red, Color.Gray, Color.Gray);
        public void ShowYellowLight() => UpdateTrafficLight(Color.Gray, Color.Yellow, Color.Gray);
        public void ShowGreenLight() => UpdateTrafficLight(Color.Gray, Color.Gray, Color.Green);

        public void EnableStartButton(bool enable)
        {
            btnStart.Enabled = enable;
        }

        public void EnablePauseButton(bool enable)
        {
            btnPause.Enabled = enable;
        }

        public void EnableStopButton(bool enable)
        {
            btnStop.Enabled = enable;
        }

        public void ShowTimerState(string timeState)
        {
            ToolFunctions.AsyncSetText(lbTimeNow, timeState);
        }
    }

    #endregion
}
