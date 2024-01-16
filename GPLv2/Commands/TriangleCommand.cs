using GPL.Utilities;

namespace GPL.Commands
{
    public class TriangleCommand : ICommand
    {
        private readonly string targetX, targetY;
        DrawingSettings stateManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangleCommand"/> class.
        /// </summary>
        /// <param name="x">The sides of the triangle.</param>
        /// <param name="cordinatesStateManager">The drawing settings for the triangle contained in the global object</param>
        /// <exception cref="ArgumentOutOfRangeException">The parameters x must be non-negative or zero</exception>
        public TriangleCommand(string x, string y, DrawingSettings cordinatesStateManager)
        {
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
            object XValue = VariableManager.CheckVariable(targetX);
            object YValue = VariableManager.CheckVariable(targetY);

            if (XValue != null && YValue != null)
            {
                // Use the variable values for drawing the Triangle
                int X = ConvertToInteger.Convert(XValue, "X");
                int Y = ConvertToInteger.Convert(YValue, "Y");

                DrawTriangle(g, X, Y);
            }
            else if (int.TryParse(targetX, out int X) && int.TryParse(targetY, out int Y))
            {
                // Use the constant values for drawing the Triangle
                DrawTriangle(g, X, Y);
            }
            else
            {
                throw new InvalidOperationException($"Invalid Trig parameters: {targetX}, {targetY}");
            }
        }

        private void DrawTriangle(Graphics g, int x, int y)
        {
            Point[] triangleVertices = {
            new Point(stateManager.GlobalY, stateManager.GlobalX),
            new Point(stateManager.GlobalX + x, stateManager.GlobalY),
            new Point(stateManager.GlobalX + x / 2, stateManager.GlobalY - (int)(Math.Sqrt(3) / 2 * x))
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

    }
}
