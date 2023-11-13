using GPL.Utilities;

namespace GPL.Commands
{
    /// <summary>
    /// This is the circle drawing class
    /// </summary>
    public class CircleCommand : ICommand
    {
        private readonly int targetX;
        readonly DrawingSettings stateManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleCommand"/> class.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="cordinatesStateManager">The drawing settings for the circle contained in the global object</param>
        /// <exception cref="ArgumentOutOfRangeException">The radius must be non-negative or zero</exception>
        public CircleCommand(int radius, DrawingSettings cordinatesStateManager)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "The radius must be greater than 0.");
            targetX = radius;
            this.stateManager = cordinatesStateManager;
        }

        /// <summary>
        /// This is the Execute method that is used in drawing the circle.The circle is either filled or outlined
        /// </summary>
        /// <param name="g">The canvas for drawing the circle.</param>
        /// <exception cref="InvalidOperationException">Thrown if an error occurs during the execution of the command.</exception>
        public void Execute(Graphics g)
        {
            try
            {
                Pen pen = new(stateManager.color, 1);
                int diameter = targetX * 2;

                int x = stateManager.GlobalX - targetX;
                int y = stateManager.GlobalY - targetX;

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
