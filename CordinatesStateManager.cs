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

            DrawCursor(canvas);
        }

        public void SetCordinates(int x, int y)
        {
            GlobalX = x;
            GlobalY = y;

        }

        public void DrawCursor( Bitmap canvas)
        {
            int width = 5;
            using (Graphics g = Graphics.FromImage(canvas))
            {
                Brush backgroundBrush = new SolidBrush(Color.White);
                g.FillEllipse(backgroundBrush, GlobalX, GlobalY, width, width);


                backgroundBrush = new SolidBrush(Color.Red);
                g.FillEllipse(backgroundBrush, GlobalX, GlobalY, width, width);

            }
        }
    }
}
