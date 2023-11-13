using GPL.Utilities;

namespace GPL.Commands
{
    public class MoveTo : ICommand
    {
        private int targetX, targetY;
        DrawingSettings stateManager;
        Bitmap bitmap;
        PictureBox pictureBox;

        public MoveTo(int x, int y, DrawingSettings cordinatesStateManager, Bitmap bitmap, PictureBox pictureBox)
        {
            targetX = x;
            targetY = y;
            this.stateManager = cordinatesStateManager;
            this.bitmap = bitmap;
            this.pictureBox = pictureBox;
        }
        public void Execute(Graphics g)
        {

            try
            {
                stateManager.SetCordinates(targetX, targetY);
                //stateManager.DrawCursor(g,true);
                pictureBox.Refresh();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'MoveTo' command: {ex.Message}");
            }
        }


    }
}
