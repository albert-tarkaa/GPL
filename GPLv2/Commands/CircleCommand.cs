using GPL.Utilities;

namespace GPL.Commands
{
    /// <summary>
    /// This is the circle drawing class
    /// </summary>
    public class CircleCommand : ICommand
    {
        private readonly string radiusParameter;
        readonly DrawingSettings stateManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleCommand"/> class.
        /// </summary>
        /// <param name="radiusParameter">The radius of the circle.</param>
        /// <param name="cordinatesStateManager">The drawing settings for the circle contained in the global object</param>
        /// <exception cref="ArgumentOutOfRangeException">The radius must be non-negative or zero</exception>
        public CircleCommand(string radiusParameter, DrawingSettings cordinatesStateManager)
        {
            this.radiusParameter = radiusParameter;
            this.stateManager = cordinatesStateManager;
        }

        public void Execute(Graphics g)
        {
            object radiusValue = VariableManager.CheckVariable(radiusParameter);

            if (radiusValue != null)
            {
                // Use the variable value for drawing the circle
                if (radiusValue is int radius)
                {
                    DrawCircle(g, radius);
                }
                else
                {
                    throw new InvalidOperationException($"Invalid radius parameter: {radiusParameter}");
                }
            }
            else if (int.TryParse(radiusParameter, out int constantRadius))
            {
                // Use the constant radius for drawing the circle
                DrawCircle(g, constantRadius);
            }
            else
            {
                throw new InvalidOperationException($"Invalid radius parameter: {constantRadius}");
            }
        }


        private void DrawCircle(Graphics g, int radius)
        {
            try
            {
                Pen pen = new(stateManager.color, 1);
                int diameter = radius * 2;

                int x = stateManager.GlobalX - radius;
                int y = stateManager.GlobalY - radius;


                if (stateManager.fill)
                {
                    g.FillEllipse(new SolidBrush(stateManager.color), x, y, diameter, diameter);
                }
                else
                {
                    g.DrawEllipse(pen, x, y, diameter, diameter);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'Circle' command: {ex.Message}");
            }
        }

    }
}
