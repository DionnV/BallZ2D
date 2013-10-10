

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
            this.LevelName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreatorName = new System.Windows.Forms.Label();
            this.CreatorBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BackgroundBox = new System.Windows.Forms.TextBox();
            this.RotateBar = new System.Windows.Forms.TrackBar();
            this.SizeBar = new System.Windows.Forms.TrackBar();
            this.label_Rotation = new System.Windows.Forms.Label();
            this.label_Size = new System.Windows.Forms.Label();
            this.Panel_Controls = new System.Windows.Forms.Panel();
            this.Button_Save = new GDD_Library.Controls.GDD_Button();
            this.Button_Browse = new GDD_Library.Controls.GDD_Button();
            this.Button_DeleteAll = new GDD_Library.Controls.GDD_Button();
            this.Button_Shapes = new GDD_Library.Controls.GDD_Button();
            this.Button_Line = new GDD_Library.Controls.GDD_Button();
            this.Button_Pencil = new GDD_Library.Controls.GDD_Button();
            this.GDD_View_LevelDesigner1 = new GDD_Library.GDD_View();
            this.Button_Eraser = new GDD_Library.Controls.GDD_Button();
            ((System.ComponentModel.ISupportInitialize)(this.RotateBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).BeginInit();
            this.Panel_Controls.SuspendLayout();
            this.SuspendLayout();
            // 
            // LevelName
            // 
            this.LevelName.Location = new System.Drawing.Point(8, 98);
            this.LevelName.Name = "LevelName";
            this.LevelName.Size = new System.Drawing.Size(100, 20);
            this.LevelName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Level name:";
            // 
            // CreatorName
            // 
            this.CreatorName.AutoSize = true;
            this.CreatorName.Location = new System.Drawing.Point(5, 121);
            this.CreatorName.Name = "CreatorName";
            this.CreatorName.Size = new System.Drawing.Size(73, 13);
            this.CreatorName.TabIndex = 10;
            this.CreatorName.Text = "Creator name:";
            // 
            // CreatorBox
            // 
            this.CreatorBox.Location = new System.Drawing.Point(8, 137);
            this.CreatorBox.Name = "CreatorBox";
            this.CreatorBox.Size = new System.Drawing.Size(100, 20);
            this.CreatorBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Background";
            // 
            // BackgroundBox
            // 
            this.BackgroundBox.Location = new System.Drawing.Point(8, 180);
            this.BackgroundBox.Name = "BackgroundBox";
            this.BackgroundBox.Size = new System.Drawing.Size(100, 20);
            this.BackgroundBox.TabIndex = 13;
            // 
            // RotateBar
            // 
            this.RotateBar.Location = new System.Drawing.Point(8, 267);
            this.RotateBar.Maximum = 360;
            this.RotateBar.Name = "RotateBar";
            this.RotateBar.Size = new System.Drawing.Size(104, 45);
            this.RotateBar.TabIndex = 15;
            this.RotateBar.TickFrequency = 45;
            this.RotateBar.Scroll += new System.EventHandler(this.RotateBar_Scroll);
            // 
            // SizeBar
            // 
            this.SizeBar.Location = new System.Drawing.Point(8, 348);
            this.SizeBar.Maximum = 200;
            this.SizeBar.Minimum = 10;
            this.SizeBar.Name = "SizeBar";
            this.SizeBar.Size = new System.Drawing.Size(104, 45);
            this.SizeBar.TabIndex = 16;
            this.SizeBar.TickFrequency = 10;
            this.SizeBar.Value = 10;
            this.SizeBar.Scroll += new System.EventHandler(this.SizeBar_Scroll);
            // 
            // label_Rotation
            // 
            this.label_Rotation.AutoSize = true;
            this.label_Rotation.Location = new System.Drawing.Point(8, 251);
            this.label_Rotation.Name = "label_Rotation";
            this.label_Rotation.Size = new System.Drawing.Size(47, 13);
            this.label_Rotation.TabIndex = 17;
            this.label_Rotation.Text = "Rotation";
            // 
            // label_Size
            // 
            this.label_Size.AutoSize = true;
            this.label_Size.Location = new System.Drawing.Point(8, 332);
            this.label_Size.Name = "label_Size";
            this.label_Size.Size = new System.Drawing.Size(27, 13);
            this.label_Size.TabIndex = 18;
            this.label_Size.Text = "Size";
            // 
            // Panel_Controls
            // 
            this.Panel_Controls.Controls.Add(this.Button_Save);
            this.Panel_Controls.Controls.Add(this.label_Size);
            this.Panel_Controls.Controls.Add(this.LevelName);
            this.Panel_Controls.Controls.Add(this.label_Rotation);
            this.Panel_Controls.Controls.Add(this.label1);
            this.Panel_Controls.Controls.Add(this.SizeBar);
            this.Panel_Controls.Controls.Add(this.CreatorName);
            this.Panel_Controls.Controls.Add(this.RotateBar);
            this.Panel_Controls.Controls.Add(this.CreatorBox);
            this.Panel_Controls.Controls.Add(this.Button_Browse);
            this.Panel_Controls.Controls.Add(this.label2);
            this.Panel_Controls.Controls.Add(this.BackgroundBox);
            this.Panel_Controls.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel_Controls.Location = new System.Drawing.Point(662, 0);
            this.Panel_Controls.Name = "Panel_Controls";
            this.Panel_Controls.Size = new System.Drawing.Size(122, 442);
            this.Panel_Controls.TabIndex = 19;
            // 
            // Button_Save
            // 
            this.Button_Save.BackColor = System.Drawing.Color.White;
            this.Button_Save.BorderWidth = 2F;
            this.Button_Save.ForeColor = System.Drawing.Color.Black;
            this.Button_Save.IsSelected = false;
            this.Button_Save.Location = new System.Drawing.Point(58, 12);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Note = null;
            this.Button_Save.Size = new System.Drawing.Size(50, 50);
            this.Button_Save.TabIndex = 7;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Browse
            // 
            this.Button_Browse.BackColor = System.Drawing.Color.White;
            this.Button_Browse.BorderWidth = 2F;
            this.Button_Browse.ForeColor = System.Drawing.Color.Black;
            this.Button_Browse.IsSelected = false;
            this.Button_Browse.Location = new System.Drawing.Point(46, 206);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Note = null;
            this.Button_Browse.Size = new System.Drawing.Size(62, 20);
            this.Button_Browse.TabIndex = 14;
            //this.Button_Browse.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // Button_DeleteAll
            // 
            this.Button_DeleteAll.BackColor = System.Drawing.Color.White;
            this.Button_DeleteAll.BorderWidth = 2F;
            this.Button_DeleteAll.ForeColor = System.Drawing.Color.Black;
            this.Button_DeleteAll.IsSelected = false;
            this.Button_DeleteAll.Location = new System.Drawing.Point(12, 380);
            this.Button_DeleteAll.Name = "Button_DeleteAll";
            this.Button_DeleteAll.Note = null;
            this.Button_DeleteAll.Size = new System.Drawing.Size(50, 50);
            this.Button_DeleteAll.TabIndex = 6;
            this.Button_DeleteAll.Click += new System.EventHandler(this.Button_DeleteAll_Click);
            // 
            // Button_Shapes
            // 
            this.Button_Shapes.BackColor = System.Drawing.Color.White;
            this.Button_Shapes.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Shapes;
            this.Button_Shapes.BorderWidth = 2F;
            this.Button_Shapes.ForeColor = System.Drawing.Color.Black;
            this.Button_Shapes.IsSelected = false;
            this.Button_Shapes.Location = new System.Drawing.Point(12, 180);
            this.Button_Shapes.Name = "Button_Shapes";
            this.Button_Shapes.Note = null;
            this.Button_Shapes.Size = new System.Drawing.Size(50, 50);
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
            this.Button_Line.Location = new System.Drawing.Point(12, 68);
            this.Button_Line.Name = "Button_Line";
            this.Button_Line.Note = null;
            this.Button_Line.Size = new System.Drawing.Size(50, 50);
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
            this.Button_Pencil.Location = new System.Drawing.Point(12, 12);
            this.Button_Pencil.Name = "Button_Pencil";
            this.Button_Pencil.Note = null;
            this.Button_Pencil.Size = new System.Drawing.Size(50, 50);
            this.Button_Pencil.TabIndex = 0;
            this.Button_Pencil.Click += new System.EventHandler(this.HighLightButton);
            // 
            // GDD_View_LevelDesigner1
            // 
            this.GDD_View_LevelDesigner1.BackColor = System.Drawing.Color.LightGray;
            this.GDD_View_LevelDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GDD_View_LevelDesigner1.Location = new System.Drawing.Point(0, 0);
            this.GDD_View_LevelDesigner1.Name = "GDD_View_LevelDesigner1";
            this.GDD_View_LevelDesigner1.Size = new System.Drawing.Size(784, 442);
            this.GDD_View_LevelDesigner1.TabIndex = 0;
            this.GDD_View_LevelDesigner1.ViewingRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.GDD_View_LevelDesigner1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GDD_View_LevelDesigner1_MouseClick);
            this.GDD_View_LevelDesigner1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GDD_View_LevelDesigner1_MouseDown);
            this.GDD_View_LevelDesigner1.MouseLeave += new System.EventHandler(this.GDD_View_LevelDesigner1_MouseLeave);
            this.GDD_View_LevelDesigner1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GDD_View_LevelDesigner1_MouseMove);
            this.GDD_View_LevelDesigner1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GDD_View_LevelDesigner1_MouseUp);
            // 
            // Button_Eraser
            // 
            this.Button_Eraser.BackColor = System.Drawing.Color.White;
            this.Button_Eraser.BackgroundImage = global::GDD_Game_Windows.Properties.Resources.Eraser;
            this.Button_Eraser.BorderWidth = 2F;
            this.Button_Eraser.ForeColor = System.Drawing.Color.Black;
            this.Button_Eraser.IsSelected = false;
            this.Button_Eraser.Location = new System.Drawing.Point(12, 124);
            this.Button_Eraser.Name = "Button_Eraser";
            this.Button_Eraser.Note = null;
            this.Button_Eraser.Size = new System.Drawing.Size(50, 50);
            this.Button_Eraser.TabIndex = 20;
            this.Button_Eraser.Click += new System.EventHandler(this.HighLightButton);
            // 
            // LevelDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.Button_Eraser);
            this.Controls.Add(this.Panel_Controls);
            this.Controls.Add(this.Button_DeleteAll);
            this.Controls.Add(this.Button_Shapes);
            this.Controls.Add(this.Button_Line);
            this.Controls.Add(this.Button_Pencil);
            this.Controls.Add(this.GDD_View_LevelDesigner1);
            this.Name = "LevelDesigner";
            this.Text = "LevelDesigner";
            this.Load += new System.EventHandler(this.LevelDesigner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RotateBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).EndInit();
            this.Panel_Controls.ResumeLayout(false);
            this.Panel_Controls.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private GDD_Library.GDD_View GDD_View_LevelDesigner1;
        private GDD_Library.Controls.GDD_Button Button_Pencil;
        private GDD_Library.Controls.GDD_Button Button_Line;
        private GDD_Library.Controls.GDD_Button Button_Shapes;
        private GDD_Library.Controls.GDD_Button Button_DeleteAll;
        private GDD_Library.Controls.GDD_Button Button_Save;
        private System.Windows.Forms.TextBox LevelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CreatorName;
        private System.Windows.Forms.TextBox CreatorBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BackgroundBox;
        private GDD_Library.Controls.GDD_Button Button_Browse;
        private System.Windows.Forms.TrackBar RotateBar;
        private System.Windows.Forms.TrackBar SizeBar;
        private System.Windows.Forms.Label label_Rotation;
        private System.Windows.Forms.Label label_Size;
        private System.Windows.Forms.Panel Panel_Controls;
        private GDD_Library.Controls.GDD_Button Button_Eraser;
    }
}