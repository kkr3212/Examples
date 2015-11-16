namespace RPGGame.GameClient
{
    partial class FormPvE_PlayDeck
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
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._lvDeck = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._lvInventory = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Gulim", 9F);
            this.button5.Location = new System.Drawing.Point(605, 510);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(81, 39);
            this.button5.TabIndex = 50;
            this.button5.Text = "취소";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OnClick_Cancel);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Gulim", 9F);
            this.button3.Location = new System.Drawing.Point(691, 510);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 39);
            this.button3.TabIndex = 49;
            this.button3.Text = "적용";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnClick_Apply);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Gulim", 9F);
            this.button2.Location = new System.Drawing.Point(289, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 50);
            this.button2.TabIndex = 47;
            this.button2.Text = "▲";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnClick_AddToDeck);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Gulim", 9F);
            this.button4.Location = new System.Drawing.Point(405, 222);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 50);
            this.button4.TabIndex = 48;
            this.button4.Text = "▼";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OnClick_RemoveFromDeck);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 92;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 259);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 15);
            this.label12.TabIndex = 44;
            this.label12.Text = "캐릭터 인벤토리";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(691, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 38);
            this.button1.TabIndex = 43;
            this.button1.Text = "< Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClick_Back);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Grade";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            this.columnHeader1.Width = 73;
            // 
            // _lvDeck
            // 
            this._lvDeck.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this._lvDeck.Font = new System.Drawing.Font("Gulim", 9F);
            this._lvDeck.FullRowSelect = true;
            this._lvDeck.GridLines = true;
            this._lvDeck.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._lvDeck.HideSelection = false;
            this._lvDeck.Location = new System.Drawing.Point(17, 92);
            this._lvDeck.Name = "_lvDeck";
            this._lvDeck.Size = new System.Drawing.Size(755, 124);
            this._lvDeck.TabIndex = 42;
            this._lvDeck.UseCompatibleStateImageBehavior = false;
            this._lvDeck.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Promotion";
            this.columnHeader4.Width = 79;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Level";
            this.columnHeader5.Width = 71;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "RaceId";
            this.columnHeader6.Width = 83;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "TypeId";
            this.columnHeader7.Width = 88;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "JobId";
            this.columnHeader8.Width = 86;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "PosId";
            this.columnHeader9.Width = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 45;
            this.label1.Text = "팀 편성";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 29);
            this.label2.TabIndex = 51;
            this.label2.Text = "PvE Deck";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lvInventory
            // 
            this._lvInventory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18});
            this._lvInventory.Font = new System.Drawing.Font("Gulim", 9F);
            this._lvInventory.FullRowSelect = true;
            this._lvInventory.GridLines = true;
            this._lvInventory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._lvInventory.HideSelection = false;
            this._lvInventory.Location = new System.Drawing.Point(17, 278);
            this._lvInventory.Name = "_lvInventory";
            this._lvInventory.Size = new System.Drawing.Size(750, 181);
            this._lvInventory.TabIndex = 52;
            this._lvInventory.UseCompatibleStateImageBehavior = false;
            this._lvInventory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "No";
            this.columnHeader10.Width = 73;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Name";
            this.columnHeader11.Width = 92;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Grade";
            this.columnHeader12.Width = 80;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Promotion";
            this.columnHeader13.Width = 79;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Level";
            this.columnHeader14.Width = 71;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "RaceId";
            this.columnHeader15.Width = 83;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "TypeId";
            this.columnHeader16.Width = 88;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "JobId";
            this.columnHeader17.Width = 86;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "PosId";
            this.columnHeader18.Width = 76;
            // 
            // FormPvE_PlayDeck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this._lvInventory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._lvDeck);
            this.Controls.Add(this.label1);
            this.Name = "FormPvE_PlayDeck";
            this.Text = "FormPvE_PlayDeck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView _lvDeck;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView _lvInventory;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
    }
}