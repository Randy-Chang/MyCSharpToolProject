namespace Project_ImageViewer
{
    partial class Form1
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
            this.plImageViewer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // plImageViewer
            // 
            this.plImageViewer.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.plImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plImageViewer.Location = new System.Drawing.Point(0, 0);
            this.plImageViewer.Name = "plImageViewer";
            this.plImageViewer.Size = new System.Drawing.Size(824, 631);
            this.plImageViewer.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 631);
            this.Controls.Add(this.plImageViewer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plImageViewer;
    }
}

