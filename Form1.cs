namespace GPL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Create rectangle.
            Rectangle rect = new Rectangle(10, 10, 10, 2);

            // Create solid brush.
            SolidBrush purpleBrush = new SolidBrush(Color.Purple);

            using (purpleBrush)
            {
                //Fills the interior of a rectangle specified by a pair of coordinates, a width, and a height.
                g.FillRectangle(purpleBrush, rect);

            }
        }
    }
}