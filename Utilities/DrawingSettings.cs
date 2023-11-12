using GPL.Commands;
using System.Windows.Forms;

namespace GPL.Utilities
{
    public class DrawingSettings
    {
        public int GlobalX { get; private set; }
        public int GlobalY { get; private set; }
        Bitmap canvas;
        PictureBox pictureBox;
        public Color color;
        public bool fill;

        public DrawingSettings(Bitmap Canvas, PictureBox PictureBox)
        {
            GlobalX = 15;
            GlobalY = 15;
            canvas = Canvas;
            pictureBox = PictureBox;
            color = Color.Black;
            fill = false;

            DrawCursor(canvas,true);
        }

        public void SetCordinates(int x, int y)
        {
            GlobalX = x;
            GlobalY = y;
        }

        public void SetFill()
        {
            fill = true;
        }
        public void SetColor(Color colour)
        {
           color = colour;
        }

        public void DrawCursor(Bitmap canvas, bool clearCanvas)
        {
            int width = 5;
            Brush backgroundBrush;
            using (Graphics g = Graphics.FromImage(canvas))
            {
                if (clearCanvas)
                {
                    backgroundBrush = new SolidBrush(Color.White);
                    g.FillEllipse(backgroundBrush, GlobalX, GlobalY, width, width);

                    backgroundBrush = new SolidBrush(color);
                    g.FillEllipse(backgroundBrush, GlobalX, GlobalY, width, width);
                }
                else
                {
                    backgroundBrush = new SolidBrush(color);
                    g.FillEllipse(backgroundBrush, GlobalX, GlobalY, width, width);
                }


            }
        }
    }
}
