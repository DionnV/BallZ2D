namespace GDD_Game_Windows
{
    partial class FormScore
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
            this.Button_Background = new GDD_Library.Controls.GDD_Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.Button_Back = new GDD_Library.Controls.GDD_Button();
            this.label_Score = new System.Windows.Forms.Label();
            this.label_Highscore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button_Background
            // 
            this.Button_Background.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Background.BackColor = System.Drawing.Color.White;
            this.Button_Background.BorderWidth = 2F;
            this.Button_Background.ForeColor = System.Drawing.Color.Black;
            this.Button_Background.IsSelected = false;
            this.Button_Background.Location = new System.Drawing.Point(0, 0);
            this.Button_Background.Medals = -1;
            this.Button_Background.Name = "Button_Background";
            this.Button_Background.Note = null;
            this.Button_Background.Size = new System.Drawing.Size(360, 212);
            this.Button_Background.TabIndex = 0;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.BackColor = System.Drawing.Color.Transparent;
            this.label_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Status.Location = new System.Drawing.Point(5, 9);
            this.label_Status.MinimumSize = new System.Drawing.Size(350, 0);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(350, 31);
            this.label_Status.TabIndex = 1;
            this.label_Status.Text = "You won!";
            this.label_Status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Button_Back
            // 
            this.Button_Back.BackColor = System.Drawing.Color.White;
            this.Button_Back.BorderWidth = 2F;
            this.Button_Back.ForeColor = System.Drawing.Color.Black;
            this.Button_Back.IsSelected = false;
            this.Button_Back.Location = new System.Drawing.Point(13, 134);
            this.Button_Back.Medals = -1;
            this.Button_Back.Name = "Button_Back";
            this.Button_Back.Note = null;
            this.Button_Back.Size = new System.Drawing.Size(335, 66);
            this.Button_Back.TabIndex = 2;
            this.Button_Back.Click += new System.EventHandler(this.Button_Back_Click);
            // 
            // label_Score
            // 
            this.label_Score.AutoSize = true;
            this.label_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Score.Location = new System.Drawing.Point(13, 57);
            this.label_Score.Name = "label_Score";
            this.label_Score.Size = new System.Drawing.Size(55, 20);
            this.label_Score.TabIndex = 3;
            this.label_Score.Text = "Score:";
            // 
            // label_Highscore
            // 
            this.label_Highscore.AutoSize = true;
            this.label_Highscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Highscore.Location = new System.Drawing.Point(13, 87);
            this.label_Highscore.Name = "label_Highscore";
            this.label_Highscore.Size = new System.Drawing.Size(85, 20);
            this.label_Highscore.TabIndex = 4;
            this.label_Highscore.Text = "Highscore:";
            // 
            // FormScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(360, 212);
            this.Controls.Add(this.label_Highscore);
            this.Controls.Add(this.label_Score);
            this.Controls.Add(this.Button_Back);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.Button_Background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Score";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected GDD_Library.Controls.GDD_Button Button_Background;
        protected System.Windows.Forms.Label label_Status;
        protected GDD_Library.Controls.GDD_Button Button_Back;
        protected System.Windows.Forms.Label label_Score;
        protected System.Windows.Forms.Label label_Highscore;
    }
}