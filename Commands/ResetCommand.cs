using GPL.Commands;
using System.Drawing;
using System.Windows.Forms;

namespace GPL.Utilities
{
    public class ResetCommand : ICommand
    {
        private int defaultTargetX, defaultTargetY;
        CordinatesStateManager stateManager;
        Bitmap bitmap;
        PictureBox pictureBox;


        public ResetCommand(int x, int y, CordinatesStateManager cordinatesStateManager, Bitmap bitmap, PictureBox pictureBox)
        {
            this.defaultTargetX = x;
            this.defaultTargetY = y;
            this.stateManager = cordinatesStateManager;
            this.bitmap = bitmap;
            this.pictureBox = pictureBox;
        }

        public void Execute(Graphics g)
        {
            stateManager.SetCordinates(defaultTargetX, defaultTargetY);
            stateManager.DrawCursor(bitmap);
            pictureBox.Refresh();
        }
    }
}
