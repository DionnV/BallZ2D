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
            //Creating the scene and adding the square
            GDD_View1.graphicsTimer.Stop();
            GDD_View1.Scene = new GDD_Scene(GDD_View1.Width, GDD_View1.Height);



            GDD_Object circle1 = new GDD_Object(new GDD_Circle());
            
            circle1.Location = new GDD_Point2F(300f, 300f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 50f;
            circle1.Rotation = new GDD_Vector2F(0f, 5f);
            circle1.Velocity = new GDD_Point2F(-45f, -1000f);
            
            for (int i = 0; i <32; i++)
            {
                GDD_Object square1 = new GDD_Object(new GDD_Square());

                float r = 250f;
                float f = 360 / ((2f * r * (float)Math.PI)/50f);

                GDD_Point2F dxdy = GDD_Math.VectorToDXDY(new GDD_Vector2F(270f - f * i, 250f));

                square1.Location = new GDD_Point2F(300f + dxdy.x, 300f + dxdy.y);
                square1.Shape.Size = 50f;
                square1.Mass = 50f;
                square1.Rotation = new GDD_Vector2F(-f * i, 0f);
                square1.Velocity = new GDD_Point2F(0f, 0f);
                square1.GravityType = GDD_GravityType.Static;
                GDD_View1.Scene.Objects.Add(square1);
                
            }


          

            
          
            //Adding the circles
            GDD_View1.Scene.Objects.Add(circle1);
            GDD_View1.graphicsTimer.Start();
            


        }
    }
}
