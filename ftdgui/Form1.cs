using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Windows.Forms.Design;

namespace ftdgui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            viewPanel.BackColor = System.Drawing.Color.FromArgb(255, 220, 220, 220);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BreadButton breadbutton = new BreadButton() { Text = "i am buttoon LOOL", BackColor = Button.DefaultBackColor, parentForm = this, gridX = Form1.gridX, gridY = Form1.gridY, Height = 40, Width = 100 };
            Random random = new Random();
            breadbutton.Location = new System.Drawing.Point(random.Next(30, 300), random.Next(50, 300));
            int gridX = Form1.gridX;
            int gridY = Form1.gridY;
            breadbutton.Left = (int)(gridX * Math.Round((float)breadbutton.Left / gridX));
            breadbutton.Top = (int)(gridY * Math.Round((float)breadbutton.Top / gridY));
            viewPanel.Controls.Add(breadbutton);
        }

        
        public static int gridX = 50;
        public static int gridY = 25;
        public static BreadButton selectedBBtn { get; set; }
        

        static class PDrag //panel dragging variables
        {
            public static bool draggingPanel = false;
            public static int cursStartX = 0;
            public static int cursStartY = 0;
            public static int cursPosX = 0;
            public static int cursPosY = 0;


        }

        private void viewPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (!PDrag.draggingPanel)
                {
                    float gridX = Form1.gridX;
                    float gridY = Form1.gridY;
                    PDrag.draggingPanel = true;
                    PDrag.cursStartX = (int)(Math.Round(Cursor.Position.X / gridX) * gridX);
                    PDrag.cursStartY = (int)(Math.Round(Cursor.Position.Y / gridY) * gridY);
                    //PDrag.cursPosX = Cursor.Position.X;
                    //PDrag.cursPosY = Cursor.Position.Y;
                }
            }
        }

        private void viewPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (PDrag.draggingPanel)
            {
                int gridX = Form1.gridX;
                int gridY = Form1.gridY;

                float cursPosX = Cursor.Position.X;
                float cursPosY = Cursor.Position.Y;

                int cursRoundX = (int)Math.Round(cursPosX / gridX) * gridX;
                int cursRoundY = (int)Math.Round(cursPosY / gridY) * gridY;

                int moveX = cursRoundX - PDrag.cursStartX;
                int moveY = cursRoundY - PDrag.cursStartY;

                PDrag.cursStartX = cursRoundX;
                PDrag.cursStartY = cursRoundY;

                foreach (Control bButton in viewPanel.Controls)
                {
                    bButton.Left += moveX;
                    bButton.Top += moveY;
                }
            }
        }

        private void viewPanel_MouseUp(object sender, MouseEventArgs e)
        {
            PDrag.draggingPanel = false;
        }

        private void btnAddInput_Click(object sender, EventArgs e)
        {
            BreadButton selected = Form1.selectedBBtn;
            bbInput newInput = new bbInput { parent = selected, Text = "i am buttoon LOOL", BackColor = Button.DefaultBackColor, id = selected.Inputs.Length };
            newInput.parent = selected;
            selected.Inputs = selected.Inputs.Append(newInput).ToArray();
            viewPanel.Controls.Add(newInput);
            selected.updateInOuts();
        }

        private void btnAddOutput_Click(object sender, EventArgs e)
        {
            BreadButton selected = Form1.selectedBBtn;
            bbOutput newOutput = new bbOutput { parent = selected, Text = "i am buttoon LOOL", BackColor = Button.DefaultBackColor, id = selected.Outputs.Length };
            newOutput.parent = selected;
            selected.Outputs = selected.Outputs.Append(newOutput).ToArray();
            viewPanel.Controls.Add(newOutput);
            selected.updateInOuts();
        }
    }

    public class BreadButton : Button
    //draggable button
    {
        bool dragging;
        float relativePosX, relativePosY; //relative to block
        //float cursPosX, cursPosY; //just regular cursor.position

        public BreadButton()
        {
            dragging = false;
            this.MouseDown += breadButton_MouseDown;
            this.MouseMove += breadButton_MouseMove;
            this.MouseUp += breadButton_MouseUp;
        }
        public Form1? parentForm { get; set; } //public property "parentForm"
        public int gridX { get; set; }
        public int gridY { get; set; }

        public bbInput[] Inputs = { };
        public bbOutput[] Outputs = { };

        private void breadButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!dragging)
                {
                    dragging = true;
                    relativePosX = ((this.Left) - Cursor.Position.X);
                    relativePosY = ((this.Top) - Cursor.Position.Y);
                    //cursPosX = Cursor.Position.X;
                    //cursPosY = Cursor.Position.Y;
                }
            }
            Form1.selectedBBtn = this;
        }

        private void breadButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                this.Left = (int)(Math.Round((Cursor.Position.X + relativePosX) / gridX) * gridX); //X grid size
                this.Top = (int)(Math.Round((Cursor.Position.Y + relativePosY) / gridY) * gridY); //Y grid size
                updateInOuts();
            }
        }

        private void breadButton_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        public void updateInOuts()
        {
            Debug.WriteLine("UpdateInOuts");
            Debug.Write(Inputs);
            Debug.Write(Outputs);
            foreach (var input in Inputs)
            {
                if (input != null)
                {
                    input.UpdateInput();
                }
            }
            foreach (var output in Outputs)
            {
                if (output != null)
                {
                output.UpdateOutput();
                }
            }
        }

    }

    public class bbInOut : Button
    {
        public BreadButton parent;
        public Form1? parentForm { get; set; } //public property "parentForm"
        public int id;
        public bbInOut()
        {
            if (this.parent == null) { this.parent = Form1.selectedBBtn; }
            //id = GetId();
            Width = 10;
        }
        /*int GetId()
        {
            return Array.IndexOf(this.parent.Inputs, this);
        }*/
        

    }

    public class bbInput : bbInOut
    {
        public bbInput()
        {
            this.Left = parent.Left - this.Width;
            this.Top = parent.Top;
            Debug.WriteLine("Added input");
        }
        public void UpdateInput()
        {
            this.Left = parent.Left - this.Width;
            float space = ((float)parent.Height / parent.Inputs.Length);
            this.Height = (int)space;
            this.Top = parent.Top + (this.id * (int)space);
            Debug.WriteLine($"ID is {this.id}");
        }
    }

    public class bbOutput : bbInOut
    {
        public bbOutput()
        {
            this.Left = parent.Left + parent.Width;
            this.Top = parent.Top;
            Debug.WriteLine("Added output");
        }
        public void UpdateOutput()
        {
            this.Left = parent.Left + parent.Width;
            float space = ((float)parent.Height / parent.Outputs.Length);
            this.Height = (int)space;
            this.Top = parent.Top + (this.id * (int)space);
            Debug.WriteLine($"ID is {this.id}");
        }
    }

}