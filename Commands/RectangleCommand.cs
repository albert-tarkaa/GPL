namespace GPL.Commands
{
    public class RectangleCommand : ICommand
    {
        private int targetX, targetY;
        CordinatesStateManager stateManager;

        public RectangleCommand(int x, int y, CordinatesStateManager cordinatesStateManager)
        {
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;

        }

        public void Execute(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 1);
            g.DrawRectangle(pen, stateManager.GlobalX, stateManager.GlobalY, targetX, targetY);
        }
    }
}
