namespace RPGGame.AuthServer
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tbSessionCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._tbLog = new System.Windows.Forms.TextBox();
            this._btnStart = new System.Windows.Forms.Button();
            this._btnStop = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this._tbUsedMemory = new System.Windows.Forms.Label();
            this.label0 = new System.Windows.Forms.Label();
            this._tbElapsedTime = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._tbActiveUserCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _tbSessionCount
            // 
            this._tbSessionCount.Location = new System.Drawing.Point(120, 149);
            this._tbSessionCount.Name = "_tbSessionCount";
            this._tbSessionCount.Size = new System.Drawing.Size(43, 23);
            this._tbSessionCount.TabIndex = 128;
            this._tbSessionCount.Text = " 0";
            this._tbSessionCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 23);
            this.label2.TabIndex = 127;
            this.label2.Text = "Session count";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _tbLog
            // 
            this._tbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tbLog.Location = new System.Drawing.Point(12, 187);
            this._tbLog.MaxLength = 1048576;
            this._tbLog.Multiline = true;
            this._tbLog.Name = "_tbLog";
            this._tbLog.ReadOnly = true;
            this._tbLog.Size = new System.Drawing.Size(460, 157);
            this._tbLog.TabIndex = 119;
            this._tbLog.TabStop = false;
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(12, 12);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(99, 56);
            this._btnStart.TabIndex = 117;
            this._btnStart.Text = "Start";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this.OnClick_Start);
            // 
            // _btnStop
            // 
            this._btnStop.Location = new System.Drawing.Point(116, 12);
            this._btnStop.Name = "_btnStop";
            this._btnStop.Size = new System.Drawing.Size(99, 56);
            this._btnStop.TabIndex = 118;
            this._btnStop.Text = "Stop";
            this._btnStop.UseVisualStyleBackColor = true;
            this._btnStop.Click += new System.EventHandler(this.OnClick_Stop);
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(12, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 26);
            this.label11.TabIndex = 126;
            this.label11.Text = "Status";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _tbUsedMemory
            // 
            this._tbUsedMemory.Location = new System.Drawing.Point(348, 46);
            this._tbUsedMemory.Name = "_tbUsedMemory";
            this._tbUsedMemory.Size = new System.Drawing.Size(77, 13);
            this._tbUsedMemory.TabIndex = 125;
            this._tbUsedMemory.Text = "0 MB";
            this._tbUsedMemory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label0
            // 
            this.label0.Location = new System.Drawing.Point(242, 46);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(101, 13);
            this.label0.TabIndex = 124;
            this.label0.Text = "Used Memory";
            this.label0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _tbElapsedTime
            // 
            this._tbElapsedTime.Location = new System.Drawing.Point(348, 22);
            this._tbElapsedTime.Name = "_tbElapsedTime";
            this._tbElapsedTime.Size = new System.Drawing.Size(77, 13);
            this._tbElapsedTime.TabIndex = 123;
            this._tbElapsedTime.Text = "00 : 00 : 00";
            this._tbElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(244, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 122;
            this.label9.Text = "Elapsed Time";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _tbActiveUserCount
            // 
            this._tbActiveUserCount.Location = new System.Drawing.Point(120, 124);
            this._tbActiveUserCount.Name = "_tbActiveUserCount";
            this._tbActiveUserCount.Size = new System.Drawing.Size(43, 23);
            this._tbActiveUserCount.TabIndex = 121;
            this._tbActiveUserCount.Text = " 0";
            this._tbActiveUserCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 23);
            this.label8.TabIndex = 120;
            this.label8.Text = "Active user count";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 369);
            this.Controls.Add(this._tbSessionCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tbLog);
            this.Controls.Add(this._btnStart);
            this.Controls.Add(this._btnStop);
            this.Controls.Add(this.label11);
            this.Controls.Add(this._tbUsedMemory);
            this.Controls.Add(this.label0);
            this.Controls.Add(this._tbElapsedTime);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._tbActiveUserCount);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label _tbSessionCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbLog;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.Button _btnStop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label _tbUsedMemory;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Label _tbElapsedTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label _tbActiveUserCount;
        private System.Windows.Forms.Label label8;
    }
}

