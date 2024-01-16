using GPL.Utilities;

namespace GPL.Commands
{
    public class MoveTo : ICommand
    {
        private readonly string targetX, targetY;
        DrawingSettings stateManager;
        Bitmap bitmap;
        PictureBox pictureBox;

        public MoveTo(string x, string y, DrawingSettings cordinatesStateManager, Bitmap bitmap, PictureBox pictureBox)
        {
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;
            this.bitmap = bitmap;
            this.pictureBox = pictureBox;
        }
        public void Execute(Graphics g)
        {
            object XValue = VariableManager.CheckVariable(targetX);
            object YValue = VariableManager.CheckVariable(targetY);

            if (XValue != null && YValue != null)
            {
                // Use the variable values for drawing the line
                if (XValue is int X && YValue is int Y)
                {
                    MoveCordinates(g, X, Y);
                }
                else
                {
                    throw new InvalidOperationException($"Invalid Move parameters: {XValue}, {YValue}");
                }
            }
            else if (int.TryParse(targetX, out int X) && int.TryParse(targetY, out int Y))
            {
                // Use the constant values for drawing the line
                MoveCordinates(g, X, Y);
            }
            else
            {
                throw new InvalidOperationException($"Invalid Move parameters: {targetX}, {targetY}");
            }
        }

        private void MoveCordinates(Graphics g, int x, int y)
        {
            try
            {
                stateManager.SetCordinates(x, y);
                pictureBox.Refresh();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'MoveTo' command: {ex.Message}");
            }
        }


    }
}
