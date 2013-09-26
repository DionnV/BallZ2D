namespace GDD_Game_Windows
{
    partial class Form1
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
            this.button_GO = new System.Windows.Forms.Button();
            this.button_Reset = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pencilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GDD_View1 = new GDD_Library.GDD_View();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_GO
            // 
            this.button_GO.Location = new System.Drawing.Point(497, 27);
            this.button_GO.Name = "button_GO";
            this.button_GO.Size = new System.Drawing.Size(75, 23);
            this.button_GO.TabIndex = 1;
            this.button_GO.Text = "GO";
            this.button_GO.UseVisualStyleBackColor = true;
            this.button_GO.Click += new System.EventHandler(this.button_GO_Click);
            // 
            // button_Reset
            // 
            this.button_Reset.Location = new System.Drawing.Point(497, 27);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(75, 23);
            this.button_Reset.TabIndex = 2;
            this.button_Reset.Text = "Reset";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Visible = false;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.levelsToolStripMenuItem,
            this.drawToolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.menuToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // levelsToolStripMenuItem
            // 
            this.levelsToolStripMenuItem.Name = "levelsToolStripMenuItem";
            this.levelsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.levelsToolStripMenuItem.Text = "Level";
            this.levelsToolStripMenuItem.Click += new System.EventHandler(this.levelsToolStripMenuItem_Click);
            // 
            // drawToolToolStripMenuItem
            // 
            this.drawToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pencilToolStripMenuItem,
            this.lineToolStripMenuItem});
            this.drawToolToolStripMenuItem.Name = "drawToolToolStripMenuItem";
            this.drawToolToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.drawToolToolStripMenuItem.Text = "Draw Tool";
            // 
            // pencilToolStripMenuItem
            // 
            this.pencilToolStripMenuItem.Name = "pencilToolStripMenuItem";
            this.pencilToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.pencilToolStripMenuItem.Text = "Pencil";
            this.pencilToolStripMenuItem.Click += new System.EventHandler(this.pencilToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Checked = true;
            this.lineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // GDD_View1
            // 
            this.GDD_View1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GDD_View1.Location = new System.Drawing.Point(0, 24);
            this.GDD_View1.Name = "GDD_View1";
            this.GDD_View1.Size = new System.Drawing.Size(584, 538);
            this.GDD_View1.TabIndex = 0;
            this.GDD_View1.ViewingRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.GDD_View1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GDD_View1_MouseDown);
            this.GDD_View1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GDD_View1_MouseMove);
            this.GDD_View1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GDD_View1_MouseUp);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.button_GO);
            this.Controls.Add(this.GDD_View1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GDD_Library.GDD_View GDD_View1;
        private System.Windows.Forms.Button button_GO;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pencilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}

