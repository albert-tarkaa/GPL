namespace GPL
{
    public class CordinatesStateManager
    {
        public int GlobalX { get; private set; }
        public int GlobalY { get; private set; }

        public CordinatesStateManager()
        {
            GlobalX = 15;
            GlobalY = 15;
        }

        public void SetCordinates(int x, int y)
        {
            GlobalX = x;
            GlobalY = y;
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
