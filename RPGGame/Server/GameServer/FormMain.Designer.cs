﻿namespace RPGGame.GameServer
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
            this._cbLogLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._lbQPSGameDB = new System.Windows.Forms.Label();
            this._lbQPSLogDB = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this._lbQPSAuthDB = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this._lbWQGameDB = new System.Windows.Forms.Label();
            this._lbWQLogDB = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._lbWQAuthDB = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            // _cbLogLevel
            // 
            this._cbLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbLogLevel.FormattingEnabled = true;
            this._cbLogLevel.Items.AddRange(new object[] {
            "None",
            "Core",
            "Important",
            "CallTest",
            "Variable",
            "Network"});
            this._cbLogLevel.Location = new System.Drawing.Point(566, 18);
            this._cbLogLevel.Name = "_cbLogLevel";
            this._cbLogLevel.Size = new System.Drawing.Size(118, 21);
            this._cbLogLevel.TabIndex = 144;
            this._cbLogLevel.SelectedIndexChanged += new System.EventHandler(this.OnSelect_LogLevel);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(493, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 143;
            this.label1.Text = "Log Level";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lbQPSGameDB
            // 
            this._lbQPSGameDB.Location = new System.Drawing.Point(396, 149);
            this._lbQPSGameDB.Name = "_lbQPSGameDB";
            this._lbQPSGameDB.Size = new System.Drawing.Size(77, 23);
            this._lbQPSGameDB.TabIndex = 142;
            this._lbQPSGameDB.Text = "0 / 0";
            this._lbQPSGameDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lbQPSLogDB
            // 
            this._lbQPSLogDB.Location = new System.Drawing.Point(396, 170);
            this._lbQPSLogDB.Name = "_lbQPSLogDB";
            this._lbQPSLogDB.Size = new System.Drawing.Size(77, 23);
            this._lbQPSLogDB.TabIndex = 141;
            this._lbQPSLogDB.Text = "0 / 0";
            this._lbQPSLogDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Location = new System.Drawing.Point(324, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(149, 26);
            this.label17.TabIndex = 140;
            this.label17.Text = "QPS";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(323, 170);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 23);
            this.label18.TabIndex = 139;
            this.label18.Text = "LogDB";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(323, 124);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 23);
            this.label19.TabIndex = 138;
            this.label19.Text = "AuthDB";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lbQPSAuthDB
            // 
            this._lbQPSAuthDB.Location = new System.Drawing.Point(396, 124);
            this._lbQPSAuthDB.Name = "_lbQPSAuthDB";
            this._lbQPSAuthDB.Size = new System.Drawing.Size(77, 23);
            this._lbQPSAuthDB.TabIndex = 137;
            this._lbQPSAuthDB.Text = "0 / 0";
            this._lbQPSAuthDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(323, 149);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 23);
            this.label22.TabIndex = 136;
            this.label22.Text = "GameDB";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lbWQGameDB
            // 
            this._lbWQGameDB.Location = new System.Drawing.Point(242, 147);
            this._lbWQGameDB.Name = "_lbWQGameDB";
            this._lbWQGameDB.Size = new System.Drawing.Size(77, 23);
            this._lbWQGameDB.TabIndex = 135;
            this._lbWQGameDB.Text = "0 / 0";
            this._lbWQGameDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lbWQLogDB
            // 
            this._lbWQLogDB.Location = new System.Drawing.Point(242, 170);
            this._lbWQLogDB.Name = "_lbWQLogDB";
            this._lbWQLogDB.Size = new System.Drawing.Size(77, 23);
            this._lbWQLogDB.TabIndex = 134;
            this._lbWQLogDB.Text = "0 / 0";
            this._lbWQLogDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(168, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 26);
            this.label7.TabIndex = 133;
            this.label7.Text = "WorkQueue";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(168, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 23);
            this.label6.TabIndex = 132;
            this.label6.Text = "LogDB";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(168, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 23);
            this.label5.TabIndex = 131;
            this.label5.Text = "AuthDB";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lbWQAuthDB
            // 
            this._lbWQAuthDB.Location = new System.Drawing.Point(242, 124);
            this._lbWQAuthDB.Name = "_lbWQAuthDB";
            this._lbWQAuthDB.Size = new System.Drawing.Size(77, 23);
            this._lbWQAuthDB.TabIndex = 130;
            this._lbWQAuthDB.Text = "0 / 0";
            this._lbWQAuthDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(168, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 23);
            this.label3.TabIndex = 129;
            this.label3.Text = "GameDB";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this._tbLog.Location = new System.Drawing.Point(14, 245);
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
            this.ClientSize = new System.Drawing.Size(692, 431);
            this.Controls.Add(this._cbLogLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._lbQPSGameDB);
            this.Controls.Add(this._lbQPSLogDB);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this._lbQPSAuthDB);
            this.Controls.Add(this.label22);
            this.Controls.Add(this._lbWQGameDB);
            this.Controls.Add(this._lbWQLogDB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._lbWQAuthDB);
            this.Controls.Add(this.label3);
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
            this.Text = "GameServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _cbLogLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lbQPSGameDB;
        private System.Windows.Forms.Label _lbQPSLogDB;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label _lbQPSAuthDB;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label _lbWQGameDB;
        private System.Windows.Forms.Label _lbWQLogDB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _lbWQAuthDB;
        private System.Windows.Forms.Label label3;
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

