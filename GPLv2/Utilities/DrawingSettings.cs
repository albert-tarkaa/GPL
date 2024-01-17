namespace GPL.Utilities
{
    /// <summary>
    /// Represents the settings for drawing operations.
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

        Bitmap canvas;
        /// <summary>
        /// Gets or sets the canvas for drawing operations.
        /// </summary>
        public Bitmap Canvas
        {
            get { return canvas; }
            set { canvas = value; }
        }

        /// <summary>
        /// Gets or sets the color for drawing operations.
        /// </summary>
        public Color color;

        /// <summary>
        /// Gets or sets the color of the cursor.
        /// </summary>
        public Color cursorColor;

        /// <summary>
        /// Gets or sets a value indicating whether to fill shapes during drawing.
        /// </summary>
        public bool fill;

        /// <summary>
        /// Gets or sets a value indicating a While loop is on or off.
        /// </summary>
        public bool whileLoopFlag;

        /// <summary>
        /// Gets or sets a value indicating a nested While loop.
        /// </summary>
        public int WhileLoopCounter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating a loop counter.
        /// </summary>
        public int LoopCounter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingSettings"/> class.
        /// </summary>
        public DrawingSettings() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingSettings"/> class with a specified canvas.
        /// </summary>
        /// <param name="Canvas">The canvas for drawing operations.</param>
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
            WhileLoopCounter = 0;
            LoopCounter = 0;
        }

        /// <summary>
        /// Sets the coordinates of the drawing cursor.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
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

        /// <summary>
        /// Sets the fill mode for drawing shapes.
        /// </summary>
        public void SetFill()
        {
            fill = true;
        }

        public void SetWhileLoopFlag(bool status)
        {
            whileLoopFlag = status;
        }


        public void IncrementLoopCounter()
        {
            LoopCounter++;
        }

        public void DecrementLoopCounter()
        {
            LoopCounter--;
        }


        public void IncrementWhileLoopCounter()
        {
            WhileLoopCounter++;
        }

        public void DecrementWhileLoopCounter()
        {
            WhileLoopCounter--;
        }

        /// <summary>
        /// Sets the color for drawing operations.
        /// </summary>
        /// <param name="colour">The color to set.</param>
        public void SetColor(Color colour)
        {
            color = colour;
        }

        /// <summary>
        /// Draws the cursor on the canvas.
        /// </summary>
        /// <param name="g">The graphics object for drawing.</param>
        /// <param name="clearCanvas">A flag indicating whether to clear the canvas before drawing the cursor.</param>
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
