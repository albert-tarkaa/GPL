using GPL.Utilities;

namespace GPL.Commands
{
    public class PenCommand : ICommand
    {
        DrawingSettings stateManager;
        PictureBox pictureBox;
        Color color;
        public PenCommand(DrawingSettings cordinatesStateManager, PictureBox picturebox, Color c)
        {
            this.stateManager = cordinatesStateManager;
            this.pictureBox = picturebox;
            this.color = c;
        }

        public void Execute(Graphics g)
        {
            stateManager.SetColor(color);
            pictureBox.Refresh();
        }

    }
}
