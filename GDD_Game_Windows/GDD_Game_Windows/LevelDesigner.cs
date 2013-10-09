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
using GDD_Library.Controls;
using System.Reflection;

namespace GDD_Game_Windows
{
    public partial class LevelDesigner : Form
    {
        public List<GDD_Button> buttons = new List<GDD_Button>();
        private GDD_Point2F Line_Start;
        private GDD_Point2F Line_End;
        private List<GDD_Object> Lines = new List<GDD_Object>();
        private GDD_Object Line_Preview = new GDD_Object(new GDD_Line());
        private GDD_Object SelectedObj;
        private GDD_Object EraserSphere;

        private string backgroundpath = "";
        private GDD_Button shapePanel;

        public LevelDesigner()
        {
            InitializeComponent();
        }

        private void LevelDesigner_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(800, 480);

            //Add all buttons to the list
            buttons.Add(Button_Pencil);
            buttons.Add(Button_Line);
            buttons.Add(Button_Eraser);
            buttons.Add(Button_Shapes);
            buttons.Add(Button_DeleteAll);

            //Set the text of the GDD_Buttons.
            this.Button_DeleteAll.Text = "Delete All";

            Button_Browse.Text = "Browse...";
            Button_Save.Text = "Save";


            GDD_View_LevelDesigner1.graphicsTimer.Start();

        }

        private void GDD_View_LevelDesigner1_MouseDown(object sender, MouseEventArgs e)
        {
            //First off; checking if we clicked on a polygon object
            foreach (GDD_Object obj in this.GDD_View_LevelDesigner1.Scene.Objects)
            {
                //Are we clicking on it?
                if (obj.Shape.ContainsPoint(new GDD_Point2F(e.X, e.Y)))
                {
                    SelectedObj = obj;
                    return;
                }
                
            }

            //Are we using a pencil?
            if (Button_Pencil.IsSelected)
            {
                //Recording the start of the Line
                if (e.Button == MouseButtons.Left)
                {
                    Line_Start = new GDD_Point2F(e.X, e.Y);
                }

                return;
            }

            //Are we using a line?
            if (Button_Line.IsSelected)
            {
                //Recording the start of the line
                if (e.Button == MouseButtons.Left)
                {
                    Line_Start = new GDD_Point2F(e.X, e.Y);

                    Line_Preview = GDD_Line.Create(Line_Start, Line_Start);
                    Line_Preview.GravityType = GDD_GravityType.Static;

                    GDD_View_LevelDesigner1.Scene.Objects.Add(Line_Preview);
                    Lines.Add(Line_Preview);
                }

                return;
            }

            //Are we erasing stuff?
            if (Button_Eraser.IsSelected)
            {
                return;
            }

            //Are we still in the process of selecting a shape?
            if (Button_Shapes.IsSelected)
            {
                //Do nothing
                return;
            }

            //This leaves us with a shape to add, getting the name we should add from the name of the sender
            if (e.Button == MouseButtons.Left)
            {
                //Trying to find the selected button
                foreach (GDD_Button button in buttons)
                {
                    if (button.IsSelected)
                    {
                        SelectedObj = new GDD_Object((GDD_Shape)Type.GetType(button.Name).GetConstructor(Type.EmptyTypes).Invoke(null));
                        SelectedObj.Location = new GDD_Point2F(e.X, e.Y);
                        SelectedObj.Shape.Size = 50f;
                        SelectedObj.Mass = 50f;
                        SelectedObj.Rotation = new GDD_Vector2F(0f, 0f);
                        SelectedObj.Velocity = new GDD_Point2F(0f, 0f);
                        SelectedObj.GravityType = GDD_GravityType.Static;
                        GDD_View_LevelDesigner1.Scene.Objects.Add(SelectedObj);

                        //Deselecting the button and hiding the menu
                        button.IsSelected = false;
                        button.BackColor = Color.White;
                        shapePanel.Visible = false;
                    }
                }   
            }         
        }

