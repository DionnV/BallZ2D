using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDD_Library;
using GDD_Library.Shapes;
using GDD_Library.Controls;
using GDD_Library.LevelDesign;

namespace GDD_Game_Windows
{
    /// <summary>
    /// This class holds the whole menu.
    /// </summary>
    public partial class FormMain : Form
    {
        private Panel CurrentPanel;
        private Panel PreviousPanel;
        private bool SoundOn = false;

        private LevelDesigner playzone;

        /// <summary>
        /// Contructor will initialize all components.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            this.PanelCustomLevels.SendToBack();
            this.PanelChapterSelect.SendToBack();
            this.PanelLevelSelect.SendToBack();
            this.PanelMain.SendToBack();
            this.PanelPlayNow.SendToBack();
            this.PanelSettings.SendToBack();
        }

        /// <summary>
        /// This will load the FormMain and start the graphics.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This will load the main menu screen.
        /// </summary>
        private void LoadMainMenu()
        {
            if (CurrentPanel != null)
            {
                CurrentPanel.SendToBack();
                PreviousPanel = CurrentPanel;
            }
            else
            {
                PreviousPanel = PanelMain;
            }
            this.PanelMain.BringToFront();
            CurrentPanel = PanelMain;
            Button_Back_Main.Text = "Main menu";
            Button_PlayNow.Text = "Play now";
            Button_Settings.Text = "Settings";
            Button_Store.Text = "Store";
            Button_LevelDesign.Text = "Level Designer";
        }

        /// <summary>
        /// This will load the play menu screen.
        /// </summary>
        private void LoadPlayMenu()
        {
            CurrentPanel.SendToBack();
            this.PanelPlayNow.BringToFront();
            PreviousPanel = CurrentPanel;
            CurrentPanel = PanelPlayNow;
            Button_Back_PlayNow.Text = "Choose a mode.";
            Button_Competitive.Text = "Competitive";
            Button_Custom.Text = "Custom";
        }

        /// <summary>
        /// This will load the level designer.
        /// </summary>
        private void LoadLevelDesigner()
        {
            //Hide this form.
            this.Hide();
            
            if (this.playzone != null)
            {
                this.playzone.Dispose();
                this.playzone = null;          
            }

            //Create a new one if the current one is null
            this.playzone = new LevelDesigner();

            //Add the FormClosed Event
            this.playzone.FormClosed += playzone_FormClosed;

            //We have designer rights.
            this.playzone.isDesigner = true;

            //Set location and show the form.
            this.playzone.Location = this.Location;
            this.playzone.Show();
        }

        /// <summary>
        /// This will load the settings menu.
        /// </summary>
        private void LoadSettings()
        {
            CurrentPanel.SendToBack();
            this.PanelSettings.BringToFront();
            PreviousPanel = CurrentPanel;
            CurrentPanel = PanelSettings;
            Button_Back_Settings.Text = "Settings";
            Button_Sound.Text = "Sound: off";
        }

        /// <summary>
        /// This will load the chapter select menu.
        /// </summary>
        private void LoadChapterSelect()
        {
            CurrentPanel.SendToBack();
            this.PanelChapterSelect.BringToFront();
            PreviousPanel = CurrentPanel;
            CurrentPanel = PanelChapterSelect;
            Button_Back_ChapterSelect.Text = "Choose a chapter.";
            Button_Chapter1.Text = "Chapter 1";
        }

        /// <summary>
        /// This will load the level select menu.
        /// </summary>
        private void LoadLevelSelect()
        {
            CurrentPanel.SendToBack();
            this.PanelLevelSelect.BringToFront();
            PreviousPanel = CurrentPanel;
            CurrentPanel = PanelLevelSelect;
            Button_Back_LevelSelect.Text = "Choose a level.";
        }

        /// <summary>
        /// This will load the custom level menu.
        /// </summary>
        private void LoadCustomLevels()
        {
            CurrentPanel.SendToBack();
            this.PanelCustomLevels.BringToFront();
            PreviousPanel = CurrentPanel;
            CurrentPanel = PanelCustomLevels;
            Button_Back_CustomLevels.Text = "Choose a custom level.";
        }

       
        /// <summary>
        /// This will load the store menu.
        /// </summary>
        private void LoadStore()
        {
            //Not implemented yet
        }

        /// <summary>
        /// This will load the background.
        /// </summary>
        private void LoadBGScene()
        {
            //Load the default background.
            LoadDefaultBG();
        }

        
        /// <summary>
        /// This will handle the clicking on the PlayNow button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_PlayNow_Click(object sender, System.EventArgs e)
        {
            //Load the play menu.
            LoadPlayMenu();
        }

        /// <summary>
        /// This will handle the clicking on the LevelDesign button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_LevelDesign_Click(object sender, System.EventArgs e)
        {
            //Load the level designer.
            LoadLevelDesigner();            
        }

