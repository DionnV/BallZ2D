namespace GDD_Game_Windows
{
    partial class FormMain
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
            this.Button_PlayNow = new GDD_Library.Controls.GDD_Button();
            this.GDD_View1 = new GDD_Library.GDD_View();
            this.Button_CustomGames = new GDD_Library.Controls.GDD_Button();
            this.gdD_Button2 = new GDD_Library.Controls.GDD_Button();
            this.gdD_Button3 = new GDD_Library.Controls.GDD_Button();
            this.Button_Back = new GDD_Library.Controls.GDD_Button();


            this.SuspendLayout();
            // 
            // GDD_View1
            // 
            this.GDD_View1.BackColor = System.Drawing.Color.White;
            this.GDD_View1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GDD_View1.Location = new System.Drawing.Point(0, 0);
            this.GDD_View1.Name = "GDD_View1";
            this.GDD_View1.Size = new System.Drawing.Size(734, 418);
            this.GDD_View1.TabIndex = 0;
            this.GDD_View1.ViewingRect = new System.Drawing.Rectangle(0, 0, 0, 0);

            // 
            // Button_PlayNow
            // 
            this.Button_PlayNow.BackColor = System.Drawing.Color.White;
            this.Button_PlayNow.BorderWidth = 2F;
            this.Button_PlayNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_PlayNow.ForeColor = System.Drawing.Color.Black;
            this.Button_PlayNow.Location = new System.Drawing.Point(50, 110);
            this.Button_PlayNow.Name = "Button_PlayNow";
            this.Button_PlayNow.Size = new System.Drawing.Size(350, 50);
            this.Button_PlayNow.TabIndex = 1;
            this.Button_PlayNow.Text = "Play Now!";
            // 
            // Button_CustomGames
            // 
            this.Button_CustomGames.BackColor = System.Drawing.Color.White;
            this.Button_CustomGames.BorderWidth = 2F;
            this.Button_CustomGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_CustomGames.ForeColor = System.Drawing.Color.Black;
            this.Button_CustomGames.Location = new System.Drawing.Point(50, 180);
            this.Button_CustomGames.Name = "Button_CustomGames";
            this.Button_CustomGames.Size = new System.Drawing.Size(350, 50);
            this.Button_CustomGames.TabIndex = 2;
            this.Button_CustomGames.Text = "Custom Games";
            // 
            // gdD_Button2
            // 
            this.gdD_Button2.BackColor = System.Drawing.Color.White;
            this.gdD_Button2.BorderWidth = 2F;
            this.gdD_Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdD_Button2.ForeColor = System.Drawing.Color.Black;
            this.gdD_Button2.Location = new System.Drawing.Point(50, 250);
            this.gdD_Button2.Name = "gdD_Button2";
            this.gdD_Button2.Size = new System.Drawing.Size(350, 50);
            this.gdD_Button2.TabIndex = 3;
            // 
            // gdD_Button3
            // 
            this.gdD_Button3.BackColor = System.Drawing.Color.White;
            this.gdD_Button3.BorderWidth = 2F;
            this.gdD_Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdD_Button3.ForeColor = System.Drawing.Color.Black;
            this.gdD_Button3.Location = new System.Drawing.Point(50, 320);
            this.gdD_Button3.Name = "gdD_Button3";
            this.gdD_Button3.Size = new System.Drawing.Size(350, 50);
            this.gdD_Button3.TabIndex = 4;
            // 
            // Button_Back
            // 
            this.Button_Back.BackColor = System.Drawing.Color.White;
            this.Button_Back.BorderWidth = 0F;
            this.Button_Back.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Back.ForeColor = System.Drawing.Color.Black;
            this.Button_Back.Location = new System.Drawing.Point(50, 40);
            this.Button_Back.Name = "Button_Back";
            this.Button_Back.Size = new System.Drawing.Size(350, 50);
            this.Button_Back.TabIndex = 5;
            this.Button_Back.Text = "Main Menu";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 418);
            this.Controls.Add(this.Button_Back);
            this.Controls.Add(this.gdD_Button3);
            this.Controls.Add(this.gdD_Button2);
            this.Controls.Add(this.Button_CustomGames);
            this.Controls.Add(this.Button_PlayNow);
            this.Controls.Add(this.GDD_View1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GDD_Library.GDD_View GDD_View1;
        private GDD_Library.Controls.GDD_Button Button_PlayNow;
        private GDD_Library.Controls.GDD_Button Button_CustomGames;
        private GDD_Library.Controls.GDD_Button gdD_Button2;
        private GDD_Library.Controls.GDD_Button gdD_Button3;
        private GDD_Library.Controls.GDD_Button Button_Back;
    }
}