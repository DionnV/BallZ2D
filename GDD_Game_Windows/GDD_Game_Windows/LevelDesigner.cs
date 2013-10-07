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
using GDD_Library.LevelDesign;

namespace GDD_Game_Windows
{
    public partial class LevelDesigner : Form
    {
        public List<Button> buttons = new List<Button>();
        private GDD_Point2F Line_Start;
        private GDD_Point2F Line_End;
        private List<GDD_Object> Lines = new List<GDD_Object>();
        private GDD_Object Line_Preview = new GDD_Object(new GDD_Line());
        private GDD_Object Circle_Preview = new GDD_Object(new GDD_Circle());
        private GDD_Object Square_Preview = new GDD_Object(new GDD_Square());
        private GDD_Object Bucket_Preview = new GDD_Object(new GDD_Bucket());
        private GDD_Object SelectedObj;
        private string backgroundpath = "";
        

        public LevelDesigner()
        {
            InitializeComponent();
        }

        private void LevelDesigner_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(800, 800);

            //Add all buttons to the list
            buttons.Add(Pencil);
            buttons.Add(Line);
            buttons.Add(Ball);
            buttons.Add(Square);
            buttons.Add(Bucket);
            buttons.Add(SelectButton);
            buttons.Add(DeleteAll);

            GDD_View_LevelDesigner1.graphicsTimer.Start();

        }

        private void GDD_View_LevelDesigner1_MouseDown(object sender, MouseEventArgs e)
        {
            int selected = 0;
            {
                GDD_Point2F location = new GDD_Point2F(e.X, e.Y);
                
                for (int i = 0; i < buttons.Count - 1; i++)
                {
                    if (buttons[i].BackColor == Color.Green)
                    {
                        selected = i;
                    }
                }

                switch (selected)
                {
                    case 0:
                        //Pencil

                        //Recording the start of the Line
                        Line_Start = new GDD_Point2F(e.X, e.Y);
                        break;
                    case 1:
                        //Line

                        //Recording the start of the Line
                        Line_Start = new GDD_Point2F(e.X, e.Y);

                        Line_Preview = GDD_Line.Create(Line_Start, Line_Start);
                        Line_Preview.GravityType = GDD_GravityType.Static;

                        GDD_View_LevelDesigner1.Scene.Objects.Add(Line_Preview);
                        Lines.Add(Line_Preview);
                        break;
                    case 2:
                        //Ball
                        Circle_Preview.Location = location;
                        Circle_Preview.Shape.Size = 50f;
                        Circle_Preview.Mass = 50f;
                        Circle_Preview.Rotation = new GDD_Vector2F(0f, 0f);
                        Circle_Preview.Velocity = new GDD_Point2F(0f, 0f);
                        Circle_Preview.GravityType = GDD_GravityType.Static;
                        GDD_View_LevelDesigner1.Scene.Objects.Add(Circle_Preview);
                        break;
                    case 3:
                        //Square
                        Square_Preview.Location = location;
                        Square_Preview.Shape.Size = 50f;
                        Square_Preview.Mass = 50f;
                        Square_Preview.Rotation = new GDD_Vector2F(0, 0f);
                        Square_Preview.Velocity = new GDD_Point2F(0f, 0f);
                        Square_Preview.GravityType = GDD_GravityType.Static;
                        GDD_View_LevelDesigner1.Scene.Objects.Add(Square_Preview);
                        break;
                    case 4:
                        //Bucket
                        Bucket_Preview.Location = location;
                        Bucket_Preview.Shape.Size = 110f;
                        Bucket_Preview.Mass = 100f;
                        Bucket_Preview.Rotation = new GDD_Vector2F(0f, 0f);
                        Bucket_Preview.Velocity = new GDD_Point2F(0f, 0f);
                        Bucket_Preview.GravityType = GDD_GravityType.Static;
                        GDD_View_LevelDesigner1.Scene.Objects.Add(Bucket_Preview);
                        break;
                    case 5:
                        //Select
                        //Make the selected item turn gray
                        if (e.Button == MouseButtons.Left)
                        {
                            foreach (GDD_Object obj in GDD_View_LevelDesigner1.Scene.Objects)
                            {
                                if (obj.Shape.Contains(new GDD_Point2F(e.X, e.Y)))
                                {
                                    obj.Shape.DrawingColor = new SolidBrush(Color.Gray);
                                    SelectedObj = obj;
                                    break;
                                }
                            }

                        }
                        break;

                }
            }
        }

