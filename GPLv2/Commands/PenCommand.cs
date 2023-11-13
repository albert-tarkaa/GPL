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

            try
            {
                stateManager.SetColor(color);
                pictureBox.Refresh();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'Pen' command: {ex.Message}");
            }
        }

    }
}
