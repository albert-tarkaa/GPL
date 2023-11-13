using GPL.Utilities;

namespace GPL.Commands
{
    public class FillCommand : ICommand
    {
        DrawingSettings stateManager;
        PictureBox pictureBox;
        public FillCommand(DrawingSettings cordinatesStateManager, PictureBox pictureBox)
        {
            this.stateManager = cordinatesStateManager;
            this.pictureBox = pictureBox;
        }

        public void Execute(Graphics g)
        {

            try
            {
                stateManager.SetFill();
                pictureBox.Refresh();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'Fill' command: {ex.Message}");
            }
        }
    }
}