        private void GDD_View_LevelDesigner1_MouseMove(object sender, MouseEventArgs e)
        {
            GDD_Point2F location = new GDD_Point2F(e.X, e.Y);
            int selected = 0;
            for (int i = 0; i < buttons.Count - 1; i++)
            {
                if (buttons[i].BackColor == Color.Green)
                {
                    selected = i;
                }
            }
            if (selected != 5)
            {
                if (SelectedObj != null)
                {
                    SelectedObj.Shape.DrawingColor = new SolidBrush(Color.White);
                    SelectedObj = null;
                }
            }
            switch (selected)
            {
                case 0:
                    //Pencil
                    //Only proceding if the mousebutton is down
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //Redording the end of the line
                        Line_End = new GDD_Point2F(e.X, e.Y);

                        //Using the Start and End to add a new line to ther scene
                        GDD_Object obj = GDD_Line.Create(Line_Start, Line_End);

                        //Adding the line
                        GDD_View_LevelDesigner1.Scene.Objects.Add(obj);
                        Lines.Add(obj);

                        //Updating the start
                        Line_Start = Line_End;
                    }
                    break;
                case 1:
                    //Line
                    //Only proceding if the mousebutton is down
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //Redording the end of the line
                        Line_End = new GDD_Point2F(e.X, e.Y);

                        //Using the Start and End to add a new line to ther scene
                        GDD_Object obj = GDD_Line.Create(Line_Start, Line_End);

                        //Modifying line_preview
                        Line_Preview.Rotation = obj.Rotation;
                        Line_Preview.Shape.Size = obj.Shape.Size;
                    }
                    break;
                case 2:
                    //Ball
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        Circle_Preview.Location = location;
                    }
                    break;
                case 3:
                    //Square
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        Square_Preview.Location = location;
                    }
                    break;
                case 4:
                    //Bucket
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        Bucket_Preview.Location = location;
                    }
                    break;
                case 5:
                    //Select
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (SelectedObj != null)
                        {
                            SelectedObj.Location = location;
                        }
                    }                  
                    break;
            }
        }
            
    

        private void GDD_View_LevelDesigner1_MouseUp(object sender, EventArgs e)
        {
            int selected = 0;
            for (int i = 0; i < buttons.Count - 1; i++)
            {
                if (buttons[i].BackColor == Color.Green)
                {
                    selected = i;
                }
            }

            switch (selected)
            {
                default: break;
                case 2:
                    //Ball
                    Circle_Preview = new GDD_Object(new GDD_Circle());
                    break;
                case 3:
                    //Square
                    Square_Preview = new GDD_Object(new GDD_Square());
                    break;
                case 4:
                    //Bucket
                    Bucket_Preview = new GDD_Object(new GDD_Bucket());
                    break;
            } 
        }

        private void GDD_View_LevelDesigner1_MouseClick(object sender, MouseEventArgs e)
        {
            int selected = 0;
            for (int i = 0; i < buttons.Count - 1; i++)
            {
                if (buttons[i].BackColor == Color.Green)
                {
                    selected = i;
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                foreach (GDD_Object obj in GDD_View_LevelDesigner1.Scene.Objects)
                {
                    if(obj.Shape.Contains(new GDD_Point2F(e.X, e.Y)))
                    {
                        GDD_View_LevelDesigner1.Scene.Objects.Remove(obj);
                        break;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {           
            //Highlight this button and downlight the others
            foreach (Button button in buttons)
            {
                button.BackColor = Color.Gray;
            }

            Pencil.BackColor = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Highlight this button and downlight the others
            foreach (Button button in buttons)
            {
                button.BackColor = Color.Gray;
            }

            Line.BackColor = Color.Green;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Highlight this button and downlight the others
            foreach (Button button in buttons)
            {
                button.BackColor = Color.Gray;
            }

            Ball.BackColor = Color.Green;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Highlight this button and downlight the others
            foreach (Button button in buttons)
            {
                button.BackColor = Color.Gray;
            }

            Square.BackColor = Color.Green;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Highlight this button and downlight the others
            foreach (Button button in buttons)
            {
                button.BackColor = Color.Gray;
            }

            Bucket.BackColor = Color.Green;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Highlight this button and downlight the others
            foreach (Button button in buttons)
            {
                button.BackColor = Color.Gray;
            }

            SelectButton.BackColor = Color.Green;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to delete everything?",
                                                    "Really?",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
            if (answer == System.Windows.Forms.DialogResult.Yes)
            {
                //Delete everything in the form
                GDD_View_LevelDesigner1.Scene.Objects.Clear();
            }

            //Else do nothing
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Saves the current built level
            GDD_Level level = new GDD_Level();
            level.Objects = GDD_View_LevelDesigner1.Scene.Objects;
            level.info = new GDD_HeaderInfo();
            level.Background = backgroundpath;
            if (LevelName.Text != null)
            {
                level.info.LevelName = LevelName.Text;
            }
            if (CreatorBox.Text != null)
            {
                level.info.CreatorName = CreatorBox.Text;
            }
            level.info.VersionNumber = 1;
            level.info.LevelVersionNumber = 1;
            level.info.Level_Width = GDD_View_LevelDesigner1.Scene.Width;
            level.info.Level_Height = GDD_View_LevelDesigner1.Scene.Height;
            level.info.MaxLineLenght = 200;

            level.WriteToZipFile();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                backgroundpath = ofd.FileName;
            }
            BackgroundBox.Text = backgroundpath;
        }

        private void RotateBar_Scroll(object sender, EventArgs e)
        {
            if (SelectedObj != null)
            {
                SelectedObj.Rotation = new GDD_Vector2F(RotateBar.Value, SelectedObj.Rotation.Size);
            }
        }

        private void SizeBar_Scroll(object sender, EventArgs e)
        {
            if (SelectedObj != null)
            {
                SelectedObj.Shape.Size = SizeBar.Value;
            }
        }

    }
}
