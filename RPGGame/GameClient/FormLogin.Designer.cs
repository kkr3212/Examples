namespace RPGGame.GameClient
{
    partial class FormLogin
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
            this._lvWorld = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._tbUserToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._tbPortNo = new System.Windows.Forms.TextBox();
            this._tbServerIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lvWorld
            // 
            this._lvWorld.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this._lvWorld.FullRowSelect = true;
            this._lvWorld.GridLines = true;
            this._lvWorld.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._lvWorld.HideSelection = false;
            this._lvWorld.Location = new System.Drawing.Point(244, 198);
            this._lvWorld.MultiSelect = false;
            this._lvWorld.Name = "_lvWorld";
            this._lvWorld.Size = new System.Drawing.Size(271, 105);
            this._lvWorld.TabIndex = 24;
            this._lvWorld.UseCompatibleStateImageBehavior = false;
            this._lvWorld.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 199;
            // 
            // _tbUserToken
            // 
            this._tbUserToken.Location = new System.Drawing.Point(287, 326);
            this._tbUserToken.Name = "_tbUserToken";
            this._tbUserToken.Size = new System.Drawing.Size(228, 20);
            this._tbUserToken.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(242, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Token";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _tbPortNo
            // 
            this._tbPortNo.Location = new System.Drawing.Point(411, 122);
            this._tbPortNo.Name = "_tbPortNo";
            this._tbPortNo.Size = new System.Drawing.Size(43, 20);
            this._tbPortNo.TabIndex = 20;
            // 
            // _tbServerIp
            // 
            this._tbServerIp.Location = new System.Drawing.Point(314, 122);
            this._tbServerIp.Name = "_tbServerIp";
            this._tbServerIp.Size = new System.Drawing.Size(91, 20);
            this._tbServerIp.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(242, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "AuthServer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(387, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 40);
            this.button2.TabIndex = 18;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnClick_Login);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 29);
            this.button1.TabIndex = 21;
            this.button1.Text = "Refresh World List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClick_RefreshWorldList);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(244, 355);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 40);
            this.button3.TabIndex = 25;
            this.button3.Text = "Register";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnClick_Register);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button3);
            this.Controls.Add(this._lvWorld);
            this.Controls.Add(this._tbUserToken);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._tbPortNo);
            this.Controls.Add(this._tbServerIp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView _lvWorld;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox _tbUserToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbPortNo;
        private System.Windows.Forms.TextBox _tbServerIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}