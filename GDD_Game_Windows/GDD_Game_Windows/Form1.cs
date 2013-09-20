using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GDD_Library;
using GDD_Library.Shapes;

namespace GDD_Game_Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            GDD_Object circle1 = new GDD_Object(new GDD_Circle());
            GDD_Object circle2 = new GDD_Object(new GDD_Circle());
            GDD_Object square1 = new GDD_Object(new GDD_Square());
            GDD_Object square2 = new GDD_Object(new GDD_Square());
            GDD_Object square3 = new GDD_Object(new GDD_Square());
            GDD_Object line1 = new GDD_Object(new GDD_Line());

            line1.Location = new GDD_Point2F(100f, 100f);
            line1.Shape.Size = 200f;
            line1.Rotation = new GDD_Vector2F(40f, 0f);
            line1.Velocity = new GDD_Point2F(0f, 0f);
            line1.GravityType = GDD_GravityType.Static;

            circle1.Location = new GDD_Point2F(210f, 0f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 50f;
            circle1.Rotation = new GDD_Vector2F(0f, 0f);
            circle1.Velocity = new GDD_Point2F(0.5f, -20f);
            
            circle2.Location = new GDD_Point2F(100f, 300f);
            circle2.Shape.Size = 50f;
            circle2.Mass = 50f;
            circle2.Rotation = new GDD_Vector2F(0f, 0f);
            circle2.Velocity = new GDD_Point2F(0f, 0f);
            circle2.GravityType = GDD_GravityType.Static;

            square1.Location = new GDD_Point2F(180f, 300f);
            square1.Shape.Size = 50f;
            square1.Mass = 50f;
            square1.Rotation = new GDD_Vector2F(0f, 0f);
            square1.Velocity = new GDD_Point2F(0f, 0f);
            square1.GravityType = GDD_GravityType.Static;

            square2.Location = new GDD_Point2F(320f, 400f);
            square2.Shape.Size = 50f;
            square2.Mass = 50f;
            square2.Rotation = new GDD_Vector2F(-30f, 0f);
            square2.Velocity = new GDD_Point2F(0f, 0f);
            square2.GravityType = GDD_GravityType.Static;



            //Creating the scene and adding the square
            GDD_View1.graphicsTimer.Stop();
            GDD_View1.Scene = new GDD_Scene(GDD_View1.Width, GDD_View1.Height);
            //GDD_View1.Scene.Objects.Add(obj);
            //GDD_View1.Scene.Objects.Add(obj1);
            GDD_View1.Scene.Objects.Add(circle1);
            GDD_View1.Scene.Objects.Add(circle2);
            GDD_View1.Scene.Objects.Add(square1);
            GDD_View1.Scene.Objects.Add(square2);
            GDD_View1.Scene.Objects.Add(line1);
            GDD_View1.graphicsTimer.Start();


        }
    }
}
