namespace RPGGame.GameClient
{
    partial class FormNewUser
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
            this._tbNickname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _tbNickname
            // 
            this._tbNickname.Location = new System.Drawing.Point(310, 222);
            this._tbNickname.Name = "_tbNickname";
            this._tbNickname.Size = new System.Drawing.Size(133, 20);
            this._tbNickname.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(308, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nickname";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(310, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClick_Ok);
            // 
            // FormNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this._tbNickname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "FormNewUser";
            this.Text = "FormNewUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbNickname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}