namespace GPL.Commands
{
    public class CircleCommand : ICommand
    {
        private readonly int targetX;
        readonly CordinatesStateManager stateManager;

        public CircleCommand(int x, CordinatesStateManager cordinatesStateManager)
        {
            targetX = x; //radius
            this.stateManager = cordinatesStateManager;
        }

        public void Execute(Graphics g)
        {
            Pen pen = new(Color.Black, 1);
            int diameter = targetX * 2;

            int x = stateManager.GlobalX - targetX;
            int y = stateManager.GlobalY - targetX;

            g.DrawEllipse(pen, x, y, diameter, diameter);
        }
    }
}
