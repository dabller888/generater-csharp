namespace Generator {
    partial class frmGenerateMain {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.pbTask = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Location = new System.Drawing.Point(12, 12);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateCode.TabIndex = 0;
            this.btnGenerateCode.Text = "生成代码";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // rtbContent
            // 
            this.rtbContent.Location = new System.Drawing.Point(4, 41);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(571, 409);
            this.rtbContent.TabIndex = 1;
            this.rtbContent.Text = "";
            // 
            // pbTask
            // 
            this.pbTask.Location = new System.Drawing.Point(106, 11);
            this.pbTask.Name = "pbTask";
            this.pbTask.Size = new System.Drawing.Size(458, 23);
            this.pbTask.TabIndex = 2;
            // 
            // frmGenerateMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 462);
            this.Controls.Add(this.pbTask);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.btnGenerateCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenerateMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C#架构代码生成器(V1.0.0)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.ProgressBar pbTask;
    }
}

