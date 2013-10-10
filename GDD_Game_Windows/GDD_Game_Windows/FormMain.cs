using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDD_Library;
using GDD_Library.Shapes;
using GDD_Library.Controls;
using GDD_Library.LevelDesign;

namespace GDD_Game_Windows
{
    public partial class FormMain : Form
    {
        private Panel CurrentPanel;
        private bool SoundOn = false;

        private List<GDD_Object> Lines = new List<GDD_Object>();
        private bool DrawingEnabled = false;

        //Defining the circle
        private GDD_Object ball = new GDD_Object(new GDD_Circle());

        //Defining the bucket
        private GDD_Object bucket = new GDD_Object(new GDD_Bucket());

        //Defining a previewed GDD_Line
        private GDD_Object Line_Preview = new GDD_Object(new GDD_Line());

        //Defining the eraser as a GDD_Square
        private GDD_Object Eraser = new GDD_Object(new GDD_Square());

        private GDD_Point2F Line_Start;
        private GDD_Point2F Line_End;

        //Defining an eraser cursor
        //Cursor eraser = new Cursor("./eraser.bmp");

        public FormMain()
        {
            InitializeComponent();
            this.PanelCustomLevels.SendToBack();
            this.PanelChapterSelect.SendToBack();
            this.PanelLevelSelect.SendToBack();
            this.PanelMain.SendToBack();
            this.PanelPlayNow.SendToBack();
            this.PanelSettings.SendToBack();

            //Initialize the eraser
            Eraser.Shape.Size = 10f;
            Eraser.Mass = 0; ;
            Eraser.Rotation = new GDD_Vector2F(0,0);
            Eraser.Velocity = new GDD_Point2F(0,0);
            Eraser.GravityType = GDD_GravityType.Static;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Setting the proper size
            this.ClientSize = new Size(800, 480);

            //Loading the background scene
            LoadBGScene();
            LoadMainMenu();

            //Starting the timer
            this.GDD_View1.graphicsTimer.Start();
        }

        private void LoadMainMenu()
        {
            if (CurrentPanel != null)
            {
                CurrentPanel.SendToBack();
            }
            this.PanelMain.BringToFront();
            CurrentPanel = PanelMain;
            Button_Back_Main.Text = "Main menu";
            Button_PlayNow.Text = "Play now";
            Button_Settings.Text = "Settings";
            Button_Store.Text = "Store";
            Button_LevelDesign.Text = "Level Designer";
        }

        private void LoadPlayMenu()
        {
            CurrentPanel.SendToBack();
            this.PanelPlayNow.BringToFront();
            CurrentPanel = PanelPlayNow;
            Button_Back_PlayNow.Text = "Choose a mode.";
            Button_Competitive.Text = "Competitive";
            Button_Custom.Text = "Custom";
        }

