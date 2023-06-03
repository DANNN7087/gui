namespace ftdgui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = System.Drawing.Color.FromArgb(255, 220, 220, 220);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BreadButton breadbutton = new BreadButton() { Text = "i am buttoon LOOL", BackColor = Button.DefaultBackColor, parentForm = this };
            Random random = new Random();
            breadbutton.Location = new System.Drawing.Point(random.Next(30, 300), random.Next(50, 300));
            panel1.Controls.Add(breadbutton);
        }
    }

    public class BreadButton : Button
    //draggable button
    {
        bool dragging;
        float curPosX, curPosY; //relative to block
        float cursPosX, cursPosY; //just regular cursor.position

        public BreadButton()
        {
            dragging = false;
            this.MouseDown += breadButton_MouseDown;
            this.MouseMove += breadButton_MouseMove;
            this.MouseUp += breadButton_MouseUp;
        }
        public Form1? parentForm { get; set; } //public property "parentForm"



        private void breadButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dragging)
            {
                dragging = true;
                curPosX = ((this.Left + this.Parent.Left - this.Parent.Location.X) - Cursor.Position.X);
                curPosY = ((this.Top + this.Parent.Top - this.Parent.Location.Y) - Cursor.Position.Y);
                cursPosX = Cursor.Position.X;
                cursPosY = Cursor.Position.Y;
            }
        }

        private void breadButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                this.Left = (int)(Math.Round((Cursor.Position.X + (curPosX)) / 50) * 50); //X grid size
                this.Top = (int)(Math.Round((Cursor.Position.Y + (curPosY)) / 25) * 25); //Y grid size
            }
        }

        private void breadButton_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

    }
}