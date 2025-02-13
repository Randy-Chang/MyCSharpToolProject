namespace TrafficLight_FSM_Project
{
    partial class Mainform
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbLight = new System.Windows.Forms.GroupBox();
            this.pbYellow = new System.Windows.Forms.PictureBox();
            this.pbGreen = new System.Windows.Forms.PictureBox();
            this.pbRed = new System.Windows.Forms.PictureBox();
            this.gbSettingDuration = new System.Windows.Forms.GroupBox();
            this.btnSettingDuration = new System.Windows.Forms.Button();
            this.lbYellowLight = new System.Windows.Forms.Label();
            this.lbGreenLight = new System.Windows.Forms.Label();
            this.tbYellowLightDuration = new System.Windows.Forms.TextBox();
            this.tbGreenLightDuration = new System.Windows.Forms.TextBox();
            this.lbRedLight = new System.Windows.Forms.Label();
            this.tbRedLightDuration = new System.Windows.Forms.TextBox();
            this.lbTimeNow = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.gbLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).BeginInit();
            this.gbSettingDuration.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLight
            // 
            this.gbLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gbLight.Controls.Add(this.pbYellow);
            this.gbLight.Controls.Add(this.pbGreen);
            this.gbLight.Controls.Add(this.pbRed);
            this.gbLight.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbLight.Location = new System.Drawing.Point(12, 12);
            this.gbLight.Name = "gbLight";
            this.gbLight.Size = new System.Drawing.Size(270, 121);
            this.gbLight.TabIndex = 0;
            this.gbLight.TabStop = false;
            this.gbLight.Text = "Light";
            // 
            // pbYellow
            // 
            this.pbYellow.BackColor = System.Drawing.Color.Black;
            this.pbYellow.Location = new System.Drawing.Point(178, 32);
            this.pbYellow.Name = "pbYellow";
            this.pbYellow.Size = new System.Drawing.Size(80, 80);
            this.pbYellow.TabIndex = 3;
            this.pbYellow.TabStop = false;
            // 
            // pbGreen
            // 
            this.pbGreen.BackColor = System.Drawing.Color.Black;
            this.pbGreen.Location = new System.Drawing.Point(92, 32);
            this.pbGreen.Name = "pbGreen";
            this.pbGreen.Size = new System.Drawing.Size(80, 80);
            this.pbGreen.TabIndex = 2;
            this.pbGreen.TabStop = false;
            // 
            // pbRed
            // 
            this.pbRed.BackColor = System.Drawing.Color.Black;
            this.pbRed.Location = new System.Drawing.Point(6, 32);
            this.pbRed.Name = "pbRed";
            this.pbRed.Size = new System.Drawing.Size(80, 80);
            this.pbRed.TabIndex = 1;
            this.pbRed.TabStop = false;
            // 
            // gbSettingDuration
            // 
            this.gbSettingDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gbSettingDuration.Controls.Add(this.btnSettingDuration);
            this.gbSettingDuration.Controls.Add(this.lbYellowLight);
            this.gbSettingDuration.Controls.Add(this.lbGreenLight);
            this.gbSettingDuration.Controls.Add(this.tbYellowLightDuration);
            this.gbSettingDuration.Controls.Add(this.tbGreenLightDuration);
            this.gbSettingDuration.Controls.Add(this.lbRedLight);
            this.gbSettingDuration.Controls.Add(this.tbRedLightDuration);
            this.gbSettingDuration.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbSettingDuration.Location = new System.Drawing.Point(288, 12);
            this.gbSettingDuration.Name = "gbSettingDuration";
            this.gbSettingDuration.Size = new System.Drawing.Size(270, 206);
            this.gbSettingDuration.TabIndex = 4;
            this.gbSettingDuration.TabStop = false;
            this.gbSettingDuration.Text = "Setting Duration";
            // 
            // btnSettingDuration
            // 
            this.btnSettingDuration.Location = new System.Drawing.Point(24, 149);
            this.btnSettingDuration.Name = "btnSettingDuration";
            this.btnSettingDuration.Size = new System.Drawing.Size(222, 43);
            this.btnSettingDuration.TabIndex = 8;
            this.btnSettingDuration.Text = "Setting";
            this.btnSettingDuration.UseVisualStyleBackColor = true;
            // 
            // lbYellowLight
            // 
            this.lbYellowLight.AutoSize = true;
            this.lbYellowLight.Location = new System.Drawing.Point(20, 113);
            this.lbYellowLight.Name = "lbYellowLight";
            this.lbYellowLight.Size = new System.Drawing.Size(131, 24);
            this.lbYellowLight.TabIndex = 7;
            this.lbYellowLight.Text = "Yellow Light :";
            // 
            // lbGreenLight
            // 
            this.lbGreenLight.AutoSize = true;
            this.lbGreenLight.Location = new System.Drawing.Point(24, 74);
            this.lbGreenLight.Name = "lbGreenLight";
            this.lbGreenLight.Size = new System.Drawing.Size(127, 24);
            this.lbGreenLight.TabIndex = 6;
            this.lbGreenLight.Text = "Green Light :";
            // 
            // tbYellowLightDuration
            // 
            this.tbYellowLightDuration.Location = new System.Drawing.Point(155, 110);
            this.tbYellowLightDuration.Name = "tbYellowLightDuration";
            this.tbYellowLightDuration.Size = new System.Drawing.Size(91, 33);
            this.tbYellowLightDuration.TabIndex = 5;
            // 
            // tbGreenLightDuration
            // 
            this.tbGreenLightDuration.Location = new System.Drawing.Point(155, 71);
            this.tbGreenLightDuration.Name = "tbGreenLightDuration";
            this.tbGreenLightDuration.Size = new System.Drawing.Size(91, 33);
            this.tbGreenLightDuration.TabIndex = 4;
            // 
            // lbRedLight
            // 
            this.lbRedLight.AutoSize = true;
            this.lbRedLight.Location = new System.Drawing.Point(44, 35);
            this.lbRedLight.Name = "lbRedLight";
            this.lbRedLight.Size = new System.Drawing.Size(107, 24);
            this.lbRedLight.TabIndex = 0;
            this.lbRedLight.Text = "Red Light :";
            // 
            // tbRedLightDuration
            // 
            this.tbRedLightDuration.Location = new System.Drawing.Point(155, 32);
            this.tbRedLightDuration.Name = "tbRedLightDuration";
            this.tbRedLightDuration.Size = new System.Drawing.Size(91, 33);
            this.tbRedLightDuration.TabIndex = 3;
            // 
            // lbTimeNow
            // 
            this.lbTimeNow.AutoSize = true;
            this.lbTimeNow.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbTimeNow.Location = new System.Drawing.Point(14, 136);
            this.lbTimeNow.Name = "lbTimeNow";
            this.lbTimeNow.Size = new System.Drawing.Size(94, 24);
            this.lbTimeNow.TabIndex = 9;
            this.lbTimeNow.Text = "Timer : --";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(12, 175);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(85, 65);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStop.Location = new System.Drawing.Point(103, 175);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(85, 65);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPause.Location = new System.Drawing.Point(194, 175);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(85, 65);
            this.btnPause.TabIndex = 12;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 255);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbTimeNow);
            this.Controls.Add(this.gbSettingDuration);
            this.Controls.Add(this.gbLight);
            this.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Mainform";
            this.Text = "Form1";
            this.gbLight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).EndInit();
            this.gbSettingDuration.ResumeLayout(false);
            this.gbSettingDuration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLight;
        private System.Windows.Forms.PictureBox pbYellow;
        private System.Windows.Forms.PictureBox pbGreen;
        private System.Windows.Forms.PictureBox pbRed;
        private System.Windows.Forms.GroupBox gbSettingDuration;
        private System.Windows.Forms.TextBox tbGreenLightDuration;
        private System.Windows.Forms.TextBox tbRedLightDuration;
        private System.Windows.Forms.Label lbRedLight;
        private System.Windows.Forms.TextBox tbYellowLightDuration;
        private System.Windows.Forms.Label lbYellowLight;
        private System.Windows.Forms.Label lbGreenLight;
        private System.Windows.Forms.Button btnSettingDuration;
        private System.Windows.Forms.Label lbTimeNow;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
    }
}

