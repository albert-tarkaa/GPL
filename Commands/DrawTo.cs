using GPL.Utilities;

namespace GPL.Commands
{
    public class DrawTo : ICommand
    {
        private int targetX, targetY;
        DrawingSettings stateManager;

        public DrawTo(int x, int y, DrawingSettings cordinatesStateManager)
        {
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;

        }

        public void Execute(Graphics g, bool fill, Color color)
        {
            Pen pen = new Pen(color, 1);

            if (fill)
            {
                SolidBrush brush = new SolidBrush(color);
                g.FillEllipse(brush, stateManager.GlobalX, stateManager.GlobalY, targetX - stateManager.GlobalX, targetY - stateManager.GlobalY);
            }
            else
            {
                g.DrawLine(pen, new Point(stateManager.GlobalX, stateManager.GlobalY), new Point(targetX, targetY));
            }

            stateManager.SetCordinates(targetX, targetY);
        }

    }
}

