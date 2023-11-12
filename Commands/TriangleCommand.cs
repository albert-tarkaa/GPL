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

        public void Execute(Graphics g)
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

    }
}
