using GPL.Commands;
using System.Windows.Forms;

namespace GPL
{
    public class CordinatesStateManager
    {
        public int GlobalX { get; private set; }
        public int GlobalY { get; private set; }
        Bitmap canvas;
        PictureBox pictureBox;

        public CordinatesStateManager(Bitmap Canvas, PictureBox PictureBox)
        {
            GlobalX = 15;
            GlobalY = 15;
            this.canvas = Canvas; 
            this.pictureBox = PictureBox;

           // DrawCursor(canvas, PictureBox);
        }

        public void SetCordinates(int x, int y)
        {
            GlobalX = x;
            GlobalY = y;

        }

        public void DrawCursor( Bitmap canvas,PictureBox pictureBox)
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                Brush backgroundBrush = new SolidBrush(Color.White); // You can change the color as needed
                g.FillEllipse(backgroundBrush, GlobalX, GlobalY, 6, 6);


                Pen pen = new Pen(Color.Red);
                g.DrawEllipse(pen, GlobalX, GlobalY, 6, 6);

                //pen.Dispose();
            }

            // If needed, trigger a refresh of the PictureBox where the canvas is displayed.
            // For example, if you're using a PictureBox called "pictureBox," you can use:
           // pictureBox.Invalidate();
        }

        //public void Cordinates()
        //{

        //    int panelWidth = panel.Width;
        //    int panelHeight = panel.Height;
        //    Bitmap bitmap = new Bitmap(panelWidth, panelHeight);

        //    using (Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        // Clear the previous drawing
        //       //  graphics.Clear(Color.Transparent);

        //        int circleDiameter = 6;
        //        Pen pen = new Pen(Color.Red, 1);
        //        graphics.DrawEllipse(pen, GlobalX, GlobalY, circleDiameter, circleDiameter);
        //    }

        //    // Display the updated Bitmap on the panel
        //    panel.BackgroundImage = bitmap;
        //    panel.BackgroundImageLayout = ImageLayout.Stretch;
        //    panel.Invalidate();
        //}
    }
}
