using GPL.Utilities;

namespace GPL.Commands
{
    public class RectangleCommand : ICommand
    {
        private int targetX, targetY;
        DrawingSettings stateManager;

        public RectangleCommand(int x, int y, DrawingSettings cordinatesStateManager)
        {
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;

        }
        public void Execute(Graphics g)
        {
            if (stateManager.fill)
            {
                using (var brush = new SolidBrush(stateManager.color))
                {
                    g.FillRectangle(brush, stateManager.GlobalX, stateManager.GlobalY, targetX, targetY);
                }
            }
            else
            {
                g.DrawRectangle(new Pen(stateManager.color), stateManager.GlobalX, stateManager.GlobalY, targetX, targetY);
            }
        }

    }
}
