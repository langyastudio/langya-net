namespace Test
{
    partial class WebSocketFrm
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_switchinteract = new System.Windows.Forms.Button();
            this.btn_setinteract = new System.Windows.Forms.Button();
            this.btn_switchppt = new System.Windows.Forms.Button();
            this.btn_stopmonitor = new System.Windows.Forms.Button();
            this.btn_startmonitor = new System.Windows.Forms.Button();
            this.txtBox_interact = new System.Windows.Forms.TextBox();
            this.txtBox_stream = new System.Windows.Forms.TextBox();
            this.chkBox_type = new System.Windows.Forms.CheckBox();
            this.btnstartpublish = new System.Windows.Forms.Button();
            this.btnuploadppt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 212);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(760, 337);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // btn_switchinteract
            // 
            this.btn_switchinteract.Location = new System.Drawing.Point(323, 82);
            this.btn_switchinteract.Name = "btn_switchinteract";
            this.btn_switchinteract.Size = new System.Drawing.Size(120, 41);
            this.btn_switchinteract.TabIndex = 9;
            this.btn_switchinteract.Text = "switchinteract";
            this.btn_switchinteract.UseVisualStyleBackColor = true;
            this.btn_switchinteract.Click += new System.EventHandler(this.btn_switchinteract_Click);
            // 
            // btn_setinteract
            // 
            this.btn_setinteract.Location = new System.Drawing.Point(168, 82);
            this.btn_setinteract.Name = "btn_setinteract";
            this.btn_setinteract.Size = new System.Drawing.Size(120, 41);
            this.btn_setinteract.TabIndex = 10;
            this.btn_setinteract.Text = "setinteract";
            this.btn_setinteract.UseVisualStyleBackColor = true;
            this.btn_setinteract.Click += new System.EventHandler(this.btn_setinteract_Click);
            // 
            // btn_switchppt
            // 
            this.btn_switchppt.Location = new System.Drawing.Point(12, 82);
            this.btn_switchppt.Name = "btn_switchppt";
            this.btn_switchppt.Size = new System.Drawing.Size(120, 41);
            this.btn_switchppt.TabIndex = 11;
            this.btn_switchppt.Text = "switchppt";
            this.btn_switchppt.UseVisualStyleBackColor = true;
            this.btn_switchppt.Click += new System.EventHandler(this.btn_switchppt_Click);
            // 
            // btn_stopmonitor
            // 
            this.btn_stopmonitor.Location = new System.Drawing.Point(168, 12);
            this.btn_stopmonitor.Name = "btn_stopmonitor";
            this.btn_stopmonitor.Size = new System.Drawing.Size(120, 41);
            this.btn_stopmonitor.TabIndex = 12;
            this.btn_stopmonitor.Text = "stopmonitor";
            this.btn_stopmonitor.UseVisualStyleBackColor = true;
            this.btn_stopmonitor.Click += new System.EventHandler(this.btn_stopmonitor_Click);
            // 
            // btn_startmonitor
            // 
            this.btn_startmonitor.Location = new System.Drawing.Point(12, 12);
            this.btn_startmonitor.Name = "btn_startmonitor";
            this.btn_startmonitor.Size = new System.Drawing.Size(120, 41);
            this.btn_startmonitor.TabIndex = 8;
            this.btn_startmonitor.Text = "startmonitor";
            this.btn_startmonitor.UseVisualStyleBackColor = true;
            this.btn_startmonitor.Click += new System.EventHandler(this.btn_startmonitor_Click);
            // 
            // txtBox_interact
            // 
            this.txtBox_interact.Location = new System.Drawing.Point(323, 12);
            this.txtBox_interact.Name = "txtBox_interact";
            this.txtBox_interact.Size = new System.Drawing.Size(120, 21);
            this.txtBox_interact.TabIndex = 14;
            this.txtBox_interact.Text = "LB101_lbrs";
            this.txtBox_interact.TextChanged += new System.EventHandler(this.txtBox_interact_TextChanged);
            // 
            // txtBox_stream
            // 
            this.txtBox_stream.Location = new System.Drawing.Point(488, 12);
            this.txtBox_stream.Name = "txtBox_stream";
            this.txtBox_stream.Size = new System.Drawing.Size(120, 21);
            this.txtBox_stream.TabIndex = 14;
            this.txtBox_stream.Text = "LB101";
            this.txtBox_stream.TextChanged += new System.EventHandler(this.txtBox_stream_TextChanged);
            // 
            // chkBox_type
            // 
            this.chkBox_type.AutoSize = true;
            this.chkBox_type.Checked = true;
            this.chkBox_type.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_type.Location = new System.Drawing.Point(637, 14);
            this.chkBox_type.Name = "chkBox_type";
            this.chkBox_type.Size = new System.Drawing.Size(72, 16);
            this.chkBox_type.TabIndex = 15;
            this.chkBox_type.Text = "开始讲课";
            this.chkBox_type.UseVisualStyleBackColor = true;
            this.chkBox_type.CheckedChanged += new System.EventHandler(this.chkBox_type_CheckedChanged);
            // 
            // btnstartpublish
            // 
            this.btnstartpublish.Location = new System.Drawing.Point(12, 150);
            this.btnstartpublish.Name = "btnstartpublish";
            this.btnstartpublish.Size = new System.Drawing.Size(120, 41);
            this.btnstartpublish.TabIndex = 8;
            this.btnstartpublish.Text = "startpublish";
            this.btnstartpublish.UseVisualStyleBackColor = true;
            this.btnstartpublish.Click += new System.EventHandler(this.btnstartpublish_Click);
            // 
            // btnuploadppt
            // 
            this.btnuploadppt.Location = new System.Drawing.Point(637, 150);
            this.btnuploadppt.Name = "btnuploadppt";
            this.btnuploadppt.Size = new System.Drawing.Size(120, 41);
            this.btnuploadppt.TabIndex = 8;
            this.btnuploadppt.Text = "uploadppt";
            this.btnuploadppt.UseVisualStyleBackColor = true;
            this.btnuploadppt.Click += new System.EventHandler(this.btnuploadppt_Click);
            // 
            // WebSocketFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.chkBox_type);
            this.Controls.Add(this.txtBox_stream);
            this.Controls.Add(this.txtBox_interact);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_switchinteract);
            this.Controls.Add(this.btn_setinteract);
            this.Controls.Add(this.btn_switchppt);
            this.Controls.Add(this.btn_stopmonitor);
            this.Controls.Add(this.btnuploadppt);
            this.Controls.Add(this.btnstartpublish);
            this.Controls.Add(this.btn_startmonitor);
            this.Name = "WebSocketFrm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_switchinteract;
        private System.Windows.Forms.Button btn_setinteract;
        private System.Windows.Forms.Button btn_switchppt;
        private System.Windows.Forms.Button btn_stopmonitor;
        private System.Windows.Forms.Button btn_startmonitor;
        private System.Windows.Forms.TextBox txtBox_interact;
        private System.Windows.Forms.TextBox txtBox_stream;
        private System.Windows.Forms.CheckBox chkBox_type;
        private System.Windows.Forms.Button btnstartpublish;
        private System.Windows.Forms.Button btnuploadppt;
    }
}

