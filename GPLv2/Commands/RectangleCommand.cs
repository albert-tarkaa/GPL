using GPL.Utilities;

namespace GPL.Commands
{
    /// <summary>
    /// This is the Rectangle drawing class
    /// </summary>
    public class RectangleCommand : ICommand
    {
        private readonly string targetX, targetY;
        DrawingSettings stateManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleCommand"/> class.
        /// </summary>
        /// <param name="x">The width of the rectangle.</param>
        /// <param name="y">The height of the rectangle.</param>
        /// <param name="cordinatesStateManager">The drawing settings for the rectangle contained in the global object</param>
        /// <exception cref="ArgumentOutOfRangeException">The parameters x,y must be non-negative or zero</exception>
        public RectangleCommand(string x, string y, DrawingSettings cordinatesStateManager)
        {
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;

        }
        /// <summary>
        /// This is the Execute method that is used in drawing the rectangle.The rectangle is either filled or outlined
        /// </summary>
        /// <param name="g">The canvas for drawing the rectangle.</param>
        /// <exception cref="InvalidOperationException">Thrown if an error occurs during the execution of the command.</exception>
        public void Execute(Graphics g)
        {
            object XValue = VariableManager.CheckVariable(targetX);
            object YValue = VariableManager.CheckVariable(targetY);

            if (XValue != null && YValue != null)
            {
                // Use the variable values for drawing the rectangle
                int X = ConvertToInteger.Convert(XValue, "X");
                int Y = ConvertToInteger.Convert(YValue, "Y");

                DrawRectangle(g, X, Y);
            }
            else if (int.TryParse(targetX, out int X) && int.TryParse(targetY, out int Y))
            {
                // Use the constant values for drawing the rectangle
                DrawRectangle(g, X, Y);
            }
            else
            {
                throw new InvalidOperationException($"Invalid Rectangle parameters: {targetX}, {targetY}");
            }
        }

        private void DrawRectangle(Graphics g, int x, int y)
        {
            try
            {
                if (stateManager.fill)
                {
                    using (var brush = new SolidBrush(stateManager.color))
                    {
                        g.FillRectangle(brush, stateManager.GlobalX, stateManager.GlobalY, x, y);
                    }
                }
                else
                {
                    g.DrawRectangle(new Pen(stateManager.color), stateManager.GlobalX, stateManager.GlobalY, x, y);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'DrawTo' command: {ex.Message}");
            }
        }

    }
}
