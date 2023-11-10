using GPL.Utilities;

namespace GPL.Commands
{
    public class DrawTo : ICommand
    {
        private int targetX, targetY;
        CordinatesStateManager stateManager;

        public DrawTo(int x, int y, CordinatesStateManager cordinatesStateManager)
        {
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;

        }

        public void Execute(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 1);
            g.DrawLine(pen, new Point(stateManager.GlobalX, stateManager.GlobalY), new Point(targetX, targetY));
            stateManager.SetCordinates(targetX, targetY);
        }
    }
}

