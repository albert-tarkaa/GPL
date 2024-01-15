using System.Drawing;

namespace GPL.Utilities
{
    /// <summary>
    /// Manages drawing settings and variables.
    /// </summary>
    public class DrawingSettings
    {
        /// <summary>
        /// Gets or sets the global X coordinate.
        /// </summary>
        public int GlobalX { get; private set; }

        /// <summary>
        /// Gets or sets the global Y coordinate.
        /// </summary>
        public int GlobalY { get; private set; }

        private Bitmap canvas;

        /// <summary>
        /// Gets or sets the drawing canvas.
        /// </summary>
        public Bitmap Canvas
        {
            get { return canvas; }
            set { canvas = value; }
        }

        /// <summary>
        /// Gets or sets the drawing color.
        /// </summary>
        public Color color { get; set; }

        /// <summary>
        /// Gets or sets the cursor color.
        /// </summary>
        public Color cursorColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to fill shapes.
        /// </summary>
        public bool fill { get; set; }

        /// <summary>
        /// Gets the dictionary of variables.
        /// </summary>
        public Dictionary<string, int> Variables { get; } = new Dictionary<string, int>();

        /// <summary>
        /// Default constructor for DrawingSettings.
        /// </summary>
        public DrawingSettings() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingSettings"/> class with a specified canvas.
        /// </summary>
        /// <param name="canvas">The drawing canvas.</param>
        public DrawingSettings(Bitmap canvas)
        {
            GlobalX = 15;
            GlobalY = 15;
            canvas = Canvas;
            color = Color.Black;
            cursorColor = Color.Red;
            fill = false;

            using (Graphics g = Graphics.FromImage(Canvas))
            {
                DrawCursor(g, true);
            }
        }

        /// <summary>
        /// Sets the coordinates of the cursor.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public void SetCoordinates(int x, int y)
        {
            try
            {
                int width = 5;
                Brush backgroundBrush;
                using (Graphics g = Graphics.FromImage(Canvas))
                {
                    backgroundBrush = new SolidBrush(Color.Transparent);
                    g.FillEllipse(backgroundBrush, GlobalX, GlobalY, width, width);

                    backgroundBrush = new SolidBrush(CursorColor);
                    g.FillEllipse(backgroundBrush, x, y, width, width);
                    GlobalX = x;
                    GlobalY = y;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error in SetCoordinates method.", ex);
            }
        }

        /// <summary>
        /// Sets the fill option for shapes.
        /// </summary>
        public void SetFill()
        {
            Fill = true;
        }

        /// <summary>
        /// Sets the drawing color.
        /// </summary>
        /// <param name="colour">The color to set.</param>
        public void SetColor(Color colour)
        {
            Color = colour;
        }

        /// <summary>
        /// Draws the cursor on the canvas.
        /// </summary>
        /// <param name="g">The graphics object.</param>
        /// <param name="clearCanvas">A value indicating whether to clear the canvas.</param>
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

                backgroundBrush = new SolidBrush(CursorColor);
                g.FillEllipse(backgroundBrush, GlobalX, GlobalY, width, width);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error in DrawCursor method.", ex);
            }
        }
    }
}