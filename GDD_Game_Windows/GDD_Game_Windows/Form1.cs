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
            obj.Location = new GDD_Point2F(50f, 50f);
            obj.Shape.Size = 10f;
            obj.Rotation = new GDD_Vector2F(45f, 0);

            //Creating a new square 
            GDD_Object obj1 = new GDD_Object(new GDD_Square());
            obj1.Location = new GDD_Point2F(78f, 100f);
            obj1.Shape.Size = 10f;
            obj1.Rotation = new GDD_Vector2F(125f, 0);
            obj1.Velocity = new GDD_Vector2F(0f, 5f);

            //Creating the scene and adding the square
            GDD_View1.Scene = new GDD_Scene(GDD_View1.Width, GDD_View1.Height);
            GDD_View1.Scene.Objects.Add(obj);
            GDD_View1.Scene.Objects.Add(obj1);
        }
    }
}
