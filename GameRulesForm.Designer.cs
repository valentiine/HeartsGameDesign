namespace HeartsGameDesign
{
    partial class GameRulesForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblClickMe = new System.Windows.Forms.Label();
            this.linkClickMe = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(344, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Objective: The main objective is to avoid getting penalty points.";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(64, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(483, 23);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Deck: A standard 52-card deck is used and all cards are dealt, so each player get" +
    "s 13 cards.";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(25, 99);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(581, 23);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "Following Suit: Players must follow the suit led if possible. If they cannot foll" +
    "ow suit, they may play any card.";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(50, 128);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(524, 23);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "Breaking Hearts: Hearts cannot be led until they have been \"broken\" (played on a " +
    "previous trick).";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Game Rules";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(220, 229);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 39);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblClickMe
            // 
            this.lblClickMe.AutoSize = true;
            this.lblClickMe.Location = new System.Drawing.Point(128, 191);
            this.lblClickMe.Name = "lblClickMe";
            this.lblClickMe.Size = new System.Drawing.Size(186, 15);
            this.lblClickMe.TabIndex = 6;
            this.lblClickMe.Text = "Visit this website for the full rules :";
            // 
            // linkClickMe
            // 
            this.linkClickMe.AutoSize = true;
            this.linkClickMe.Location = new System.Drawing.Point(320, 191);
            this.linkClickMe.Name = "linkClickMe";
            this.linkClickMe.Size = new System.Drawing.Size(150, 15);
            this.linkClickMe.TabIndex = 7;
            this.linkClickMe.TabStop = true;
            this.linkClickMe.Text = "Hearts Game Full Rulebook";
            this.linkClickMe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClickMe_LinkClicked);
            // 
            // GameRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 283);
            this.Controls.Add(this.linkClickMe);
            this.Controls.Add(this.lblClickMe);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "GameRulesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameRulesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private Button btnClose;
        private Label lblClickMe;
        private LinkLabel linkClickMe;
    }
}