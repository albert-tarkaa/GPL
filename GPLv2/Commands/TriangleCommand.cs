using GPL.Utilities;

namespace GPL.Commands
{
    public class TriangleCommand : ICommand
    {
        private int targetX, targetY;
        DrawingSettings stateManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangleCommand"/> class.
        /// </summary>
        /// <param name="x">The sides of the triangle.</param>
        /// <param name="cordinatesStateManager">The drawing settings for the triangle contained in the global object</param>
        /// <exception cref="ArgumentOutOfRangeException">The parameters x must be non-negative or zero</exception>
        public TriangleCommand(int x, int y, DrawingSettings cordinatesStateManager)
        {
            if (x <= 0 || y <= 0)
            {
                throw new ArgumentOutOfRangeException("x must be non-negative or zero");
            }
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;

        }

        /// <summary>
        /// This is the Execute method that is used in drawing the triangle.The triangle is either filled or outlined
        /// </summary>
        /// <param name="g">The canvas for drawing the triangle.</param>
        /// <exception cref="InvalidOperationException">Thrown if an error occurs during the execution of the command.</exception>
        public void Execute(Graphics g)
        {
            try
            {
                Point[] triangleVertices = {
        new Point(stateManager.GlobalY, stateManager.GlobalX),
        new Point(stateManager.GlobalX + targetX, stateManager.GlobalY),
        new Point(stateManager.GlobalX + targetX / 2, stateManager.GlobalY - (int)(Math.Sqrt(3) / 2 * targetX))
        };

                if (stateManager.fill)
                {
                    SolidBrush brush = new SolidBrush(stateManager.color);
                    g.FillPolygon(brush, triangleVertices);
                }
                else
                {
                    Pen pen = new(stateManager.color, 1);
                    g.DrawPolygon(pen, triangleVertices);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'Trig' command: {ex.Message}");
            }

        }

    }
}
