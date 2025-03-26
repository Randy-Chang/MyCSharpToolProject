namespace CoffeeMachineProject
{
    partial class CoffeeMachineForm
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
            this.lbCoffeeMachineType = new System.Windows.Forms.Label();
            this.cmbCoffeeMachineType = new System.Windows.Forms.ComboBox();
            this.lbCoffeeBean = new System.Windows.Forms.Label();
            this.cmbCoffeeBean = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbCoffeeMachinState = new System.Windows.Forms.Label();
            this.rtbCoffeeBeamInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbCoffeeMachineType
            // 
            this.lbCoffeeMachineType.AutoSize = true;
            this.lbCoffeeMachineType.Location = new System.Drawing.Point(12, 25);
            this.lbCoffeeMachineType.Name = "lbCoffeeMachineType";
            this.lbCoffeeMachineType.Size = new System.Drawing.Size(209, 24);
            this.lbCoffeeMachineType.TabIndex = 0;
            this.lbCoffeeMachineType.Text = "Coffee Machine Type :";
            // 
            // cmbCoffeeMachineType
            // 
            this.cmbCoffeeMachineType.FormattingEnabled = true;
            this.cmbCoffeeMachineType.Location = new System.Drawing.Point(227, 22);
            this.cmbCoffeeMachineType.Name = "cmbCoffeeMachineType";
            this.cmbCoffeeMachineType.Size = new System.Drawing.Size(172, 32);
            this.cmbCoffeeMachineType.TabIndex = 1;
            // 
            // lbCoffeeBean
            // 
            this.lbCoffeeBean.AutoSize = true;
            this.lbCoffeeBean.Location = new System.Drawing.Point(93, 75);
            this.lbCoffeeBean.Name = "lbCoffeeBean";
            this.lbCoffeeBean.Size = new System.Drawing.Size(128, 24);
            this.lbCoffeeBean.TabIndex = 2;
            this.lbCoffeeBean.Text = "Coffee Bean :";
            // 
            // cmbCoffeeBean
            // 
            this.cmbCoffeeBean.FormattingEnabled = true;
            this.cmbCoffeeBean.Location = new System.Drawing.Point(227, 72);
            this.cmbCoffeeBean.Name = "cmbCoffeeBean";
            this.cmbCoffeeBean.Size = new System.Drawing.Size(172, 32);
            this.cmbCoffeeBean.TabIndex = 3;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(421, 22);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(91, 82);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // lbCoffeeMachinState
            // 
            this.lbCoffeeMachinState.AutoSize = true;
            this.lbCoffeeMachinState.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lbCoffeeMachinState.Location = new System.Drawing.Point(12, 320);
            this.lbCoffeeMachinState.Name = "lbCoffeeMachinState";
            this.lbCoffeeMachinState.Size = new System.Drawing.Size(170, 24);
            this.lbCoffeeMachinState.TabIndex = 5;
            this.lbCoffeeMachinState.Text = "--------------------";
            this.lbCoffeeMachinState.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // rtbCoffeeBeamInfo
            // 
            this.rtbCoffeeBeamInfo.Location = new System.Drawing.Point(16, 122);
            this.rtbCoffeeBeamInfo.Name = "rtbCoffeeBeamInfo";
            this.rtbCoffeeBeamInfo.Size = new System.Drawing.Size(496, 185);
            this.rtbCoffeeBeamInfo.TabIndex = 6;
            this.rtbCoffeeBeamInfo.Text = "";
            // 
            // CoffeeMachineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 368);
            this.Controls.Add(this.rtbCoffeeBeamInfo);
            this.Controls.Add(this.lbCoffeeMachinState);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cmbCoffeeBean);
            this.Controls.Add(this.lbCoffeeBean);
            this.Controls.Add(this.cmbCoffeeMachineType);
            this.Controls.Add(this.lbCoffeeMachineType);
            this.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CoffeeMachineForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCoffeeMachineType;
        private System.Windows.Forms.ComboBox cmbCoffeeMachineType;
        private System.Windows.Forms.Label lbCoffeeBean;
        private System.Windows.Forms.ComboBox cmbCoffeeBean;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lbCoffeeMachinState;
        private System.Windows.Forms.RichTextBox rtbCoffeeBeamInfo;
    }
}

