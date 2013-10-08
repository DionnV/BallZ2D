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

namespace GDD_Game_Windows
{
    public partial class FormMain : Form
    {
        private Panel CurrentPanel;
        public FormMain()
        {
            InitializeComponent();
            Button_Back.Text = "Main menu";
            Button_PlayNow.Text = "Play now";
            Button_Settings.Text = "Settings";
            Button_Store.Text = "Store";
            Button_LevelDesigner.Text = "Level Designer";
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
            CurrentPanel.SendToBack();
            this.PanelMain.BringToFront();
            CurrentPanel = PanelMain;
        }

        private void LoadPlayMenu()
        {
            CurrentPanel.SendToBack();
            this.PanelPlayNow.BringToFront();
            CurrentPanel = PanelPlayNow;
        }

        private void LoadLevelDesigner()
        {
            Application.Run(new LevelDesigner());
            CurrentPanel.SendToBack();
            this.PanelMain.BringToFront();
            CurrentPanel = PanelMain;
        }

        private void LoadSettings()
        {
            CurrentPanel.SendToBack();
            this.PanelSettings.BringToFront();
            CurrentPanel = PanelSettings;
        }

        private void LoadChapterSelect()
        {
            CurrentPanel.SendToBack();
            this.PanelChapterSelect.BringToFront();
            CurrentPanel = PanelChapterSelect;
        }

        private void LoadLevelSelect()
        {
            CurrentPanel.SendToBack();
            this.PanelLevelSelect.BringToFront();
            CurrentPanel = PanelLevelSelect;
        }

        private void LoadCustomLevels()
        {
            CurrentPanel.SendToBack();
            this.PanelCustomLevels.BringToFront();
            CurrentPanel = PanelCustomLevels;
        }

        private void LoadStore()
        {
            //Not implemented yet
        }


        private void LoadBGScene()
        {
            LoadDefaultBG();
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
    }
}
