using GPL.Utilities;

namespace GPL.Commands
{
    /// <summary>
    /// Represents the DrawTo command for drawing a line to a specified point.
    /// </summary>
    public class DrawTo : ICommand
    {
        private readonly string targetX, targetY;
        DrawingSettings stateManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawTo"/> class.
        /// </summary>
        /// <param name="x">The parameter or variable for the X coordinate.</param>
        /// <param name="y">The parameter or variable for the Y coordinate.</param>
        /// <param name="cordinatesStateManager">The drawing settings for the line contained in the global object.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the parameters are not greater than 0.</exception>

        public DrawTo(string x, string y, DrawingSettings cordinatesStateManager)
        {
            targetX = x;
            targetY = y;

            this.stateManager = cordinatesStateManager;
        }

        /// <summary>
        /// Executes the DrawTo command by drawing a line to the specified coordinates.
        /// </summary>
        /// <param name="g">The graphics object for drawing.</param>
        /// <exception cref="InvalidOperationException">Thrown if an error occurs during the execution of the command.</exception>
        //public void Execute(Graphics g)
        //{
        //    try
        //    {
        //        Pen pen = new(stateManager.color, 1);

        //        g.DrawLine(pen, new Point(stateManager.GlobalX, stateManager.GlobalY), new Point(targetX, targetY));
        //        stateManager.SetCordinates(targetX, targetY);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new InvalidOperationException($"Error executing 'DrawTo' command: {ex.Message}");
        //    }

        //}
        /// <summary>
        /// Executes the DrawTo command by drawing a line to the specified coordinates.
        /// </summary>
        /// <param name="g">The graphics object for drawing.</param>
        /// <exception cref="InvalidOperationException">Thrown if an error occurs during the execution of the command.</exception>
        public void Execute(Graphics g)
        {
            object XValue = VariableManager.CheckVariable(targetX);
            object YValue = VariableManager.CheckVariable(targetY);

            if (XValue != null && YValue != null)
            {
                
                int X = ConvertToInteger.Convert(XValue, "X");
                int Y = ConvertToInteger.Convert(YValue, "Y");

                // Use the variable values for drawing the line
                DrawLine(g, X, Y);
            }
            else if (int.TryParse(targetX, out int X) && int.TryParse(targetY, out int Y))
            {
                // Use the constant values for drawing the line
                DrawLine(g, X, Y);
            }
            else
            {
                throw new InvalidOperationException($"Invalid Draw parameters: {targetX}, {targetY}");
            }
        }

        private void DrawLine(Graphics g, int x, int y)
        {
            try
            {
                Pen pen = new(stateManager.color, 1);

                g.DrawLine(pen, new Point(stateManager.GlobalX, stateManager.GlobalY), new Point(x, y));
                stateManager.SetCordinates(x, y);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'DrawTo' command: {ex.Message}");
            }
        }
    }
}

