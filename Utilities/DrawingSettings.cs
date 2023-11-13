namespace GPL.Utilities
{
    public class DrawingSettings
    {
        public int GlobalX { get; private set; }
        public int GlobalY { get; private set; }
        Bitmap canvas;
        public Color color;
        public Color cursorColor;
        public bool fill;

        public DrawingSettings(Bitmap Canvas)
        {
            GlobalX = 15;
            GlobalY = 15;
            canvas = Canvas;
            color = Color.Black;
            cursorColor = Color.Red;
            fill = false;

            using (Graphics g = Graphics.FromImage(canvas))
            {
                DrawCursor(g, true);
            }
            // DrawCursor(canvas, true);
        }

        public void SetCordinates(int x, int y)
        {
            try
            {
                int width = 5;
                Brush backgroundBrush;
                using (Graphics g = Graphics.FromImage(canvas))
                {

                    backgroundBrush = new SolidBrush(Color.Transparent);
                    g.FillEllipse(backgroundBrush, GlobalX, GlobalY, width, width);


                    backgroundBrush = new SolidBrush(cursorColor);
                    g.FillEllipse(backgroundBrush, x, y, width, width);
                    GlobalX = x;
                    GlobalY = y;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error in SetCordinates method.", ex);
            }


        }

        public void SetFill()
        {
            fill = true;
        }
        public void SetColor(Color colour)
        {
            color = colour;
        }

        public void DrawCursor(Graphics g, bool clearCanvas)
        {
            try
            {
                int width = 5;
                Brush backgroundBrush;
                //if (clearCanvas)
                //{
                //    backgroundBrush = new SolidBrush(Color.White);
                //    g.FillEllipse(backgroundBrush, GlobalX, GlobalY, width, width);
                //}

                backgroundBrush = new SolidBrush(cursorColor);
                g.FillEllipse(backgroundBrush, GlobalX, GlobalY, width, width);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error in DrawCursor method.", ex);
            }

        }
    }
}
