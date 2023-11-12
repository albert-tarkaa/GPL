using GPL.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPL.Commands
{
    public class FillCommand:ICommand
    {
        DrawingSettings stateManager;
        Bitmap bitmap;
        PictureBox pictureBox;
        public FillCommand(DrawingSettings cordinatesStateManager, Bitmap bitmap, PictureBox pictureBox)
        {
            this.stateManager = cordinatesStateManager;
            this.bitmap = bitmap;
            this.pictureBox = pictureBox;
        }

        public void Execute(Graphics g)
        {
            stateManager.SetFill();
            pictureBox.Refresh();
        }
    }
}
