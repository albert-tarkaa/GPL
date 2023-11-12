using System.Drawing;
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
            stateManager.SetCordinates(targetX, targetY);
            stateManager.DrawCursor(bitmap,true);
            pictureBox.Refresh();
        }

       
    }
}