        private void GDD_View_LevelDesigner1_MouseMove(object sender, MouseEventArgs e)
        {
            //Checking if we have a selected object now
            if ((SelectedObj != null) && (SelectedObj != EraserSphere))
            {
                //This leaves us with the other option; moving the just added object
                SelectedObj.Location = new GDD_Point2F(e.X, e.Y);
                return;
            }

            //Are we using a pencil?
            if (Button_Pencil.IsSelected)
            {
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

                return;
            }

            //Are we using a line?
            if (Button_Line.IsSelected)
            {
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

                return;
            }

            //Are we erasing stuff?
            if (Button_Eraser.IsSelected)
            {
                
                //Creating a sphere with width 10px
                if (EraserSphere == null)
                {
                    EraserSphere = new GDD_Object(new GDD_Circle()); 
                    EraserSphere.Shape.Size = 20;
                    EraserSphere.Rotation = new GDD_Vector2F(0f, 0f);
                    EraserSphere.Shape.DrawingColor = new SolidBrush(GDD_View_LevelDesigner1.BackColor);
                    EraserSphere.GravityType = GDD_GravityType.Static;
                    GDD_View_LevelDesigner1.Scene.Objects.Add(EraserSphere);
                }

                //Updating preview
                EraserSphere.Location = new GDD_Point2F(e.X, e.Y);
                EraserSphere.Desired_Location = new GDD_Point2F(e.X, e.Y);
                
                //Deleting if we're holding down
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //What are we suppose to delete
                    List<GDD_Object> toDelete = new List<GDD_Object>();

                    //Checking for collisions
                    foreach (GDD_Object obj in GDD_View_LevelDesigner1.Scene.Objects)
                    {
                        //Are we colliding?
                        GDD_CollisionInfo CI = GDD_Shape.Collides(EraserSphere.Shape, obj.Shape);
                        if (CI != null)
                        {
                            //We need to delete this
                            toDelete.Add(obj);
                        }
                    }

                    //Deleting everything we came across
                    foreach (GDD_Object obj in toDelete)
                    {
                        GDD_View_LevelDesigner1.Scene.Objects.Remove(obj);
                    }
                }
                
                
                return;
            }

