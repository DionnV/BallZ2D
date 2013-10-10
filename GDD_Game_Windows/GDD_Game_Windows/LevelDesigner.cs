﻿using System;
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
        private GDD_Point2F MouseStart;
        private GDD_Point2F StartLocation;
        private GDD_Vector2F StartRotation;
        private float StartSize;
        private string backgroundpath = "";
        private GDD_Button shapePanel;

        /// <summary>
        /// The tile size of the buttons
        /// </summary>
        private Size tileSize = new Size(76, 76);
        
        /// <summary>
        /// The distance between the buttons
        /// </summary>
        Size tileDistance = new Size(10, 10);

        /// <summary>
        /// Puts it in Designer or Player Mode
        /// </summary>
        public Boolean isDesigner 
        {
            get
            {
                return _isDesigner;
            }
            set
            {
                this._isDesigner = value;

                if (value == false)
                {
                    Button_Shapes.Enabled = false;
                    Button_Select.Enabled = false;
                    Button_Shapes.Visible = false;
                    Button_Select.Visible = false;
                }
                else
                {
                    Button_Shapes.Enabled = true;
                    Button_Select.Enabled = true;
                    Button_Shapes.Visible = true;
                    Button_Select.Visible = true;
                }

                PositionComponents();
            }
        }
        private Boolean _isDesigner;

        public LevelDesigner()
        {
            InitializeComponent();
        }

        private void LevelDesigner_Load(object sender, EventArgs e)
        {
            //Setting the correct size
            this.ClientSize = new System.Drawing.Size(800, 480);

            //Add all buttons to the list
            buttons.Add(Button_Pencil);
            buttons.Add(Button_Line);
            buttons.Add(Button_Eraser);
            buttons.Add(Button_Shapes);
            buttons.Add(Button_Select);
            buttons.Add(Button_Move);
            buttons.Add(Button_Rotate);
            buttons.Add(Button_Resize);

            //Set the text of the GDD_Buttons.
            this.Button_Select.Text = "Edit";
            this.editPanel.BackColor = GDD_View_LevelDesigner1.BackColor;
            this.editPanel.Visible = false;
            this.optionPanel.BackColor = GDD_View_LevelDesigner1.BackColor;
            this.optionPanel.Visible = false;
     
            //GDD_View_LevelDesigner1
            GDD_View_LevelDesigner1.graphicsTimer.Start();

            this.isDesigner = true;

        }

        private void GDD_View_LevelDesigner1_MouseDown(object sender, MouseEventArgs e)
        {
            //First off; checking if we clicked on a polygon object
            if (Button_Select.IsSelected)
            {
                if (e.Button == MouseButtons.Left)
                {
                    foreach (GDD_Object obj in this.GDD_View_LevelDesigner1.Scene.Objects)
                    {
                        //Are we clicking on it?
                        if (obj.Shape.ContainsPoint(new GDD_Point2F(e.X, e.Y)))
                        {
                            //De-Highlighting the shape
                            if (SelectedObj != null)
                            {
                                SelectedObj.Shape.DrawingColor = new SolidBrush(Color.White);
                            }

                            //We are clicking on it
                            SelectedObj = obj;
                            SelectedObj.Shape.DrawingColor = new SolidBrush(Color.LightGray);

                            //Now we should transform the select button to the edit button
                            editPanel.Show();
                            editPanel.BringToFront();


                            return;
                        }
                    }

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

            //Are we Editing the object
            if (Button_Move.IsSelected || Button_Rotate.IsSelected || Button_Resize.IsSelected)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (SelectedObj != null)
                    {
                        MouseStart = new GDD_Point2F(e.X, e.Y);
                        StartRotation = SelectedObj.Rotation;
                        StartSize = SelectedObj.Shape.Size;
                        StartLocation = SelectedObj.Location;
                    }
                }
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
                        SelectedObj.Shape.DrawingColor = new SolidBrush(Color.LightGray);
                        GDD_View_LevelDesigner1.Scene.Objects.Add(SelectedObj);
                        StartLocation = SelectedObj.Location;
                        MouseStart = new GDD_Point2F(e.X, e.Y);

                        //Deselecting the button and hiding the menu
                        button.IsSelected = false;
                        button.BackColor = Color.White;
                        shapePanel.Visible = false;
                        Button_Move.IsSelected = true;
                        Button_Move.BackColor = Color.LightGray;
                        editPanel.Visible = true;
                    }
                }   
            }         
        }

        private void GDD_View_LevelDesigner1_MouseMove(object sender, MouseEventArgs e)
        {
            //Checking if we have a selected object now
            if (Button_Select.IsSelected)
            {
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

            //Are we moving the object?
            if (Button_Move.IsSelected)
            {
                //Are we pressing the mouse?
                if (e.Button == MouseButtons.Left)
                {
                    if (SelectedObj != null)
                    {
                        SelectedObj.Location = new GDD_Point2F(
                            StartLocation.x + (e.X - MouseStart.x), 
                            StartLocation.y + (e.Y - MouseStart.y));
                    }
                }
                return;
            }

            //Are we moving the object?
            if (Button_Resize.IsSelected)
            {
                //Are we pressing the mouse?
                if (e.Button == MouseButtons.Left)
                {
                    if (SelectedObj != null)
                    {
                        //Calculating the distances
                        float oldEud = (float)GDD_Math.EuclidianDistance(new GDD_Point2F(MouseStart.x, MouseStart.y), SelectedObj.Location);
                        float newEud = (float)GDD_Math.EuclidianDistance(new GDD_Point2F(e.X, e.Y), SelectedObj.Location);

                        //Insuring a big enough size
                        float s = StartSize + (newEud - oldEud);
                        s = s < 3 ? 3 : s;

                        //resizing the object
                        SelectedObj.Shape.Size = s;
                    }
                }
                return;
            }

            //Are we moving the object?
            if (Button_Rotate.IsSelected)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (SelectedObj != null)
                    {
                        //Creating a vector
                        GDD_Point2F p1 = new GDD_Point2F(MouseStart.x - SelectedObj.Location.x, MouseStart.y - SelectedObj.Location.y);
                        GDD_Vector2F v1 = p1.ToVector();

                        GDD_Point2F p2 = new GDD_Point2F(e.X - SelectedObj.Location.x, e.Y - SelectedObj.Location.y);
                        GDD_Vector2F v2 = p2.ToVector();


                        //resizing the object
                        SelectedObj.Rotation = new GDD_Vector2F((StartRotation.Direction + (v2.Direction - v1.Direction)) % 360, SelectedObj.Rotation.Size);

                    }
                }
                return;
            }           
        }       

        private void GDD_View_LevelDesigner1_MouseUp(object sender, MouseEventArgs e)
        {
            //Making sure we stop pointing at the just added or selected object
            /*if (SelectedObj != null)
            {
                SelectedObj.Shape.DrawingColor = new SolidBrush(Color.White);
            }
            SelectedObj = new GDD_Object(new GDD_Square());
            SelectedObj = null;*/
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

            //Do we need to hide the options?
            if (sender != Button_Select && sender != Button_Move && sender != Button_Rotate && sender != Button_Resize)
            {
                editPanel.Visible = false;

                if (SelectedObj != null)
                {
                    SelectedObj.Shape.DrawingColor = new SolidBrush(Color.White);
                    SelectedObj = null;
                }
            }
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
                int x = polygonTypes.Count * (tileSize.Width + tileDistance.Width) - tileDistance.Width ;
                int y = ((x / shapePanel.MaximumSize.Width) + 1) * tileSize.Height;
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

        private void Button_Save_Click(object sender, EventArgs e)
        {
            //Saves the current built level
            GDD_Level level = new GDD_Level();
            level.Objects = GDD_View_LevelDesigner1.Scene.Objects;
            level.info = new GDD_HeaderInfo();
            level.Background = backgroundpath;
            /*if (LevelName.Text != null)
            {
                level.info.LevelName = LevelName.Text;
            }
            if (CreatorBox.Text != null)
            {
                level.info.CreatorName = CreatorBox.Text;
            }*/
            level.info.VersionNumber = 1;
            level.info.LevelVersionNumber = 1;
            level.info.Level_Width = GDD_View_LevelDesigner1.Scene.Width;
            level.info.Level_Height = GDD_View_LevelDesigner1.Scene.Height;
            level.info.MaxLineLenght = 200;

            level.WriteToZipFile();

            MessageBox.Show("Level saved.");
        }

        private void GDD_View_LevelDesigner1_MouseLeave(object sender, EventArgs e)      
        {
            GDD_View_LevelDesigner1.Scene.Objects.Remove(EraserSphere);
            EraserSphere = null;
        }

        private void LevelDesigner_Resize(object sender, EventArgs e)
        {
            PositionComponents();
        }

        private void PositionComponents()
        {
            //We need to position all the buttons; 
            int i = (this.ClientSize.Height - (6 * tileDistance.Height)) / 5;
            this.tileSize = new Size(i, i); i = 0;

            //Positioning the pencil
            Button_Pencil.Location = new Point(tileDistance.Width, tileDistance.Height * (i + 1) + tileSize.Height * i);
            Button_Pencil.Size = tileSize; i++;

            //Positioning the lne
            Button_Line.Location = new Point(tileDistance.Width, tileDistance.Height * (i + 1) + tileSize.Height * i);
            Button_Line.Size = tileSize; i++;

            //Positioning the Eraser button
            Button_Eraser.Location = new Point(tileDistance.Width, tileDistance.Height * (i + 1) + tileSize.Height * i);
            Button_Eraser.Size = tileSize; i++;

            //Positioning the Shapes button
            Button_Shapes.Location = new Point(tileDistance.Width, tileDistance.Height * (i + 1) + tileSize.Height * i);
            Button_Shapes.Size = tileSize; i++;

            //Positioning the Select button
            Button_Select.Location = new Point(tileDistance.Width, tileDistance.Height * (i + 1) + tileSize.Height * i);
            Button_Select.Size = tileSize;


            //Positioning the Panel
            editPanel.Location = new Point(Button_Select.Right + tileDistance.Width, Button_Select.Top);
            i = 0;

            //Moving the buttons etc
            Button_Move.Location = new Point(tileDistance.Width * (i) + tileSize.Width * i, 0);
            Button_Move.Size = tileSize; i++;
            Button_Resize.Location = new Point(tileDistance.Width * (i) + tileSize.Width * i, 0);
            Button_Resize.Size = tileSize; i++;
            Button_Rotate.Location = new Point(tileDistance.Width * (i) + tileSize.Width * i, 0);
            Button_Rotate.Size = tileSize; i++;
            editPanel.Height = tileSize.Height;
            editPanel.Width = Button_Rotate.Right;

            //Moving the options
            i = 0;

            //Positioning the Save button
            if (isDesigner)
            {
                Button_Save.Location = new Point(0, tileDistance.Height * i + tileSize.Height * i);
                Button_Save.Size = tileSize; i++;
            }

            //Positioning the Play Button
            Button_Play.Location = new Point(0, tileDistance.Height * i + tileSize.Height * i);
            Button_Play.Size = tileSize; i++;

            //Positioning the Er button
            Button_Reset.Location = new Point(0, tileDistance.Height * i + tileSize.Height * i);
            Button_Reset.Size = tileSize; i++;

            //Positioning the Shapes button
            Button_Exit.Location = new Point(0, tileDistance.Height * i + tileSize.Height * i);
            Button_Exit.Size = tileSize; i++;

            //Positioning the Shapes button
            Button_Options.Location = new Point(this.ClientRectangle.Width - (tileDistance.Width + tileSize.Width), this.ClientRectangle.Height - (tileDistance.Height + tileSize.Height));
            Button_Options.Size = tileSize;

            //Positioning the panel
            optionPanel.Width = tileSize.Width;
            optionPanel.Height = (i - 1) * tileDistance.Height + tileSize.Height * i;
            optionPanel.Location = new Point(this.ClientRectangle.Width - (tileDistance.Width + tileSize.Width), this.ClientRectangle.Height - (optionPanel.Height + tileSize.Height + tileDistance.Height * 2));

         
        }

        private void Button_Options_Click(object sender, EventArgs e)
        {
            optionPanel.Show();
            optionPanel.BringToFront();
        }
    }
}
