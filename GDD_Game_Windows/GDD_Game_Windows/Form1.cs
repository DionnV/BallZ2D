﻿using System;
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

            //The bounce test
            //BucketTest();
            //BounceTest();
            //AngularMomentumTest();
            LineTest2();
            //LineTest();
            
            //Starting the graphics timer
            GDD_View1.graphicsTimer.Start();
        }

        private void BucketTest()
        {
            GDD_Object circle1 = new GDD_Object(new GDD_Circle());

            circle1.Location = new GDD_Point2F(300f, 300f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 50f;
            circle1.Rotation = new GDD_Vector2F(0f, 5f);
            circle1.Velocity = new GDD_Point2F(0f, 0f);

            GDD_Object bucket1 = new GDD_Object(new GDD_Bucket());
            bucket1.Location = new GDD_Point2F(300f, 500f);
            bucket1.Shape.Size = 100f;
            bucket1.Mass = 100f;
            bucket1.Rotation = new GDD_Vector2F(0f, 0f);
            bucket1.Velocity = new GDD_Point2F(0f, 0f);
            bucket1.GravityType = GDD_GravityType.Static;


            //Adding the circles
            GDD_View1.Scene.Objects.Add(circle1);
            GDD_View1.Scene.Objects.Add(bucket1);
        }

        private void LineTest()
        {
            GDD_Object circle1 = new GDD_Object(new GDD_Circle());

            circle1.Location = new GDD_Point2F(200f, 200f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 50f;
            circle1.Rotation = new GDD_Vector2F(0f, 0f);
            circle1.Velocity = new GDD_Point2F(500f, 0f);

            float r = 250f;
            float f = 360 / ((2f * r * (float)Math.PI) / 50f);

            //Looping 32 boxes
            for (int i = 0; i < 32; i++)
            {
                GDD_Point2F p1 = GDD_Math.VectorToDXDY(new GDD_Vector2F(f * i, 250f));
                GDD_Point2F p2 = GDD_Math.VectorToDXDY(new GDD_Vector2F(f * (i + 1), 250f));
                
                GDD_Object line1 = new GDD_Object(new GDD_Line());
                line1.Location = new GDD_Point2F(300f + p1.x, 300f + p1.y);
                line1.Shape.Size = 50f;
                line1.Mass = 50f;
                line1.Rotation = GDD_Math.DXDYToVector(new GDD_Point2F(p2.x - p1.x, p2.y - p1.y));
                line1.Velocity = new GDD_Point2F(0f, 0f);
                line1.GravityType = GDD_GravityType.Static;
                GDD_View1.Scene.Objects.Add(line1);

            }
            GDD_View1.Scene.Objects.Add(circle1);
        }

        private void LineTest2()
        {
            GDD_Object circle1 = new GDD_Object(new GDD_Circle());

            circle1.Location = new GDD_Point2F(100f, 350f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 50f;
            circle1.Rotation = new GDD_Vector2F(0f, 1f);
            circle1.Velocity = new GDD_Point2F(0f, 0f);

            float angle = 10;
            float LongSize = (float)(Math.Sqrt(2d) * 50f);
            GDD_Point2F dxdy = GDD_Math.VectorToDXDY(new GDD_Vector2F(90f + angle, 50f));


            //Placing a few lines
            for (int i = 0; i < 8; i++)
            {
                GDD_Object line1 = new GDD_Object(new GDD_Line());

                line1.Location = new GDD_Point2F(50f + dxdy.x * i, 400f + dxdy.y * i);
                line1.Shape.Size = 50f;
                line1.Mass = 50f;
                line1.Rotation = new GDD_Vector2F(angle + 90f, 0f);
                line1.Velocity = new GDD_Point2F(0f, 0f);
                line1.GravityType = GDD_GravityType.Static;
                GDD_View1.Scene.Objects.Add(line1);

            }
            GDD_View1.Scene.Objects.Add(circle1);
        }

        private void BounceTest()
        {

            GDD_Object circle1 = new GDD_Object(new GDD_Circle());

            circle1.Location = new GDD_Point2F(300f, 300f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 50f;
            circle1.Rotation = new GDD_Vector2F(0f, 5f);
            circle1.Velocity = new GDD_Point2F(-200f, -200f);

            float r = 250f;
            float f = 360 / ((2f * r * (float)Math.PI) / 50f);

            //Looping 32 boxes
            for (int i = 0; i < 32; i++)
            {
                GDD_Object square1 = new GDD_Object(new GDD_Square());
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
        }

        private void AngularMomentumTest()
        {

            GDD_Object circle1 = new GDD_Object(new GDD_Circle());

            circle1.Location = new GDD_Point2F(50f, 50f);
            circle1.Shape.Size = 50f;
            circle1.Mass = 50f;
            circle1.Rotation = new GDD_Vector2F(0f, 2f);
            circle1.Velocity = new GDD_Point2F(0f, 0f);
           
            //Angle of the boxes;
            float angle = 10;
            float LongSize = (float)(Math.Sqrt(2d) * 50f);
            GDD_Point2F dxdy = GDD_Math.VectorToDXDY(new GDD_Vector2F(90f + angle, 50f));

            //Placing a few boxes
            for (int i = 0; i < 4; i++)
            {
                GDD_Object square1 = new GDD_Object(new GDD_Square());
               
                square1.Location = new GDD_Point2F(50f + dxdy.x * i, 200f + dxdy.y * i);
                square1.Shape.Size = 50f;
                square1.Mass = 50f;
                square1.Rotation = new GDD_Vector2F(angle, 0f);
                square1.Velocity = new GDD_Point2F(0f, 0f);
                square1.GravityType = GDD_GravityType.Static;
                GDD_View1.Scene.Objects.Add(square1);

            }

            dxdy = GDD_Math.VectorToDXDY(new GDD_Vector2F(90f - angle, 50f));

            //Placing a few boxes
            for (int i = 0; i < 8; i++)
            {
                GDD_Object square1 = new GDD_Object(new GDD_Square());

                square1.Location = new GDD_Point2F(150f + dxdy.x * i, 450f + dxdy.y * i);
                square1.Shape.Size = 50f;
                square1.Mass = 50f;
                square1.Rotation = new GDD_Vector2F(-angle, 0f);
                square1.Velocity = new GDD_Point2F(0f, 0f);
                square1.GravityType = GDD_GravityType.Static;
                GDD_View1.Scene.Objects.Add(square1);

            }


            //Adding the circles
            GDD_View1.Scene.Objects.Add(circle1);
        }
    }
}
