using GPL.Utilities;

namespace GPL.Commands
{
    public class DrawTo : ICommand
    {
        private int targetX, targetY;
        DrawingSettings stateManager;

        public DrawTo(int x, int y, DrawingSettings cordinatesStateManager)
        {
            if (x <= 0 || y <=0)
                throw new ArgumentOutOfRangeException("The paramters must be greater than 0.");
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;

        }

        public void Execute(Graphics g)
        {
            try
            {
                Pen pen = new(stateManager.color, 1);

                g.DrawLine(pen, new Point(stateManager.GlobalX, stateManager.GlobalY), new Point(targetX, targetY));
                stateManager.SetCordinates(targetX, targetY);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'DrawTo' command: {ex.Message}");
            }

        }

    }
}

