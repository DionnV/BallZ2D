namespace GDD_Game_Windows
{
    partial class LevelInfo
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
            this.LevelName = new System.Windows.Forms.Label();
            this.LevelNameBox = new System.Windows.Forms.TextBox();
            this.CreatorName = new System.Windows.Forms.Label();
            this.CreatorNameBox = new System.Windows.Forms.TextBox();
            this.Button_OK = new GDD_Library.Controls.GDD_Button();
            this.Button_Cancel = new GDD_Library.Controls.GDD_Button();
            this.SuspendLayout();
            // 
            // LevelName
            // 
            this.LevelName.AutoSize = true;
            this.LevelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelName.Location = new System.Drawing.Point(12, 19);
            this.LevelName.Name = "LevelName";
            this.LevelName.Size = new System.Drawing.Size(105, 20);
            this.LevelName.TabIndex = 0;
            this.LevelName.Text = "Level name:";
            // 
            // LevelNameBox
            // 
            this.LevelNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LevelNameBox.BackColor = System.Drawing.Color.White;
            this.LevelNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelNameBox.Location = new System.Drawing.Point(12, 42);
            this.LevelNameBox.Name = "LevelNameBox";
            this.LevelNameBox.Size = new System.Drawing.Size(760, 26);
            this.LevelNameBox.TabIndex = 1;
            // 
            // CreatorName
            // 
            this.CreatorName.AutoSize = true;
            this.CreatorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatorName.Location = new System.Drawing.Point(8, 75);
            this.CreatorName.Name = "CreatorName";
            this.CreatorName.Size = new System.Drawing.Size(123, 20);
            this.CreatorName.TabIndex = 2;
            this.CreatorName.Text = "Creator name:";
            // 
            // CreatorNameBox
            // 
            this.CreatorNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreatorNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatorNameBox.Location = new System.Drawing.Point(12, 98);
            this.CreatorNameBox.Name = "CreatorNameBox";
            this.CreatorNameBox.Size = new System.Drawing.Size(760, 26);
            this.CreatorNameBox.TabIndex = 3;
            // 
            // Button_OK
            // 
            this.Button_OK.BackColor = System.Drawing.Color.White;
            this.Button_OK.BorderWidth = 2F;
            this.Button_OK.ForeColor = System.Drawing.Color.Black;
            this.Button_OK.IsSelected = false;
            this.Button_OK.Location = new System.Drawing.Point(463, 380);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Note = null;
            this.Button_OK.Size = new System.Drawing.Size(150, 50);
            this.Button_OK.TabIndex = 4;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.BackColor = System.Drawing.Color.White;
            this.Button_Cancel.BorderWidth = 2F;
            this.Button_Cancel.ForeColor = System.Drawing.Color.Black;
            this.Button_Cancel.IsSelected = false;
            this.Button_Cancel.Location = new System.Drawing.Point(622, 380);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Note = null;
            this.Button_Cancel.Size = new System.Drawing.Size(150, 50);
            this.Button_Cancel.TabIndex = 5;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // LevelInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.CreatorNameBox);
            this.Controls.Add(this.CreatorName);
            this.Controls.Add(this.LevelNameBox);
            this.Controls.Add(this.LevelName);
            this.Name = "LevelInfo";
            this.Text = "Get it in, bro! - Level info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LevelName;
        public System.Windows.Forms.TextBox LevelNameBox;
        private System.Windows.Forms.Label CreatorName;
        public System.Windows.Forms.TextBox CreatorNameBox;
        private GDD_Library.Controls.GDD_Button Button_OK;
        private GDD_Library.Controls.GDD_Button Button_Cancel;
    }
}