        /// <summary>
        /// This will handle the clicking on the Settings button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Settings_Click(object sender, System.EventArgs e)
        {
            //Load the settings menu.
            LoadSettings();
        }

        private void Button_GoBack_Click(object sender, System.EventArgs e)
        {
            CurrentPanel.SendToBack();
            PreviousPanel.BringToFront();
            CurrentPanel = PreviousPanel;
        }

        /// <summary>
        /// This will handle the clicking on the Sound button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Sound_Click(object sender, System.EventArgs e)
        {
            //Sound is not implemented yet
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

        /// <summary>
        /// This will handle the clicking on the Chapter1 button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Chapter1_Click(object sender, System.EventArgs e)
        {
            //We will make 3 columns
            int col = 3;

            //Tile size
            int x = 50;
            int y = 20;

            //Add tiles to the panel
            for (int i = 0; i < 7; i++)
            {
                //Add a new row after 3 tiles
                if ((i % col) == 0)
                {
                    y += 85;
                    x = 50;
                }
              
                //Add the button
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

                //Increase x for the next button
                x += 113;
            }

            //Load the levelselect.
            LoadLevelSelect();
        }

        /// <summary>
        /// This will load the selected level.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_LoadLevel(object sender, EventArgs e)
        {
            //Who pressed me?
            GDD_Button button = (GDD_Button)sender;
            
            //Hide the FormMain.
            this.Hide();

            //Make a new playzone with no designer rights
            if (this.playzone == null)
            {
                this.playzone = new LevelDesigner();
                this.playzone.FormClosed += playzone_FormClosed;

            }
            this.playzone.isDesigner = false;
            this.playzone.Location = this.Location;          

            //Load the level.          
            GDD_Level level = GDD_IO.LoadFromZipFile("./Competitive/Chapter1/" + button.Name + ".zip");

            //Put the levels in a new list, because serializing gives errors with the Owners.
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

            //This works fine though.
            level.Objects = newlist;
            
            //Load the level
            this.playzone.LoadLevel(level);

            //Show the playzone
            playzone.Show();

            //LoadPlayingScreen();
            //GDD_View1.graphicsTimer.Start();
            //DrawingEnabled = true;
        }

        /// <summary>
        /// This will handle the clicking on the custom button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Custom_Click(object sender, System.EventArgs e)
        {
            //Load the custom levels menu.
            LoadCustomLevels();
        }

        /// <summary>
        /// This will handle the clicking on the competitive button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Competitive_Click(object sender, System.EventArgs e)
        {
            //Load the chapter select.
            LoadChapterSelect();
        }

/*        void Button_Line_Click(object sender, System.EventArgs e)
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
            //DrawingEnabled = false;
            //ball.GravityType = GDD_GravityType.Normal;
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

 */

        /// <summary>
        /// This will handle the closing of the playzone form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playzone_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            //Dispose and set to null.
            this.playzone.Dispose();
            this.playzone = null;

            //Show the main form.
            this.Show();          
        }

        private void Button_Exit_Click(object sender, System.EventArgs e)
        {
            //Dispose and set to null.
            this.playzone.Dispose();
            this.playzone = null;

            //Show the main form.
            this.Show();
        }  

        /// <summary>
        /// This will load the default background.
        /// </summary>
        private void LoadDefaultBG()
        {
            //For our convienence
            GDD_Scene Scene = this.GDD_View1.Scene;

            //Add a circle
            GDD_Object obj = new GDD_Object(new GDD_Circle());
            obj.Shape.Size = 50f;
            obj.Location = new GDD_Point2F(600f, 10f);
            obj.Rotation = new GDD_Vector2F(10f, 0);
            obj.GravityType = GDD_GravityType.Normal;
            obj.Velocity_Vector = new GDD_Vector2F(80f, 200f);
            obj.FrontColor = Color.Black;
            ((GDD_Circle)obj.Shape).RestitutionRate = 0.98f;
            Scene.Objects.Add(obj);

            //Add 3 lines.
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

            //Add a bucket.
            obj = new GDD_Object(new GDD_Bucket());
            obj.Shape.Size = 100f;
            obj.Location = new GDD_Point2F(600f, 430f);
            obj.Rotation = new GDD_Vector2F(180f, 0);
            obj.GravityType = GDD_GravityType.Static;
            obj.FrontColor = Color.Black;

            //Or not
            //Scene.Objects.Add(obj);           
        }
/*
        private void GDD_View1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (DrawingEnabled)
            {
                if (!GDD_View1.Scene.PointInZone(new GDD_Point2F(e.X, e.Y), GDD_ZoneType.NoDraw))
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
                    else
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
 */

        private void FormMain_Resize(object sender, EventArgs e)
        {
            //Updating all buttons to the right location
            
        }
    }
}
