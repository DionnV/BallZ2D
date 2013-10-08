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
            this.Button_Back = new GDD_Library.Controls.GDD_Button();
            this.Button_Settings = new GDD_Library.Controls.GDD_Button();
            this.Button_Store = new GDD_Library.Controls.GDD_Button();
            this.Button_LevelDesigner = new GDD_Library.Controls.GDD_Button();
            this.Button_PlayNow = new GDD_Library.Controls.GDD_Button();
            this.GDD_View1 = new GDD_Library.GDD_View();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.PanelPlayNow = new System.Windows.Forms.Panel();
            this.PanelSettings = new System.Windows.Forms.Panel();
            this.PanelLevelSelect = new System.Windows.Forms.Panel();
            this.PanelCustomLevels = new System.Windows.Forms.Panel();
            this.PanelChapterSelect = new System.Windows.Forms.Panel();
            this.PanelMain.SuspendLayout();
            this.SuspendLayout();
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
            this.Button_Back.Note = "";
            this.Button_Back.Size = new System.Drawing.Size(350, 50);
            this.Button_Back.TabIndex = 5;
            // 
            // Button_Settings
            // 
            this.Button_Settings.BackColor = System.Drawing.Color.White;
            this.Button_Settings.BorderWidth = 2F;
            this.Button_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Settings.ForeColor = System.Drawing.Color.Black;
            this.Button_Settings.Location = new System.Drawing.Point(50, 320);
            this.Button_Settings.Name = "Button_Settings";
            this.Button_Settings.Note = "";
            this.Button_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Button_Settings.Size = new System.Drawing.Size(350, 50);
            this.Button_Settings.TabIndex = 4;
            // 
            // Button_Store
            // 
            this.Button_Store.BackColor = System.Drawing.Color.White;
            this.Button_Store.BorderWidth = 2F;
            this.Button_Store.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Store.ForeColor = System.Drawing.Color.Black;
            this.Button_Store.Location = new System.Drawing.Point(50, 250);
            this.Button_Store.Name = "Button_Store";
            this.Button_Store.Note = "Soon";
            this.Button_Store.Padding = new System.Windows.Forms.Padding(3);
            this.Button_Store.Size = new System.Drawing.Size(350, 50);
            this.Button_Store.TabIndex = 3;
            // 
            // Button_LevelDesigner
            // 
            this.Button_LevelDesigner.BackColor = System.Drawing.Color.White;
            this.Button_LevelDesigner.BorderWidth = 2F;
            this.Button_LevelDesigner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_LevelDesigner.ForeColor = System.Drawing.Color.Black;
            this.Button_LevelDesigner.Location = new System.Drawing.Point(50, 180);
            this.Button_LevelDesigner.Name = "Button_LevelDesigner";
            this.Button_LevelDesigner.Note = "Beta";
            this.Button_LevelDesigner.Padding = new System.Windows.Forms.Padding(3);
            this.Button_LevelDesigner.Size = new System.Drawing.Size(350, 50);
            this.Button_LevelDesigner.TabIndex = 2;
            // 
            // Button_PlayNow
            // 
            this.Button_PlayNow.BackColor = System.Drawing.Color.White;
            this.Button_PlayNow.BorderWidth = 2F;
            this.Button_PlayNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_PlayNow.ForeColor = System.Drawing.Color.Black;
            this.Button_PlayNow.Location = new System.Drawing.Point(50, 110);
            this.Button_PlayNow.Name = "Button_PlayNow";
            this.Button_PlayNow.Note = "";
            this.Button_PlayNow.Padding = new System.Windows.Forms.Padding(3);
            this.Button_PlayNow.Size = new System.Drawing.Size(350, 50);
            this.Button_PlayNow.TabIndex = 1;
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
            // PanelMain
            // 
            this.PanelMain.Controls.Add(this.Button_Back);
            this.PanelMain.Controls.Add(this.Button_Settings);
            this.PanelMain.Controls.Add(this.Button_Store);
            this.PanelMain.Controls.Add(this.Button_LevelDesigner);
            this.PanelMain.Controls.Add(this.Button_PlayNow);
            this.PanelMain.BackColor = System.Drawing.Color.White;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(400, 480);
            this.PanelMain.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 418);
            this.Controls.Add(this.GDD_View1);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.PanelChapterSelect);
            this.Controls.Add(this.PanelLevelSelect);
            this.Controls.Add(this.PanelCustomLevels);
            this.Controls.Add(this.PanelSettings);
            this.Controls.Add(this.PanelPlayNow);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.PanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GDD_Library.GDD_View GDD_View1;
        private GDD_Library.Controls.GDD_Button Button_PlayNow;
        private GDD_Library.Controls.GDD_Button Button_LevelDesigner;
        private GDD_Library.Controls.GDD_Button Button_Store;
        private GDD_Library.Controls.GDD_Button Button_Settings;
        private GDD_Library.Controls.GDD_Button Button_Back;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Panel PanelPlayNow;
        private System.Windows.Forms.Panel PanelSettings;
        private System.Windows.Forms.Panel PanelChapterSelect;
        private System.Windows.Forms.Panel PanelCustomLevels;
        private System.Windows.Forms.Panel PanelLevelSelect;
    }
}