            //Are we still in the process of selecting a shape?
            if (Button_Shapes.IsSelected)
            {
                //Do nothing
                return;
            }



            
        }
            
    

        private void GDD_View_LevelDesigner1_MouseUp(object sender, MouseEventArgs e)
        {
            //Making sure we stop pointing at the just added or selected object
            SelectedObj = new GDD_Object(new GDD_Square());
            SelectedObj = null;
        }

        private void GDD_View_LevelDesigner1_MouseClick(object sender, MouseEventArgs e)
        {
            int selected = 0;
            for (int i = 0; i < buttons.Count - 1; i++)
            {
                if (buttons[i].BackColor == Color.LightGray)
                {
                    selected = i;
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                foreach (GDD_Object obj in GDD_View_LevelDesigner1.Scene.Objects)
                {
                    if(obj.Shape.ContainsPoint(new GDD_Point2F(e.X, e.Y)))
                    {
                        GDD_View_LevelDesigner1.Scene.Objects.Remove(obj);
                        break;
                    }
                }
            }
        }

        private void HighLightButton(object sender, EventArgs e)
        {           
            //Highlight this button and downlight the others
            foreach (GDD_Button button in buttons)
            {
                button.BackColor = Color.White;
                button.IsSelected = false;
            }

            //Highlighting ourself
            ((GDD_Button)sender).BackColor = Color.LightGray;
            ((GDD_Button)sender).IsSelected = true;
        }


        /// <summary>
        /// Suppose to show all the shapes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button_Shapes_Click(object sender, System.EventArgs e)
        {

            if (shapePanel == null)
            {
                //Getting a list of all types known right now
                Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();
                List<Type> polygonTypes = new List<Type>();


                //Looping each type we can find
                foreach (Type type in allTypes)
                {
                    //Is it a subclass?
                    if (type.IsSubclassOf(typeof(GDD_Polygon)))
                    {
                        //Yes; adding it to the list
                        polygonTypes.Add(type);
                    }
                }

                //Type now holds all the shapes that are derived from polygon; just need to add circle
                polygonTypes.Add((new GDD_Circle()).GetType());

                //Defining the tile sizes
                Size tileSize = new Size(50, 50);
                Size tileDistance = new Size(10, 10);

                //Max size of the panel          
                shapePanel = new GDD_Button();
                shapePanel.Location = new Point(Button_Shapes.Right + 10, Button_Shapes.Top);
                shapePanel.MaximumSize = new Size(600, 300); 
                shapePanel.Name = "shapePanel";
                shapePanel.BackColor = GDD_View_LevelDesigner1.BackColor;
                shapePanel.ForeColor = GDD_View_LevelDesigner1.BackColor;
                shapePanel.IsSelected = false;
                shapePanel.Note = null;
                shapePanel.Text = "";
                shapePanel.TabIndex = 0;
                shapePanel.BorderWidth = 0f;
                int x = (polygonTypes.Count) * (tileSize.Width + tileDistance.Width) + tileDistance.Width ;
                int y = ((x / shapePanel.MaximumSize.Width) + 1) * (tileSize.Width + tileDistance.Width) + tileDistance.Width;
                shapePanel.Size = new Size(x, y);
                shapePanel.Visible = false;

                //Looping each shape to draw
                for (int i = 0; i<polygonTypes.Count; i++)
                {       
                    //Initializing a new GDD_Object type with the shape we found
                    GDD_Object obj = new GDD_Object((GDD_Shape)polygonTypes[i].GetConstructor(Type.EmptyTypes).Invoke(null));
                    obj.Location = new GDD_Point2F(32f, 32f);
                    obj.Shape.Size = 50;
                    obj.Rotation = new GDD_Vector2F(0f, 0f);
                    obj.Shape.DrawingColor = new SolidBrush(Color.FromArgb(160, 160, 160));

                    //Trying to draw it
                    Bitmap b = new Bitmap(64, 64);
                    Graphics g = Graphics.FromImage(b);
                    obj.Shape.Draw(g);

                    //Making a new GDD_Button 
                    GDD_Button button = new GDD_Button();
                    x = i * (tileSize.Width + tileDistance.Width);
                    y = (x / shapePanel.MaximumSize.Width) * (tileSize.Height + tileDistance.Height);
                    button.BackgroundImage = b;
                    button.Location = new Point(x, y);
                    button.Name = polygonTypes[i].FullName;
                    button.Size = tileSize;
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
                    button.IsSelected = false;
                    button.Note = null;
                    button.Text = "";
                    button.TabIndex = 0;
                    button.BorderWidth = 2f;
                    button.Click += this.HighLightButton;
                    buttons.Add(button);
                    shapePanel.Controls.Add(button);
                    
                }

                this.Controls.Add(shapePanel);
                
            }

            //Making the panel ( and all its buttons ) visable
            shapePanel.Visible = !shapePanel.Visible;
            shapePanel.BringToFront();
            
        }

        private void Button_DeleteAll_Click(object sender, EventArgs e)
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

        private void Button_Save_Click(object sender, EventArgs e)
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

            MessageBox.Show("Level saved.");
        }


        /// <summary>
        /// Handles the click when the Eraser button gets clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eraser_Click(object sender, EventArgs e)
        {
            /*//Creating a temporarly circle
            GDD_Object circle = new GDD_Object(new GDD_Circle());
            circle.Shape.Size = 10f;
            circle.Rotation = new GDD_Vector2F(0f, 0f);
            circle*/
        }

        private void Button_Browse_Click(object sender, EventArgs e)
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

        private void GDD_View_LevelDesigner1_MouseLeave(object sender, EventArgs e)
        
        {
            GDD_View_LevelDesigner1.Scene.Objects.Remove(EraserSphere);
            EraserSphere = null;
        }
    }
}
