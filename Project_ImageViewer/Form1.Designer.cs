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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnSaveRoiImage = new System.Windows.Forms.Button();
            this.plRoiImage = new System.Windows.Forms.Panel();
            this.btnMatch = new System.Windows.Forms.Button();
            this.btnShowMatchResult = new System.Windows.Forms.Button();
            this.plOperate = new System.Windows.Forms.Panel();
            this.plOperate.SuspendLayout();
            this.SuspendLayout();
            // 
            // plImageViewer
            // 
            this.plImageViewer.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.plImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plImageViewer.Location = new System.Drawing.Point(0, 0);
            this.plImageViewer.Margin = new System.Windows.Forms.Padding(6);
            this.plImageViewer.Name = "plImageViewer";
            this.plImageViewer.Size = new System.Drawing.Size(882, 600);
            this.plImageViewer.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(882, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(6);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 600);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // btnSaveRoiImage
            // 
            this.btnSaveRoiImage.Location = new System.Drawing.Point(21, 319);
            this.btnSaveRoiImage.Name = "btnSaveRoiImage";
            this.btnSaveRoiImage.Size = new System.Drawing.Size(400, 52);
            this.btnSaveRoiImage.TabIndex = 2;
            this.btnSaveRoiImage.Text = "Save Roi Image";
            this.btnSaveRoiImage.UseVisualStyleBackColor = true;
            // 
            // plRoiImage
            // 
            this.plRoiImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.plRoiImage.Location = new System.Drawing.Point(21, 13);
            this.plRoiImage.Name = "plRoiImage";
            this.plRoiImage.Size = new System.Drawing.Size(400, 300);
            this.plRoiImage.TabIndex = 3;
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(21, 377);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(400, 52);
            this.btnMatch.TabIndex = 4;
            this.btnMatch.Text = "Match";
            this.btnMatch.UseVisualStyleBackColor = true;
            // 
            // btnShowMatchResult
            // 
            this.btnShowMatchResult.Location = new System.Drawing.Point(21, 435);
            this.btnShowMatchResult.Name = "btnShowMatchResult";
            this.btnShowMatchResult.Size = new System.Drawing.Size(400, 52);
            this.btnShowMatchResult.TabIndex = 5;
            this.btnShowMatchResult.Text = "Show Match Result";
            this.btnShowMatchResult.UseVisualStyleBackColor = true;
            // 
            // plOperate
            // 
            this.plOperate.Controls.Add(this.btnShowMatchResult);
            this.plOperate.Controls.Add(this.plRoiImage);
            this.plOperate.Controls.Add(this.btnMatch);
            this.plOperate.Controls.Add(this.btnSaveRoiImage);
            this.plOperate.Dock = System.Windows.Forms.DockStyle.Right;
            this.plOperate.Location = new System.Drawing.Point(892, 0);
            this.plOperate.Name = "plOperate";
            this.plOperate.Size = new System.Drawing.Size(546, 600);
            this.plOperate.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 600);
            this.Controls.Add(this.plImageViewer);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.plOperate);
            this.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.plOperate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plImageViewer;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnSaveRoiImage;
        private System.Windows.Forms.Panel plRoiImage;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.Button btnShowMatchResult;
        private System.Windows.Forms.Panel plOperate;
    }
}