        private void LoadLevelDesigner()
        {
            System.Threading.Thread levelthread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenLevelDesigner));
            levelthread.Start();
            CurrentPanel.SendToBack();
            this.PanelMain.BringToFront();
            CurrentPanel = PanelMain;
        }

        private void LoadSettings()
        {
            CurrentPanel.SendToBack();
            this.PanelSettings.BringToFront();
            CurrentPanel = PanelSettings;
            Button_Back_Settings.Text = "Settings";
            Button_Sound.Text = "Sound: off";
        }

        private void LoadChapterSelect()
        {
            CurrentPanel.SendToBack();
            this.PanelChapterSelect.BringToFront();
            CurrentPanel = PanelChapterSelect;
            Button_Back_ChapterSelect.Text = "Choose a chapter.";
            Button_Chapter1.Text = "Chapter 1";
        }

        private void LoadLevelSelect()
        {
            CurrentPanel.SendToBack();
            this.PanelLevelSelect.BringToFront();
            CurrentPanel = PanelLevelSelect;
            Button_Back_LevelSelect.Text = "Choose a level.";
        }

        private void LoadCustomLevels()
        {
            CurrentPanel.SendToBack();
            this.PanelCustomLevels.BringToFront();
            CurrentPanel = PanelCustomLevels;
            Button_Back_CustomLevels.Text = "Choose a custom level.";
        }

        private void LoadPlayingScreen()
        {
            CurrentPanel.SendToBack();
            this.PanelPlaying.BringToFront();
            CurrentPanel = PanelPlaying;
            Button_Pencil.Text = "Pencil";
            Button_Line.Text = "Line";
            Button_StartGame.Text = "Start!";
            Button_Eraser.Text = "Eraser";

        }

        private void LoadStore()
        {
            //Not implemented yet
        }

        private void LoadBGScene()
        {
            LoadDefaultBG();
        }

        private void OpenLevelDesigner()
        {
            Application.Run(new LevelDesigner());
        }

        private void Button_PlayNow_Click(object sender, System.EventArgs e)
        {
            LoadPlayMenu();
        }

        private void Button_LevelDesign_Click(object sender, System.EventArgs e)
        {
            LoadLevelDesigner();            
        }

        private void Button_Settings_Click(object sender, System.EventArgs e)
        {
            LoadSettings();
        }

        private void Button_Sound_Click(object sender, System.EventArgs e)
        {
            if (!SoundOn)
            {
                Button_Sound.Text = "Sound: on";
                SoundOn = true;
            }
            else
            {
                Button_Sound.Text = "Sound: off";
            }

        }

        private void Button_Chapter1_Click(object sender, System.EventArgs e)
        {
            
            int col = 3;

            int x = 50;
            int y = 20;

            for (int i = 0; i < 10; i++)
            {
                if ((i % col) == 0)
                {
                    y += 85;
                    x = 50;
                }
              
                GDD_Button b = new GDD_Button();
                b.Note = "";
                b.Text = "" + (i+1);
                b.Location = new Point(x, y);
                b.BackColor = System.Drawing.Color.White;
                b.BorderWidth = 2F;
                b.Name = "ch1lev" + (i+1);
                b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                b.ForeColor = System.Drawing.Color.Black;
                b.Padding = new System.Windows.Forms.Padding(3);
                b.Size = new System.Drawing.Size(100, 75);
                b.TabIndex = 4;
                b.Click += new EventHandler(Button_LoadLevel);
                PanelLevelSelect.Controls.Add(b);

                x += 113;
            }
            LoadLevelSelect();
        }

        private void Button_LoadLevel(object sender, EventArgs e)
        {
            //Who pressed me?
            GDD_Button button = (GDD_Button)sender;

            //Bring the current panel to the background.
            CurrentPanel.SendToBack();

            //Stop the background.
            GDD_View1.Scene.Objects.Clear();

            //Stop the graphicstimer.
            GDD_View1.graphicsTimer.Stop();


            //Load the level.          
            GDD_Level level = GDD_IO.CreateFromZipFile("./Competitive/Chapter1/" + button.Name + ".zip");
            List<GDD_Object> newlist = new List<GDD_Object>();
            foreach (GDD_Object obj in level.Objects)
            {
                GDD_Object temp = new GDD_Object(obj.Shape);
                temp.Location = obj.Location;
                temp.Shape.Size = obj.Shape.Size;
                temp.Mass = obj.Mass; ;
                temp.Rotation = obj.Rotation;
                temp.Velocity = obj.Velocity;
                temp.GravityType = obj.GravityType;
                newlist.Add(temp);
            }
            GDD_View1.Scene.Objects = newlist;
            
            foreach (GDD_Object obj in GDD_View1.Scene.Objects)
            {
                if (obj.Shape is GDD_Circle)
                {
                    ball = obj;
                }
                if (obj.Shape is GDD_Bucket)
                {
                    bucket = obj;
                }
            }
            LoadPlayingScreen();
            GDD_View1.graphicsTimer.Start();
            DrawingEnabled = true;
        }

        private void Button_Custom_Click(object sender, System.EventArgs e)
        {
            LoadCustomLevels();
        }

        private void Button_Competitive_Click(object sender, System.EventArgs e)
        {
            LoadChapterSelect();
        }

        void Button_Line_Click(object sender, System.EventArgs e)
        {
            Button_Pencil.IsSelected = false;
            Button_Eraser.IsSelected = false;
            if (Button_Line.IsSelected)
            {
                Button_Line.IsSelected = false;
            }
            else
            {
                Button_Line.IsSelected = true;
            }
        }

        void Button_StartGame_Click(object sender, System.EventArgs e)
        {
            DrawingEnabled = false;
            ball.GravityType = GDD_GravityType.Normal;
        }

        void Button_Eraser_Click(object sender, System.EventArgs e)
        {
            //this.Cursor = eraser;

            Button_Line.IsSelected = false;
            Button_Pencil.IsSelected = false;
            if (Button_Eraser.IsSelected)
            {
                Button_Eraser.IsSelected = false;
            }
            else
            {
                Button_Eraser.IsSelected = true;
            }
            Point p = Cursor.Position;
            p = PointToClient(p);
            Eraser.Location = new GDD_Point2F(p.X, p.Y);
            Cursor.Hide();
            GDD_View1.Scene.Objects.Add(Eraser);
        }

        void Button_Pencil_Click(object sender, System.EventArgs e)
        {

            Button_Line.IsSelected = false;
            Button_Eraser.IsSelected = false;
            if (Button_Pencil.IsSelected)
            {
                Button_Pencil.IsSelected = false;
            }
            else
            {
                Button_Pencil.IsSelected = true;
            }
        }


        private void LoadDefaultBG()
        {
            //For our convienence
            GDD_Scene Scene = this.GDD_View1.Scene;

            GDD_Object obj = new GDD_Object(new GDD_Circle());
            obj.Shape.Size = 50f;
            obj.Location = new GDD_Point2F(600f, 10f);
            obj.Rotation = new GDD_Vector2F(10f, 0);
            obj.GravityType = GDD_GravityType.Normal;
            obj.Velocity_Vector = new GDD_Vector2F(80f, 200f);
            obj.FrontColor = Color.Black;
            ((GDD_Circle)obj.Shape).RestitutionRate = 0.98f;
            Scene.Objects.Add(obj);

            obj = new GDD_Object(new GDD_Line());
            obj.Shape.Size = 460f;
            obj.Location = new GDD_Point2F(780f, 470f);
            obj.Rotation = new GDD_Vector2F(0f, 0);
            obj.GravityType = GDD_GravityType.Static;
            obj.FrontColor = Color.Black;
            Scene.Objects.Add(obj);

            obj = new GDD_Object(new GDD_Line());
            obj.Shape.Size = 370f;
            obj.Location = new GDD_Point2F(410f, 470);
            obj.Rotation = new GDD_Vector2F(90f, 0);
            obj.GravityType = GDD_GravityType.Static;
            obj.FrontColor = Color.Black;
            Scene.Objects.Add(obj);

            obj = new GDD_Object(new GDD_Line());
            obj.Shape.Size = 460f;
            obj.Location = new GDD_Point2F(410f, 10f);
            obj.Rotation = new GDD_Vector2F(180f, 0);
            obj.GravityType = GDD_GravityType.Static;
            obj.FrontColor = Color.Black;
            Scene.Objects.Add(obj);

            obj = new GDD_Object(new GDD_Bucket());
            obj.Shape.Size = 100f;
            obj.Location = new GDD_Point2F(600f, 430f);
            obj.Rotation = new GDD_Vector2F(180f, 0);
            obj.GravityType = GDD_GravityType.Static;
            obj.FrontColor = Color.Black;
           // Scene.Objects.Add(obj);           
        }

        private void GDD_View1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (DrawingEnabled)
            {
                /*if (Button_Eraser.IsSelected)
                {
                    foreach(GDD_Object line in Lines)
                    {
                        if (Eraser.Shape.Contains(line.Location))
                        {
                            Lines.Remove(line);
                            GDD_View1.Scene.Objects.Remove(line);
                            break;
                        }
                    }                  
                }
                else*/ if (!GDD_View1.Scene.PointInZone(new GDD_Point2F(e.X, e.Y), GDD_ZoneType.NoDraw))
                {
                    {
                        //Recording the start of the Line
                        Line_Start = new GDD_Point2F(e.X, e.Y);

                        //Creating a new line
                        if (Button_Line.IsSelected)
                        {
                            Line_Preview = GDD_Line.Create(Line_Start, Line_Start);
                            Line_Preview.GravityType = GDD_GravityType.Static;

                            GDD_View1.Scene.Objects.Add(Line_Preview);
                            Lines.Add(Line_Preview);
                        }
                    }
                }
            }
        }

        private void GDD_View1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (DrawingEnabled)
            {
                if (Button_Eraser.IsSelected)
                {
                    Point p = Cursor.Position;
                    p = PointToClient(p);
                    Eraser.Location = new GDD_Point2F(p.X, p.Y);
                }
                //Only proceding if the mousebutton is down
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    /*if (Button_Eraser.IsSelected)
                    {
                        foreach (GDD_Object line in Lines)
                        {
                            if (Eraser.Shape.Contains(line.Location))
                            {
                                Lines.Remove(line);
                                GDD_View1.Scene.Objects.Remove(line);
                                break;
                            }
                        }
                    }
                    else*/
                    {
                        //Making the right frontcolor depending on the current end of the line
                        Line_Preview.FrontColor = GDD_View1.Scene.PointInZone(new GDD_Point2F(e.X, e.Y), GDD_ZoneType.NoDraw) ? Color.Red : Color.Black;

                        GDD_View1.Scene.LineThroughObject(Line_Preview);

                        //Redording the end of the line
                        Line_End = new GDD_Point2F(e.X, e.Y);

                        //Using the Start and End to add a new line to ther scene
                        GDD_Object obj = GDD_Line.Create(Line_Start, Line_End);

                        //Determining what to do with the start and end
                        if (Button_Pencil.IsSelected)
                        {
                            //Adding the line
                            GDD_View1.Scene.Objects.Add(obj);
                            Lines.Add(obj);

                            //Updating the start
                            Line_Start = Line_End;
                        }

                        //
                        if (Button_Line.IsSelected)
                        {
                            //if (!nodraw.Contains(new Point(e.X, e.Y)))
                            //{
                            //Only proceding if the mousebutton is down
                            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {
                                //Modifying line_preview
                                Line_Preview.Rotation = obj.Rotation;
                                Line_Preview.Shape.Size = obj.Shape.Size;
                            }
                        }
                    }
                }
            }
        }

    
        

        private void GDD_View1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (DrawingEnabled)
            {
                //Only proceding if the mousebutton is down
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //Making the right frontcolor depending on the current end of the line
                    Line_Preview.FrontColor = GDD_View1.Scene.PointInZone(new GDD_Point2F(e.X, e.Y), GDD_ZoneType.NoDraw) ? Color.Red : Color.Black;

                    GDD_View1.Scene.LineThroughObject(Line_Preview);

                    //Redording the end of the line
                    Line_End = new GDD_Point2F(e.X, e.Y);

                    //Using the Start and End to add a new line to ther scene
                    GDD_Object obj = GDD_Line.Create(Line_Start, Line_End);

                    //Determining what to do with the start and end
                    if (Button_Pencil.IsSelected)
                    {
                        //Adding the line
                        GDD_View1.Scene.Objects.Add(obj);
                        Lines.Add(obj);

                        //Updating the start
                        Line_Start = Line_End;
                    }

                    //
                    if (Button_Line.IsSelected)
                    {
                        //if (!nodraw.Contains(new Point(e.X, e.Y)))
                        //{
                        //Only proceding if the mousebutton is down
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            //Modifying line_preview
                            Line_Preview.Rotation = obj.Rotation;
                            Line_Preview.Shape.Size = obj.Shape.Size;
                        }
                    }
                }
            }
        }        
    }
}
