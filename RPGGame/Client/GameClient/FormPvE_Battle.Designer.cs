namespace GameClient
{
    partial class FormPvE_Battle
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
            this._btnBack = new System.Windows.Forms.Button();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button6 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this._lvRound = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this._lvMonster = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _btnBack
            // 
            this._btnBack.Location = new System.Drawing.Point(691, 12);
            this._btnBack.Name = "_btnBack";
            this._btnBack.Size = new System.Drawing.Size(81, 38);
            this._btnBack.TabIndex = 54;
            this._btnBack.Text = "< Back";
            this._btnBack.UseVisualStyleBackColor = true;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Level";
            this.columnHeader7.Width = 78;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Promotion";
            this.columnHeader6.Width = 97;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Grade";
            this.columnHeader5.Width = 104;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 117;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Id";
            this.columnHeader3.Width = 51;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button6.Location = new System.Drawing.Point(681, 509);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(91, 40);
            this.button6.TabIndex = 47;
            this.button6.Text = "실패";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 18);
            this.label12.TabIndex = 45;
            this.label12.Text = "라운드 선택";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lvRound
            // 
            this._lvRound.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this._lvRound.Font = new System.Drawing.Font("Gulim", 9F);
            this._lvRound.FullRowSelect = true;
            this._lvRound.GridLines = true;
            this._lvRound.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._lvRound.HideSelection = false;
            this._lvRound.Location = new System.Drawing.Point(17, 90);
            this._lvRound.MultiSelect = false;
            this._lvRound.Name = "_lvRound";
            this._lvRound.Size = new System.Drawing.Size(755, 136);
            this._lvRound.TabIndex = 46;
            this._lvRound.UseCompatibleStateImageBehavior = false;
            this._lvRound.View = System.Windows.Forms.View.Details;
            this._lvRound.SelectedIndexChanged += new System.EventHandler(this.OnSelect_Round);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "RoundId";
            this.columnHeader10.Width = 65;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Name";
            this.columnHeader11.Width = 92;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Type";
            this.columnHeader12.Width = 97;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "No";
            this.columnHeader2.Width = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 50;
            this.label2.Text = "몬스터 정보";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lvMonster
            // 
            this._lvMonster.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this._lvMonster.Font = new System.Drawing.Font("Gulim", 9F);
            this._lvMonster.FullRowSelect = true;
            this._lvMonster.GridLines = true;
            this._lvMonster.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._lvMonster.HideSelection = false;
            this._lvMonster.Location = new System.Drawing.Point(17, 280);
            this._lvMonster.Name = "_lvMonster";
            this._lvMonster.Size = new System.Drawing.Size(755, 191);
            this._lvMonster.TabIndex = 51;
            this._lvMonster.UseCompatibleStateImageBehavior = false;
            this._lvMonster.View = System.Windows.Forms.View.Details;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(577, 509);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 40);
            this.button1.TabIndex = 49;
            this.button1.Text = "클리어";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 29);
            this.label6.TabIndex = 57;
            this.label6.Text = "PvE 일반/정예 던전 전투";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormPvE_Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._btnBack);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this._lvRound);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._lvMonster);
            this.Controls.Add(this.button1);
            this.Name = "FormPvE_Battle";
            this.Text = "FormPvE_Battle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _btnBack;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView _lvRound;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView _lvMonster;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
    }
}