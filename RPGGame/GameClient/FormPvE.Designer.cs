namespace RPGGame.GameClient
{
    partial class FormPvE
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
            this._lvDeck = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._lvMercenary = new System.Windows.Forms.ListView();
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this._lvField = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._lvDungeon = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button7 = new System.Windows.Forms.Button();
            this._lvWorld = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _lvDeck
            // 
            this._lvDeck.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader18});
            this._lvDeck.Font = new System.Drawing.Font("Gulim", 9F);
            this._lvDeck.FullRowSelect = true;
            this._lvDeck.GridLines = true;
            this._lvDeck.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._lvDeck.HideSelection = false;
            this._lvDeck.Location = new System.Drawing.Point(17, 362);
            this._lvDeck.MultiSelect = false;
            this._lvDeck.Name = "_lvDeck";
            this._lvDeck.Size = new System.Drawing.Size(363, 142);
            this._lvDeck.TabIndex = 18;
            this._lvDeck.UseCompatibleStateImageBehavior = false;
            this._lvDeck.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Name";
            this.columnHeader11.Width = 92;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Grade";
            this.columnHeader12.Width = 90;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Promotion";
            this.columnHeader13.Width = 79;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "World";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(383, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "용병 정보";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lvMercenary
            // 
            this._lvMercenary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this._lvMercenary.Font = new System.Drawing.Font("Gulim", 9F);
            this._lvMercenary.FullRowSelect = true;
            this._lvMercenary.GridLines = true;
            this._lvMercenary.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._lvMercenary.HideSelection = false;
            this._lvMercenary.Location = new System.Drawing.Point(386, 362);
            this._lvMercenary.MultiSelect = false;
            this._lvMercenary.Name = "_lvMercenary";
            this._lvMercenary.Size = new System.Drawing.Size(386, 142);
            this._lvMercenary.TabIndex = 20;
            this._lvMercenary.UseCompatibleStateImageBehavior = false;
            this._lvMercenary.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "No";
            this.columnHeader14.Width = 67;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Name";
            this.columnHeader15.Width = 103;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Level";
            this.columnHeader16.Width = 61;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Character";
            this.columnHeader17.Width = 123;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Field";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lvField
            // 
            this._lvField.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this._lvField.Font = new System.Drawing.Font("Gulim", 9F);
            this._lvField.FullRowSelect = true;
            this._lvField.GridLines = true;
            this._lvField.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._lvField.HideSelection = false;
            this._lvField.Location = new System.Drawing.Point(195, 112);
            this._lvField.MultiSelect = false;
            this._lvField.Name = "_lvField";
            this._lvField.Size = new System.Drawing.Size(166, 142);
            this._lvField.TabIndex = 7;
            this._lvField.UseCompatibleStateImageBehavior = false;
            this._lvField.View = System.Windows.Forms.View.Details;
            this._lvField.SelectedIndexChanged += new System.EventHandler(this.OnSelected_Field);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 92;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 62;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Gulim", 9F);
            this.button4.Location = new System.Drawing.Point(631, 260);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(68, 30);
            this.button4.TabIndex = 11;
            this.button4.Text = "소탕권";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Gulim", 9F);
            this.button3.Location = new System.Drawing.Point(704, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 30);
            this.button3.TabIndex = 10;
            this.button3.Text = "입장";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnClick_Enter);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Gulim", 9F);
            this.button2.Location = new System.Drawing.Point(704, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "초기화";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(364, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dungeon";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lvDungeon
            // 
            this._lvDungeon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader19,
            this.columnHeader3});
            this._lvDungeon.Font = new System.Drawing.Font("Gulim", 9F);
            this._lvDungeon.FullRowSelect = true;
            this._lvDungeon.GridLines = true;
            this._lvDungeon.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._lvDungeon.HideSelection = false;
            this._lvDungeon.Location = new System.Drawing.Point(367, 112);
            this._lvDungeon.MultiSelect = false;
            this._lvDungeon.Name = "_lvDungeon";
            this._lvDungeon.Size = new System.Drawing.Size(405, 142);
            this._lvDungeon.TabIndex = 9;
            this._lvDungeon.UseCompatibleStateImageBehavior = false;
            this._lvDungeon.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "ID";
            this.columnHeader8.Width = 92;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Name";
            this.columnHeader9.Width = 62;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Level";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 172;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button7.Location = new System.Drawing.Point(704, 510);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(68, 30);
            this.button7.TabIndex = 22;
            this.button7.Text = "재추천";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // _lvWorld
            // 
            this._lvWorld.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this._lvWorld.Font = new System.Drawing.Font("Gulim", 9F);
            this._lvWorld.FullRowSelect = true;
            this._lvWorld.GridLines = true;
            this._lvWorld.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._lvWorld.HideSelection = false;
            this._lvWorld.Location = new System.Drawing.Point(17, 112);
            this._lvWorld.MultiSelect = false;
            this._lvWorld.Name = "_lvWorld";
            this._lvWorld.Size = new System.Drawing.Size(172, 142);
            this._lvWorld.TabIndex = 5;
            this._lvWorld.UseCompatibleStateImageBehavior = false;
            this._lvWorld.View = System.Windows.Forms.View.Details;
            this._lvWorld.SelectedIndexChanged += new System.EventHandler(this.OnSelected_World);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 92;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(691, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 38);
            this.button1.TabIndex = 16;
            this.button1.Text = "< Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClick_Back);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button6.Location = new System.Drawing.Point(311, 511);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(68, 30);
            this.button6.TabIndex = 21;
            this.button6.Text = "변경";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.OnClick_CheckDeck);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 343);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 15);
            this.label12.TabIndex = 17;
            this.label12.Text = "팀 정보";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 29);
            this.label6.TabIndex = 52;
            this.label6.Text = "PvE 일반/정예 던전";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormPvE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._lvDeck);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._lvMercenary);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this._lvDungeon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._lvField);
            this.Controls.Add(this._lvWorld);
            this.Name = "FormPvE";
            this.Text = "FormPvE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView _lvDeck;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView _lvMercenary;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView _lvField;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView _lvDungeon;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ListView _lvWorld;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}