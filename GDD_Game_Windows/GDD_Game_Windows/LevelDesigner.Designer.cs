

namespace GDD_Game_Windows
{
    partial class LevelDesigner
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
            this.editPanel = new System.Windows.Forms.Panel();
            this.optionPanel = new System.Windows.Forms.Panel();
            this.Button_Play = new GDD_Library.Controls.GDD_Button();
            this.Button_Reset = new GDD_Library.Controls.GDD_Button();
            this.Button_Save = new GDD_Library.Controls.GDD_Button();
            this.Button_Exit = new GDD_Library.Controls.GDD_Button();
            this.Button_Options = new GDD_Library.Controls.GDD_Button();
            this.Button_Resize = new GDD_Library.Controls.GDD_Button();
            this.Button_Rotate = new GDD_Library.Controls.GDD_Button();
            this.Button_Move = new GDD_Library.Controls.GDD_Button();
            this.Button_Eraser = new GDD_Library.Controls.GDD_Button();
            this.Button_Select = new GDD_Library.Controls.GDD_Button();
            this.Button_Shapes = new GDD_Library.Controls.GDD_Button();
            this.Button_Line = new GDD_Library.Controls.GDD_Button();
            this.Button_Pencil = new GDD_Library.Controls.GDD_Button();
            this.GDD_View_LevelDesigner1 = new GDD_Library.GDD_View();
            this.editPanel.SuspendLayout();
            this.optionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editPanel
            // 
            this.editPanel.Controls.Add(this.Button_Resize);
            this.editPanel.Controls.Add(this.Button_Rotate);
            this.editPanel.Controls.Add(this.Button_Move);
            this.editPanel.Location = new System.Drawing.Point(96, 354);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(248, 76);
            this.editPanel.TabIndex = 24;
            // 
            // optionPanel
            // 
            this.optionPanel.Controls.Add(this.Button_Play);
            this.optionPanel.Controls.Add(this.Button_Reset);
            this.optionPanel.Controls.Add(this.Button_Save);
            this.optionPanel.Controls.Add(this.Button_Exit);
            this.optionPanel.Location = new System.Drawing.Point(694, 18);
            this.optionPanel.Name = "optionPanel";
            this.optionPanel.Size = new System.Drawing.Size(78, 332);
            this.optionPanel.TabIndex = 30;
            // 
            // Button_Play
            // 
            this.Button_Play.BackColor = System.Drawing.Color.White;
            this.Button_Play.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Play;
            this.Button_Play.BorderWidth = 2F;
            this.Button_Play.ForeColor = System.Drawing.Color.Black;
            this.Button_Play.IsSelected = false;
            this.Button_Play.Location = new System.Drawing.Point(0, 86);
            this.Button_Play.Name = "Button_Play";
            this.Button_Play.Note = null;
            this.Button_Play.Size = new System.Drawing.Size(76, 76);
            this.Button_Play.TabIndex = 28;
            this.Button_Play.Click += new System.EventHandler(this.Button_Play_Click);
            // 
            // Button_Reset
            // 
            this.Button_Reset.BackColor = System.Drawing.Color.White;
            this.Button_Reset.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Reset;
            this.Button_Reset.BorderWidth = 2F;
            this.Button_Reset.ForeColor = System.Drawing.Color.Black;
            this.Button_Reset.IsSelected = false;
            this.Button_Reset.Location = new System.Drawing.Point(0, 172);
            this.Button_Reset.Name = "Button_Reset";
            this.Button_Reset.Note = null;
            this.Button_Reset.Size = new System.Drawing.Size(76, 76);
            this.Button_Reset.TabIndex = 27;
            this.Button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // Button_Save
            // 
            this.Button_Save.BackColor = System.Drawing.Color.White;
            this.Button_Save.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Save;
            this.Button_Save.BorderWidth = 2F;
            this.Button_Save.ForeColor = System.Drawing.Color.Black;
            this.Button_Save.IsSelected = false;
            this.Button_Save.Location = new System.Drawing.Point(0, 0);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Note = null;
            this.Button_Save.Size = new System.Drawing.Size(76, 76);
            this.Button_Save.TabIndex = 29;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Exit
            // 
            this.Button_Exit.BackColor = System.Drawing.Color.White;
            this.Button_Exit.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Exit;
            this.Button_Exit.BorderWidth = 2F;
            this.Button_Exit.ForeColor = System.Drawing.Color.Black;
            this.Button_Exit.IsSelected = false;
            this.Button_Exit.Location = new System.Drawing.Point(0, 258);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Note = null;
            this.Button_Exit.Size = new System.Drawing.Size(76, 76);
            this.Button_Exit.TabIndex = 26;
            this.Button_Exit.Click += new System.EventHandler(Button_Exit_Click);
            // 
            // Button_Options
            // 
            this.Button_Options.BackColor = System.Drawing.Color.White;
            this.Button_Options.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Options;
            this.Button_Options.BorderWidth = 2F;
            this.Button_Options.ForeColor = System.Drawing.Color.Black;
            this.Button_Options.IsSelected = false;
            this.Button_Options.Location = new System.Drawing.Point(698, 356);
            this.Button_Options.Name = "Button_Options";
            this.Button_Options.Note = null;
            this.Button_Options.Size = new System.Drawing.Size(76, 76);
            this.Button_Options.TabIndex = 25;
            this.Button_Options.Click += new System.EventHandler(this.Button_Options_Click);
            // 
            // Button_Resize
            // 
            this.Button_Resize.BackColor = System.Drawing.Color.White;
            this.Button_Resize.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Resize;
            this.Button_Resize.BorderWidth = 2F;
            this.Button_Resize.ForeColor = System.Drawing.Color.Black;
            this.Button_Resize.IsSelected = false;
            this.Button_Resize.Location = new System.Drawing.Point(84, 0);
            this.Button_Resize.Name = "Button_Resize";
            this.Button_Resize.Note = null;
            this.Button_Resize.Size = new System.Drawing.Size(76, 76);
            this.Button_Resize.TabIndex = 22;
            this.Button_Resize.Click += new System.EventHandler(this.HighLightButton);
            // 
            // Button_Rotate
            // 
            this.Button_Rotate.BackColor = System.Drawing.Color.White;
            this.Button_Rotate.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Rotate;
            this.Button_Rotate.BorderWidth = 2F;
            this.Button_Rotate.ForeColor = System.Drawing.Color.Black;
            this.Button_Rotate.IsSelected = false;
            this.Button_Rotate.Location = new System.Drawing.Point(170, 0);
            this.Button_Rotate.Name = "Button_Rotate";
            this.Button_Rotate.Note = null;
            this.Button_Rotate.Size = new System.Drawing.Size(76, 76);
            this.Button_Rotate.TabIndex = 23;
            this.Button_Rotate.Click += new System.EventHandler(this.HighLightButton);
            // 
            // Button_Move
            // 
            this.Button_Move.BackColor = System.Drawing.Color.White;
            this.Button_Move.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Move;
            this.Button_Move.BorderWidth = 2F;
            this.Button_Move.ForeColor = System.Drawing.Color.Black;
            this.Button_Move.IsSelected = false;
            this.Button_Move.Location = new System.Drawing.Point(0, 0);
            this.Button_Move.Name = "Button_Move";
            this.Button_Move.Note = null;
            this.Button_Move.Size = new System.Drawing.Size(76, 76);
            this.Button_Move.TabIndex = 21;
            this.Button_Move.Click += new System.EventHandler(this.HighLightButton);
            // 
            // Button_Eraser
            // 
            this.Button_Eraser.BackColor = System.Drawing.Color.White;
            this.Button_Eraser.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Eraser;
            this.Button_Eraser.BorderWidth = 2F;
            this.Button_Eraser.ForeColor = System.Drawing.Color.Black;
            this.Button_Eraser.IsSelected = false;
            this.Button_Eraser.Location = new System.Drawing.Point(10, 182);
            this.Button_Eraser.Name = "Button_Eraser";
            this.Button_Eraser.Note = null;
            this.Button_Eraser.Size = new System.Drawing.Size(76, 76);
            this.Button_Eraser.TabIndex = 20;
            this.Button_Eraser.Click += new System.EventHandler(this.HighLightButton);
            // 
            // Button_Select
            // 
            this.Button_Select.BackColor = System.Drawing.Color.White;
            this.Button_Select.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Select;
            this.Button_Select.BorderWidth = 2F;
            this.Button_Select.ForeColor = System.Drawing.Color.Black;
            this.Button_Select.IsSelected = false;
            this.Button_Select.Location = new System.Drawing.Point(10, 354);
            this.Button_Select.Name = "Button_Select";
            this.Button_Select.Note = null;
            this.Button_Select.Size = new System.Drawing.Size(76, 76);
            this.Button_Select.TabIndex = 6;
            this.Button_Select.Click += new System.EventHandler(this.HighLightButton);
            // 
            // Button_Shapes
            // 
            this.Button_Shapes.BackColor = System.Drawing.Color.White;
            this.Button_Shapes.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Shapes;
            this.Button_Shapes.BorderWidth = 2F;
            this.Button_Shapes.ForeColor = System.Drawing.Color.Black;
            this.Button_Shapes.IsSelected = false;
            this.Button_Shapes.Location = new System.Drawing.Point(10, 268);
            this.Button_Shapes.Name = "Button_Shapes";
            this.Button_Shapes.Note = null;
            this.Button_Shapes.Size = new System.Drawing.Size(76, 76);
            this.Button_Shapes.TabIndex = 5;
            this.Button_Shapes.Click += new System.EventHandler(this.Button_Shapes_Click);
            // 
            // Button_Line
            // 
            this.Button_Line.BackColor = System.Drawing.Color.White;
            this.Button_Line.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Line;
            this.Button_Line.BorderWidth = 2F;
            this.Button_Line.ForeColor = System.Drawing.Color.Black;
            this.Button_Line.IsSelected = false;
            this.Button_Line.Location = new System.Drawing.Point(10, 92);
            this.Button_Line.Name = "Button_Line";
            this.Button_Line.Note = null;
            this.Button_Line.Size = new System.Drawing.Size(76, 76);
            this.Button_Line.TabIndex = 1;
            this.Button_Line.Click += new System.EventHandler(this.HighLightButton);
            // 
            // Button_Pencil
            // 
            this.Button_Pencil.BackColor = System.Drawing.Color.White;
            this.Button_Pencil.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Pencil;
            this.Button_Pencil.BorderWidth = 2F;
            this.Button_Pencil.ForeColor = System.Drawing.Color.Black;
            this.Button_Pencil.IsSelected = false;
            this.Button_Pencil.Location = new System.Drawing.Point(10, 10);
            this.Button_Pencil.Name = "Button_Pencil";
            this.Button_Pencil.Note = null;
            this.Button_Pencil.Size = new System.Drawing.Size(76, 76);
            this.Button_Pencil.TabIndex = 0;
            this.Button_Pencil.Click += new System.EventHandler(this.HighLightButton);
            // 
            // GDD_View_LevelDesigner1
            // 
            this.GDD_View_LevelDesigner1.BackColor = System.Drawing.Color.White;
            this.GDD_View_LevelDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GDD_View_LevelDesigner1.Location = new System.Drawing.Point(0, 0);
            this.GDD_View_LevelDesigner1.Name = "GDD_View_LevelDesigner1";
            this.GDD_View_LevelDesigner1.ShowFPS = false;
            this.GDD_View_LevelDesigner1.Size = new System.Drawing.Size(784, 442);
            this.GDD_View_LevelDesigner1.TabIndex = 0;
            this.GDD_View_LevelDesigner1.ViewingRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.GDD_View_LevelDesigner1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GDD_View_LevelDesigner1_MouseDown);
            this.GDD_View_LevelDesigner1.MouseLeave += new System.EventHandler(this.GDD_View_LevelDesigner1_MouseLeave);
            this.GDD_View_LevelDesigner1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GDD_View_LevelDesigner1_MouseMove);
            this.GDD_View_LevelDesigner1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GDD_View_LevelDesigner1_MouseUp);
            // 
            // LevelDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.optionPanel);
            this.Controls.Add(this.Button_Options);
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.Button_Eraser);
            this.Controls.Add(this.Button_Select);
            this.Controls.Add(this.Button_Shapes);
            this.Controls.Add(this.Button_Line);
            this.Controls.Add(this.Button_Pencil);
            this.Controls.Add(this.GDD_View_LevelDesigner1);
            this.Name = "LevelDesigner";
            this.Text = "LevelDesigner";
            this.Resize += new System.EventHandler(this.LevelDesigner_Resize);
            this.editPanel.ResumeLayout(false);
            this.optionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }       


        #endregion

        public GDD_Library.GDD_View GDD_View_LevelDesigner1;
        private GDD_Library.Controls.GDD_Button Button_Pencil;
        private GDD_Library.Controls.GDD_Button Button_Line;
        private GDD_Library.Controls.GDD_Button Button_Shapes;
        private GDD_Library.Controls.GDD_Button Button_Select;
        private GDD_Library.Controls.GDD_Button Button_Eraser;
        private GDD_Library.Controls.GDD_Button Button_Move;
        private GDD_Library.Controls.GDD_Button Button_Resize;
        private GDD_Library.Controls.GDD_Button Button_Rotate;
        private System.Windows.Forms.Panel editPanel;
        public GDD_Library.Controls.GDD_Button Button_Exit;
        private GDD_Library.Controls.GDD_Button Button_Reset;
        private GDD_Library.Controls.GDD_Button Button_Options;
        private GDD_Library.Controls.GDD_Button Button_Play;
        private GDD_Library.Controls.GDD_Button Button_Save;
        private System.Windows.Forms.Panel optionPanel;
    }
}