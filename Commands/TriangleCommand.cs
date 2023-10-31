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
            Pen pen = new Pen(Color.Black, 1);
            double height = (Math.Sqrt(3) / 2) * targetX;
            Point[] triangleVertices = {
                new Point(stateManager.GlobalY, stateManager.GlobalX),
                new Point(stateManager.GlobalX + targetX, stateManager.GlobalY),
                new Point(stateManager.GlobalX + targetX / 2, stateManager.GlobalY - (int)height)
            };
            g.DrawPolygon(pen, triangleVertices);
        }
    }
}
