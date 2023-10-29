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
            //Color[] shapeColors = { Color.Blue, Color.Red, Color.Green, Color.Orange, Color.Purple };
            //Random random = new Random();
            //int randomIndex = random.Next(0, shapeColors.Length);

            //Pen pen = new Pen(shapeColors[randomIndex], 2);
            //pen.StartCap = LineCap.ArrowAnchor;
            //pen.EndCap = LineCap.RoundAnchor;
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(stateManager.GlobalY, stateManager.GlobalX), new Point(targetX, targetY));
        }

        public void Execute()
        {

        }
    }
}

