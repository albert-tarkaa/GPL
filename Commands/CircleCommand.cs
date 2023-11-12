using GPL.Utilities;

namespace GPL.Commands
{
    public class CircleCommand : ICommand
    {
        private readonly int targetX;
        readonly DrawingSettings stateManager;

        public CircleCommand(int x, DrawingSettings cordinatesStateManager)
        {
            targetX = x; //radius
            this.stateManager = cordinatesStateManager;
        }

        public void Execute(Graphics g)
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

    }
}
