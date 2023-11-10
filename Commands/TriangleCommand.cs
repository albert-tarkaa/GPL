using GPL.Utilities;

namespace GPL.Commands
{
    public class TriangleCommand : ICommand
    {
        private int targetX, targetY;
        DrawingSettings stateManager;

        public TriangleCommand(int x, int y, DrawingSettings cordinatesStateManager)
        {
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;

        }

        public void Execute(Graphics g, bool fill, Color color)
        {
            Point[] triangleVertices = {
        new Point(stateManager.GlobalY, stateManager.GlobalX),
        new Point(stateManager.GlobalX + targetX, stateManager.GlobalY),
        new Point(stateManager.GlobalX + targetX / 2, stateManager.GlobalY - (int)(Math.Sqrt(3) / 2 * targetX))
        };

            if (fill)
            {
                SolidBrush brush = new SolidBrush(color);
                g.FillPolygon(brush, triangleVertices);
            }

            Pen pen = new Pen(Color.Black, 1);
            g.DrawPolygon(pen, triangleVertices);
        }

    }
}
