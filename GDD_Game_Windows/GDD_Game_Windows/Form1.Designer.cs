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
            GDD_Library.GDD_Timer gdD_Timer1 = new GDD_Library.GDD_Timer();
            this.GDD_View1 = new GDD_Library.GDD_View();
            this.SuspendLayout();
            // 
            // GDD_View1
            // 
            this.GDD_View1.Dock = System.Windows.Forms.DockStyle.Fill;
            gdD_Timer1.DesiredTickTime = 16.66667F;
            gdD_Timer1.TickCap = 60;
            gdD_Timer1.TickTime = 16;
            this.GDD_View1.graphicsTimer = gdD_Timer1;
            this.GDD_View1.Location = new System.Drawing.Point(0, 0);
            this.GDD_View1.Name = "GDD_View1";
            this.GDD_View1.Size = new System.Drawing.Size(584, 562);
            this.GDD_View1.TabIndex = 0;
            this.GDD_View1.ViewingRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.GDD_View1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GDD_Library.GDD_View GDD_View1;
    }
}

