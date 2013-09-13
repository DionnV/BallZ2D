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

            //Creating a new square 
            GDD_Object obj = new GDD_Object(new GDD_Square());
            obj.Location = new GDD_Point2F(50f, 250f);
            obj.Shape.Size = 10f;
            obj.Rotation = new GDD_Vector2F(270f, 0);

            //Creating a new square 
            GDD_Object obj1 = new GDD_Object(new GDD_Square());
            obj1.Location = new GDD_Point2F(50f, 250f);
            obj1.Shape.Size = 10f;
            obj1.Rotation = new GDD_Vector2F(125f, 2f);
            obj1.Velocity = new GDD_Point2F(5f, -5f);

            GDD_Object circle1 = new GDD_Object(new GDD_Circle());
            circle1.Location = new GDD_Point2F(0f, 150f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 25f;
            circle1.Rotation = new GDD_Vector2F(0f, 2f);
            circle1.Velocity = new GDD_Point2F(10f, -2f);


            GDD_Object circle2 = new GDD_Object(new GDD_Circle());
            circle2.Location = new GDD_Point2F(250f, 100f);
            circle2.Shape.Size = 20f;
            circle2.Mass = 1f;
            circle2.Rotation = new GDD_Vector2F(0f, 2f);
            circle2.Velocity = new GDD_Point2F(-5f, 0f);

            //Creating the scene and adding the square
            GDD_View1.graphicsTimer.Stop();
            GDD_View1.Scene = new GDD_Scene(GDD_View1.Width, GDD_View1.Height);
            //GDD_View1.Scene.Objects.Add(obj);
            //GDD_View1.Scene.Objects.Add(obj1);
            GDD_View1.Scene.Objects.Add(circle1);
            GDD_View1.Scene.Objects.Add(circle2);
            GDD_View1.graphicsTimer.Start();


        }
    }
}
