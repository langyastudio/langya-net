namespace Test
{
    partial class APIFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.upload_btn = new CCWin.SkinControl.SkinButton();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // upload_btn
            // 
            this.upload_btn.BackColor = System.Drawing.Color.Transparent;
            this.upload_btn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.upload_btn.DownBack = null;
            this.upload_btn.Location = new System.Drawing.Point(211, 103);
            this.upload_btn.MouseBack = null;
            this.upload_btn.Name = "upload_btn";
            this.upload_btn.NormlBack = null;
            this.upload_btn.Size = new System.Drawing.Size(117, 48);
            this.upload_btn.TabIndex = 0;
            this.upload_btn.Text = "上传";
            this.upload_btn.UseVisualStyleBackColor = false;
            this.upload_btn.Click += new System.EventHandler(this.upload_btn_Click);
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.Location = new System.Drawing.Point(211, 185);
            this.skinButton1.MouseBack = null;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.Size = new System.Drawing.Size(117, 48);
            this.skinButton1.TabIndex = 0;
            this.skinButton1.Text = "重置密码";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.check_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 323);
            this.Controls.Add(this.skinButton1);
            this.Controls.Add(this.upload_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button upload_btn;
        private System.Windows.Forms.Button skinButton1;
    }
}

