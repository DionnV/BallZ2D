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
            this.Button_Back_Main = new GDD_Library.Controls.GDD_Button();
            this.Button_Settings = new GDD_Library.Controls.GDD_Button();
            this.Button_Store = new GDD_Library.Controls.GDD_Button();
            this.Button_LevelDesign = new GDD_Library.Controls.GDD_Button();
            this.Button_PlayNow = new GDD_Library.Controls.GDD_Button();
            this.Button_Back_PlayNow = new GDD_Library.Controls.GDD_Button();
            this.Button_Back_Settings = new GDD_Library.Controls.GDD_Button();
            this.Button_Back_ChapterSelect = new GDD_Library.Controls.GDD_Button();
            this.Button_Back_LevelSelect = new GDD_Library.Controls.GDD_Button();
            this.Button_Back_CustomLevels = new GDD_Library.Controls.GDD_Button();
            this.Button_Sound = new GDD_Library.Controls.GDD_Button();
            this.Button_Competitive = new GDD_Library.Controls.GDD_Button();
            this.Button_Custom = new GDD_Library.Controls.GDD_Button();
            this.Button_Chapter1 = new GDD_Library.Controls.GDD_Button();
            this.GDD_View1 = new GDD_Library.GDD_View();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.PanelPlayNow = new System.Windows.Forms.Panel();
            this.PanelSettings = new System.Windows.Forms.Panel();
            this.PanelLevelSelect = new System.Windows.Forms.Panel();
            this.PanelCustomLevels = new System.Windows.Forms.Panel();
            this.PanelChapterSelect = new System.Windows.Forms.Panel();
            this.PanelMain.SuspendLayout();
            this.PanelPlayNow.SuspendLayout();
            this.PanelSettings.SuspendLayout();
            this.PanelLevelSelect.SuspendLayout();
            this.PanelCustomLevels.SuspendLayout();
            this.PanelChapterSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_Back_Main
            // 
            this.Button_Back_Main.BackColor = System.Drawing.Color.White;
            this.Button_Back_Main.BorderWidth = 0F;
            this.Button_Back_Main.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button_Back_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Back_Main.ForeColor = System.Drawing.Color.Black;
            this.Button_Back_Main.IsSelected = false;
            this.Button_Back_Main.Location = new System.Drawing.Point(50, 40);
            this.Button_Back_Main.Name = "Button_Back_Main";
            this.Button_Back_Main.Note = "";
            this.Button_Back_Main.Size = new System.Drawing.Size(350, 50);
            this.Button_Back_Main.TabIndex = 5;
            // 
            // Button_Settings
            // 
            this.Button_Settings.BackColor = System.Drawing.Color.White;
            this.Button_Settings.BorderWidth = 2F;
            this.Button_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Settings.ForeColor = System.Drawing.Color.Black;
            this.Button_Settings.IsSelected = false;
            this.Button_Settings.Location = new System.Drawing.Point(50, 320);
            this.Button_Settings.Name = "Button_Settings";
            this.Button_Settings.Note = "";
            this.Button_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Button_Settings.Size = new System.Drawing.Size(350, 50);
            this.Button_Settings.TabIndex = 4;
            this.Button_Settings.Click += new System.EventHandler(this.Button_Settings_Click);
            // 
            // Button_Store
            // 
            this.Button_Store.BackColor = System.Drawing.Color.White;
            this.Button_Store.BorderWidth = 2F;
            this.Button_Store.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Store.ForeColor = System.Drawing.Color.Black;
            this.Button_Store.IsSelected = false;
            this.Button_Store.Location = new System.Drawing.Point(50, 250);
            this.Button_Store.Name = "Button_Store";
            this.Button_Store.Note = "Soon";
            this.Button_Store.Padding = new System.Windows.Forms.Padding(3);
            this.Button_Store.Size = new System.Drawing.Size(350, 50);
            this.Button_Store.TabIndex = 3;
            // 
            // Button_LevelDesign
            // 
            this.Button_LevelDesign.BackColor = System.Drawing.Color.White;
            this.Button_LevelDesign.BorderWidth = 2F;
            this.Button_LevelDesign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_LevelDesign.ForeColor = System.Drawing.Color.Black;
            this.Button_LevelDesign.IsSelected = false;
            this.Button_LevelDesign.Location = new System.Drawing.Point(50, 180);
            this.Button_LevelDesign.Name = "Button_LevelDesign";
            this.Button_LevelDesign.Note = "";
            this.Button_LevelDesign.Padding = new System.Windows.Forms.Padding(3);
            this.Button_LevelDesign.Size = new System.Drawing.Size(350, 50);
            this.Button_LevelDesign.TabIndex = 2;
            this.Button_LevelDesign.Click += new System.EventHandler(this.Button_LevelDesign_Click);
            // 
            // Button_PlayNow
            // 
            this.Button_PlayNow.BackColor = System.Drawing.Color.White;
            this.Button_PlayNow.BorderWidth = 2F;
            this.Button_PlayNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_PlayNow.ForeColor = System.Drawing.Color.Black;
            this.Button_PlayNow.IsSelected = false;
            this.Button_PlayNow.Location = new System.Drawing.Point(50, 110);
            this.Button_PlayNow.Name = "Button_PlayNow";
            this.Button_PlayNow.Note = "";
            this.Button_PlayNow.Padding = new System.Windows.Forms.Padding(3);
            this.Button_PlayNow.Size = new System.Drawing.Size(350, 50);
            this.Button_PlayNow.TabIndex = 1;
            this.Button_PlayNow.Click += new System.EventHandler(this.Button_PlayNow_Click);
            // 
            // Button_Back_PlayNow
            // 
            this.Button_Back_PlayNow.BackColor = System.Drawing.Color.White;
            this.Button_Back_PlayNow.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Back;
            this.Button_Back_PlayNow.BorderWidth = 0F;
            this.Button_Back_PlayNow.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button_Back_PlayNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Back_PlayNow.ForeColor = System.Drawing.Color.Black;
            this.Button_Back_PlayNow.IsSelected = false;
            this.Button_Back_PlayNow.Location = new System.Drawing.Point(50, 40);
            this.Button_Back_PlayNow.Name = "Button_Back_PlayNow";
            this.Button_Back_PlayNow.Note = "";
            this.Button_Back_PlayNow.Size = new System.Drawing.Size(350, 50);
            this.Button_Back_PlayNow.TabIndex = 5;
            this.Button_Back_PlayNow.Click += new System.EventHandler(this.Button_Back_PlayNow_Click);
            // 
            // Button_Back_Settings
            // 
            this.Button_Back_Settings.BackColor = System.Drawing.Color.White;
            this.Button_Back_Settings.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Back;
            this.Button_Back_Settings.BorderWidth = 0F;
            this.Button_Back_Settings.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button_Back_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Back_Settings.ForeColor = System.Drawing.Color.Black;
            this.Button_Back_Settings.IsSelected = false;
            this.Button_Back_Settings.Location = new System.Drawing.Point(50, 40);
            this.Button_Back_Settings.Name = "Button_Back_Settings";
            this.Button_Back_Settings.Note = "";
            this.Button_Back_Settings.Size = new System.Drawing.Size(350, 50);
            this.Button_Back_Settings.TabIndex = 5;
            this.Button_Back_Settings.Click += new System.EventHandler(this.Button_Back_Settings_Click);
            // 
            // Button_Back_ChapterSelect
            // 
            this.Button_Back_ChapterSelect.BackColor = System.Drawing.Color.White;
            this.Button_Back_ChapterSelect.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Back;
            this.Button_Back_ChapterSelect.BorderWidth = 0F;
            this.Button_Back_ChapterSelect.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button_Back_ChapterSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Back_ChapterSelect.ForeColor = System.Drawing.Color.Black;
            this.Button_Back_ChapterSelect.IsSelected = false;
            this.Button_Back_ChapterSelect.Location = new System.Drawing.Point(50, 40);
            this.Button_Back_ChapterSelect.Name = "Button_Back_ChapterSelect";
            this.Button_Back_ChapterSelect.Note = "";
            this.Button_Back_ChapterSelect.Size = new System.Drawing.Size(350, 50);
            this.Button_Back_ChapterSelect.TabIndex = 5;
            this.Button_Back_ChapterSelect.Click += new System.EventHandler(this.Button_Back_ChapterSelect_Click);
            // 
            // Button_Back_LevelSelect
            // 
            this.Button_Back_LevelSelect.BackColor = System.Drawing.Color.White;
            this.Button_Back_LevelSelect.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Back;
            this.Button_Back_LevelSelect.BorderWidth = 0F;
            this.Button_Back_LevelSelect.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button_Back_LevelSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Back_LevelSelect.ForeColor = System.Drawing.Color.Black;
            this.Button_Back_LevelSelect.IsSelected = false;
            this.Button_Back_LevelSelect.Location = new System.Drawing.Point(50, 40);
            this.Button_Back_LevelSelect.Name = "Button_Back_LevelSelect";
            this.Button_Back_LevelSelect.Note = "";
            this.Button_Back_LevelSelect.Size = new System.Drawing.Size(350, 50);
            this.Button_Back_LevelSelect.TabIndex = 5;
            this.Button_Back_LevelSelect.Click += new System.EventHandler(this.Button_Back_LevelSelect_Click);
            // 
            // Button_Back_CustomLevels
            // 
            this.Button_Back_CustomLevels.BackColor = System.Drawing.Color.White;
            this.Button_Back_CustomLevels.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Back;
            this.Button_Back_CustomLevels.BorderWidth = 0F;
            this.Button_Back_CustomLevels.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button_Back_CustomLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Back_CustomLevels.ForeColor = System.Drawing.Color.Black;
            this.Button_Back_CustomLevels.IsSelected = false;
            this.Button_Back_CustomLevels.Location = new System.Drawing.Point(50, 40);
            this.Button_Back_CustomLevels.Name = "Button_Back_CustomLevels";
            this.Button_Back_CustomLevels.Note = "";
            this.Button_Back_CustomLevels.Size = new System.Drawing.Size(350, 50);
            this.Button_Back_CustomLevels.TabIndex = 5;
            this.Button_Back_CustomLevels.Click += new System.EventHandler(this.Button_Back_Custom_Click);
            // 
            // Button_Sound
            // 
            this.Button_Sound.BackColor = System.Drawing.Color.White;
            this.Button_Sound.BorderWidth = 2F;
            this.Button_Sound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Sound.ForeColor = System.Drawing.Color.Black;
            this.Button_Sound.IsSelected = false;
            this.Button_Sound.Location = new System.Drawing.Point(50, 110);
            this.Button_Sound.Name = "Button_Sound";
            this.Button_Sound.Note = "";
            this.Button_Sound.Padding = new System.Windows.Forms.Padding(3);
            this.Button_Sound.Size = new System.Drawing.Size(350, 50);
            this.Button_Sound.TabIndex = 4;
            this.Button_Sound.Click += new System.EventHandler(this.Button_Sound_Click);
            // 
            // Button_Competitive
            // 
            this.Button_Competitive.BackColor = System.Drawing.Color.White;
            this.Button_Competitive.BorderWidth = 2F;
            this.Button_Competitive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Competitive.ForeColor = System.Drawing.Color.Black;
            this.Button_Competitive.IsSelected = false;
            this.Button_Competitive.Location = new System.Drawing.Point(50, 110);
            this.Button_Competitive.Name = "Button_Competitive";
            this.Button_Competitive.Note = "";
            this.Button_Competitive.Padding = new System.Windows.Forms.Padding(3);
            this.Button_Competitive.Size = new System.Drawing.Size(350, 50);
            this.Button_Competitive.TabIndex = 4;
            this.Button_Competitive.Click += new System.EventHandler(this.Button_Competitive_Click);
            // 
            // Button_Custom
            // 
            this.Button_Custom.BackColor = System.Drawing.Color.White;
            this.Button_Custom.BorderWidth = 2F;
            this.Button_Custom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Custom.ForeColor = System.Drawing.Color.Black;
            this.Button_Custom.IsSelected = false;
            this.Button_Custom.Location = new System.Drawing.Point(50, 180);
            this.Button_Custom.Name = "Button_Custom";
            this.Button_Custom.Note = "";
            this.Button_Custom.Padding = new System.Windows.Forms.Padding(3);
            this.Button_Custom.Size = new System.Drawing.Size(350, 50);
            this.Button_Custom.TabIndex = 4;
            this.Button_Custom.Click += new System.EventHandler(this.Button_Custom_Click);
            // 
            // Button_Chapter1
            // 
            this.Button_Chapter1.BackColor = System.Drawing.Color.White;
            this.Button_Chapter1.BorderWidth = 2F;
            this.Button_Chapter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Chapter1.ForeColor = System.Drawing.Color.Black;
            this.Button_Chapter1.IsSelected = false;
            this.Button_Chapter1.Location = new System.Drawing.Point(50, 110);
            this.Button_Chapter1.Name = "Button_Chapter1";
            this.Button_Chapter1.Note = "";
            this.Button_Chapter1.Padding = new System.Windows.Forms.Padding(3);
            this.Button_Chapter1.Size = new System.Drawing.Size(350, 50);
            this.Button_Chapter1.TabIndex = 4;
            this.Button_Chapter1.Click += new System.EventHandler(this.Button_Chapter_Click);
            // 
            // GDD_View1
            // 
            this.GDD_View1.BackColor = System.Drawing.Color.White;
            this.GDD_View1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GDD_View1.Location = new System.Drawing.Point(0, 0);
            this.GDD_View1.Name = "GDD_View1";
            this.GDD_View1.ShowFPS = false;
            this.GDD_View1.Size = new System.Drawing.Size(734, 418);
            this.GDD_View1.TabIndex = 0;
            this.GDD_View1.ViewingRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // PanelMain
            // 
            this.PanelMain.BackColor = System.Drawing.Color.White;
            this.PanelMain.Controls.Add(this.Button_Back_Main);
            this.PanelMain.Controls.Add(this.Button_PlayNow);
            this.PanelMain.Controls.Add(this.Button_LevelDesign);
            this.PanelMain.Controls.Add(this.Button_Store);
            this.PanelMain.Controls.Add(this.Button_Settings);
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(400, 480);
            this.PanelMain.TabIndex = 1;
            // 
            // PanelPlayNow
            // 
            this.PanelPlayNow.BackColor = System.Drawing.Color.White;
            this.PanelPlayNow.Controls.Add(this.Button_Back_PlayNow);
            this.PanelPlayNow.Controls.Add(this.Button_Competitive);
            this.PanelPlayNow.Controls.Add(this.Button_Custom);
            this.PanelPlayNow.Location = new System.Drawing.Point(0, 0);
            this.PanelPlayNow.Name = "PanelPlayNow";
            this.PanelPlayNow.Size = new System.Drawing.Size(400, 480);
            this.PanelPlayNow.TabIndex = 1;
            // 
            // PanelSettings
            // 
            this.PanelSettings.BackColor = System.Drawing.Color.White;
            this.PanelSettings.Controls.Add(this.Button_Back_Settings);
            this.PanelSettings.Controls.Add(this.Button_Sound);
            this.PanelSettings.Location = new System.Drawing.Point(0, 0);
            this.PanelSettings.Name = "PanelSettings";
            this.PanelSettings.Size = new System.Drawing.Size(400, 480);
            this.PanelSettings.TabIndex = 1;
            // 
            // PanelLevelSelect
            // 
            this.PanelLevelSelect.BackColor = System.Drawing.Color.White;
            this.PanelLevelSelect.Location = new System.Drawing.Point(0, 0);
            this.PanelLevelSelect.Name = "PanelLevelSelect";
            this.PanelLevelSelect.Size = new System.Drawing.Size(400, 480);
            this.PanelLevelSelect.TabIndex = 1;
            // 
            // PanelCustomLevels
            // 
            this.PanelCustomLevels.BackColor = System.Drawing.Color.White;
            this.PanelCustomLevels.Controls.Add(this.Button_Back_CustomLevels);
            this.PanelCustomLevels.Location = new System.Drawing.Point(0, 0);
            this.PanelCustomLevels.Name = "PanelCustomLevels";
            this.PanelCustomLevels.Size = new System.Drawing.Size(400, 480);
            this.PanelCustomLevels.TabIndex = 2;
            // 
            // PanelChapterSelect
            // 
            this.PanelChapterSelect.BackColor = System.Drawing.Color.White;
            this.PanelChapterSelect.Controls.Add(this.Button_Back_ChapterSelect);
            this.PanelChapterSelect.Location = new System.Drawing.Point(0, 0);
            this.PanelChapterSelect.Name = "PanelChapterSelect";
            this.PanelChapterSelect.Size = new System.Drawing.Size(400, 480);
            this.PanelChapterSelect.TabIndex = 1;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Text = "Get it in, bro!";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.PanelMain.ResumeLayout(false);
            this.PanelPlayNow.ResumeLayout(false);
            this.PanelSettings.ResumeLayout(false);
            this.PanelLevelSelect.ResumeLayout(false);
            this.PanelCustomLevels.ResumeLayout(false);
            this.PanelChapterSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }
      
        #endregion

        private GDD_Library.GDD_View GDD_View1;
        private GDD_Library.Controls.GDD_Button Button_PlayNow;
        private GDD_Library.Controls.GDD_Button Button_LevelDesign;
        private GDD_Library.Controls.GDD_Button Button_Store;
        private GDD_Library.Controls.GDD_Button Button_Settings;
        private GDD_Library.Controls.GDD_Button Button_Back_Main;
        private GDD_Library.Controls.GDD_Button Button_Back_PlayNow;
        private GDD_Library.Controls.GDD_Button Button_Back_Settings;
        private GDD_Library.Controls.GDD_Button Button_Back_ChapterSelect;
        private GDD_Library.Controls.GDD_Button Button_Back_LevelSelect;
        private GDD_Library.Controls.GDD_Button Button_Back_CustomLevels;
        private GDD_Library.Controls.GDD_Button Button_Sound;
        private GDD_Library.Controls.GDD_Button Button_Competitive;
        private GDD_Library.Controls.GDD_Button Button_Custom;
        private GDD_Library.Controls.GDD_Button Button_Chapter1;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Panel PanelPlayNow;
        private System.Windows.Forms.Panel PanelSettings;
        private System.Windows.Forms.Panel PanelChapterSelect;
        private System.Windows.Forms.Panel PanelCustomLevels;
        private System.Windows.Forms.Panel PanelLevelSelect;
    }
}
