namespace GPL.Commands
{
    public class MoveTo : ICommand
    {
        private int targetX, targetY;
        CordinatesStateManager stateManager;

        public MoveTo(int x, int y, CordinatesStateManager cordinatesStateManager)
        {
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;
        }
        public void Execute(Graphics g)
        {
            stateManager.SetCordinates(targetX, targetY);

        }
    }
}
