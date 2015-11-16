namespace RPGGame.GameClient
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
            this._panel = new System.Windows.Forms.Panel();
            this._lbMessage = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._lbConnectionStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _panel
            // 
            this._panel.Location = new System.Drawing.Point(12, 12);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(800, 600);
            this._panel.TabIndex = 0;
            // 
            // _lbMessage
            // 
            this._lbMessage.Location = new System.Drawing.Point(12, 648);
            this._lbMessage.Name = "_lbMessage";
            this._lbMessage.Size = new System.Drawing.Size(607, 23);
            this._lbMessage.TabIndex = 1;
            this._lbMessage.Text = "Ready";
            this._lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(720, 621);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 50);
            this.button1.TabIndex = 2;
            this.button1.Text = "Disconnect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClick_Disconnect);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(625, 621);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnClick_LoginPage);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 621);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Connection Status";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lbConnectionStatus
            // 
            this._lbConnectionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbConnectionStatus.Location = new System.Drawing.Point(116, 621);
            this._lbConnectionStatus.Name = "_lbConnectionStatus";
            this._lbConnectionStatus.Size = new System.Drawing.Size(137, 23);
            this._lbConnectionStatus.TabIndex = 5;
            this._lbConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 695);
            this.Controls.Add(this._lbConnectionStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._lbMessage);
            this.Controls.Add(this._panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panel;
        private System.Windows.Forms.Label _lbMessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lbConnectionStatus;
    }
}

