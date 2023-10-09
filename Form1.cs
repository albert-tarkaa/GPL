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
            Rectangle rect = new Rectangle(10, 10, 10, 2);
            SolidBrush purpleBrush = new SolidBrush(Color.Purple);

            using (purpleBrush)
            {
                g.FillRectangle(purpleBrush, rect);
            }
        }

    }
}