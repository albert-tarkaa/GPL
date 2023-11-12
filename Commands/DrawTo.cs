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

        public void Execute(Graphics g)
        {
            Pen pen = new Pen(stateManager.color, 1);

            g.DrawLine(pen, new Point(stateManager.GlobalX, stateManager.GlobalY), new Point(targetX, targetY));
            stateManager.SetCordinates(targetX, targetY);
        }

    }
}

