using GPL.Commands;

namespace GPL.Utilities
{
    public class ResetCommand : ICommand
    {
        private int defaultTargetX, defaultTargetY;
        DrawingSettings stateManager;


        public ResetCommand(int x, int y, DrawingSettings cordinatesStateManager)
        {
            this.defaultTargetX = x;
            this.defaultTargetY = y;
            this.stateManager = cordinatesStateManager;
        }

        public void Execute(Graphics g)
        {
            
            try
            {
                stateManager.SetCordinates(defaultTargetX, defaultTargetY);
                //stateManager.DrawCursor(bitmap, false);
                //pictureBox.Refresh();
                // pictureBox.Invalidate();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing 'Reset' command: {ex.Message}");
            }
        }
    }
}
