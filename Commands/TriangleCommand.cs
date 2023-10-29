namespace GPL.Commands
{
    public class TriangleCommand : ICommand
    {
        private int targetX, targetY;
        CordinatesStateManager stateManager;

        public TriangleCommand(int x, int y, CordinatesStateManager cordinatesStateManager)
        {
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;

        }

        public void Execute(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);
            g.DrawRectangle(pen, stateManager.GlobalY, stateManager.GlobalX, targetX, targetY);
        }
    }
}
